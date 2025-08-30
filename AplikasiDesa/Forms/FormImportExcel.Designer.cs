namespace AplikasiDesa.Forms
{
    partial class FormImportExcel
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportExcel));
            panelMain = new Panel();
            groupBoxPreview = new GroupBox();
            dataGridViewPreview = new DataGridView();
            groupBoxStatus = new GroupBox();
            lblValidationStatus = new Label();
            progressBarValidation = new ProgressBar();
            richTextBoxErrors = new RichTextBox();
            lblErrorsTitle = new Label();
            groupBoxFile = new GroupBox();
            lblSelectedFile = new Label();
            btnBrowseFile = new FontAwesome.Sharp.IconButton();
            lblFileInfo = new Label();
            panelButtons = new Panel();
            btnImport = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnValidate = new FontAwesome.Sharp.IconButton();
            btnDownloadTemplate = new FontAwesome.Sharp.IconButton();
            toolTip = new ToolTip(components);
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            backgroundWorkerValidation = new System.ComponentModel.BackgroundWorker();
            backgroundWorkerImport = new System.ComponentModel.BackgroundWorker();
            panelMain.SuspendLayout();
            groupBoxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPreview).BeginInit();
            groupBoxStatus.SuspendLayout();
            groupBoxFile.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(groupBoxPreview);
            panelMain.Controls.Add(groupBoxStatus);
            panelMain.Controls.Add(groupBoxFile);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(17, 20, 17, 20);
            panelMain.Size = new Size(1050, 742);
            panelMain.TabIndex = 0;
            // 
            // groupBoxPreview
            // 
            groupBoxPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPreview.Controls.Add(dataGridViewPreview);
            groupBoxPreview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxPreview.Location = new Point(17, 477);
            groupBoxPreview.Margin = new Padding(3, 4, 3, 4);
            groupBoxPreview.Name = "groupBoxPreview";
            groupBoxPreview.Padding = new Padding(18, 13, 18, 15);
            groupBoxPreview.Size = new Size(1016, 241);
            groupBoxPreview.TabIndex = 2;
            groupBoxPreview.TabStop = false;
            groupBoxPreview.Text = "👁️ Preview Data";
            // 
            // dataGridViewPreview
            // 
            dataGridViewPreview.AllowUserToAddRows = false;
            dataGridViewPreview.AllowUserToDeleteRows = false;
            dataGridViewPreview.AllowUserToResizeRows = false;
            dataGridViewPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewPreview.BackgroundColor = Color.White;
            dataGridViewPreview.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPreview.Dock = DockStyle.Fill;
            dataGridViewPreview.Font = new Font("Segoe UI", 9F);
            dataGridViewPreview.Location = new Point(18, 36);
            dataGridViewPreview.Margin = new Padding(3, 4, 3, 4);
            dataGridViewPreview.MultiSelect = false;
            dataGridViewPreview.Name = "dataGridViewPreview";
            dataGridViewPreview.ReadOnly = true;
            dataGridViewPreview.RowHeadersVisible = false;
            dataGridViewPreview.RowHeadersWidth = 51;
            dataGridViewPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPreview.Size = new Size(980, 190);
            dataGridViewPreview.TabIndex = 0;
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxStatus.Controls.Add(lblValidationStatus);
            groupBoxStatus.Controls.Add(progressBarValidation);
            groupBoxStatus.Controls.Add(richTextBoxErrors);
            groupBoxStatus.Controls.Add(lblErrorsTitle);
            groupBoxStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxStatus.Location = new Point(17, 180);
            groupBoxStatus.Margin = new Padding(3, 4, 3, 4);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Padding = new Padding(11, 13, 11, 13);
            groupBoxStatus.Size = new Size(1016, 297);
            groupBoxStatus.TabIndex = 1;
            groupBoxStatus.TabStop = false;
            groupBoxStatus.Text = "📊 Status Validasi";
            // 
            // lblValidationStatus
            // 
            lblValidationStatus.AutoSize = true;
            lblValidationStatus.Font = new Font("Segoe UI", 9F);
            lblValidationStatus.Location = new Point(17, 47);
            lblValidationStatus.Name = "lblValidationStatus";
            lblValidationStatus.Size = new Size(242, 20);
            lblValidationStatus.TabIndex = 0;
            lblValidationStatus.Text = "Belum ada validasi yang dijalankan";
            // 
            // progressBarValidation
            // 
            progressBarValidation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarValidation.Location = new Point(17, 80);
            progressBarValidation.Margin = new Padding(3, 4, 3, 4);
            progressBarValidation.Name = "progressBarValidation";
            progressBarValidation.Size = new Size(981, 33);
            progressBarValidation.TabIndex = 1;
            progressBarValidation.Visible = false;
            // 
            // richTextBoxErrors
            // 
            richTextBoxErrors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxErrors.BackColor = Color.FromArgb(248, 249, 250);
            richTextBoxErrors.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxErrors.Font = new Font("Consolas", 9F);
            richTextBoxErrors.Location = new Point(17, 167);
            richTextBoxErrors.Margin = new Padding(3, 4, 3, 4);
            richTextBoxErrors.Name = "richTextBoxErrors";
            richTextBoxErrors.ReadOnly = true;
            richTextBoxErrors.Size = new Size(981, 112);
            richTextBoxErrors.TabIndex = 3;
            richTextBoxErrors.Text = "";
            richTextBoxErrors.Visible = false;
            // 
            // lblErrorsTitle
            // 
            lblErrorsTitle.AutoSize = true;
            lblErrorsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblErrorsTitle.Location = new Point(17, 133);
            lblErrorsTitle.Name = "lblErrorsTitle";
            lblErrorsTitle.Size = new Size(201, 20);
            lblErrorsTitle.TabIndex = 2;
            lblErrorsTitle.Text = "Kesalahan yang ditemukan:";
            lblErrorsTitle.Visible = false;
            // 
            // groupBoxFile
            // 
            groupBoxFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFile.Controls.Add(lblSelectedFile);
            groupBoxFile.Controls.Add(btnBrowseFile);
            groupBoxFile.Controls.Add(lblFileInfo);
            groupBoxFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFile.Location = new Point(17, 20);
            groupBoxFile.Margin = new Padding(3, 4, 3, 4);
            groupBoxFile.Name = "groupBoxFile";
            groupBoxFile.Padding = new Padding(11, 13, 11, 13);
            groupBoxFile.Size = new Size(1016, 160);
            groupBoxFile.TabIndex = 0;
            groupBoxFile.TabStop = false;
            groupBoxFile.Text = "📁 Pilih File Excel";
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Font = new Font("Segoe UI", 9F);
            lblSelectedFile.ForeColor = Color.Gray;
            lblSelectedFile.Location = new Point(17, 47);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(187, 20);
            lblSelectedFile.TabIndex = 0;
            lblSelectedFile.Text = "Belum ada file yang dipilih";
            // 
            // btnBrowseFile
            // 
            btnBrowseFile.BackColor = Color.FromArgb(52, 152, 219);
            btnBrowseFile.FlatAppearance.BorderSize = 0;
            btnBrowseFile.FlatStyle = FlatStyle.Flat;
            btnBrowseFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseFile.ForeColor = Color.White;
            btnBrowseFile.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBrowseFile.IconColor = Color.White;
            btnBrowseFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBrowseFile.IconSize = 20;
            btnBrowseFile.Location = new Point(17, 80);
            btnBrowseFile.Margin = new Padding(3, 4, 3, 4);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(171, 53);
            btnBrowseFile.TabIndex = 1;
            btnBrowseFile.Text = " Pilih File Excel";
            btnBrowseFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBrowseFile.UseVisualStyleBackColor = false;
            btnBrowseFile.Click += btnBrowseFile_Click;
            // 
            // lblFileInfo
            // 
            lblFileInfo.AutoSize = true;
            lblFileInfo.Font = new Font("Segoe UI", 8F);
            lblFileInfo.ForeColor = Color.Gray;
            lblFileInfo.Location = new Point(206, 93);
            lblFileInfo.Name = "lblFileInfo";
            lblFileInfo.Size = new Size(0, 19);
            lblFileInfo.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnImport);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnValidate);
            panelButtons.Controls.Add(btnDownloadTemplate);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 742);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(17, 20, 17, 20);
            panelButtons.Size = new Size(1050, 107);
            panelButtons.TabIndex = 1;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(39, 174, 96);
            btnImport.Enabled = false;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImport.ForeColor = Color.White;
            btnImport.IconChar = FontAwesome.Sharp.IconChar.Upload;
            btnImport.IconColor = Color.White;
            btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImport.IconSize = 20;
            btnImport.Location = new Point(417, 27);
            btnImport.Margin = new Padding(3, 4, 3, 4);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(171, 60);
            btnImport.TabIndex = 2;
            btnImport.Text = " Import Data";
            btnImport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancel.IconColor = Color.White;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 20;
            btnCancel.Location = new Point(606, 27);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 60);
            btnCancel.TabIndex = 3;
            btnCancel.Text = " Tutup";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnValidate
            // 
            btnValidate.BackColor = Color.FromArgb(243, 156, 18);
            btnValidate.Enabled = false;
            btnValidate.FlatAppearance.BorderSize = 0;
            btnValidate.FlatStyle = FlatStyle.Flat;
            btnValidate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnValidate.ForeColor = Color.White;
            btnValidate.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            btnValidate.IconColor = Color.White;
            btnValidate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnValidate.IconSize = 20;
            btnValidate.Location = new Point(229, 27);
            btnValidate.Margin = new Padding(3, 4, 3, 4);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(171, 60);
            btnValidate.TabIndex = 1;
            btnValidate.Text = " Validasi Data";
            btnValidate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnValidate.UseVisualStyleBackColor = false;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnDownloadTemplate
            // 
            btnDownloadTemplate.BackColor = Color.FromArgb(155, 89, 182);
            btnDownloadTemplate.FlatAppearance.BorderSize = 0;
            btnDownloadTemplate.FlatStyle = FlatStyle.Flat;
            btnDownloadTemplate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDownloadTemplate.ForeColor = Color.White;
            btnDownloadTemplate.IconChar = FontAwesome.Sharp.IconChar.Download;
            btnDownloadTemplate.IconColor = Color.White;
            btnDownloadTemplate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDownloadTemplate.IconSize = 20;
            btnDownloadTemplate.Location = new Point(17, 27);
            btnDownloadTemplate.Margin = new Padding(3, 4, 3, 4);
            btnDownloadTemplate.Name = "btnDownloadTemplate";
            btnDownloadTemplate.Size = new Size(194, 60);
            btnDownloadTemplate.TabIndex = 0;
            btnDownloadTemplate.Text = " Download Template";
            btnDownloadTemplate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDownloadTemplate.UseVisualStyleBackColor = false;
            btnDownloadTemplate.Click += btnDownloadTemplate_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.Title = "Pilih File Excel untuk Import";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Simpan Template Excel";
            // 
            // backgroundWorkerValidation
            // 
            backgroundWorkerValidation.WorkerReportsProgress = true;
            backgroundWorkerValidation.WorkerSupportsCancellation = true;
            backgroundWorkerValidation.DoWork += backgroundWorkerValidation_DoWork;
            backgroundWorkerValidation.ProgressChanged += backgroundWorkerValidation_ProgressChanged;
            backgroundWorkerValidation.RunWorkerCompleted += backgroundWorkerValidation_RunWorkerCompleted;
            // 
            // backgroundWorkerImport
            // 
            backgroundWorkerImport.WorkerReportsProgress = true;
            backgroundWorkerImport.WorkerSupportsCancellation = true;
            backgroundWorkerImport.DoWork += backgroundWorkerImport_DoWork;
            backgroundWorkerImport.ProgressChanged += backgroundWorkerImport_ProgressChanged;
            backgroundWorkerImport.RunWorkerCompleted += backgroundWorkerImport_RunWorkerCompleted;
            // 
            // FormImportExcel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(1050, 849);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormImportExcel";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Import Data Penduduk dari Excel";
            FormClosing += FormImportExcel_FormClosing;
            panelMain.ResumeLayout(false);
            groupBoxPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPreview).EndInit();
            groupBoxStatus.ResumeLayout(false);
            groupBoxStatus.PerformLayout();
            groupBoxFile.ResumeLayout(false);
            groupBoxFile.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private GroupBox groupBoxFile;
        private Label lblSelectedFile;
        private FontAwesome.Sharp.IconButton btnBrowseFile;
        private Label lblFileInfo;
        private GroupBox groupBoxStatus;
        private Label lblValidationStatus;
        private ProgressBar progressBarValidation;
        private RichTextBox richTextBoxErrors;
        private Label lblErrorsTitle;
        private GroupBox groupBoxPreview;
        private DataGridView dataGridViewPreview;
        private Panel panelButtons;
        private FontAwesome.Sharp.IconButton btnDownloadTemplate;
        private FontAwesome.Sharp.IconButton btnValidate;
        private FontAwesome.Sharp.IconButton btnImport;
        private FontAwesome.Sharp.IconButton btnCancel;
        private ToolTip toolTip;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerValidation;
        private System.ComponentModel.BackgroundWorker backgroundWorkerImport;
    }
}