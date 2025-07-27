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
    public partial class FormRegister : Form
    {
        private const int MinPasswordLength = 8;

        public FormRegister()
        {
            InitializeComponent();
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

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtKonfirmasiPassword.Text) ||
                cmbJabatan.SelectedIndex == -1)
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

            string password = txtPassword.Text;
            if (!IsPasswordStrong(password))
            {
                MessageBox.Show(
                    $"Password harus memiliki minimal {MinPasswordLength} karakter dan mengandung huruf besar, huruf kecil, angka, dan karakter khusus!",
                    "Password Lemah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtKonfirmasiPassword.Text)
            {
                MessageBox.Show("Password dan konfirmasi password tidak cocok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = InputSanitizer.SanitizeInput(txtUsername.Text).Trim();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    // Create a PetugasModel for searching
                    var searchModel = new PetugasModel
                    {
                        username = username
                    };
                    var encryptedSearchModel = searchModel.EncryptModel();

                    // Check for existing username - need to compare against encrypted values
                    string checkQuery = "SELECT COUNT(*) FROM petugas WHERE username = @username";
                    int userExists = await connection.ExecuteScalarAsync<int>(checkQuery, encryptedSearchModel);

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username sudah digunakan. Silakan pilih username lain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check for existing email
                    var emailSearchModel = new PetugasModel
                    {
                        email = txtEmail.Text.Trim()
                    };
                    var encryptedEmailModel = emailSearchModel.EncryptModel();

                    string checkEmailQuery = "SELECT COUNT(*) FROM petugas WHERE email = @email";
                    int emailExists = await connection.ExecuteScalarAsync<int>(checkEmailQuery, encryptedEmailModel);

                    if (emailExists > 0)
                    {
                        MessageBox.Show("Email sudah digunakan. Silakan gunakan email lain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Generate a random salt
                    string salt = GenerateSalt();

                    // Hash the password with the salt
                    string passwordHash = HashPassword(password, salt);
                    string namalengkap = InputSanitizer.SanitizeInput(txtNamaLengkap.Text).Trim();

                    // Create PetugasModel with all data
                    var petugasModel = new PetugasModel
                    {
                        nama_petugas = namalengkap,
                        jabatan = cmbJabatan.SelectedItem.ToString(),
                        email = txtEmail.Text.Trim(),
                        username = username,
                        password_hash = passwordHash,
                        password_salt = salt,
                        created_at = DateTime.Now,
                        failed_login_attempts = 0
                    };

                    // Encrypt fields marked with [Encrypt]
                    var encryptedModel = petugasModel.EncryptModel();

                    string query = @"INSERT INTO petugas 
                                    (nama_petugas, jabatan, email, username, password_hash, password_salt, created_at, failed_login_attempts) 
                                    VALUES 
                                    (@nama_petugas, @jabatan, @email, @username, @password_hash, @password_salt, @created_at, @failed_login_attempts)";

                    int result = await connection.ExecuteAsync(query, encryptedModel);

                    if (result > 0)
                    {
                        MessageBox.Show("Registrasi berhasil! Pengguna baru telah ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambahkan pengguna baru.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool IsPasswordStrong(string password)
        {
            // Password should be at least 8 characters
            if (password.Length < MinPasswordLength)
                return false;

            // Check for at least one uppercase letter
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return false;

            // Check for at least one lowercase letter
            if (!Regex.IsMatch(password, @"[a-z]"))
                return false;

            // Check for at least one digit
            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;

            // Check for at least one special character
            if (!Regex.IsMatch(password, @"[^A-Za-z0-9]"))
                return false;

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}