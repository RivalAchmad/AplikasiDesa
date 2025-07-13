namespace AplikasiDesa
{
    partial class FormMainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelMenu = new Panel();
            BtnStat = new FontAwesome.Sharp.IconButton();
            btnDP = new FontAwesome.Sharp.IconButton();
            btnDomisili = new FontAwesome.Sharp.IconButton();
            btnPD = new FontAwesome.Sharp.IconButton();
            btnAKM = new FontAwesome.Sharp.IconButton();
            btnAKL = new FontAwesome.Sharp.IconButton();
            btnKK = new FontAwesome.Sharp.IconButton();
            btnKTP = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panelShadow = new Panel();
            panelDesktop = new Panel();
            pictureBox2 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            dropdownContainer = new FlowLayoutPanel();
            panel1 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            btnProfil = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            btnRegister = new FontAwesome.Sharp.IconButton();
            panel4 = new Panel();
            btnLogout = new FontAwesome.Sharp.IconButton();
            panel5 = new Panel();
            btnmngUser = new FontAwesome.Sharp.IconButton();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            dropdownContainer.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(22, 17, 121);
            panelMenu.Controls.Add(BtnStat);
            panelMenu.Controls.Add(btnDP);
            panelMenu.Controls.Add(btnDomisili);
            panelMenu.Controls.Add(btnPD);
            panelMenu.Controls.Add(btnAKM);
            panelMenu.Controls.Add(btnAKL);
            panelMenu.Controls.Add(btnKK);
            panelMenu.Controls.Add(btnKTP);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 636);
            panelMenu.TabIndex = 0;
            // 
            // BtnStat
            // 
            BtnStat.Dock = DockStyle.Top;
            BtnStat.FlatAppearance.BorderSize = 0;
            BtnStat.FlatStyle = FlatStyle.Flat;
            BtnStat.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnStat.ForeColor = Color.Gainsboro;
            BtnStat.IconChar = FontAwesome.Sharp.IconChar.PieChart;
            BtnStat.IconColor = Color.Gainsboro;
            BtnStat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnStat.ImageAlign = ContentAlignment.MiddleLeft;
            BtnStat.Location = new Point(0, 560);
            BtnStat.Name = "BtnStat";
            BtnStat.Size = new Size(220, 60);
            BtnStat.TabIndex = 8;
            BtnStat.Text = "Statistik";
            BtnStat.TextAlign = ContentAlignment.MiddleLeft;
            BtnStat.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnStat.UseVisualStyleBackColor = true;
            BtnStat.Click += BtnStat_Click;
            // 
            // btnDP
            // 
            btnDP.Dock = DockStyle.Top;
            btnDP.FlatAppearance.BorderSize = 0;
            btnDP.FlatStyle = FlatStyle.Flat;
            btnDP.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDP.ForeColor = Color.Gainsboro;
            btnDP.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnDP.IconColor = Color.Gainsboro;
            btnDP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDP.ImageAlign = ContentAlignment.MiddleLeft;
            btnDP.Location = new Point(0, 500);
            btnDP.Name = "btnDP";
            btnDP.Size = new Size(220, 60);
            btnDP.TabIndex = 7;
            btnDP.Text = "Data Penduduk";
            btnDP.TextAlign = ContentAlignment.MiddleLeft;
            btnDP.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDP.UseVisualStyleBackColor = true;
            btnDP.Click += btnDP_Click;
            // 
            // btnDomisili
            // 
            btnDomisili.Dock = DockStyle.Top;
            btnDomisili.FlatAppearance.BorderSize = 0;
            btnDomisili.FlatStyle = FlatStyle.Flat;
            btnDomisili.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDomisili.ForeColor = Color.Gainsboro;
            btnDomisili.IconChar = FontAwesome.Sharp.IconChar.MapLocationDot;
            btnDomisili.IconColor = Color.Gainsboro;
            btnDomisili.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDomisili.ImageAlign = ContentAlignment.MiddleLeft;
            btnDomisili.Location = new Point(0, 440);
            btnDomisili.Name = "btnDomisili";
            btnDomisili.Size = new Size(220, 60);
            btnDomisili.TabIndex = 6;
            btnDomisili.Text = "Domisili";
            btnDomisili.TextAlign = ContentAlignment.MiddleLeft;
            btnDomisili.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDomisili.UseVisualStyleBackColor = true;
            btnDomisili.Click += btnDomisili_Click;
            // 
            // btnPD
            // 
            btnPD.Dock = DockStyle.Top;
            btnPD.FlatAppearance.BorderSize = 0;
            btnPD.FlatStyle = FlatStyle.Flat;
            btnPD.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPD.ForeColor = Color.Gainsboro;
            btnPD.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            btnPD.IconColor = Color.Gainsboro;
            btnPD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPD.ImageAlign = ContentAlignment.MiddleLeft;
            btnPD.Location = new Point(0, 380);
            btnPD.Name = "btnPD";
            btnPD.Size = new Size(220, 60);
            btnPD.TabIndex = 5;
            btnPD.Text = "Pindah Datang";
            btnPD.TextAlign = ContentAlignment.MiddleLeft;
            btnPD.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPD.UseVisualStyleBackColor = true;
            btnPD.Click += btnPD_Click;
            // 
            // btnAKM
            // 
            btnAKM.Dock = DockStyle.Top;
            btnAKM.FlatAppearance.BorderSize = 0;
            btnAKM.FlatStyle = FlatStyle.Flat;
            btnAKM.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAKM.ForeColor = Color.Gainsboro;
            btnAKM.IconChar = FontAwesome.Sharp.IconChar.UserMinus;
            btnAKM.IconColor = Color.Gainsboro;
            btnAKM.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAKM.ImageAlign = ContentAlignment.MiddleLeft;
            btnAKM.Location = new Point(0, 320);
            btnAKM.Name = "btnAKM";
            btnAKM.Size = new Size(220, 60);
            btnAKM.TabIndex = 4;
            btnAKM.Text = "Akta Kematian";
            btnAKM.TextAlign = ContentAlignment.MiddleLeft;
            btnAKM.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAKM.UseVisualStyleBackColor = true;
            btnAKM.Click += btnAKM_Click;
            // 
            // btnAKL
            // 
            btnAKL.Dock = DockStyle.Top;
            btnAKL.FlatAppearance.BorderSize = 0;
            btnAKL.FlatStyle = FlatStyle.Flat;
            btnAKL.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAKL.ForeColor = Color.Gainsboro;
            btnAKL.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnAKL.IconColor = Color.Gainsboro;
            btnAKL.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAKL.ImageAlign = ContentAlignment.MiddleLeft;
            btnAKL.Location = new Point(0, 260);
            btnAKL.Name = "btnAKL";
            btnAKL.Size = new Size(220, 60);
            btnAKL.TabIndex = 3;
            btnAKL.Text = "Akta Kelahiran";
            btnAKL.TextAlign = ContentAlignment.MiddleLeft;
            btnAKL.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAKL.UseVisualStyleBackColor = true;
            btnAKL.Click += btnAKL_Click;
            // 
            // btnKK
            // 
            btnKK.Dock = DockStyle.Top;
            btnKK.FlatAppearance.BorderSize = 0;
            btnKK.FlatStyle = FlatStyle.Flat;
            btnKK.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKK.ForeColor = Color.Gainsboro;
            btnKK.IconChar = FontAwesome.Sharp.IconChar.UsersRectangle;
            btnKK.IconColor = Color.Gainsboro;
            btnKK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKK.ImageAlign = ContentAlignment.MiddleLeft;
            btnKK.Location = new Point(0, 200);
            btnKK.Name = "btnKK";
            btnKK.Size = new Size(220, 60);
            btnKK.TabIndex = 2;
            btnKK.Text = "Kartu Keluarga";
            btnKK.TextAlign = ContentAlignment.MiddleLeft;
            btnKK.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKK.UseVisualStyleBackColor = true;
            btnKK.Click += btnKK_Click;
            // 
            // btnKTP
            // 
            btnKTP.Dock = DockStyle.Top;
            btnKTP.FlatAppearance.BorderSize = 0;
            btnKTP.FlatStyle = FlatStyle.Flat;
            btnKTP.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKTP.ForeColor = Color.Gainsboro;
            btnKTP.IconChar = FontAwesome.Sharp.IconChar.DriversLicense;
            btnKTP.IconColor = Color.Gainsboro;
            btnKTP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKTP.ImageAlign = ContentAlignment.MiddleLeft;
            btnKTP.Location = new Point(0, 140);
            btnKTP.Name = "btnKTP";
            btnKTP.Size = new Size(220, 60);
            btnKTP.TabIndex = 1;
            btnKTP.Text = "KTP";
            btnKTP.TextAlign = ContentAlignment.MiddleLeft;
            btnKTP.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKTP.UseVisualStyleBackColor = true;
            btnKTP.Click += btnKTP_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 140);
            panelLogo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Desa_Cibeuteung_Muara;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(196, 109);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(18, 16, 103);
            panelTitleBar.Controls.Add(iconPictureBox1);
            panelTitleBar.Controls.Add(lblTitleChildForm);
            panelTitleBar.Controls.Add(iconCurrentChildForm);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(962, 75);
            panelTitleBar.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox1.BackColor = Color.FromArgb(18, 16, 103);
            iconPictureBox1.ForeColor = Color.Yellow;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconPictureBox1.IconColor = Color.Yellow;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 56;
            iconPictureBox1.Location = new Point(571, 13);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(59, 56);
            iconPictureBox1.TabIndex = 3;
            iconPictureBox1.TabStop = false;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.FlatStyle = FlatStyle.Flat;
            lblTitleChildForm.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleChildForm.ForeColor = Color.Gainsboro;
            lblTitleChildForm.Location = new Point(44, 26);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(59, 21);
            lblTitleChildForm.TabIndex = 2;
            lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(18, 16, 103);
            iconCurrentChildForm.ForeColor = Color.Yellow;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.Yellow;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.Location = new Point(6, 21);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(32, 32);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            panelShadow.BackColor = Color.FromArgb(18, 16, 103);
            panelShadow.Dock = DockStyle.Top;
            panelShadow.Location = new Point(220, 75);
            panelShadow.Name = "panelShadow";
            panelShadow.Size = new Size(962, 9);
            panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(36, 32, 175);
            panelDesktop.Controls.Add(pictureBox2);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(220, 84);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(962, 552);
            panelDesktop.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = Properties.Resources.Desa_Cibeuteung_Muara;
            pictureBox2.Location = new Point(246, 109);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(481, 281);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // dropdownContainer
            // 
            dropdownContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dropdownContainer.BackColor = Color.Transparent;
            dropdownContainer.Controls.Add(panel1);
            dropdownContainer.Controls.Add(panel2);
            dropdownContainer.Controls.Add(panel3);
            dropdownContainer.Controls.Add(panel4);
            dropdownContainer.Controls.Add(panel5);
            dropdownContainer.Location = new Point(845, 12);
            dropdownContainer.Margin = new Padding(0);
            dropdownContainer.MaximumSize = new Size(335, 253);
            dropdownContainer.MinimumSize = new Size(335, 50);
            dropdownContainer.Name = "dropdownContainer";
            dropdownContainer.Size = new Size(335, 50);
            dropdownContainer.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(iconButton1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(335, 50);
            panel1.TabIndex = 4;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(18, 16, 103);
            iconButton1.Dock = DockStyle.Fill;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Century Gothic", 10.2F);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 40;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(0, 0);
            iconButton1.Margin = new Padding(0);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(335, 50);
            iconButton1.TabIndex = 3;
            iconButton1.Text = "Selamat datang, PetugasDesa";
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnProfil);
            panel2.Location = new Point(0, 50);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(335, 50);
            panel2.TabIndex = 5;
            // 
            // btnProfil
            // 
            btnProfil.BackColor = Color.FromArgb(30, 30, 170);
            btnProfil.Dock = DockStyle.Fill;
            btnProfil.FlatStyle = FlatStyle.Flat;
            btnProfil.Font = new Font("Century Gothic", 10.2F);
            btnProfil.ForeColor = Color.Transparent;
            btnProfil.IconChar = FontAwesome.Sharp.IconChar.User;
            btnProfil.IconColor = Color.White;
            btnProfil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProfil.IconSize = 35;
            btnProfil.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfil.Location = new Point(0, 0);
            btnProfil.Margin = new Padding(0);
            btnProfil.Name = "btnProfil";
            btnProfil.Size = new Size(335, 50);
            btnProfil.TabIndex = 3;
            btnProfil.Text = "Profil";
            btnProfil.TextAlign = ContentAlignment.MiddleRight;
            btnProfil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfil.UseVisualStyleBackColor = false;
            btnProfil.Click += btnProfil_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnRegister);
            panel3.Location = new Point(0, 100);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(335, 50);
            panel3.TabIndex = 6;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(30, 30, 170);
            btnRegister.Dock = DockStyle.Fill;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Century Gothic", 10.2F);
            btnRegister.ForeColor = Color.Transparent;
            btnRegister.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnRegister.IconColor = Color.White;
            btnRegister.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRegister.IconSize = 35;
            btnRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegister.Location = new Point(0, 0);
            btnRegister.Margin = new Padding(0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(335, 50);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Register Pengguna Baru";
            btnRegister.TextAlign = ContentAlignment.MiddleRight;
            btnRegister.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnLogout);
            panel4.Location = new Point(0, 150);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(335, 50);
            panel4.TabIndex = 7;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 30, 170);
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Century Gothic", 10.2F);
            btnLogout.ForeColor = Color.Transparent;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnLogout.IconColor = Color.White;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.IconSize = 35;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 0);
            btnLogout.Margin = new Padding(0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(335, 50);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnmngUser);
            panel5.Location = new Point(0, 200);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(335, 50);
            panel5.TabIndex = 8;
            // 
            // btnmngUser
            // 
            btnmngUser.BackColor = Color.FromArgb(30, 30, 170);
            btnmngUser.Dock = DockStyle.Fill;
            btnmngUser.FlatStyle = FlatStyle.Flat;
            btnmngUser.Font = new Font("Century Gothic", 10.2F);
            btnmngUser.ForeColor = Color.Transparent;
            btnmngUser.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnmngUser.IconColor = Color.White;
            btnmngUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnmngUser.IconSize = 35;
            btnmngUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnmngUser.Location = new Point(0, 0);
            btnmngUser.Margin = new Padding(0);
            btnmngUser.Name = "btnmngUser";
            btnmngUser.Size = new Size(335, 50);
            btnmngUser.TabIndex = 3;
            btnmngUser.Text = "Manajemen Pengguna";
            btnmngUser.TextAlign = ContentAlignment.MiddleRight;
            btnmngUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnmngUser.UseVisualStyleBackColor = false;
            btnmngUser.Click += btnmngUser_Click;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 636);
            Controls.Add(dropdownContainer);
            Controls.Add(panelDesktop);
            Controls.Add(panelShadow);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Name = "FormMainMenu";
            Text = "Menu Utama";
            FormClosing += FormMainMenu_FormClosing;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            dropdownContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnKTP;
        private FontAwesome.Sharp.IconButton btnDomisili;
        private FontAwesome.Sharp.IconButton btnPD;
        private FontAwesome.Sharp.IconButton btnAKM;
        private FontAwesome.Sharp.IconButton btnAKL;
        private FontAwesome.Sharp.IconButton btnKK;
        private PictureBox pictureBox1;
        private Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblTitleChildForm;
        private Panel panelShadow;
        private Panel panelDesktop;
        private PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton btnDP;
        private FontAwesome.Sharp.IconButton BtnStat;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Timer timer1;
        private FlowLayoutPanel dropdownContainer;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnProfil;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton btnRegister;
        private Panel panel4;
        private FontAwesome.Sharp.IconButton btnLogout;
        private Panel panel5;
        private FontAwesome.Sharp.IconButton btnmngUser;
    }
}
