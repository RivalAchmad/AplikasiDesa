namespace AplikasiDesa.Forms
{
    partial class FormRegister
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
            panel1 = new Panel();
            chkShowPassword = new CheckBox();
            lblSyarat5 = new Label();
            lblSyarat4 = new Label();
            lblSyarat3 = new Label();
            lblSyarat2 = new Label();
            lblSyarat1 = new Label();
            lblPassword = new Label();
            cmbJabatan = new ComboBox();
            btnCancel = new Button();
            btnRegister = new Button();
            txtKonfirmasiPassword = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            txtNamaLengkap = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(36, 32, 175);
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(lblSyarat5);
            panel1.Controls.Add(lblSyarat4);
            panel1.Controls.Add(lblSyarat3);
            panel1.Controls.Add(lblSyarat2);
            panel1.Controls.Add(lblSyarat1);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(cmbJabatan);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(txtKonfirmasiPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtNamaLengkap);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(40, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(520, 450);
            panel1.TabIndex = 0;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.White;
            chkShowPassword.Location = new Point(223, 296);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(163, 24);
            chkShowPassword.TabIndex = 21;
            chkShowPassword.Text = "Tampilkan Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // lblSyarat5
            // 
            lblSyarat5.AutoSize = true;
            lblSyarat5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat5.ForeColor = Color.Red;
            lblSyarat5.Location = new Point(259, 235);
            lblSyarat5.Name = "lblSyarat5";
            lblSyarat5.Size = new Size(128, 17);
            lblSyarat5.TabIndex = 20;
            lblSyarat5.Text = "dan karakter khusus!";
            // 
            // lblSyarat4
            // 
            lblSyarat4.AutoSize = true;
            lblSyarat4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat4.ForeColor = Color.Red;
            lblSyarat4.Location = new Point(218, 235);
            lblSyarat4.Name = "lblSyarat4";
            lblSyarat4.Size = new Size(46, 17);
            lblSyarat4.TabIndex = 19;
            lblSyarat4.Text = "angka,";
            // 
            // lblSyarat3
            // 
            lblSyarat3.AutoSize = true;
            lblSyarat3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat3.ForeColor = Color.Red;
            lblSyarat3.Location = new Point(152, 235);
            lblSyarat3.Name = "lblSyarat3";
            lblSyarat3.Size = new Size(74, 17);
            lblSyarat3.TabIndex = 18;
            lblSyarat3.Text = "huruf kecil, ";
            // 
            // lblSyarat2
            // 
            lblSyarat2.AutoSize = true;
            lblSyarat2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat2.ForeColor = Color.Red;
            lblSyarat2.Location = new Point(319, 218);
            lblSyarat2.Name = "lblSyarat2";
            lblSyarat2.Size = new Size(163, 17);
            lblSyarat2.TabIndex = 17;
            lblSyarat2.Text = "mengandung huruf besar, ";
            // 
            // lblSyarat1
            // 
            lblSyarat1.AutoSize = true;
            lblSyarat1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat1.ForeColor = Color.Red;
            lblSyarat1.Location = new Point(152, 218);
            lblSyarat1.Name = "lblSyarat1";
            lblSyarat1.Size = new Size(170, 17);
            lblSyarat1.TabIndex = 16;
            lblSyarat1.Text = "Memiliki minimal 8 karakter,";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(52, 218);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(103, 17);
            lblPassword.TabIndex = 15;
            lblPassword.Text = "Password harus:";
            // 
            // cmbJabatan
            // 
            cmbJabatan.BackColor = Color.White;
            cmbJabatan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJabatan.Font = new Font("Segoe UI", 10F);
            cmbJabatan.FormattingEnabled = true;
            cmbJabatan.Items.AddRange(new object[] { "Kepala Desa", "Sekertaris Desa", "Kepala Seksi Pemerintahan", "Kepala Seksi Pelayanan", "Kepala Seksi Kesejahteraan", "Kepala Urusan Tata Usaha dan Umum", "Kepala Urusan Keuangan", "Kepala Urusan Perencanaan", "Staf Desa", "Pengguna Umum" });
            cmbJabatan.Location = new Point(223, 74);
            cmbJabatan.Name = "cmbJabatan";
            cmbJabatan.Size = new Size(267, 31);
            cmbJabatan.TabIndex = 14;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(249, 88, 155);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(130, 386);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Batal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(95, 77, 221);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(270, 386);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 40);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Daftar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtKonfirmasiPassword
            // 
            txtKonfirmasiPassword.Font = new Font("Segoe UI", 10F);
            txtKonfirmasiPassword.Location = new Point(223, 326);
            txtKonfirmasiPassword.Name = "txtKonfirmasiPassword";
            txtKonfirmasiPassword.PasswordChar = '*';
            txtKonfirmasiPassword.Size = new Size(267, 30);
            txtKonfirmasiPassword.TabIndex = 11;
            txtKonfirmasiPassword.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(223, 260);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(267, 30);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(223, 174);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(267, 30);
            txtUsername.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(223, 124);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(267, 30);
            txtEmail.TabIndex = 8;
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.Font = new Font("Segoe UI", 10F);
            txtNamaLengkap.Location = new Point(223, 24);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(267, 30);
            txtNamaLengkap.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(30, 326);
            label6.Name = "label6";
            label6.Size = new Size(187, 23);
            label6.TabIndex = 5;
            label6.Text = "Konfirmasi Password :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(30, 260);
            label5.Name = "label5";
            label5.Size = new Size(95, 23);
            label5.TabIndex = 4;
            label5.Text = "Password :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(30, 174);
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
            label3.Location = new Point(30, 124);
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
            label2.Location = new Point(30, 74);
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
            label1.Location = new Point(30, 24);
            label1.Name = "label1";
            label1.Size = new Size(141, 23);
            label1.TabIndex = 0;
            label1.Text = "Nama Lengkap :";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(22, 17, 121);
            panel2.Controls.Add(label7);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(600, 60);
            panel2.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(168, 15);
            label7.Name = "label7";
            label7.Size = new Size(262, 32);
            label7.TabIndex = 0;
            label7.Text = "REGISTRASI PETUGAS";
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 37, 81);
            ClientSize = new Size(600, 550);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrasi Petugas";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtKonfirmasiPassword;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtNamaLengkap;
        private Button btnCancel;
        private Button btnRegister;
        private ComboBox cmbJabatan;
        private Panel panel2;
        private Label label7;
        private Label lblPassword;
        private Label lblSyarat1;
        private Label lblSyarat5;
        private Label lblSyarat4;
        private Label lblSyarat3;
        private Label lblSyarat2;
        private CheckBox chkShowPassword;
    }
}
