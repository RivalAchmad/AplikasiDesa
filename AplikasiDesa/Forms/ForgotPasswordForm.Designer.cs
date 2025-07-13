namespace AplikasiDesa.Forms
{
    partial class ForgotPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm));
            panelMain = new Panel();
            lnkReset = new LinkLabel();
            pbLoading = new PictureBox();
            btnCancel = new Button();
            btnSendResetLink = new Button();
            txtEmail = new TextBox();
            lblInstructions = new Label();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoading).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lnkReset);
            panelMain.Controls.Add(pbLoading);
            panelMain.Controls.Add(btnCancel);
            panelMain.Controls.Add(btnSendResetLink);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblInstructions);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(12, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(460, 276);
            panelMain.TabIndex = 0;
            // 
            // lnkReset
            // 
            lnkReset.AutoSize = true;
            lnkReset.Location = new Point(157, 215);
            lnkReset.Name = "lnkReset";
            lnkReset.Size = new Size(142, 20);
            lnkReset.TabIndex = 7;
            lnkReset.TabStop = true;
            lnkReset.Text = "Sudah punya token?";
            lnkReset.LinkClicked += lnkReset_LinkClicked;
            // 
            // pbLoading
            // 
            pbLoading.Image = (Image)resources.GetObject("pbLoading.Image");
            pbLoading.Location = new Point(345, 144);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new Size(104, 83);
            pbLoading.SizeMode = PictureBoxSizeMode.Zoom;
            pbLoading.TabIndex = 6;
            pbLoading.TabStop = false;
            pbLoading.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(72, 126, 176);
            btnCancel.Location = new Point(227, 170);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Batal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSendResetLink
            // 
            btnSendResetLink.BackColor = Color.FromArgb(72, 126, 176);
            btnSendResetLink.FlatAppearance.BorderSize = 0;
            btnSendResetLink.FlatStyle = FlatStyle.Flat;
            btnSendResetLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendResetLink.ForeColor = Color.White;
            btnSendResetLink.Location = new Point(109, 170);
            btnSendResetLink.Name = "btnSendResetLink";
            btnSendResetLink.Size = new Size(112, 34);
            btnSendResetLink.TabIndex = 4;
            btnSendResetLink.Text = "Kirim Link";
            btnSendResetLink.UseVisualStyleBackColor = false;
            btnSendResetLink.Click += btnSendResetLink_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(60, 111);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Masukkan email Anda";
            txtEmail.Size = new Size(340, 27);
            txtEmail.TabIndex = 2;
            // 
            // lblInstructions
            // 
            lblInstructions.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstructions.ForeColor = Color.FromArgb(64, 64, 64);
            lblInstructions.Location = new Point(44, 60);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(372, 48);
            lblInstructions.TabIndex = 1;
            lblInstructions.Text = "Masukkan alamat email yang terdaftar. Kami akan mengirimkan link untuk reset password ke email Anda.";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(72, 126, 176);
            lblTitle.Location = new Point(155, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lupa Password";
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(484, 300);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lupa Password";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label lblTitle;
        private Label lblInstructions;
        private TextBox txtEmail;
        private Button btnSendResetLink;
        private Button btnCancel;
        private PictureBox pbLoading;
        private LinkLabel lnkReset;
    }
}
