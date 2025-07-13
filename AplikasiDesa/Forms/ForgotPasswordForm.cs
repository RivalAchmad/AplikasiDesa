using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;

namespace AplikasiDesa.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private const int TokenExpiryHours = 1;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set rounded corners for the form and controls
            panelMain.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMain.Width, panelMain.Height, 15, 15));
            btnSendResetLink.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSendResetLink.Width, btnSendResetLink.Height, 10, 10));

            // Apply styling to the textbox
            ApplyTextBoxStyling(txtEmail);
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

        private async void btnSendResetLink_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Silakan masukkan alamat email Anda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !InputSanitizer.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Format email tidak valid.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSendResetLink.Enabled = false;
            btnSendResetLink.Text = "Mengirim...";
            pbLoading.Visible = true;

            try
            {
                string email = txtEmail.Text.Trim();

                // Create a model to encrypt the email
                var emailModel = new PetugasModel
                {
                    email = email
                };
                var encryptedEmailModel = emailModel.EncryptModel();

                // Get user ID by encrypted email
                int userId = await GetUserIdByEmail(encryptedEmailModel.email);

                if (userId <= 0)
                {
                    MessageBox.Show("Email tidak terdaftar dalam sistem.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetForm();
                    return;
                }

                // Generate a secure reset token
                string resetToken = GenerateSecureToken();
                DateTime expiryTime = DateTime.Now.AddHours(TokenExpiryHours);

                // Save the reset token to database (encrypted)
                await SaveResetToken(userId, resetToken, expiryTime);

                // Send email with reset link
                bool emailSent = await SendPasswordResetEmail(email, resetToken);

                if (emailSent)
                {
                    MessageBox.Show(
                        $"Link reset password telah dikirim ke {email}.\nSilakan periksa email Anda dan ikuti petunjuk yang diberikan.",
                        "Reset Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    btnSendResetLink.Text = "Terkirim";
                    pbLoading.Visible = false;
                }
                else
                {
                    MessageBox.Show(
                        "Gagal mengirim email reset password. Silakan coba lagi nanti.",
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
            btnSendResetLink.Enabled = true;
            btnSendResetLink.Text = "Kirim Link Reset";
            pbLoading.Visible = false;
        }

        private async Task<int> GetUserIdByEmail(string encryptedEmail)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string query = "SELECT id FROM petugas WHERE email = @Email";
                var result = await connection.QuerySingleOrDefaultAsync<int?>(query, new { Email = encryptedEmail });
                return result ?? 0;
            }
        }

        private string GenerateSecureToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var tokenBytes = new byte[32]; // 256 bits
                rng.GetBytes(tokenBytes);
                return Convert.ToBase64String(tokenBytes)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .Replace("=", "");
            }
        }

        private async Task SaveResetToken(int userId, string resetToken, DateTime expiryTime)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                // First, invalidate any existing reset tokens
                string invalidateQuery = @"
                    UPDATE password_reset_tokens 
                    SET is_used = 1 
                    WHERE user_id = @UserId AND is_used = 0";

                await connection.ExecuteAsync(invalidateQuery, new { UserId = userId });

                // Create a model for the token to encrypt it
                var tokenModel = new ResetTokenModel
                {
                    token = resetToken
                };

                // Encrypt the token
                var encryptedTokenModel = tokenModel.EncryptModel();

                // Now insert the new encrypted token
                string insertQuery = @"
                    INSERT INTO password_reset_tokens 
                    (user_id, token, expiry_date, is_used, created_at) 
                    VALUES 
                    (@UserId, @Token, @ExpiryDate, 0, @CreatedAt)";

                await connection.ExecuteAsync(insertQuery, new
                {
                    UserId = userId,
                    Token = encryptedTokenModel.token, // Use the encrypted token
                    ExpiryDate = expiryTime,
                    CreatedAt = DateTime.Now
                });
            }
        }

        private async Task<bool> SendPasswordResetEmail(string recipientEmail, string resetToken)
        {
            try
            {
                // Ambil konfigurasi email dari appsettings.json
                var configuration = Program.Configuration;
                var emailSettings = configuration.GetSection("EmailSettings");

                string smtpServer = emailSettings["SmtpServer"];
                int smtpPort = int.Parse(emailSettings["SmtpPort"]);
                string senderEmail = emailSettings["SenderEmail"];
                string senderName = emailSettings["SenderName"];
                string password = emailSettings["Password"];
                bool useSsl = bool.Parse(emailSettings["UseSsl"]);

                // Buat email message dengan MimeKit
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = "Reset Password - Aplikasi Desa";

                // Buat HTML body
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $@"
                    <html>
                    <head>
                        <style>
                            body {{ font-family: 'Segoe UI', Arial, sans-serif; }}
                            .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                            .header {{ background-color: #487eb0; color: white; padding: 15px; text-align: center; }}
                            .content {{ padding: 20px; border: 1px solid #ddd; }}
                            .footer {{ text-align: center; margin-top: 20px; font-size: 12px; color: #777; }}
                            .button {{ background-color: #487eb0; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; }}
                            .token {{ font-family: monospace; padding: 10px; background-color: #f5f5f5; border: 1px solid #ddd; margin: 10px 0; }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>
                                <h2>Reset Password</h2>
                            </div>
                            <div class='content'>
                                <p>Anda menerima email ini karena ada permintaan untuk reset password akun Anda di Aplikasi Desa.</p>
                                <p>Untuk melanjutkan proses reset password, gunakan kode token berikut di aplikasi:</p>
                                
                                <div class='token'>{resetToken}</div>
                                
                                <p>Token ini akan kadaluarsa dalam {TokenExpiryHours} jam.</p>
                                <p>Jika Anda tidak merasa meminta reset password, abaikan email ini.</p>
                            </div>
                            <div class='footer'>
                                <p>Email ini dikirim secara otomatis, mohon untuk tidak membalas.</p>
                                <p>&copy; {DateTime.Now.Year} Aplikasi Desa - All rights reserved</p>
                            </div>
                        </div>
                    </body>
                    </html>"
                };

                message.Body = bodyBuilder.ToMessageBody();

                // Kirim email menggunakan MailKit
                using (var client = new SmtpClient())
                {
                    client.Timeout = 20000; // 20 detik timeout

                    // Connect
                    await client.ConnectAsync(smtpServer, smtpPort,
                        useSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None);

                    // Authenticate
                    await client.AuthenticateAsync(senderEmail, password);

                    // Kirim email
                    await client.SendAsync(message);

                    // Disconnect
                    await client.DisconnectAsync(true);

                    return true;
                }
            }
            catch (AuthenticationException)
            {
                MessageBox.Show("Gagal autentikasi dengan server email. Periksa username dan password di konfigurasi.",
                    "Error Autentikasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (SmtpCommandException smtpEx)
            {
                string errorMessage = $"SMTP Error: {smtpEx.Message}, Status: {smtpEx.StatusCode}";
                MessageBox.Show(errorMessage, "Error SMTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (SmtpProtocolException protocolEx)
            {
                MessageBox.Show($"Protokol SMTP Error: {protocolEx.Message}",
                    "Error Protokol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                MessageBox.Show($"Gagal mengirim email: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var resetForm = new ResetPasswordForm();
            resetForm.ShowDialog();
            this.Close();
        }
    }
}

