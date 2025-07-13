using AplikasiDesa.Forms;
using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using Color = System.Drawing.Color;

namespace AplikasiDesa
{
    public partial class FormMainMenu : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private System.Windows.Forms.Timer sessionTimer;

        public FormMainMenu()
        {
            InitializeComponent();
            VerifySession();
            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 600000; // Periksa setiap 10 menit
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            string loggedInUser = Session1.LoggedInUser;
            string loggedInUserName = Session1.LoggedInUserName;

            iconButton1.Text = $"Selamat datang, {loggedInUserName}";
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

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.MidnightBlue;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }

        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnKTP_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormKartuTP());
        }

        private void btnKK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormKK());
        }

        private void btnAKL_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormAKL());
        }

        private void btnAKM_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormAKM());
        }

        private void btnPD_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FormPD());
        }

        private void btnDomisili_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormDomisili());
        }

        private void btnDP_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormTambahPenduduk());
        }

        private void BtnStat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new FormStatistik());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Yellow;
            lblTitleChildForm.Text = "Home";
        }

        bool expand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand == false)
            {
                dropdownContainer.Height += 15;
                if (dropdownContainer.Height >= dropdownContainer.MaximumSize.Height)
                {
                    timer1.Stop();
                    expand = true;
                }
            }
            else
            {
                dropdownContainer.Height -= 15;
                if (dropdownContainer.Height <= dropdownContainer.MinimumSize.Height)
                {
                    timer1.Stop();
                    expand = false;
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            timer1.Start();

            FormProfil profilForm = new FormProfil();
            profilForm.ShowDialog();
            if (profilForm.DialogResult == DialogResult.OK)
            {
                string loggedInUserName = Session1.LoggedInUserName;
                iconButton1.Text = $"Selamat datang, {loggedInUserName}";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            timer1.Start();

            FormRegister registerForm = new FormRegister();
            registerForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            timer1.Start();

            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin keluar?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Session1.ClearSession();

                this.Close();

                // Start the application fresh from login
                Application.Restart();
            }
        }

        private void btnmngUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the current user has Admin Utama role
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    var searchModel = new PetugasModel
                    {
                        username = Session1.LoggedInUser
                    };
                    var encryptedSearchModel = searchModel.EncryptModel();

                    string query = "SELECT jabatan FROM petugas WHERE username = @username";
                    string jabatan = connection.QueryFirstOrDefault<string>(query, encryptedSearchModel);

                    if (jabatan == "Admin Utama")
                    {
                        ActivateButton(sender, RGBColors.color7);
                        OpenChildForm(new FormManageUsers());
                    }
                    else
                    {
                        MessageBox.Show("Anda tidak memiliki akses untuk fitur ini. Hanya Admin Utama yang dapat mengakses halaman ini.",
                            "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timer1.Start();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
