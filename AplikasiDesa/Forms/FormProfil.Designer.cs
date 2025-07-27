namespace AplikasiDesa.Forms
{
    partial class FormProfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblUserPosition = new Label();
            lblUserName = new Label();
            iconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            lblTitle = new Label();
            panelForm = new Panel();
            lblSyarat5 = new Label();
            lblSyarat4 = new Label();
            lblSyarat3 = new Label();
            lblSyarat2 = new Label();
            lblSyarat1 = new Label();
            lblPassword = new Label();
            chkShowPassword = new CheckBox();
            btnBatal = new Button();
            btnSimpan = new Button();
            cmbJabatan = new ComboBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            txtNamaLengkap = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(22, 17, 121);
            panelHeader.Controls.Add(lblUserPosition);
            panelHeader.Controls.Add(lblUserName);
            panelHeader.Controls.Add(iconPictureBox);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 180);
            panelHeader.TabIndex = 0;
            // 
            // lblUserPosition
            // 
            lblUserPosition.AutoSize = true;
            lblUserPosition.Font = new Font("Segoe UI", 10F);
            lblUserPosition.ForeColor = Color.Gainsboro;
            lblUserPosition.Location = new Point(227, 111);
            lblUserPosition.Name = "lblUserPosition";
            lblUserPosition.Size = new Size(69, 23);
            lblUserPosition.TabIndex = 3;
            lblUserPosition.Text = "Jabatan";
            lblUserPosition.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(225, 77);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(81, 32);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Nama";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = Color.FromArgb(22, 17, 121);
            iconPictureBox.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconPictureBox.IconColor = Color.White;
            iconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox.IconSize = 96;
            iconPictureBox.Location = new Point(119, 64);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(96, 96);
            iconPictureBox.TabIndex = 1;
            iconPictureBox.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(207, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(173, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PROFIL ANDA";
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.FromArgb(36, 32, 175);
            panelForm.Controls.Add(lblSyarat5);
            panelForm.Controls.Add(lblSyarat4);
            panelForm.Controls.Add(lblSyarat3);
            panelForm.Controls.Add(lblSyarat2);
            panelForm.Controls.Add(lblSyarat1);
            panelForm.Controls.Add(lblPassword);
            panelForm.Controls.Add(chkShowPassword);
            panelForm.Controls.Add(btnBatal);
            panelForm.Controls.Add(btnSimpan);
            panelForm.Controls.Add(cmbJabatan);
            panelForm.Controls.Add(txtPassword);
            panelForm.Controls.Add(txtUsername);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(txtNamaLengkap);
            panelForm.Controls.Add(label5);
            panelForm.Controls.Add(label4);
            panelForm.Controls.Add(label3);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(label1);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 180);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(600, 412);
            panelForm.TabIndex = 1;
            // 
            // lblSyarat5
            // 
            lblSyarat5.AutoSize = true;
            lblSyarat5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat5.ForeColor = Color.Red;
            lblSyarat5.Location = new Point(311, 235);
            lblSyarat5.Name = "lblSyarat5";
            lblSyarat5.Size = new Size(128, 17);
            lblSyarat5.TabIndex = 26;
            lblSyarat5.Text = "dan karakter khusus!";
            // 
            // lblSyarat4
            // 
            lblSyarat4.AutoSize = true;
            lblSyarat4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat4.ForeColor = Color.Red;
            lblSyarat4.Location = new Point(270, 235);
            lblSyarat4.Name = "lblSyarat4";
            lblSyarat4.Size = new Size(46, 17);
            lblSyarat4.TabIndex = 25;
            lblSyarat4.Text = "angka,";
            // 
            // lblSyarat3
            // 
            lblSyarat3.AutoSize = true;
            lblSyarat3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat3.ForeColor = Color.Red;
            lblSyarat3.Location = new Point(204, 235);
            lblSyarat3.Name = "lblSyarat3";
            lblSyarat3.Size = new Size(74, 17);
            lblSyarat3.TabIndex = 24;
            lblSyarat3.Text = "huruf kecil, ";
            // 
            // lblSyarat2
            // 
            lblSyarat2.AutoSize = true;
            lblSyarat2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat2.ForeColor = Color.Red;
            lblSyarat2.Location = new Point(371, 218);
            lblSyarat2.Name = "lblSyarat2";
            lblSyarat2.Size = new Size(163, 17);
            lblSyarat2.TabIndex = 23;
            lblSyarat2.Text = "mengandung huruf besar, ";
            // 
            // lblSyarat1
            // 
            lblSyarat1.AutoSize = true;
            lblSyarat1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat1.ForeColor = Color.Red;
            lblSyarat1.Location = new Point(204, 218);
            lblSyarat1.Name = "lblSyarat1";
            lblSyarat1.Size = new Size(170, 17);
            lblSyarat1.TabIndex = 22;
            lblSyarat1.Text = "Memiliki minimal 8 karakter,";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(104, 218);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(103, 17);
            lblPassword.TabIndex = 21;
            lblPassword.Text = "Password harus:";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.White;
            chkShowPassword.Location = new Point(207, 296);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(163, 24);
            chkShowPassword.TabIndex = 13;
            chkShowPassword.Text = "Tampilkan Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.FromArgb(249, 88, 155);
            btnBatal.FlatAppearance.BorderSize = 0;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBatal.ForeColor = Color.White;
            btnBatal.Location = new Point(148, 343);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(130, 40);
            btnBatal.TabIndex = 12;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(95, 77, 221);
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(318, 343);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(130, 40);
            btnSimpan.TabIndex = 11;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // cmbJabatan
            // 
            cmbJabatan.BackColor = Color.White;
            cmbJabatan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJabatan.Font = new Font("Segoe UI", 10F);
            cmbJabatan.FormattingEnabled = true;
            cmbJabatan.Items.AddRange(new object[] { "Kepala Desa", "Sekertaris Desa", "Kepala Seksi Pemerintahan", "Kepala Seksi Pelayanan", "Kepala Seksi Kesejahteraan", "Kepala Urusan Tata Usaha dan Umum", "Kepala Urusan Keuangan", "Kepala Urusan Perencanaan", "Staf Desa", "Pengguna Umum" });
            cmbJabatan.Location = new Point(209, 78);
            cmbJabatan.Name = "cmbJabatan";
            cmbJabatan.Size = new Size(320, 31);
            cmbJabatan.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(207, 258);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 30);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(209, 170);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(320, 30);
            txtUsername.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(209, 125);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 30);
            txtEmail.TabIndex = 7;
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.Font = new Font("Segoe UI", 10F);
            txtNamaLengkap.Location = new Point(209, 32);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(320, 30);
            txtNamaLengkap.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(48, 261);
            label5.Name = "label5";
            label5.Size = new Size(137, 23);
            label5.TabIndex = 4;
            label5.Text = "Password Baru :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(50, 173);
            label4.Name = "label4";
            label4.Size = new Size(99, 23);
            label4.TabIndex = 3;
            label4.Text = "Username :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(50, 128);
            label3.Name = "label3";
            label3.Size = new Size(64, 23);
            label3.TabIndex = 2;
            label3.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(50, 81);
            label2.Name = "label2";
            label2.Size = new Size(83, 23);
            label2.TabIndex = 1;
            label2.Text = "Jabatan :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(50, 35);
            label1.Name = "label1";
            label1.Size = new Size(141, 23);
            label1.TabIndex = 0;
            label1.Text = "Nama Lengkap :";
            // 
            // FormProfil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 592);
            Controls.Add(panelForm);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormProfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profil Pengguna";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox;
        private System.Windows.Forms.Label lblUserPosition;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNamaLengkap;
        private System.Windows.Forms.ComboBox cmbJabatan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private Label lblSyarat5;
        private Label lblSyarat4;
        private Label lblSyarat3;
        private Label lblSyarat2;
        private Label lblSyarat1;
        private Label lblPassword;
    }
}
