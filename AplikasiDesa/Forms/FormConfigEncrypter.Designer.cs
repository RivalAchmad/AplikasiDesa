namespace AplikasiDesa.Forms
{
    partial class FormConfigEncrypter
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lblBackupStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkOpenFolder = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File konfigurasi:";
            // 
            // txtInputPath
            // 
            this.txtInputPath.Location = new System.Drawing.Point(114, 71);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.ReadOnly = true;
            this.txtInputPath.Size = new System.Drawing.Size(332, 23);
            this.txtInputPath.TabIndex = 1;
            this.txtInputPath.Text = "appsettings.json";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(452, 71);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.Location = new System.Drawing.Point(114, 134);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(133, 34);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Enkripsi File";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 233);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 203);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(515, 23);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(253, 134);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(133, 34);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Kembalikan File Asli";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lblBackupStatus
            // 
            this.lblBackupStatus.AutoSize = true;
            this.lblBackupStatus.Location = new System.Drawing.Point(12, 255);
            this.lblBackupStatus.Name = "lblBackupStatus";
            this.lblBackupStatus.Size = new System.Drawing.Size(83, 15);
            this.lblBackupStatus.TabIndex = 7;
            this.lblBackupStatus.Text = "Status backup";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(392, 134);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 34);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Tutup";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkOpenFolder
            // 
            this.chkOpenFolder.AutoSize = true;
            this.chkOpenFolder.Checked = true;
            this.chkOpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenFolder.Location = new System.Drawing.Point(114, 107);
            this.chkOpenFolder.Name = "chkOpenFolder";
            this.chkOpenFolder.Size = new System.Drawing.Size(229, 19);
            this.chkOpenFolder.TabIndex = 9;
            this.chkOpenFolder.Text = "Buka folder setelah enkripsi berhasil";
            this.chkOpenFolder.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 60);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Alat Enkripsi Konfigurasi untuk Embedded Resource";
            // 
            // FormConfigEncrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkOpenFolder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblBackupStatus);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtInputPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormConfigEncrypter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplikasi Desa - Enkripsi Konfigurasi";
            this.Load += new System.EventHandler(this.FormConfigEncrypter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtInputPath;
        private Button btnBrowse;
        private Button btnEncrypt;
        private Label lblStatus;
        private ProgressBar progressBar;
        private Button btnRestore;
        private Label lblBackupStatus;
        private Button btnClose;
        private CheckBox chkOpenFolder;
        private GroupBox groupBox1;
        private Label label2;
    }
}
