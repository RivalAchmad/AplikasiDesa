namespace AplikasiDesa
{
    partial class FormAKM
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAKM));
            tabPage2 = new TabPage();
            buttonDeletePenduduk = new Button();
            panel6 = new Panel();
            lblPerBulanKategori = new Label();
            lblTotalTahunKategori = new Label();
            label11 = new Label();
            comboBoxTahun = new ComboBox();
            comboBoxBulan = new ComboBox();
            label39 = new Label();
            label41 = new Label();
            label42 = new Label();
            panel4 = new Panel();
            label28 = new Label();
            groupBox5 = new GroupBox();
            panel1 = new Panel();
            label8 = new Label();
            label7 = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            btnJumlahOrangMeninggal = new Button();
            groupBox4 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            txtSearch = new TextBox();
            dataGridViewSurat = new DataGridView();
            tabPage1 = new TabPage();
            tabControl2 = new TabControl();
            tabPage4 = new TabPage();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel8 = new Panel();
            label40 = new Label();
            btnTambahData = new Button();
            panel2 = new Panel();
            label19 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            label12 = new Label();
            textBoxNama = new TextBox();
            radioButtonPR = new RadioButton();
            comboBoxNama = new ComboBox();
            radioButtonLK = new RadioButton();
            richTextBoxAlamat = new RichTextBox();
            numericUpDownUmur = new NumericUpDown();
            labelNIK = new Label();
            labelJenisKelamin = new Label();
            labelUmur = new Label();
            labelWargaNegara = new Label();
            txtWarganegara = new TextBox();
            labelAgama = new Label();
            txtAgama = new TextBox();
            labelAlamat = new Label();
            groupBox3 = new GroupBox();
            richTextBoxLokasiKematian = new RichTextBox();
            labelHariTgl = new Label();
            dtpHariTgl = new DateTimePicker();
            txtHubungan = new TextBox();
            labelHubungan = new Label();
            cmbPenyebab = new ComboBox();
            labelWaktu = new Label();
            txtNamaPelapor = new TextBox();
            dtpJam = new DateTimePicker();
            labelNamaPelapor = new Label();
            labelLokasi = new Label();
            labelPenyebab = new Label();
            groupBox6 = new GroupBox();
            label31 = new Label();
            txtNamaPetugas = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtNamaKepalaDesa = new TextBox();
            label2 = new Label();
            txtNomorSurat = new TextBox();
            label1 = new Label();
            panel5 = new Panel();
            btnPrint = new Button();
            tabPage5 = new TabPage();
            groupBox9 = new GroupBox();
            radioButtonPRNonSurat = new RadioButton();
            comboBoxNonSurat = new ComboBox();
            radioButtonLKNonSurat = new RadioButton();
            label10 = new Label();
            btnLapor = new Button();
            label30 = new Label();
            dtpHariTglNonSurat = new DateTimePicker();
            richTextBoxAlamatNonSurat = new RichTextBox();
            numericUpDownUmurNonSurat = new NumericUpDown();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            txtWarganegaraNonSurat = new TextBox();
            label26 = new Label();
            txtAgamaNonSurat = new TextBox();
            label27 = new Label();
            panel3 = new Panel();
            label20 = new Label();
            tabControl1 = new TabControl();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            groupBox5.SuspendLayout();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSurat).BeginInit();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage4.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUmur).BeginInit();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            panel5.SuspendLayout();
            tabPage5.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUmurNonSurat).BeginInit();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(buttonDeletePenduduk);
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1154, 676);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "📜 Riwayat Surat";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeletePenduduk
            // 
            buttonDeletePenduduk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDeletePenduduk.BackColor = Color.FromArgb(198, 67, 72);
            buttonDeletePenduduk.FlatStyle = FlatStyle.Flat;
            buttonDeletePenduduk.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeletePenduduk.ForeColor = Color.White;
            buttonDeletePenduduk.Location = new Point(6, 482);
            buttonDeletePenduduk.Name = "buttonDeletePenduduk";
            buttonDeletePenduduk.RightToLeft = RightToLeft.No;
            buttonDeletePenduduk.Size = new Size(162, 57);
            buttonDeletePenduduk.TabIndex = 132;
            buttonDeletePenduduk.Text = "Hapus Riwayat";
            buttonDeletePenduduk.UseVisualStyleBackColor = false;
            buttonDeletePenduduk.Click += buttonDeletePenduduk_Click;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(lblPerBulanKategori);
            panel6.Controls.Add(lblTotalTahunKategori);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(comboBoxTahun);
            panel6.Controls.Add(comboBoxBulan);
            panel6.Controls.Add(label39);
            panel6.Controls.Add(label41);
            panel6.Controls.Add(label42);
            panel6.Location = new Point(228, 482);
            panel6.Name = "panel6";
            panel6.Size = new Size(921, 191);
            panel6.TabIndex = 130;
            // 
            // lblPerBulanKategori
            // 
            lblPerBulanKategori.AutoSize = true;
            lblPerBulanKategori.Font = new Font("Segoe UI", 10.2F);
            lblPerBulanKategori.Location = new Point(374, 90);
            lblPerBulanKategori.Name = "lblPerBulanKategori";
            lblPerBulanKategori.Size = new Size(460, 23);
            lblPerBulanKategori.TabIndex = 26;
            lblPerBulanKategori.Text = "Jumlah pengajuan Surat Keterangan Kematian [Pilih Bulan]";
            // 
            // lblTotalTahunKategori
            // 
            lblTotalTahunKategori.AutoSize = true;
            lblTotalTahunKategori.Font = new Font("Segoe UI", 10.2F);
            lblTotalTahunKategori.Location = new Point(374, 120);
            lblTotalTahunKategori.Name = "lblTotalTahunKategori";
            lblTotalTahunKategori.Size = new Size(463, 23);
            lblTotalTahunKategori.TabIndex = 27;
            lblTotalTahunKategori.Text = "Jumlah pengajuan Surat Keterangan Kematian [Pilih Tahun]";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(20, 54);
            label11.Name = "label11";
            label11.Size = new Size(104, 28);
            label11.TabIndex = 23;
            label11.Text = "Filter Data";
            // 
            // comboBoxTahun
            // 
            comboBoxTahun.BackColor = SystemColors.Control;
            comboBoxTahun.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTahun.FormattingEnabled = true;
            comboBoxTahun.Items.AddRange(new object[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030" });
            comboBoxTahun.Location = new Point(132, 124);
            comboBoxTahun.Name = "comboBoxTahun";
            comboBoxTahun.Size = new Size(189, 28);
            comboBoxTahun.TabIndex = 22;
            comboBoxTahun.SelectedIndexChanged += comboBoxTahun_SelectedIndexChanged;
            // 
            // comboBoxBulan
            // 
            comboBoxBulan.BackColor = SystemColors.Control;
            comboBoxBulan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBulan.FormattingEnabled = true;
            comboBoxBulan.Items.AddRange(new object[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" });
            comboBoxBulan.Location = new Point(132, 90);
            comboBoxBulan.Name = "comboBoxBulan";
            comboBoxBulan.Size = new Size(189, 28);
            comboBoxBulan.TabIndex = 18;
            comboBoxBulan.SelectedIndexChanged += comboBoxBulan_SelectedIndexChanged;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Segoe UI", 9F);
            label39.Location = new Point(27, 127);
            label39.Name = "label39";
            label39.Size = new Size(47, 20);
            label39.TabIndex = 21;
            label39.Text = "Tahun";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 9F);
            label41.Location = new Point(27, 93);
            label41.Name = "label41";
            label41.Size = new Size(46, 20);
            label41.TabIndex = 20;
            label41.Text = "Bulan";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label42.Location = new Point(252, 8);
            label42.Name = "label42";
            label42.Size = new Size(432, 28);
            label42.TabIndex = 6;
            label42.Text = "Jumlah Pengajuan Surat Keterangan Kematian";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(163, 57, 99);
            panel4.Controls.Add(label28);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1148, 63);
            panel4.TabIndex = 39;
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.None;
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.WhiteSmoke;
            label28.Location = new Point(251, 9);
            label28.Name = "label28";
            label28.Size = new Size(690, 41);
            label28.TabIndex = 0;
            label28.Text = "RIWAYAT DAN REKAPITULASI DATA KEMATIAN";
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox5.BackColor = Color.WhiteSmoke;
            groupBox5.Controls.Add(panel1);
            groupBox5.Controls.Add(btnJumlahOrangMeninggal);
            groupBox5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(849, 72);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(300, 404);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "REKAPITULASI DATA";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpEndDate);
            panel1.Controls.Add(dtpStartDate);
            panel1.Location = new Point(11, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 159);
            panel1.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 85);
            label8.Name = "label8";
            label8.Size = new Size(96, 17);
            label8.TabIndex = 7;
            label8.Text = "Rentang Akhir";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(14, 9);
            label7.Name = "label7";
            label7.Size = new Size(93, 17);
            label7.TabIndex = 6;
            label7.Text = "Rentang Awal";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.Location = new Point(14, 113);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.Location = new Point(14, 35);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 2;
            // 
            // btnJumlahOrangMeninggal
            // 
            btnJumlahOrangMeninggal.BackColor = Color.FromArgb(95, 183, 120);
            btnJumlahOrangMeninggal.FlatStyle = FlatStyle.Flat;
            btnJumlahOrangMeninggal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnJumlahOrangMeninggal.ForeColor = Color.White;
            btnJumlahOrangMeninggal.Location = new Point(25, 270);
            btnJumlahOrangMeninggal.Name = "btnJumlahOrangMeninggal";
            btnJumlahOrangMeninggal.Size = new Size(250, 61);
            btnJumlahOrangMeninggal.TabIndex = 4;
            btnJumlahOrangMeninggal.Text = "Jumlah Kematian";
            btnJumlahOrangMeninggal.UseVisualStyleBackColor = false;
            btnJumlahOrangMeninggal.Click += btnJumlahOrangMeninggal_Click;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.BackColor = Color.WhiteSmoke;
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(txtSearch);
            groupBox4.Controls.Add(dataGridViewSurat);
            groupBox4.FlatStyle = FlatStyle.System;
            groupBox4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(6, 72);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(837, 404);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "DAFTAR RIWAYAT SURAT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(120, 57);
            label4.Name = "label4";
            label4.Size = new Size(533, 20);
            label4.TabIndex = 3;
            label4.Text = "Masukkan Nama / NIK Terlapor / Nama Pelapor / Tanggal Surat (YYYY-MM-DD)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 50);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 2;
            label3.Text = "Cari Surat";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(15, 81);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔎";
            txtSearch.Size = new Size(638, 34);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dataGridViewSurat
            // 
            dataGridViewSurat.AllowUserToAddRows = false;
            dataGridViewSurat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(244, 143, 177);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(163, 57, 99);
            dataGridViewSurat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewSurat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSurat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewSurat.BackgroundColor = Color.FromArgb(248, 249, 250);
            dataGridViewSurat.BorderStyle = BorderStyle.None;
            dataGridViewSurat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewSurat.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewSurat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(163, 57, 99);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(244, 143, 177);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewSurat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewSurat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(244, 143, 177);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(163, 57, 99);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewSurat.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewSurat.EnableHeadersVisualStyles = false;
            dataGridViewSurat.GridColor = Color.FromArgb(221, 213, 243);
            dataGridViewSurat.Location = new Point(15, 121);
            dataGridViewSurat.Name = "dataGridViewSurat";
            dataGridViewSurat.ReadOnly = true;
            dataGridViewSurat.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(108, 117, 125);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(244, 143, 177);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(163, 57, 99);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewSurat.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewSurat.RowHeadersVisible = false;
            dataGridViewSurat.RowHeadersWidth = 51;
            dataGridViewSurat.RowTemplate.Height = 35;
            dataGridViewSurat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSurat.Size = new Size(800, 266);
            dataGridViewSurat.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.AllowDrop = true;
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1154, 676);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📝 Pelaporan Kematian";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1148, 670);
            tabControl2.TabIndex = 19;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(iconButton1);
            tabPage4.Controls.Add(panel8);
            tabPage4.Controls.Add(panel2);
            tabPage4.Controls.Add(tableLayoutPanel1);
            tabPage4.Location = new Point(4, 32);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1140, 634);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Surat";
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton1.BackColor = Color.WhiteSmoke;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(1079, 576);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(55, 55);
            iconButton1.TabIndex = 50;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.BackColor = Color.WhiteSmoke;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label40);
            panel8.Controls.Add(btnTambahData);
            panel8.Location = new Point(867, 490);
            panel8.MaximumSize = new Size(274, 150);
            panel8.MinimumSize = new Size(57, 57);
            panel8.Name = "panel8";
            panel8.Size = new Size(267, 141);
            panel8.TabIndex = 196;
            panel8.Visible = false;
            // 
            // label40
            // 
            label40.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label40.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label40.Location = new Point(9, 4);
            label40.Name = "label40";
            label40.Size = new Size(253, 69);
            label40.TabIndex = 49;
            label40.Text = "Tambah data baru apabila data \r\npenduduk yang diinginkan \r\nbelum ada pada database";
            // 
            // btnTambahData
            // 
            btnTambahData.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTambahData.BackColor = SystemColors.ActiveCaption;
            btnTambahData.FlatStyle = FlatStyle.Flat;
            btnTambahData.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahData.Location = new Point(9, 85);
            btnTambahData.Name = "btnTambahData";
            btnTambahData.Size = new Size(196, 45);
            btnTambahData.TabIndex = 47;
            btnTambahData.Text = "Tambah Data Penduduk";
            btnTambahData.UseVisualStyleBackColor = false;
            btnTambahData.Click += btnTambahData_Click;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = Color.FromArgb(163, 57, 99);
            panel2.Controls.Add(label19);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1134, 63);
            panel2.TabIndex = 38;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(233, 9);
            label19.Name = "label19";
            label19.Size = new Size(674, 41);
            label19.TabIndex = 0;
            label19.Text = "PENGAJUAN SURAT KETERANGAN KEMATIAN";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox3, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox6, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Location = new Point(3, 67);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69.8961945F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.1038055F));
            tableLayoutPanel1.Size = new Size(1134, 564);
            tableLayoutPanel1.TabIndex = 197;
            // 
            // groupBox1
            // 
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(textBoxNama);
            groupBox1.Controls.Add(radioButtonPR);
            groupBox1.Controls.Add(comboBoxNama);
            groupBox1.Controls.Add(radioButtonLK);
            groupBox1.Controls.Add(richTextBoxAlamat);
            groupBox1.Controls.Add(numericUpDownUmur);
            groupBox1.Controls.Add(labelNIK);
            groupBox1.Controls.Add(labelJenisKelamin);
            groupBox1.Controls.Add(labelUmur);
            groupBox1.Controls.Add(labelWargaNegara);
            groupBox1.Controls.Add(txtWarganegara);
            groupBox1.Controls.Add(labelAgama);
            groupBox1.Controls.Add(txtAgama);
            groupBox1.Controls.Add(labelAlamat);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(561, 388);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "FORMULIR DATA TERLAPOR";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(14, 95);
            label12.Name = "label12";
            label12.Size = new Size(49, 20);
            label12.TabIndex = 21;
            label12.Text = "Nama";
            // 
            // textBoxNama
            // 
            textBoxNama.Anchor = AnchorStyles.None;
            textBoxNama.Font = new Font("Segoe UI", 9F);
            textBoxNama.Location = new Point(151, 92);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(295, 27);
            textBoxNama.TabIndex = 20;
            // 
            // radioButtonPR
            // 
            radioButtonPR.Anchor = AnchorStyles.None;
            radioButtonPR.AutoSize = true;
            radioButtonPR.Font = new Font("Segoe UI", 9F);
            radioButtonPR.Location = new Point(269, 126);
            radioButtonPR.Name = "radioButtonPR";
            radioButtonPR.Size = new Size(104, 24);
            radioButtonPR.TabIndex = 1;
            radioButtonPR.TabStop = true;
            radioButtonPR.Text = "Perempuan";
            radioButtonPR.UseVisualStyleBackColor = true;
            // 
            // comboBoxNama
            // 
            comboBoxNama.Anchor = AnchorStyles.None;
            comboBoxNama.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxNama.FormattingEnabled = true;
            comboBoxNama.Location = new Point(151, 40);
            comboBoxNama.Name = "comboBoxNama";
            comboBoxNama.Size = new Size(398, 36);
            comboBoxNama.TabIndex = 19;
            comboBoxNama.SelectedIndexChanged += comboBoxNama_SelectedIndexChanged;
            comboBoxNama.TextChanged += comboBoxNama_TextChanged;
            comboBoxNama.KeyDown += comboBoxNama_KeyDown;
            // 
            // radioButtonLK
            // 
            radioButtonLK.Anchor = AnchorStyles.None;
            radioButtonLK.AutoSize = true;
            radioButtonLK.Font = new Font("Segoe UI", 9F);
            radioButtonLK.Location = new Point(153, 126);
            radioButtonLK.Name = "radioButtonLK";
            radioButtonLK.Size = new Size(85, 24);
            radioButtonLK.TabIndex = 0;
            radioButtonLK.TabStop = true;
            radioButtonLK.Text = "Laki-laki";
            radioButtonLK.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAlamat
            // 
            richTextBoxAlamat.Anchor = AnchorStyles.None;
            richTextBoxAlamat.Font = new Font("Segoe UI", 9F);
            richTextBoxAlamat.Location = new Point(151, 284);
            richTextBoxAlamat.Name = "richTextBoxAlamat";
            richTextBoxAlamat.Size = new Size(405, 101);
            richTextBoxAlamat.TabIndex = 18;
            richTextBoxAlamat.Text = "";
            // 
            // numericUpDownUmur
            // 
            numericUpDownUmur.Anchor = AnchorStyles.None;
            numericUpDownUmur.Font = new Font("Segoe UI", 9F);
            numericUpDownUmur.Location = new Point(153, 161);
            numericUpDownUmur.Name = "numericUpDownUmur";
            numericUpDownUmur.Size = new Size(150, 27);
            numericUpDownUmur.TabIndex = 15;
            numericUpDownUmur.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelNIK
            // 
            labelNIK.Anchor = AnchorStyles.None;
            labelNIK.AutoSize = true;
            labelNIK.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNIK.Location = new Point(14, 38);
            labelNIK.Name = "labelNIK";
            labelNIK.Size = new Size(138, 40);
            labelNIK.TabIndex = 0;
            labelNIK.Text = "Cari Data \r\n(Masukkan Nama)";
            // 
            // labelJenisKelamin
            // 
            labelJenisKelamin.Anchor = AnchorStyles.None;
            labelJenisKelamin.AutoSize = true;
            labelJenisKelamin.Font = new Font("Segoe UI", 9F);
            labelJenisKelamin.Location = new Point(14, 128);
            labelJenisKelamin.Name = "labelJenisKelamin";
            labelJenisKelamin.Size = new Size(98, 20);
            labelJenisKelamin.TabIndex = 2;
            labelJenisKelamin.Text = "Jenis Kelamin";
            // 
            // labelUmur
            // 
            labelUmur.Anchor = AnchorStyles.None;
            labelUmur.AutoSize = true;
            labelUmur.Font = new Font("Segoe UI", 9F);
            labelUmur.Location = new Point(14, 168);
            labelUmur.Name = "labelUmur";
            labelUmur.Size = new Size(45, 20);
            labelUmur.TabIndex = 3;
            labelUmur.Text = "Umur";
            // 
            // labelWargaNegara
            // 
            labelWargaNegara.Anchor = AnchorStyles.None;
            labelWargaNegara.AutoSize = true;
            labelWargaNegara.Font = new Font("Segoe UI", 9F);
            labelWargaNegara.Location = new Point(14, 206);
            labelWargaNegara.Name = "labelWargaNegara";
            labelWargaNegara.Size = new Size(98, 20);
            labelWargaNegara.TabIndex = 4;
            labelWargaNegara.Text = "Warganegara";
            // 
            // txtWarganegara
            // 
            txtWarganegara.Anchor = AnchorStyles.None;
            txtWarganegara.Font = new Font("Segoe UI", 9F);
            txtWarganegara.Location = new Point(151, 203);
            txtWarganegara.Name = "txtWarganegara";
            txtWarganegara.Size = new Size(295, 27);
            txtWarganegara.TabIndex = 11;
            // 
            // labelAgama
            // 
            labelAgama.Anchor = AnchorStyles.None;
            labelAgama.AutoSize = true;
            labelAgama.Font = new Font("Segoe UI", 9F);
            labelAgama.Location = new Point(14, 244);
            labelAgama.Name = "labelAgama";
            labelAgama.Size = new Size(57, 20);
            labelAgama.TabIndex = 5;
            labelAgama.Text = "Agama";
            // 
            // txtAgama
            // 
            txtAgama.Anchor = AnchorStyles.None;
            txtAgama.Font = new Font("Segoe UI", 9F);
            txtAgama.Location = new Point(151, 244);
            txtAgama.Name = "txtAgama";
            txtAgama.Size = new Size(295, 27);
            txtAgama.TabIndex = 12;
            // 
            // labelAlamat
            // 
            labelAlamat.Anchor = AnchorStyles.None;
            labelAlamat.AutoEllipsis = true;
            labelAlamat.AutoSize = true;
            labelAlamat.Font = new Font("Segoe UI", 9F);
            labelAlamat.Location = new Point(14, 284);
            labelAlamat.Name = "labelAlamat";
            labelAlamat.Size = new Size(113, 20);
            labelAlamat.TabIndex = 6;
            labelAlamat.Text = "Alamat Terakhir";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.WhiteSmoke;
            groupBox3.Controls.Add(richTextBoxLokasiKematian);
            groupBox3.Controls.Add(labelHariTgl);
            groupBox3.Controls.Add(dtpHariTgl);
            groupBox3.Controls.Add(txtHubungan);
            groupBox3.Controls.Add(labelHubungan);
            groupBox3.Controls.Add(cmbPenyebab);
            groupBox3.Controls.Add(labelWaktu);
            groupBox3.Controls.Add(txtNamaPelapor);
            groupBox3.Controls.Add(dtpJam);
            groupBox3.Controls.Add(labelNamaPelapor);
            groupBox3.Controls.Add(labelLokasi);
            groupBox3.Controls.Add(labelPenyebab);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(570, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(561, 388);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "FORMULIR DATA KEMATIAN";
            // 
            // richTextBoxLokasiKematian
            // 
            richTextBoxLokasiKematian.Anchor = AnchorStyles.None;
            richTextBoxLokasiKematian.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxLokasiKematian.Location = new Point(151, 114);
            richTextBoxLokasiKematian.Name = "richTextBoxLokasiKematian";
            richTextBoxLokasiKematian.Size = new Size(394, 106);
            richTextBoxLokasiKematian.TabIndex = 30;
            richTextBoxLokasiKematian.Text = "";
            // 
            // labelHariTgl
            // 
            labelHariTgl.Anchor = AnchorStyles.None;
            labelHariTgl.AutoSize = true;
            labelHariTgl.Font = new Font("Segoe UI", 9F);
            labelHariTgl.Location = new Point(17, 35);
            labelHariTgl.Name = "labelHariTgl";
            labelHariTgl.Size = new Size(128, 20);
            labelHariTgl.TabIndex = 19;
            labelHariTgl.Text = "Tanggal Kematian";
            // 
            // dtpHariTgl
            // 
            dtpHariTgl.Anchor = AnchorStyles.None;
            dtpHariTgl.CustomFormat = "dddd, dd MMMM yyyy";
            dtpHariTgl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpHariTgl.Format = DateTimePickerFormat.Custom;
            dtpHariTgl.Location = new Point(151, 30);
            dtpHariTgl.Name = "dtpHariTgl";
            dtpHariTgl.Size = new Size(273, 27);
            dtpHariTgl.TabIndex = 18;
            // 
            // txtHubungan
            // 
            txtHubungan.Anchor = AnchorStyles.None;
            txtHubungan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHubungan.Location = new Point(152, 321);
            txtHubungan.Name = "txtHubungan";
            txtHubungan.Size = new Size(188, 27);
            txtHubungan.TabIndex = 27;
            // 
            // labelHubungan
            // 
            labelHubungan.Anchor = AnchorStyles.None;
            labelHubungan.AutoSize = true;
            labelHubungan.Font = new Font("Segoe UI", 9F);
            labelHubungan.Location = new Point(17, 316);
            labelHubungan.Name = "labelHubungan";
            labelHubungan.Size = new Size(118, 40);
            labelHubungan.TabIndex = 28;
            labelHubungan.Text = "Hubungan\r\ndengan Terlapor";
            // 
            // cmbPenyebab
            // 
            cmbPenyebab.Anchor = AnchorStyles.None;
            cmbPenyebab.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPenyebab.FormattingEnabled = true;
            cmbPenyebab.Items.AddRange(new object[] { "Sakit Biasa / Tua", "Wabah Penyakit", "Kecelakaan", "Kriminalitas", "Bunuh Diri", "Lainnya" });
            cmbPenyebab.Location = new Point(151, 234);
            cmbPenyebab.Name = "cmbPenyebab";
            cmbPenyebab.Size = new Size(189, 28);
            cmbPenyebab.TabIndex = 29;
            // 
            // labelWaktu
            // 
            labelWaktu.Anchor = AnchorStyles.None;
            labelWaktu.AutoSize = true;
            labelWaktu.Font = new Font("Segoe UI", 9F);
            labelWaktu.Location = new Point(17, 76);
            labelWaktu.Name = "labelWaktu";
            labelWaktu.Size = new Size(35, 20);
            labelWaktu.TabIndex = 21;
            labelWaktu.Text = "Jam";
            // 
            // txtNamaPelapor
            // 
            txtNamaPelapor.Anchor = AnchorStyles.None;
            txtNamaPelapor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNamaPelapor.Location = new Point(151, 275);
            txtNamaPelapor.Name = "txtNamaPelapor";
            txtNamaPelapor.Size = new Size(273, 27);
            txtNamaPelapor.TabIndex = 17;
            // 
            // dtpJam
            // 
            dtpJam.Anchor = AnchorStyles.None;
            dtpJam.CustomFormat = "HH:mm WIB";
            dtpJam.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpJam.Format = DateTimePickerFormat.Custom;
            dtpJam.Location = new Point(151, 71);
            dtpJam.Name = "dtpJam";
            dtpJam.ShowUpDown = true;
            dtpJam.Size = new Size(180, 27);
            dtpJam.TabIndex = 20;
            // 
            // labelNamaPelapor
            // 
            labelNamaPelapor.Anchor = AnchorStyles.None;
            labelNamaPelapor.AutoSize = true;
            labelNamaPelapor.Font = new Font("Segoe UI", 9F);
            labelNamaPelapor.Location = new Point(17, 278);
            labelNamaPelapor.Name = "labelNamaPelapor";
            labelNamaPelapor.Size = new Size(103, 20);
            labelNamaPelapor.TabIndex = 16;
            labelNamaPelapor.Text = "Nama Pelapor";
            // 
            // labelLokasi
            // 
            labelLokasi.Anchor = AnchorStyles.None;
            labelLokasi.AutoSize = true;
            labelLokasi.Font = new Font("Segoe UI", 9F);
            labelLokasi.Location = new Point(17, 117);
            labelLokasi.Name = "labelLokasi";
            labelLokasi.Size = new Size(117, 20);
            labelLokasi.TabIndex = 23;
            labelLokasi.Text = "Lokasi Kematian";
            // 
            // labelPenyebab
            // 
            labelPenyebab.Anchor = AnchorStyles.None;
            labelPenyebab.AutoSize = true;
            labelPenyebab.Font = new Font("Segoe UI", 9F);
            labelPenyebab.Location = new Point(17, 237);
            labelPenyebab.Name = "labelPenyebab";
            labelPenyebab.Size = new Size(73, 20);
            labelPenyebab.TabIndex = 25;
            labelPenyebab.Text = "Penyebab";
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.WhiteSmoke;
            groupBox6.Controls.Add(label31);
            groupBox6.Controls.Add(txtNamaPetugas);
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(txtNamaKepalaDesa);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(txtNomorSurat);
            groupBox6.Controls.Add(label1);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox6.Location = new Point(3, 397);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(561, 164);
            groupBox6.TabIndex = 37;
            groupBox6.TabStop = false;
            groupBox6.Text = "KETERANGAN SURAT";
            // 
            // label31
            // 
            label31.Anchor = AnchorStyles.None;
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label31.Location = new Point(16, 113);
            label31.Name = "label31";
            label31.Size = new Size(60, 20);
            label31.TabIndex = 40;
            label31.Text = "Petugas";
            // 
            // txtNamaPetugas
            // 
            txtNamaPetugas.Anchor = AnchorStyles.None;
            txtNamaPetugas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNamaPetugas.Location = new Point(148, 110);
            txtNamaPetugas.Name = "txtNamaPetugas";
            txtNamaPetugas.Size = new Size(407, 27);
            txtNamaPetugas.TabIndex = 39;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 73);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 38;
            label6.Text = "Kepala Desa";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 43);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 37;
            label5.Text = "Nomor Surat";
            // 
            // txtNamaKepalaDesa
            // 
            txtNamaKepalaDesa.Anchor = AnchorStyles.None;
            txtNamaKepalaDesa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNamaKepalaDesa.Location = new Point(148, 70);
            txtNamaKepalaDesa.Name = "txtNamaKepalaDesa";
            txtNamaKepalaDesa.Size = new Size(407, 27);
            txtNamaKepalaDesa.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(-110, 75);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 36;
            label2.Text = "Kepala Desa";
            // 
            // txtNomorSurat
            // 
            txtNomorSurat.Anchor = AnchorStyles.None;
            txtNomorSurat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomorSurat.Location = new Point(148, 36);
            txtNomorSurat.Name = "txtNomorSurat";
            txtNomorSurat.Size = new Size(407, 27);
            txtNomorSurat.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(-110, 11);
            label1.Name = "label1";
            label1.Size = new Size(109, 23);
            label1.TabIndex = 35;
            label1.Text = "Nomor Surat";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(btnPrint);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(570, 397);
            panel5.Name = "panel5";
            panel5.Size = new Size(561, 164);
            panel5.TabIndex = 38;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.None;
            btnPrint.BackColor = Color.FromArgb(72, 126, 176);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = SystemColors.Control;
            btnPrint.Location = new Point(61, 50);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(187, 58);
            btnPrint.TabIndex = 15;
            btnPrint.Text = "CETAK PDF";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(groupBox9);
            tabPage5.Controls.Add(panel3);
            tabPage5.Location = new Point(4, 32);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1140, 634);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "Non Surat";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox9.BackColor = Color.WhiteSmoke;
            groupBox9.Controls.Add(radioButtonPRNonSurat);
            groupBox9.Controls.Add(comboBoxNonSurat);
            groupBox9.Controls.Add(radioButtonLKNonSurat);
            groupBox9.Controls.Add(label10);
            groupBox9.Controls.Add(btnLapor);
            groupBox9.Controls.Add(label30);
            groupBox9.Controls.Add(dtpHariTglNonSurat);
            groupBox9.Controls.Add(richTextBoxAlamatNonSurat);
            groupBox9.Controls.Add(numericUpDownUmurNonSurat);
            groupBox9.Controls.Add(label23);
            groupBox9.Controls.Add(label24);
            groupBox9.Controls.Add(label25);
            groupBox9.Controls.Add(txtWarganegaraNonSurat);
            groupBox9.Controls.Add(label26);
            groupBox9.Controls.Add(txtAgamaNonSurat);
            groupBox9.Controls.Add(label27);
            groupBox9.Dock = DockStyle.Fill;
            groupBox9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox9.ForeColor = SystemColors.ControlText;
            groupBox9.Location = new Point(3, 66);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(1134, 565);
            groupBox9.TabIndex = 40;
            groupBox9.TabStop = false;
            groupBox9.Text = "DATA TERLAPOR";
            // 
            // radioButtonPRNonSurat
            // 
            radioButtonPRNonSurat.Anchor = AnchorStyles.None;
            radioButtonPRNonSurat.AutoSize = true;
            radioButtonPRNonSurat.Font = new Font("Segoe UI", 9F);
            radioButtonPRNonSurat.Location = new Point(281, 173);
            radioButtonPRNonSurat.Name = "radioButtonPRNonSurat";
            radioButtonPRNonSurat.Size = new Size(104, 24);
            radioButtonPRNonSurat.TabIndex = 1;
            radioButtonPRNonSurat.TabStop = true;
            radioButtonPRNonSurat.Text = "Perempuan";
            radioButtonPRNonSurat.UseVisualStyleBackColor = true;
            // 
            // comboBoxNonSurat
            // 
            comboBoxNonSurat.Anchor = AnchorStyles.None;
            comboBoxNonSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxNonSurat.FormattingEnabled = true;
            comboBoxNonSurat.Location = new Point(163, 124);
            comboBoxNonSurat.Name = "comboBoxNonSurat";
            comboBoxNonSurat.Size = new Size(398, 36);
            comboBoxNonSurat.TabIndex = 43;
            comboBoxNonSurat.SelectedIndexChanged += comboBoxNonSurat_SelectedIndexChanged;
            comboBoxNonSurat.TextChanged += comboBoxNonSurat_TextChanged;
            comboBoxNonSurat.KeyDown += comboBoxNonSurat_KeyDown;
            // 
            // radioButtonLKNonSurat
            // 
            radioButtonLKNonSurat.Anchor = AnchorStyles.None;
            radioButtonLKNonSurat.AutoSize = true;
            radioButtonLKNonSurat.Font = new Font("Segoe UI", 9F);
            radioButtonLKNonSurat.Location = new Point(165, 173);
            radioButtonLKNonSurat.Name = "radioButtonLKNonSurat";
            radioButtonLKNonSurat.Size = new Size(85, 24);
            radioButtonLKNonSurat.TabIndex = 0;
            radioButtonLKNonSurat.TabStop = true;
            radioButtonLKNonSurat.Text = "Laki-laki";
            radioButtonLKNonSurat.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(26, 131);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 42;
            label10.Text = "Cari Nama";
            // 
            // btnLapor
            // 
            btnLapor.Anchor = AnchorStyles.None;
            btnLapor.BackColor = Color.FromArgb(72, 126, 176);
            btnLapor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLapor.ForeColor = SystemColors.Control;
            btnLapor.Location = new Point(712, 333);
            btnLapor.Name = "btnLapor";
            btnLapor.Size = new Size(273, 83);
            btnLapor.TabIndex = 41;
            btnLapor.Text = "LAPORKAN";
            btnLapor.UseVisualStyleBackColor = false;
            btnLapor.Click += btnLapor_Click;
            // 
            // label30
            // 
            label30.Anchor = AnchorStyles.None;
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label30.Location = new Point(712, 120);
            label30.Name = "label30";
            label30.Size = new Size(96, 40);
            label30.TabIndex = 20;
            label30.Text = "Hari, Tanggal\r\nKematian\r\n";
            // 
            // dtpHariTglNonSurat
            // 
            dtpHariTglNonSurat.Anchor = AnchorStyles.None;
            dtpHariTglNonSurat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpHariTglNonSurat.Location = new Point(831, 129);
            dtpHariTglNonSurat.Name = "dtpHariTglNonSurat";
            dtpHariTglNonSurat.Size = new Size(273, 27);
            dtpHariTglNonSurat.TabIndex = 19;
            // 
            // richTextBoxAlamatNonSurat
            // 
            richTextBoxAlamatNonSurat.Anchor = AnchorStyles.None;
            richTextBoxAlamatNonSurat.Font = new Font("Segoe UI", 9F);
            richTextBoxAlamatNonSurat.Location = new Point(163, 333);
            richTextBoxAlamatNonSurat.Name = "richTextBoxAlamatNonSurat";
            richTextBoxAlamatNonSurat.Size = new Size(398, 86);
            richTextBoxAlamatNonSurat.TabIndex = 18;
            richTextBoxAlamatNonSurat.Text = "";
            // 
            // numericUpDownUmurNonSurat
            // 
            numericUpDownUmurNonSurat.Anchor = AnchorStyles.None;
            numericUpDownUmurNonSurat.Font = new Font("Segoe UI", 9F);
            numericUpDownUmurNonSurat.Location = new Point(165, 210);
            numericUpDownUmurNonSurat.Name = "numericUpDownUmurNonSurat";
            numericUpDownUmurNonSurat.Size = new Size(150, 27);
            numericUpDownUmurNonSurat.TabIndex = 15;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.None;
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F);
            label23.Location = new Point(26, 175);
            label23.Name = "label23";
            label23.Size = new Size(98, 20);
            label23.TabIndex = 2;
            label23.Text = "Jenis Kelamin";
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.None;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F);
            label24.Location = new Point(26, 217);
            label24.Name = "label24";
            label24.Size = new Size(45, 20);
            label24.TabIndex = 3;
            label24.Text = "Umur";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.None;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F);
            label25.Location = new Point(26, 255);
            label25.Name = "label25";
            label25.Size = new Size(98, 20);
            label25.TabIndex = 4;
            label25.Text = "Warganegara";
            // 
            // txtWarganegaraNonSurat
            // 
            txtWarganegaraNonSurat.Anchor = AnchorStyles.None;
            txtWarganegaraNonSurat.Font = new Font("Segoe UI", 9F);
            txtWarganegaraNonSurat.Location = new Point(163, 252);
            txtWarganegaraNonSurat.Name = "txtWarganegaraNonSurat";
            txtWarganegaraNonSurat.Size = new Size(226, 27);
            txtWarganegaraNonSurat.TabIndex = 11;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.None;
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F);
            label26.Location = new Point(26, 293);
            label26.Name = "label26";
            label26.Size = new Size(57, 20);
            label26.TabIndex = 5;
            label26.Text = "Agama";
            // 
            // txtAgamaNonSurat
            // 
            txtAgamaNonSurat.Anchor = AnchorStyles.None;
            txtAgamaNonSurat.Font = new Font("Segoe UI", 9F);
            txtAgamaNonSurat.Location = new Point(163, 293);
            txtAgamaNonSurat.Name = "txtAgamaNonSurat";
            txtAgamaNonSurat.Size = new Size(226, 27);
            txtAgamaNonSurat.TabIndex = 12;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.None;
            label27.AutoEllipsis = true;
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F);
            label27.Location = new Point(26, 333);
            label27.Name = "label27";
            label27.Size = new Size(113, 20);
            label27.TabIndex = 6;
            label27.Text = "Alamat Terakhir";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(163, 57, 99);
            panel3.Controls.Add(label20);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1134, 63);
            panel3.TabIndex = 39;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.None;
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.White;
            label20.Location = new Point(250, 9);
            label20.Name = "label20";
            label20.Size = new Size(671, 41);
            label20.TabIndex = 0;
            label20.Text = "LAPOR KEMATIAN NON SURAT KETERANGAN";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(150, 35);
            tabControl1.Location = new Point(7, 7);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1162, 719);
            tabControl1.TabIndex = 33;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // FormAKM
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1176, 733);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(1194, 780);
            Name = "FormAKM";
            Padding = new Padding(7);
            Text = "Pengajuan Surat Keterangan Kematian";
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSurat).EndInit();
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUmur).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            panel5.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUmurNonSurat).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage2;
        private Panel panel4;
        private Label label28;
        private GroupBox groupBox4;
        private Label label4;
        private Label label3;
        private TextBox txtSearch;
        private DataGridView dataGridViewSurat;
        private TabPage tabPage1;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private Panel panel2;
        private Label label19;
        private GroupBox groupBox1;
        private RichTextBox richTextBoxAlamat;
        private RadioButton radioButtonPR;
        private NumericUpDown numericUpDownUmur;
        private Label labelNIK;
        private Label labelJenisKelamin;
        private Label labelUmur;
        private Label labelWargaNegara;
        private TextBox txtWarganegara;
        private Label labelAgama;
        private TextBox txtAgama;
        private Label labelAlamat;
        private Button btnPrint;
        private GroupBox groupBox3;
        private RichTextBox richTextBoxLokasiKematian;
        private Label labelHariTgl;
        private DateTimePicker dtpHariTgl;
        private TextBox txtHubungan;
        private Label labelHubungan;
        private ComboBox cmbPenyebab;
        private Label labelWaktu;
        private TextBox txtNamaPelapor;
        private DateTimePicker dtpJam;
        private Label labelNamaPelapor;
        private Label labelLokasi;
        private Label labelPenyebab;
        private GroupBox groupBox6;
        private Label label31;
        private TextBox txtNamaPetugas;
        private Label label6;
        private Label label5;
        private TextBox txtNamaKepalaDesa;
        private Label label2;
        private TextBox txtNomorSurat;
        private Label label1;
        private TabPage tabPage5;
        private GroupBox groupBox9;
        private Button btnLapor;
        private Label label30;
        private DateTimePicker dtpHariTglNonSurat;
        private RichTextBox richTextBoxAlamatNonSurat;
        private RadioButton radioButtonPRNonSurat;
        private RadioButton radioButtonLKNonSurat;
        private NumericUpDown numericUpDownUmurNonSurat;
        private Label label23;
        private Label label24;
        private Label label25;
        private TextBox txtWarganegaraNonSurat;
        private Label label26;
        private TextBox txtAgamaNonSurat;
        private Label label27;
        private Panel panel3;
        private Label label20;
        private TabControl tabControl1;
        private ComboBox comboBoxNama;
        private RadioButton radioButtonLK;
        private ComboBox comboBoxNonSurat;
        private Label label10;
        private Panel panel6;
        private Label lblPerBulanKategori;
        private Label lblTotalTahunKategori;
        private Label label11;
        private ComboBox comboBoxTahun;
        private ComboBox comboBoxBulan;
        private Label label39;
        private Label label41;
        private Label label42;
        private Label label12;
        private TextBox textBoxNama;
        private Button buttonDeletePenduduk;
        private Panel panel8;
        private Label label40;
        private Button btnTambahData;
        private GroupBox groupBox5;
        private Panel panel1;
        private Label label8;
        private Label label7;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Button btnJumlahOrangMeninggal;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel5;
    }
}