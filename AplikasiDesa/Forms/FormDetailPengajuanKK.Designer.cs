namespace AplikasiDesa.Forms
{
    partial class FormDetailPengajuanKK
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel2 = new Panel();
            label2 = new Label();
            lblNomorKKValue = new Label();
            lblNomorKK = new Label();
            lblStatusValue = new Label();
            lblStatus = new Label();
            lblJenisValue = new Label();
            lblJenis = new Label();
            lblNamaValue = new Label();
            lblNama = new Label();
            lblNIKValue = new Label();
            lblNIK = new Label();
            lblTanggalValue = new Label();
            lblTanggal = new Label();
            lblIDValue = new Label();
            lblID = new Label();
            btnClose = new Button();
            dataGridViewAnggota = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnggota).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblNomorKKValue);
            panel2.Controls.Add(lblNomorKK);
            panel2.Controls.Add(lblStatusValue);
            panel2.Controls.Add(lblStatus);
            panel2.Controls.Add(lblJenisValue);
            panel2.Controls.Add(lblJenis);
            panel2.Controls.Add(lblNamaValue);
            panel2.Controls.Add(lblNama);
            panel2.Controls.Add(lblNIKValue);
            panel2.Controls.Add(lblNIK);
            panel2.Controls.Add(lblTanggalValue);
            panel2.Controls.Add(lblTanggal);
            panel2.Controls.Add(lblIDValue);
            panel2.Controls.Add(lblID);
            panel2.Controls.Add(btnClose);
            panel2.Controls.Add(dataGridViewAnggota);
            panel2.Location = new Point(12, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(772, 507);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 160);
            label2.Name = "label2";
            label2.Size = new Size(257, 31);
            label2.TabIndex = 22;
            label2.Text = "Data Anggota Keluarga";
            // 
            // lblNomorKKValue
            // 
            lblNomorKKValue.AutoSize = true;
            lblNomorKKValue.Location = new Point(567, 87);
            lblNomorKKValue.Name = "lblNomorKKValue";
            lblNomorKKValue.Size = new Size(15, 20);
            lblNomorKKValue.TabIndex = 19;
            lblNomorKKValue.Text = "-";
            // 
            // lblNomorKK
            // 
            lblNomorKK.AutoSize = true;
            lblNomorKK.Location = new Point(423, 87);
            lblNomorKK.Name = "lblNomorKK";
            lblNomorKK.Size = new Size(91, 20);
            lblNomorKK.TabIndex = 18;
            lblNomorKK.Text = "No. KK Baru:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Location = new Point(567, 57);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(15, 20);
            lblStatusValue.TabIndex = 17;
            lblStatusValue.Text = "-";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(423, 57);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(124, 20);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "Status Pengajuan:";
            // 
            // lblJenisValue
            // 
            lblJenisValue.AutoSize = true;
            lblJenisValue.Location = new Point(567, 28);
            lblJenisValue.Name = "lblJenisValue";
            lblJenisValue.Size = new Size(15, 20);
            lblJenisValue.TabIndex = 15;
            lblJenisValue.Text = "-";
            // 
            // lblJenis
            // 
            lblJenis.AutoSize = true;
            lblJenis.Location = new Point(423, 28);
            lblJenis.Name = "lblJenis";
            lblJenis.Size = new Size(102, 20);
            lblJenis.TabIndex = 14;
            lblJenis.Text = "Jenis Formulir:";
            // 
            // lblNamaValue
            // 
            lblNamaValue.AutoSize = true;
            lblNamaValue.Location = new Point(205, 117);
            lblNamaValue.Name = "lblNamaValue";
            lblNamaValue.Size = new Size(15, 20);
            lblNamaValue.TabIndex = 13;
            lblNamaValue.Text = "-";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(34, 117);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(165, 20);
            lblNama.TabIndex = 12;
            lblNama.Text = "Nama Kepala Keluarga:";
            // 
            // lblNIKValue
            // 
            lblNIKValue.AutoSize = true;
            lblNIKValue.Location = new Point(205, 87);
            lblNIKValue.Name = "lblNIKValue";
            lblNIKValue.Size = new Size(15, 20);
            lblNIKValue.TabIndex = 11;
            lblNIKValue.Text = "-";
            // 
            // lblNIK
            // 
            lblNIK.AutoSize = true;
            lblNIK.Location = new Point(34, 87);
            lblNIK.Name = "lblNIK";
            lblNIK.Size = new Size(157, 20);
            lblNIK.TabIndex = 10;
            lblNIK.Text = "NIK Kepala Keluaraga:";
            // 
            // lblTanggalValue
            // 
            lblTanggalValue.AutoSize = true;
            lblTanggalValue.Location = new Point(205, 57);
            lblTanggalValue.Name = "lblTanggalValue";
            lblTanggalValue.Size = new Size(15, 20);
            lblTanggalValue.TabIndex = 9;
            lblTanggalValue.Text = "-";
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Location = new Point(34, 57);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(136, 20);
            lblTanggal.TabIndex = 8;
            lblTanggal.Text = "Tanggal Pengajuan:";
            // 
            // lblIDValue
            // 
            lblIDValue.AutoSize = true;
            lblIDValue.Location = new Point(205, 28);
            lblIDValue.Name = "lblIDValue";
            lblIDValue.Size = new Size(15, 20);
            lblIDValue.TabIndex = 7;
            lblIDValue.Text = "-";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(34, 28);
            lblID.Name = "lblID";
            lblID.Size = new Size(99, 20);
            lblID.TabIndex = 6;
            lblID.Text = "ID Pengajuan:";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.FromArgb(198, 67, 72);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(653, 465);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(116, 39);
            btnClose.TabIndex = 5;
            btnClose.Text = "Tutup";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // dataGridViewAnggota
            // 
            dataGridViewAnggota.AllowUserToAddRows = false;
            dataGridViewAnggota.AllowUserToDeleteRows = false;
            dataGridViewAnggota.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(213, 247, 239);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(173, 236, 223);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(69, 150, 129);
            dataGridViewAnggota.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewAnggota.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewAnggota.BackgroundColor = Color.FromArgb(240, 252, 248);
            dataGridViewAnggota.BorderStyle = BorderStyle.None;
            dataGridViewAnggota.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewAnggota.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(102, 194, 165);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.Window;
            dataGridViewCellStyle2.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(69, 150, 129);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewAnggota.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewAnggota.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(173, 236, 223);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(69, 150, 129);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewAnggota.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewAnggota.EnableHeadersVisualStyles = false;
            dataGridViewAnggota.GridColor = Color.FromArgb(173, 236, 223);
            dataGridViewAnggota.Location = new Point(34, 194);
            dataGridViewAnggota.MultiSelect = false;
            dataGridViewAnggota.Name = "dataGridViewAnggota";
            dataGridViewAnggota.ReadOnly = true;
            dataGridViewAnggota.RowHeadersVisible = false;
            dataGridViewAnggota.RowHeadersWidth = 51;
            dataGridViewAnggota.RowTemplate.Height = 35;
            dataGridViewAnggota.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAnggota.Size = new Size(709, 247);
            dataGridViewAnggota.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(173, 236, 223);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 84);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(110, 20);
            label1.Name = "label1";
            label1.Size = new Size(574, 41);
            label1.TabIndex = 0;
            label1.Text = "DETAIL PENGAJUAN KARTU KELUARGA";
            // 
            // FormDetailPengajuanKK
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 616);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormDetailPengajuanKK";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form Detail Pengajuan KK";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnggota).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private DataGridView dataGridViewAnggota;
        private Panel panel1;
        private Label label1;
        private Button btnClose;
        private Label lblIDValue;
        private Label lblID;
        private Label lblNomorKKValue;
        private Label lblNomorKK;
        private Label lblStatusValue;
        private Label lblStatus;
        private Label lblJenisValue;
        private Label lblJenis;
        private Label lblNamaValue;
        private Label lblNama;
        private Label lblNIKValue;
        private Label lblNIK;
        private Label lblTanggalValue;
        private Label lblTanggal;
        private Label label2;
    }
}