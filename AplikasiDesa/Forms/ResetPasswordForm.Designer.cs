namespace AplikasiDesa.Forms
{
    partial class ResetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPasswordForm));
            panelMain = new Panel();
            lblSyarat5 = new Label();
            lblSyarat4 = new Label();
            lblSyarat3 = new Label();
            lblSyarat2 = new Label();
            lblSyarat1 = new Label();
            lblPassword = new Label();
            pbLoading = new PictureBox();
            chkShowPassword = new CheckBox();
            btnCancel = new Button();
            btnResetPassword = new Button();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            txtToken = new TextBox();
            lblToken = new Label();
            lblInstructions = new Label();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoading).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblSyarat5);
            panelMain.Controls.Add(lblSyarat4);
            panelMain.Controls.Add(lblSyarat3);
            panelMain.Controls.Add(lblSyarat2);
            panelMain.Controls.Add(lblSyarat1);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(pbLoading);
            panelMain.Controls.Add(chkShowPassword);
            panelMain.Controls.Add(btnCancel);
            panelMain.Controls.Add(btnResetPassword);
            panelMain.Controls.Add(txtConfirmPassword);
            panelMain.Controls.Add(lblConfirmPassword);
            panelMain.Controls.Add(txtNewPassword);
            panelMain.Controls.Add(lblNewPassword);
            panelMain.Controls.Add(txtToken);
            panelMain.Controls.Add(lblToken);
            panelMain.Controls.Add(lblInstructions);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(12, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(460, 376);
            panelMain.TabIndex = 0;
            // 
            // lblSyarat5
            // 
            lblSyarat5.AutoSize = true;
            lblSyarat5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSyarat5.ForeColor = Color.Red;
            lblSyarat5.Location = new Point(226, 170);
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
            lblSyarat4.Location = new Point(185, 170);
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
            lblSyarat3.Location = new Point(119, 170);
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
            lblSyarat2.Location = new Point(286, 153);
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
            lblSyarat1.Location = new Point(119, 153);
            lblSyarat1.Name = "lblSyarat1";
            lblSyarat1.Size = new Size(170, 17);
            lblSyarat1.TabIndex = 22;
            lblSyarat1.Text = "Memiliki minimal 8 karakter,";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(19, 153);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(103, 17);
            lblPassword.TabIndex = 21;
            lblPassword.Text = "Password harus:";
            // 
            // pbLoading
            // 
            pbLoading.Image = (Image)resources.GetObject("pbLoading.Image");
            pbLoading.Location = new Point(346, 299);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new Size(80, 74);
            pbLoading.SizeMode = PictureBoxSizeMode.Zoom;
            pbLoading.TabIndex = 11;
            pbLoading.TabStop = false;
            pbLoading.Visible = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.Location = new Point(204, 225);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(148, 21);
            chkShowPassword.TabIndex = 10;
            chkShowPassword.Text = "Tampilkan Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(72, 126, 176);
            btnCancel.Location = new Point(228, 319);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Batal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(72, 126, 176);
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(110, 319);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(112, 34);
            btnResetPassword.TabIndex = 8;
            btnResetPassword.Text = "Reset";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(204, 252);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(196, 27);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(52, 255);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(145, 20);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Konfirmasi Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(204, 192);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(196, 27);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(93, 195);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(104, 20);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "Password Baru";
            // 
            // txtToken
            // 
            txtToken.Location = new Point(204, 110);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(196, 27);
            txtToken.TabIndex = 3;
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Location = new Point(68, 113);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(129, 20);
            lblToken.TabIndex = 2;
            lblToken.Text = "Token Reset Email";
            // 
            // lblInstructions
            // 
            lblInstructions.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstructions.ForeColor = Color.FromArgb(64, 64, 64);
            lblInstructions.Location = new Point(44, 60);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(372, 43);
            lblInstructions.TabIndex = 1;
            lblInstructions.Text = "Masukkan token dari email dan buat password baru Anda.";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(72, 126, 176);
            lblTitle.Location = new Point(155, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(159, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reset Password";
            // 
            // ResetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(484, 400);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reset Password";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label lblTitle;
        private Label lblInstructions;
        private TextBox txtToken;
        private Label lblToken;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private TextBox txtNewPassword;
        private Label lblNewPassword;
        private Button btnCancel;
        private Button btnResetPassword;
        private CheckBox chkShowPassword;
        private PictureBox pbLoading;
        private Label lblSyarat5;
        private Label lblSyarat4;
        private Label lblSyarat3;
        private Label lblSyarat2;
        private Label lblSyarat1;
        private Label lblPassword;
    }
}
