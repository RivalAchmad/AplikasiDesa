﻿namespace AplikasiDesa
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
            label9 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtSearch = new TextBox();
            dataGridViewSurat = new DataGridView();
            tabPage1 = new TabPage();
            tabControl2 = new TabControl();
            tabPage4 = new TabPage();
            panel8 = new Panel();
            label40 = new Label();
            btnTambahData = new Button();
            panel2 = new Panel();
            label19 = new Label();
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
            btnPrint = new Button();
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUmur).BeginInit();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
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
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1169, 693);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Riwayat Surat";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeletePenduduk
            // 
            buttonDeletePenduduk.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeletePenduduk.Location = new Point(6, 496);
            buttonDeletePenduduk.Name = "buttonDeletePenduduk";
            buttonDeletePenduduk.Size = new Size(135, 47);
            buttonDeletePenduduk.TabIndex = 132;
            buttonDeletePenduduk.Text = "Hapus Riwayat";
            buttonDeletePenduduk.UseVisualStyleBackColor = true;
            buttonDeletePenduduk.Click += buttonDeletePenduduk_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightGray;
            panel6.Controls.Add(lblPerBulanKategori);
            panel6.Controls.Add(lblTotalTahunKategori);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(comboBoxTahun);
            panel6.Controls.Add(comboBoxBulan);
            panel6.Controls.Add(label39);
            panel6.Controls.Add(label41);
            panel6.Controls.Add(label42);
            panel6.Location = new Point(242, 496);
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
            panel4.BackColor = Color.LightGray;
            panel4.Controls.Add(label28);
            panel4.Location = new Point(6, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(1157, 60);
            panel4.TabIndex = 39;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label28.Location = new Point(258, 8);
            label28.Name = "label28";
            label28.Size = new Size(690, 41);
            label28.TabIndex = 0;
            label28.Text = "RIWAYAT DAN REKAPITULASI DATA KEMATIAN";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.LightGray;
            groupBox5.Controls.Add(panel1);
            groupBox5.Controls.Add(btnJumlahOrangMeninggal);
            groupBox5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(863, 72);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(300, 418);
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
            btnJumlahOrangMeninggal.BackColor = Color.Orange;
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
            groupBox4.BackColor = Color.LightGray;
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(txtSearch);
            groupBox4.Controls.Add(dataGridViewSurat);
            groupBox4.FlatStyle = FlatStyle.System;
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(6, 72);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(851, 418);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 0);
            label9.Name = "label9";
            label9.Size = new Size(282, 31);
            label9.TabIndex = 4;
            label9.Text = "DAFTAR RIWAYAT SURAT";
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
            txtSearch.Size = new Size(638, 34);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dataGridViewSurat
            // 
            dataGridViewSurat.AllowUserToAddRows = false;
            dataGridViewSurat.AllowUserToOrderColumns = true;
            dataGridViewSurat.BackgroundColor = Color.LightGray;
            dataGridViewSurat.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewSurat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSurat.Location = new Point(15, 142);
            dataGridViewSurat.Name = "dataGridViewSurat";
            dataGridViewSurat.ReadOnly = true;
            dataGridViewSurat.RowHeadersWidth = 51;
            dataGridViewSurat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSurat.Size = new Size(814, 259);
            dataGridViewSurat.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.AllowDrop = true;
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1169, 693);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pelaporan Kematian";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1160, 684);
            tabControl2.TabIndex = 19;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(panel8);
            tabPage4.Controls.Add(panel2);
            tabPage4.Controls.Add(groupBox1);
            tabPage4.Controls.Add(btnPrint);
            tabPage4.Controls.Add(groupBox3);
            tabPage4.Controls.Add(groupBox6);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1152, 651);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Surat";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            panel8.BackColor = Color.LightGray;
            panel8.Controls.Add(label40);
            panel8.Controls.Add(btnTambahData);
            panel8.Location = new Point(888, 495);
            panel8.Name = "panel8";
            panel8.Size = new Size(258, 150);
            panel8.TabIndex = 196;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label40.Location = new Point(2, 7);
            label40.Name = "label40";
            label40.Size = new Size(253, 69);
            label40.TabIndex = 49;
            label40.Text = "Tambah data baru apabila data \r\npenduduk yang diinginkan \r\nbelum ada pada database";
            // 
            // btnTambahData
            // 
            btnTambahData.BackColor = SystemColors.ButtonFace;
            btnTambahData.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahData.Location = new Point(32, 90);
            btnTambahData.Name = "btnTambahData";
            btnTambahData.Size = new Size(196, 45);
            btnTambahData.TabIndex = 47;
            btnTambahData.Text = "Tambah Data Penduduk";
            btnTambahData.UseVisualStyleBackColor = false;
            btnTambahData.Click += btnTambahData_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(label19);
            panel2.Location = new Point(3, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(1143, 60);
            panel2.TabIndex = 38;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label19.Location = new Point(258, 8);
            label19.Name = "label19";
            label19.Size = new Size(674, 41);
            label19.TabIndex = 0;
            label19.Text = "PENGAJUAN SURAT KETERANGAN KEMATIAN";
            // 
            // groupBox1
            // 
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.BackColor = Color.LightGray;
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
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(3, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(576, 417);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "FORMULIR DATA TERLAPOR";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(18, 100);
            label12.Name = "label12";
            label12.Size = new Size(49, 20);
            label12.TabIndex = 21;
            label12.Text = "Nama";
            // 
            // textBoxNama
            // 
            textBoxNama.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNama.Font = new Font("Segoe UI", 9F);
            textBoxNama.Location = new Point(155, 97);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(303, 27);
            textBoxNama.TabIndex = 20;
            // 
            // radioButtonPR
            // 
            radioButtonPR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonPR.AutoSize = true;
            radioButtonPR.Font = new Font("Segoe UI", 9F);
            radioButtonPR.Location = new Point(273, 131);
            radioButtonPR.Name = "radioButtonPR";
            radioButtonPR.Size = new Size(104, 24);
            radioButtonPR.TabIndex = 1;
            radioButtonPR.TabStop = true;
            radioButtonPR.Text = "Perempuan";
            radioButtonPR.UseVisualStyleBackColor = true;
            // 
            // comboBoxNama
            // 
            comboBoxNama.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxNama.FormattingEnabled = true;
            comboBoxNama.Location = new Point(155, 45);
            comboBoxNama.Name = "comboBoxNama";
            comboBoxNama.Size = new Size(398, 36);
            comboBoxNama.TabIndex = 19;
            comboBoxNama.SelectedIndexChanged += comboBoxNama_SelectedIndexChanged;
            comboBoxNama.TextChanged += comboBoxNama_TextChanged;
            comboBoxNama.KeyDown += comboBoxNama_KeyDown;
            // 
            // radioButtonLK
            // 
            radioButtonLK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonLK.AutoSize = true;
            radioButtonLK.Font = new Font("Segoe UI", 9F);
            radioButtonLK.Location = new Point(157, 131);
            radioButtonLK.Name = "radioButtonLK";
            radioButtonLK.Size = new Size(85, 24);
            radioButtonLK.TabIndex = 0;
            radioButtonLK.TabStop = true;
            radioButtonLK.Text = "Laki-laki";
            radioButtonLK.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAlamat
            // 
            richTextBoxAlamat.Font = new Font("Segoe UI", 9F);
            richTextBoxAlamat.Location = new Point(155, 289);
            richTextBoxAlamat.Name = "richTextBoxAlamat";
            richTextBoxAlamat.Size = new Size(405, 101);
            richTextBoxAlamat.TabIndex = 18;
            richTextBoxAlamat.Text = "";
            // 
            // numericUpDownUmur
            // 
            numericUpDownUmur.Font = new Font("Segoe UI", 9F);
            numericUpDownUmur.Location = new Point(157, 166);
            numericUpDownUmur.Name = "numericUpDownUmur";
            numericUpDownUmur.Size = new Size(150, 27);
            numericUpDownUmur.TabIndex = 15;
            numericUpDownUmur.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelNIK
            // 
            labelNIK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNIK.AutoSize = true;
            labelNIK.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNIK.Location = new Point(18, 43);
            labelNIK.Name = "labelNIK";
            labelNIK.Size = new Size(138, 40);
            labelNIK.TabIndex = 0;
            labelNIK.Text = "Cari Data \r\n(Masukkan Nama)";
            // 
            // labelJenisKelamin
            // 
            labelJenisKelamin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelJenisKelamin.AutoSize = true;
            labelJenisKelamin.Font = new Font("Segoe UI", 9F);
            labelJenisKelamin.Location = new Point(18, 133);
            labelJenisKelamin.Name = "labelJenisKelamin";
            labelJenisKelamin.Size = new Size(98, 20);
            labelJenisKelamin.TabIndex = 2;
            labelJenisKelamin.Text = "Jenis Kelamin";
            // 
            // labelUmur
            // 
            labelUmur.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelUmur.AutoSize = true;
            labelUmur.Font = new Font("Segoe UI", 9F);
            labelUmur.Location = new Point(18, 173);
            labelUmur.Name = "labelUmur";
            labelUmur.Size = new Size(45, 20);
            labelUmur.TabIndex = 3;
            labelUmur.Text = "Umur";
            // 
            // labelWargaNegara
            // 
            labelWargaNegara.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelWargaNegara.AutoSize = true;
            labelWargaNegara.Font = new Font("Segoe UI", 9F);
            labelWargaNegara.Location = new Point(18, 211);
            labelWargaNegara.Name = "labelWargaNegara";
            labelWargaNegara.Size = new Size(98, 20);
            labelWargaNegara.TabIndex = 4;
            labelWargaNegara.Text = "Warganegara";
            // 
            // txtWarganegara
            // 
            txtWarganegara.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWarganegara.Font = new Font("Segoe UI", 9F);
            txtWarganegara.Location = new Point(155, 208);
            txtWarganegara.Name = "txtWarganegara";
            txtWarganegara.Size = new Size(303, 27);
            txtWarganegara.TabIndex = 11;
            // 
            // labelAgama
            // 
            labelAgama.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelAgama.AutoSize = true;
            labelAgama.Font = new Font("Segoe UI", 9F);
            labelAgama.Location = new Point(18, 249);
            labelAgama.Name = "labelAgama";
            labelAgama.Size = new Size(57, 20);
            labelAgama.TabIndex = 5;
            labelAgama.Text = "Agama";
            // 
            // txtAgama
            // 
            txtAgama.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAgama.Font = new Font("Segoe UI", 9F);
            txtAgama.Location = new Point(155, 249);
            txtAgama.Name = "txtAgama";
            txtAgama.Size = new Size(303, 27);
            txtAgama.TabIndex = 12;
            // 
            // labelAlamat
            // 
            labelAlamat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelAlamat.AutoEllipsis = true;
            labelAlamat.AutoSize = true;
            labelAlamat.Font = new Font("Segoe UI", 9F);
            labelAlamat.Location = new Point(18, 289);
            labelAlamat.Name = "labelAlamat";
            labelAlamat.Size = new Size(113, 20);
            labelAlamat.TabIndex = 6;
            labelAlamat.Text = "Alamat Terakhir";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.None;
            btnPrint.BackColor = Color.MediumSeaGreen;
            btnPrint.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = SystemColors.Control;
            btnPrint.Location = new Point(648, 536);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(187, 58);
            btnPrint.TabIndex = 15;
            btnPrint.Text = "CETAK PDF";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.BackColor = Color.LightGray;
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
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(587, 72);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(559, 417);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "FORMULIR DATA KEMATIAN";
            // 
            // richTextBoxLokasiKematian
            // 
            richTextBoxLokasiKematian.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxLokasiKematian.Location = new Point(150, 123);
            richTextBoxLokasiKematian.Name = "richTextBoxLokasiKematian";
            richTextBoxLokasiKematian.Size = new Size(394, 126);
            richTextBoxLokasiKematian.TabIndex = 30;
            richTextBoxLokasiKematian.Text = "";
            // 
            // labelHariTgl
            // 
            labelHariTgl.Anchor = AnchorStyles.None;
            labelHariTgl.AutoSize = true;
            labelHariTgl.Font = new Font("Segoe UI", 9F);
            labelHariTgl.Location = new Point(16, 45);
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
            dtpHariTgl.Location = new Point(150, 39);
            dtpHariTgl.Name = "dtpHariTgl";
            dtpHariTgl.Size = new Size(273, 27);
            dtpHariTgl.TabIndex = 18;
            // 
            // txtHubungan
            // 
            txtHubungan.Anchor = AnchorStyles.None;
            txtHubungan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHubungan.Location = new Point(151, 354);
            txtHubungan.Name = "txtHubungan";
            txtHubungan.Size = new Size(188, 27);
            txtHubungan.TabIndex = 27;
            // 
            // labelHubungan
            // 
            labelHubungan.Anchor = AnchorStyles.None;
            labelHubungan.AutoSize = true;
            labelHubungan.Font = new Font("Segoe UI", 9F);
            labelHubungan.Location = new Point(16, 350);
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
            cmbPenyebab.Location = new Point(150, 267);
            cmbPenyebab.Name = "cmbPenyebab";
            cmbPenyebab.Size = new Size(189, 28);
            cmbPenyebab.TabIndex = 29;
            // 
            // labelWaktu
            // 
            labelWaktu.Anchor = AnchorStyles.None;
            labelWaktu.AutoSize = true;
            labelWaktu.Font = new Font("Segoe UI", 9F);
            labelWaktu.Location = new Point(16, 83);
            labelWaktu.Name = "labelWaktu";
            labelWaktu.Size = new Size(35, 20);
            labelWaktu.TabIndex = 21;
            labelWaktu.Text = "Jam";
            // 
            // txtNamaPelapor
            // 
            txtNamaPelapor.Anchor = AnchorStyles.None;
            txtNamaPelapor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNamaPelapor.Location = new Point(150, 308);
            txtNamaPelapor.Name = "txtNamaPelapor";
            txtNamaPelapor.Size = new Size(366, 27);
            txtNamaPelapor.TabIndex = 17;
            // 
            // dtpJam
            // 
            dtpJam.Anchor = AnchorStyles.None;
            dtpJam.CustomFormat = "HH:mm WIB";
            dtpJam.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpJam.Format = DateTimePickerFormat.Custom;
            dtpJam.Location = new Point(150, 80);
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
            labelNamaPelapor.Location = new Point(16, 308);
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
            labelLokasi.Location = new Point(16, 120);
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
            labelPenyebab.Location = new Point(16, 270);
            labelPenyebab.Name = "labelPenyebab";
            labelPenyebab.Size = new Size(73, 20);
            labelPenyebab.TabIndex = 25;
            labelPenyebab.Text = "Penyebab";
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.LightGray;
            groupBox6.Controls.Add(label31);
            groupBox6.Controls.Add(txtNamaPetugas);
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(txtNamaKepalaDesa);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(txtNomorSurat);
            groupBox6.Controls.Add(label1);
            groupBox6.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox6.Location = new Point(6, 495);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(574, 150);
            groupBox6.TabIndex = 37;
            groupBox6.TabStop = false;
            groupBox6.Text = "KETERANGAN SURAT";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label31.Location = new Point(20, 115);
            label31.Name = "label31";
            label31.Size = new Size(60, 20);
            label31.TabIndex = 40;
            label31.Text = "Petugas";
            // 
            // txtNamaPetugas
            // 
            txtNamaPetugas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNamaPetugas.Location = new Point(152, 112);
            txtNamaPetugas.Name = "txtNamaPetugas";
            txtNamaPetugas.Size = new Size(407, 27);
            txtNamaPetugas.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 75);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 38;
            label6.Text = "Kepala Desa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 45);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 37;
            label5.Text = "Nomor Surat";
            // 
            // txtNamaKepalaDesa
            // 
            txtNamaKepalaDesa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNamaKepalaDesa.Location = new Point(152, 72);
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
            txtNomorSurat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomorSurat.Location = new Point(152, 38);
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
            // tabPage5
            // 
            tabPage5.Controls.Add(groupBox9);
            tabPage5.Controls.Add(panel3);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1152, 651);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "Non Surat";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox9.BackColor = Color.LightGray;
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
            groupBox9.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox9.ForeColor = SystemColors.ControlText;
            groupBox9.Location = new Point(6, 72);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(1140, 405);
            groupBox9.TabIndex = 40;
            groupBox9.TabStop = false;
            groupBox9.Text = "DATA TERLAPOR";
            // 
            // radioButtonPRNonSurat
            // 
            radioButtonPRNonSurat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonPRNonSurat.AutoSize = true;
            radioButtonPRNonSurat.Font = new Font("Segoe UI", 9F);
            radioButtonPRNonSurat.Location = new Point(273, 94);
            radioButtonPRNonSurat.Name = "radioButtonPRNonSurat";
            radioButtonPRNonSurat.Size = new Size(104, 24);
            radioButtonPRNonSurat.TabIndex = 1;
            radioButtonPRNonSurat.TabStop = true;
            radioButtonPRNonSurat.Text = "Perempuan";
            radioButtonPRNonSurat.UseVisualStyleBackColor = true;
            // 
            // comboBoxNonSurat
            // 
            comboBoxNonSurat.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxNonSurat.FormattingEnabled = true;
            comboBoxNonSurat.Location = new Point(155, 45);
            comboBoxNonSurat.Name = "comboBoxNonSurat";
            comboBoxNonSurat.Size = new Size(398, 36);
            comboBoxNonSurat.TabIndex = 43;
            comboBoxNonSurat.SelectedIndexChanged += comboBoxNonSurat_SelectedIndexChanged;
            comboBoxNonSurat.TextChanged += comboBoxNonSurat_TextChanged;
            comboBoxNonSurat.KeyDown += comboBoxNonSurat_KeyDown;
            // 
            // radioButtonLKNonSurat
            // 
            radioButtonLKNonSurat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonLKNonSurat.AutoSize = true;
            radioButtonLKNonSurat.Font = new Font("Segoe UI", 9F);
            radioButtonLKNonSurat.Location = new Point(157, 94);
            radioButtonLKNonSurat.Name = "radioButtonLKNonSurat";
            radioButtonLKNonSurat.Size = new Size(85, 24);
            radioButtonLKNonSurat.TabIndex = 0;
            radioButtonLKNonSurat.TabStop = true;
            radioButtonLKNonSurat.Text = "Laki-laki";
            radioButtonLKNonSurat.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(18, 45);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 42;
            label10.Text = "Cari Nama";
            // 
            // btnLapor
            // 
            btnLapor.Anchor = AnchorStyles.None;
            btnLapor.BackColor = Color.MediumSeaGreen;
            btnLapor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLapor.ForeColor = SystemColors.Control;
            btnLapor.Location = new Point(773, 274);
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
            label30.Location = new Point(706, 37);
            label30.Name = "label30";
            label30.Size = new Size(96, 40);
            label30.TabIndex = 20;
            label30.Text = "Hari, Tanggal\r\nKematian\r\n";
            // 
            // dtpHariTglNonSurat
            // 
            dtpHariTglNonSurat.Anchor = AnchorStyles.None;
            dtpHariTglNonSurat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpHariTglNonSurat.Location = new Point(828, 45);
            dtpHariTglNonSurat.Name = "dtpHariTglNonSurat";
            dtpHariTglNonSurat.Size = new Size(273, 27);
            dtpHariTglNonSurat.TabIndex = 19;
            // 
            // richTextBoxAlamatNonSurat
            // 
            richTextBoxAlamatNonSurat.Font = new Font("Segoe UI", 9F);
            richTextBoxAlamatNonSurat.Location = new Point(155, 254);
            richTextBoxAlamatNonSurat.Name = "richTextBoxAlamatNonSurat";
            richTextBoxAlamatNonSurat.Size = new Size(398, 86);
            richTextBoxAlamatNonSurat.TabIndex = 18;
            richTextBoxAlamatNonSurat.Text = "";
            // 
            // numericUpDownUmurNonSurat
            // 
            numericUpDownUmurNonSurat.Font = new Font("Segoe UI", 9F);
            numericUpDownUmurNonSurat.Location = new Point(157, 131);
            numericUpDownUmurNonSurat.Name = "numericUpDownUmurNonSurat";
            numericUpDownUmurNonSurat.Size = new Size(150, 27);
            numericUpDownUmurNonSurat.TabIndex = 15;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F);
            label23.Location = new Point(18, 96);
            label23.Name = "label23";
            label23.Size = new Size(98, 20);
            label23.TabIndex = 2;
            label23.Text = "Jenis Kelamin";
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F);
            label24.Location = new Point(18, 138);
            label24.Name = "label24";
            label24.Size = new Size(45, 20);
            label24.TabIndex = 3;
            label24.Text = "Umur";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F);
            label25.Location = new Point(18, 176);
            label25.Name = "label25";
            label25.Size = new Size(98, 20);
            label25.TabIndex = 4;
            label25.Text = "Warganegara";
            // 
            // txtWarganegaraNonSurat
            // 
            txtWarganegaraNonSurat.Font = new Font("Segoe UI", 9F);
            txtWarganegaraNonSurat.Location = new Point(155, 173);
            txtWarganegaraNonSurat.Name = "txtWarganegaraNonSurat";
            txtWarganegaraNonSurat.Size = new Size(226, 27);
            txtWarganegaraNonSurat.TabIndex = 11;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F);
            label26.Location = new Point(18, 214);
            label26.Name = "label26";
            label26.Size = new Size(57, 20);
            label26.TabIndex = 5;
            label26.Text = "Agama";
            // 
            // txtAgamaNonSurat
            // 
            txtAgamaNonSurat.Font = new Font("Segoe UI", 9F);
            txtAgamaNonSurat.Location = new Point(155, 214);
            txtAgamaNonSurat.Name = "txtAgamaNonSurat";
            txtAgamaNonSurat.Size = new Size(226, 27);
            txtAgamaNonSurat.TabIndex = 12;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label27.AutoEllipsis = true;
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F);
            label27.Location = new Point(18, 254);
            label27.Name = "label27";
            label27.Size = new Size(113, 20);
            label27.TabIndex = 6;
            label27.Text = "Alamat Terakhir";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Controls.Add(label20);
            panel3.Location = new Point(6, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(1140, 60);
            panel3.TabIndex = 39;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label20.Location = new Point(257, 7);
            label20.Name = "label20";
            label20.Size = new Size(671, 41);
            label20.TabIndex = 0;
            label20.Text = "LAPOR KEMATIAN NON SURAT KETERANGAN";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1177, 726);
            tabControl1.TabIndex = 33;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // FormAKM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1201, 750);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAKM";
            Text = "Pengajuan Surat Keterangan Kematian";
            FormClosing += FormAKM_FormClosing;
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
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUmur).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
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
        private ToolStripContainer toolStripContainer1;
        private TabPage tabPage2;
        private Panel panel4;
        private Label label28;
        private GroupBox groupBox5;
        private Panel panel1;
        private Label label8;
        private Label label7;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Button btnJumlahOrangMeninggal;
        private GroupBox groupBox4;
        private Label label9;
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
        private GroupBox groupBox10;
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
    }
}