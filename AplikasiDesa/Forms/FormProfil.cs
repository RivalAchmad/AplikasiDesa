using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AplikasiDesa.Forms
{
    public partial class FormProfil : Form
    {
        private int _petugasId;
        private System.Windows.Forms.Timer sessionTimer;
        private const int MinPasswordLength = 8;

        public FormProfil()
        {
            InitializeComponent();
            LoadUserData();
            VerifySession();
            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 600000; // Periksa setiap 10 menit
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
        }

        private void VerifySession()
        {
            if (!Session1.IsSessionValid())
            {
                Session1.ClearSession();
                MessageBox.Show("Sesi Anda telah berakhir. Silakan login kembali.",
                              "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.BeginInvoke(new Action(() =>
                {
                    this.Close();

                    using (var loginForm = new LoginForm())
                    {
                        if (loginForm.ShowDialog() == DialogResult.OK)
                        {
                            FormMainMenu mainMenu = new FormMainMenu();
                            mainMenu.Show();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }));
            }
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            VerifySession();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            UpdatePasswordStrengthIndicator(txtPassword.Text);
        }

        private void UpdatePasswordStrengthIndicator(string password)
        {
            var requirements = new[]
            {
                (Condition: password.Length >= MinPasswordLength, Label: lblSyarat1),
                (Condition: Regex.IsMatch(password, @"[A-Z]"), Label: lblSyarat2),
                (Condition: Regex.IsMatch(password, @"[a-z]"), Label: lblSyarat3),
                (Condition: Regex.IsMatch(password, @"[0-9]"), Label: lblSyarat4),
                (Condition: Regex.IsMatch(password, @"[^A-Za-z0-9]"), Label: lblSyarat5)
            };

            foreach (var (Condition, Label) in requirements)
            {
                Label.ForeColor = Condition ? Color.Green : Color.Red;
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    var searchModel = new PetugasModel
                    {
                        username = Session1.LoggedInUser
                    };
                    var encryptedSearchModel = searchModel.EncryptModel();

                    string query = "SELECT * FROM petugas WHERE username = @username";
                    var encryptedUser = connection.QuerySingleOrDefault(query, encryptedSearchModel);

                    if (encryptedUser != null)
                    {
                        _petugasId = encryptedUser.id;

                        var userModel = new PetugasModel
                        {
                            nama_petugas = encryptedUser.nama_petugas,
                            email = encryptedUser.email,
                            username = encryptedUser.username
                        };

                        var decryptedUser = userModel.DecryptModel();

                        txtNamaLengkap.Text = decryptedUser.nama_petugas;
                        txtEmail.Text = decryptedUser.email;
                        txtUsername.Text = decryptedUser.username;

                        txtPassword.Text = string.Empty;

                        string jabatan = encryptedUser.jabatan;
                        if (!string.IsNullOrEmpty(jabatan) && cmbJabatan.Items.Contains(jabatan))
                        {
                            cmbJabatan.SelectedItem = jabatan;
                        }

                        if (jabatan == "Admin Utama")
                        {
                            cmbJabatan.Enabled = false;
                            cmbJabatan.Visible = false;
                            label2.Visible = false;
                        }

                        lblUserName.Text = decryptedUser.nama_petugas;
                        lblUserPosition.Text = jabatan;
                    }
                    else
                    {
                        MessageBox.Show("Data pengguna tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !InputSanitizer.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Format email tidak valid.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text) && !IsPasswordStrong(txtPassword.Text))
            {
                MessageBox.Show(
                    $"Password harus memiliki minimal {MinPasswordLength} karakter dan mengandung huruf besar, huruf kecil, angka, dan karakter khusus!",
                    "Password Lemah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan memperbarui data?",
                "Konfirmasi Update Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        if (txtUsername.Text != Session1.LoggedInUser)
                        {
                            var checkModel = new PetugasModel
                            {
                                username = txtUsername.Text
                            };
                            var encryptedCheckModel = checkModel.EncryptModel();

                            string checkQuery = "SELECT COUNT(*) FROM petugas WHERE username = @Username AND id != @Id";
                            int userExists = connection.ExecuteScalar<int>(checkQuery,
                                new { Username = encryptedCheckModel.username, Id = _petugasId });

                            if (userExists > 0)
                            {
                                MessageBox.Show("Username sudah digunakan. Silakan pilih username lain.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        var updateModel = new PetugasModel
                        {
                            nama_petugas = InputSanitizer.SanitizeInput(txtNamaLengkap.Text),
                            email = txtEmail.Text,
                            username = InputSanitizer.SanitizeInput(txtUsername.Text)
                        };

                        // Add jabatan only if available and enabled
                        if (cmbJabatan.SelectedItem != null && cmbJabatan.Enabled)
                        {
                            updateModel.jabatan = cmbJabatan.SelectedItem.ToString();
                        }

                        var encryptedUpdateModel = updateModel.EncryptModel();

                        // Build query dynamically based on what needs to be updated
                        var queryBuilder = new StringBuilder("UPDATE petugas SET ");
                        queryBuilder.Append("nama_petugas = @Nama_petugas, ");
                        queryBuilder.Append("email = @Email, ");
                        queryBuilder.Append("username = @Username");

                        // Create parameters object with dynamic properties
                        var parameters = new Dictionary<string, object>
                        {
                            { "Nama_petugas", encryptedUpdateModel.nama_petugas },
                            { "Email", encryptedUpdateModel.email },
                            { "Username", encryptedUpdateModel.username },
                            { "Id", _petugasId }
                        };

                        // Add jabatan if it was set
                        if (updateModel.jabatan != null)
                        {
                            queryBuilder.Append(", jabatan = @Jabatan");
                            parameters.Add("Jabatan", encryptedUpdateModel.jabatan);
                        }

                        // Add password-related fields if password was provided
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            string salt = GenerateSalt();
                            string passwordHash = HashPassword(txtPassword.Text, salt);

                            queryBuilder.Append(", password_hash = @password_hash, password_salt = @password_salt");
                            parameters.Add("password_hash", passwordHash);
                            parameters.Add("password_salt", salt);
                        }

                        queryBuilder.Append(" WHERE id = @Id");

                        int rowsAffected = connection.Execute(queryBuilder.ToString(), parameters);
                        HandleUpdateResult(rowsAffected);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsPasswordStrong(string password)
        {
            if (password.Length < MinPasswordLength)
                return false;

            if (!Regex.IsMatch(password, @"[A-Z]"))
                return false;

            if (!Regex.IsMatch(password, @"[a-z]"))
                return false;

            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;

            if (!Regex.IsMatch(password, @"[^A-Za-z0-9]"))
                return false;

            return true;
        }

        private void HandleUpdateResult(int rowsAffected)
        {
            if (rowsAffected > 0)
            {
                Session1.LoggedInUser = txtUsername.Text;
                Session1.LoggedInUserName = txtNamaLengkap.Text;

                MessageBox.Show("Profil berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var saltBytes = new byte[16]; // 128 bits
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void FormProfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
