using AplikasiDesa.Forms;
using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace AplikasiDesa
{
    public partial class LoginForm : Form
    {
        private readonly int _maxLoginAttempts = 8;
        private int _loginAttempts = 0;
        private DateTime _lockoutTime = DateTime.MinValue;
        private const int _lockoutDurationMinutes = 15;

        public LoginForm()
        {
            InitializeComponent();

            // Set modern rounded corners for panel
            panel1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 15, 15));
            btnLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 10, 10));

            // Apply modern text box styling
            ApplyTextBoxStyling(txtUsername);
            ApplyTextBoxStyling(txtPassword);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyTextBoxStyling(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.WhiteSmoke;
            textBox.Font = new Font("Segoe UI", 10F);

            Panel panel = new Panel
            {
                Height = 2,
                BackColor = Color.FromArgb(72, 126, 176),
                Location = new Point(textBox.Location.X, textBox.Location.Y + textBox.Height + 2),
                Width = textBox.Width
            };

            panel1.Controls.Add(panel);
        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check for account lockout
                if (DateTime.Now < _lockoutTime)
                {
                    TimeSpan remainingTime = _lockoutTime - DateTime.Now;
                    MessageBox.Show($"Terlalu banyak percobaan login gagal. Akun terkunci selama {Math.Ceiling(remainingTime.TotalMinutes)} menit.",
                        "Akun Terkunci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Username dan password tidak boleh kosong.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Input sanitization to prevent SQL injection
                string username = InputSanitizer.SanitizeInput(txtUsername.Text);
                string password = txtPassword.Text;

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    // Create a model with the username to encrypt it
                    var searchModel = new PetugasModel { username = username };
                    var encryptedSearchModel = searchModel.EncryptModel();

                    // First, get the user's salt and password hash
                    string getUserSql = @"SELECT id, username, nama_petugas, password_hash, password_salt, 
                                        failed_login_attempts, last_failed_login 
                                        FROM petugas WHERE username = @username";

                    var encryptedUser = await connection.QuerySingleOrDefaultAsync(getUserSql, encryptedSearchModel);

                    if (encryptedUser == null)
                    {
                        _loginAttempts++;
                        int remainingAttempts = _maxLoginAttempts - _loginAttempts;

                        if (remainingAttempts > 0)
                        {
                            MessageBox.Show($"Username atau password salah.\nSisa percobaan: {remainingAttempts}", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        CheckLockout();
                        return;
                    }

                    // Decrypt the username and nama_petugas
                    var userModel = new PetugasModel
                    {
                        username = encryptedUser.username,
                        nama_petugas = encryptedUser.nama_petugas
                    };

                    var decryptedUser = userModel.DecryptModel();
                    var userId = encryptedUser.id;
                    var decryptedUsername = decryptedUser.username;
                    var decryptedNamaPetugas = decryptedUser.nama_petugas;

                    // Check if account is locked
                    int failedAttempts = encryptedUser.failed_login_attempts;
                    DateTime? lastFailedLogin = encryptedUser.last_failed_login;

                    if (failedAttempts >= _maxLoginAttempts && lastFailedLogin.HasValue &&
                        DateTime.Now < lastFailedLogin.Value.AddMinutes(_lockoutDurationMinutes))
                    {
                        TimeSpan remainingTime = lastFailedLogin.Value.AddMinutes(_lockoutDurationMinutes) - DateTime.Now;
                        MessageBox.Show($"Akun terkunci karena terlalu banyak percobaan login gagal. Coba lagi dalam {Math.Ceiling(remainingTime.TotalMinutes)} menit.",
                            "Akun Terkunci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Get the stored salt and hash
                    string storedHash = encryptedUser.password_hash;
                    string storedSalt = encryptedUser.password_salt;

                    // Compute hash of provided password with the same salt
                    string computedHash = HashPassword(password, storedSalt);

                    // Compare the computed hash with the stored hash
                    if (computedHash == storedHash)
                    {
                        // Reset failed login attempts
                        string resetAttemptsSql = "UPDATE petugas SET failed_login_attempts = 0, last_failed_login = NULL WHERE id = @Id";
                        await connection.ExecuteAsync(resetAttemptsSql, new { Id = userId });

                        // Create a new secure session token
                        string sessionToken = GenerateSecureSessionToken();

                        // Store the session token in memory
                        Session1.LoggedInUser = decryptedUsername;
                        Session1.LoggedInUserName = decryptedNamaPetugas;
                        Session1.SessionToken = sessionToken;
                        Session1.SessionExpiry = DateTime.Now.AddHours(4); // Session expires after 4 hours
                        Session1.UserId = userId;

                        // Create a model for the session token to encrypt it
                        var sessionModel = new SessionTokenModel
                        {
                            session_token = sessionToken
                        };

                        // Encrypt the session token
                        var encryptedSessionModel = sessionModel.EncryptModel();

                        // Update the session token in the database
                        string updateSessionSql = "UPDATE petugas SET session_token = @Session_token, session_expiry = @sessionExpiry WHERE id = @Id";
                        await connection.ExecuteAsync(updateSessionSql, new
                        {
                            Session_token = encryptedSessionModel.session_token,
                            sessionExpiry = Session1.SessionExpiry,
                            Id = userId
                        });

                        // Log successful login
                        string logLoginSql = "INSERT INTO login_logs (user_id, login_time, ip_address, login_status) VALUES (@UserId, @LoginTime, @IpAddress, @LoginStatus)";
                        await connection.ExecuteAsync(logLoginSql, new
                        {
                            UserId = userId,
                            LoginTime = DateTime.Now,
                            IpAddress = GetClientIPAddress(),
                            LoginStatus = "SUCCESS"
                        });

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Increment failed login attempts
                        string updateAttemptsSql = "UPDATE petugas SET failed_login_attempts = failed_login_attempts + 1, last_failed_login = @LastFailedLogin WHERE id = @Id";
                        await connection.ExecuteAsync(updateAttemptsSql, new
                        {
                            LastFailedLogin = DateTime.Now,
                            Id = userId
                        });

                        // Calculate remaining attempts for this user
                        int currentFailedAttempts = failedAttempts + 1;
                        int remainingAttempts = _maxLoginAttempts - currentFailedAttempts;

                        // Log failed login
                        string logLoginSql = "INSERT INTO login_logs (user_id, login_time, ip_address, login_status) VALUES (@UserId, @LoginTime, @IpAddress, @LoginStatus)";
                        await connection.ExecuteAsync(logLoginSql, new
                        {
                            UserId = userId,
                            LoginTime = DateTime.Now,
                            IpAddress = GetClientIPAddress(),
                            LoginStatus = "FAILED"
                        });

                        if (remainingAttempts > 0)
                        {
                            MessageBox.Show($"Username atau password salah.\nSisa percobaan: {remainingAttempts}", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Username atau password salah.\nAkun akan terkunci karena terlalu banyak percobaan login gagal.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        _loginAttempts++;
                        CheckLockout();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckLockout()
        {
            if (_loginAttempts >= _maxLoginAttempts)
            {
                _lockoutTime = DateTime.Now.AddMinutes(_lockoutDurationMinutes);
                MessageBox.Show($"Terlalu banyak percobaan login gagal. Coba lagi dalam {_lockoutDurationMinutes} menit.",
                    "Akun Terkunci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                var hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private string GenerateSecureSessionToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var tokenBytes = new byte[32]; // 256 bits
                rng.GetBytes(tokenBytes);
                return Convert.ToBase64String(tokenBytes);
            }
        }

        private string GetClientIPAddress()
        {
            try
            {
                // Prioritaskan mendapatkan IP address eksternal (non-loopback)
                string ipAddress = string.Empty;

                // Mendapatkan semua network interface yang aktif
                var networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

                foreach (var networkInterface in networkInterfaces)
                {
                    // Hanya proses interface yang aktif dan bukan loopback
                    if (networkInterface.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up &&
                        networkInterface.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                    {
                        // Dapatkan properti IP untuk interface ini
                        var properties = networkInterface.GetIPProperties();

                        // Cari alamat IPv4 yang bukan loopback dan bukan link-local
                        foreach (var ipInfo in properties.UnicastAddresses)
                        {
                            if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                                !System.Net.IPAddress.IsLoopback(ipInfo.Address) &&
                                !ipInfo.Address.ToString().StartsWith("169.254"))
                            {
                                return ipInfo.Address.ToString();
                            }
                        }
                    }
                }

                // Jika tidak ditemukan alamat eksternal yang aktif, gunakan hostname DNS
                string hostName = System.Net.Dns.GetHostName();
                var hostEntry = System.Net.Dns.GetHostEntry(hostName);

                foreach (var address in hostEntry.AddressList)
                {
                    // Ambil alamat IPv4 pertama yang bukan loopback
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                        !System.Net.IPAddress.IsLoopback(address))
                    {
                        return address.ToString();
                    }
                }

                // Jika masih belum menemukan alamat yang valid, gunakan loopback sebagai fallback
                return "127.0.0.1";
            }
            catch (Exception ex)
            {
                // Log error jika diperlukan
                Console.WriteLine($"Error mendapatkan IP address: {ex.Message}");
                return "127.0.0.1"; // Return loopback address sebagai fallback
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void linkLupaPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
