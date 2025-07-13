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
    public partial class ResetPasswordForm : Form
    {
        private const int MinPasswordLength = 8;

        public ResetPasswordForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set rounded corners for panel and buttons
            panelMain.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMain.Width, panelMain.Height, 15, 15));
            btnResetPassword.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnResetPassword.Width, btnResetPassword.Height, 10, 10));

            // Apply styling to textboxes
            ApplyTextBoxStyling(txtToken);
            ApplyTextBoxStyling(txtNewPassword);
            ApplyTextBoxStyling(txtConfirmPassword);
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

            panelMain.Controls.Add(panel);
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            UpdatePasswordStrengthIndicator(txtNewPassword.Text);
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

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtToken.Text))
            {
                MessageBox.Show("Silakan masukkan token reset password.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Silakan isi semua field password.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password baru dan konfirmasi password tidak cocok.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = txtNewPassword.Text;
            if (!IsPasswordStrong(password))
            {
                MessageBox.Show(
                    $"Password harus memiliki minimal {MinPasswordLength} karakter dan mengandung huruf besar, huruf kecil, angka, dan karakter khusus!",
                    "Password Lemah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnResetPassword.Enabled = false;
            btnResetPassword.Text = "Processing...";
            pbLoading.Visible = true;

            try
            {
                string token = txtToken.Text.Trim();
                var tokenInfo = await ValidateResetToken(token);

                if (tokenInfo == null)
                {
                    MessageBox.Show("Token reset password tidak valid atau sudah kadaluarsa.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetForm();
                    return;
                }

                int userId = tokenInfo.Value.userId;

                // Generate a new salt for the new password
                string salt = GenerateSalt();
                string passwordHash = HashPassword(password, salt);

                // Update the user's password
                bool passwordUpdated = await UpdateUserPassword(userId, passwordHash, salt);

                if (passwordUpdated)
                {
                    // Mark the token as used
                    await MarkTokenAsUsed(tokenInfo.Value.tokenId);

                    MessageBox.Show(
                        "Password Anda berhasil diubah. Silakan login dengan password baru Anda.",
                        "Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Gagal mengubah password. Silakan coba lagi nanti.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetForm();
            }
        }

        private void ResetForm()
        {
            btnResetPassword.Enabled = true;
            btnResetPassword.Text = "Reset Password";
            pbLoading.Visible = false;
        }

        private async Task<(int userId, int tokenId)?> ValidateResetToken(string token)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                // Create a model for the token to encrypt it
                var tokenModel = new ResetTokenModel
                {
                    token = token
                };

                // Encrypt the token
                var encryptedTokenModel = tokenModel.EncryptModel();

                string query = @"
                    SELECT id, user_id 
                    FROM password_reset_tokens 
                    WHERE token = @Token 
                    AND is_used = 0 
                    AND expiry_date > @CurrentTime";

                var result = await connection.QuerySingleOrDefaultAsync<dynamic>(query, new
                {
                    Token = encryptedTokenModel.token, // Use the encrypted token for comparison
                    CurrentTime = DateTime.Now
                });

                if (result == null)
                    return null;

                return (userId: (int)result.user_id, tokenId: (int)result.id);
            }
        }

        private async Task<bool> UpdateUserPassword(int userId, string passwordHash, string salt)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string query = @"
                    UPDATE petugas 
                    SET password_hash = @PasswordHash, 
                        password_salt = @Salt,
                        last_password_change = @LastPasswordChange 
                    WHERE id = @UserId";

                int affectedRows = await connection.ExecuteAsync(query, new
                {
                    PasswordHash = passwordHash,
                    Salt = salt,
                    LastPasswordChange = DateTime.Now,
                    UserId = userId
                });

                return affectedRows > 0;
            }
        }

        private async Task MarkTokenAsUsed(int tokenId)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string query = @"
                    UPDATE password_reset_tokens 
                    SET is_used = 1, 
                        used_at = @UsedAt 
                    WHERE id = @TokenId";

                await connection.ExecuteAsync(query, new
                {
                    UsedAt = DateTime.Now,
                    TokenId = tokenId
                });
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

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
