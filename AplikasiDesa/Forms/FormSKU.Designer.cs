namespace AplikasiDesa.Forms
{
    partial class FormSKU
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            txtSampai = new TextBox();
            label15 = new Label();
            txtJenisUsaha = new TextBox();
            label14 = new Label();
            txtLokasiUsaha = new RichTextBox();
            label13 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel8 = new Panel();
            label40 = new Label();
            btnTambahData = new Button();
            txtSejak = new TextBox();
            label10 = new Label();
            cmbBoxCari = new ComboBox();
            label27 = new Label();
            label26 = new Label();
            txtAlamat = new RichTextBox();
            txtKades = new TextBox();
            txtPekerjaan = new TextBox();
            label11 = new Label();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            txtAgama = new TextBox();
            label9 = new Label();
            label7 = new Label();
            txtNIK = new TextBox();
            label4 = new Label();
            txtNoSurat = new TextBox();
            dtpTanggalLahir = new DateTimePicker();
            rbLK = new RadioButton();
            btnCetakPDF = new Button();
            label3 = new Label();
            txtNamaLengkap = new TextBox();
            rbPR = new RadioButton();
            label8 = new Label();
            label2 = new Label();
            txtTempatLahir = new TextBox();
            txtWarganegara = new TextBox();
            panel2 = new Panel();
            label19 = new Label();
            tabPage2 = new TabPage();
            panel6 = new Panel();
            lblPerBulanKategori = new Label();
            lblTotalTahunKategori = new Label();
            label24 = new Label();
            comboBoxTahun = new ComboBox();
            comboBoxBulan = new ComboBox();
            label39 = new Label();
            label41 = new Label();
            label42 = new Label();
            panel4 = new Panel();
            btnDelete = new Button();
            label22 = new Label();
            dataGridView1 = new DataGridView();
            label29 = new Label();
            txtNomorSurat = new TextBox();
            panel3 = new Panel();
            label12 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(7, 7);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(973, 659);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(965, 623);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📝 Formulir";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(txtSampai);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txtJenisUsaha);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtLokasiUsaha);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(iconButton1);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(txtSejak);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cmbBoxCari);
            panel1.Controls.Add(label27);
            panel1.Controls.Add(label26);
            panel1.Controls.Add(txtAlamat);
            panel1.Controls.Add(txtKades);
            panel1.Controls.Add(txtPekerjaan);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtAgama);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtNIK);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtNoSurat);
            panel1.Controls.Add(dtpTanggalLahir);
            panel1.Controls.Add(rbLK);
            panel1.Controls.Add(btnCetakPDF);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtNamaLengkap);
            panel1.Controls.Add(rbPR);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtTempatLahir);
            panel1.Controls.Add(txtWarganegara);
            panel1.ImeMode = ImeMode.Off;
            panel1.Location = new Point(15, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(936, 520);
            panel1.TabIndex = 40;
            // 
            // txtSampai
            // 
            txtSampai.Anchor = AnchorStyles.None;
            txtSampai.Location = new Point(791, 175);
            txtSampai.Name = "txtSampai";
            txtSampai.Size = new Size(118, 27);
            txtSampai.TabIndex = 204;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.None;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F);
            label15.Location = new Point(750, 174);
            label15.Name = "label15";
            label15.Size = new Size(34, 23);
            label15.TabIndex = 203;
            label15.Text = "s/d";
            // 
            // txtJenisUsaha
            // 
            txtJenisUsaha.Anchor = AnchorStyles.None;
            txtJenisUsaha.Location = new Point(624, 37);
            txtJenisUsaha.Name = "txtJenisUsaha";
            txtJenisUsaha.Size = new Size(285, 27);
            txtJenisUsaha.TabIndex = 202;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F);
            label14.Location = new Point(510, 38);
            label14.Name = "label14";
            label14.Size = new Size(98, 23);
            label14.TabIndex = 201;
            label14.Text = "Jenis Usaha";
            // 
            // txtLokasiUsaha
            // 
            txtLokasiUsaha.Anchor = AnchorStyles.None;
            txtLokasiUsaha.Location = new Point(624, 74);
            txtLokasiUsaha.Name = "txtLokasiUsaha";
            txtLokasiUsaha.Size = new Size(285, 90);
            txtLokasiUsaha.TabIndex = 200;
            txtLokasiUsaha.Text = "";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F);
            label13.Location = new Point(510, 75);
            label13.Name = "label13";
            label13.Size = new Size(108, 23);
            label13.TabIndex = 199;
            label13.Text = "Lokasi Usaha";
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton1.BackColor = Color.WhiteSmoke;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(881, 465);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(55, 55);
            iconButton1.TabIndex = 198;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.BackColor = SystemColors.ButtonFace;
            panel8.Controls.Add(label40);
            panel8.Controls.Add(btnTambahData);
            panel8.Location = new Point(669, 385);
            panel8.Name = "panel8";
            panel8.Size = new Size(267, 135);
            panel8.TabIndex = 197;
            panel8.Visible = false;
            // 
            // label40
            // 
            label40.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label40.AutoSize = true;
            label40.BackColor = SystemColors.Control;
            label40.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label40.Location = new Point(5, 4);
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
            btnTambahData.Location = new Point(10, 80);
            btnTambahData.Name = "btnTambahData";
            btnTambahData.Size = new Size(196, 45);
            btnTambahData.TabIndex = 47;
            btnTambahData.Text = "Tambah Data Penduduk";
            btnTambahData.UseVisualStyleBackColor = false;
            btnTambahData.Click += btnTambahData_Click;
            // 
            // txtSejak
            // 
            txtSejak.Anchor = AnchorStyles.None;
            txtSejak.Location = new Point(624, 175);
            txtSejak.Name = "txtSejak";
            txtSejak.Size = new Size(118, 27);
            txtSejak.TabIndex = 31;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F);
            label10.Location = new Point(510, 176);
            label10.Name = "label10";
            label10.Size = new Size(100, 23);
            label10.TabIndex = 30;
            label10.Text = "Sejak Tahun";
            // 
            // cmbBoxCari
            // 
            cmbBoxCari.Anchor = AnchorStyles.None;
            cmbBoxCari.FormattingEnabled = true;
            cmbBoxCari.Location = new Point(153, 37);
            cmbBoxCari.Name = "cmbBoxCari";
            cmbBoxCari.Size = new Size(273, 28);
            cmbBoxCari.TabIndex = 29;
            cmbBoxCari.SelectedIndexChanged += cmbBoxCari_SelectedIndexChanged;
            cmbBoxCari.TextChanged += cmbBoxCari_TextChanged;
            cmbBoxCari.KeyDown += cmbBoxCari_KeyDown;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.None;
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 10.2F);
            label27.Location = new Point(19, 142);
            label27.Name = "label27";
            label27.Size = new Size(112, 23);
            label27.TabIndex = 28;
            label27.Text = "Jenis Kelamin";
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.None;
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.Location = new Point(19, 31);
            label26.Name = "label26";
            label26.Size = new Size(134, 40);
            label26.TabIndex = 27;
            label26.Text = "Cari Data\r\n(Masukkan Nama)";
            // 
            // txtAlamat
            // 
            txtAlamat.Anchor = AnchorStyles.None;
            txtAlamat.Location = new Point(153, 372);
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(273, 90);
            txtAlamat.TabIndex = 15;
            txtAlamat.Text = "";
            // 
            // txtKades
            // 
            txtKades.Anchor = AnchorStyles.None;
            txtKades.Location = new Point(624, 265);
            txtKades.Name = "txtKades";
            txtKades.Size = new Size(285, 27);
            txtKades.TabIndex = 26;
            // 
            // txtPekerjaan
            // 
            txtPekerjaan.Anchor = AnchorStyles.None;
            txtPekerjaan.Location = new Point(153, 332);
            txtPekerjaan.Name = "txtPekerjaan";
            txtPekerjaan.Size = new Size(273, 27);
            txtPekerjaan.TabIndex = 11;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F);
            label11.Location = new Point(478, 266);
            label11.Name = "label11";
            label11.Size = new Size(135, 23);
            label11.TabIndex = 25;
            label11.Text = "a.n. Kepala Desa";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(19, 294);
            label5.Name = "label5";
            label5.Size = new Size(64, 23);
            label5.TabIndex = 10;
            label5.Text = "Agama";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(19, 335);
            label6.Name = "label6";
            label6.Size = new Size(83, 23);
            label6.TabIndex = 12;
            label6.Text = "Pekerjaan";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(19, 78);
            label1.Name = "label1";
            label1.Size = new Size(38, 23);
            label1.TabIndex = 4;
            label1.Text = "NIK";
            // 
            // txtAgama
            // 
            txtAgama.Anchor = AnchorStyles.None;
            txtAgama.Location = new Point(153, 290);
            txtAgama.Name = "txtAgama";
            txtAgama.Size = new Size(273, 27);
            txtAgama.TabIndex = 9;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(510, 233);
            label9.Name = "label9";
            label9.Size = new Size(82, 23);
            label9.TabIndex = 22;
            label9.Text = "No. Surat";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(19, 375);
            label7.Name = "label7";
            label7.Size = new Size(64, 23);
            label7.TabIndex = 14;
            label7.Text = "Alamat";
            // 
            // txtNIK
            // 
            txtNIK.Anchor = AnchorStyles.None;
            txtNIK.Location = new Point(153, 74);
            txtNIK.Name = "txtNIK";
            txtNIK.Size = new Size(273, 27);
            txtNIK.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(15, 252);
            label4.Name = "label4";
            label4.Size = new Size(107, 23);
            label4.TabIndex = 8;
            label4.Text = "Tanggal lahir";
            // 
            // txtNoSurat
            // 
            txtNoSurat.Anchor = AnchorStyles.None;
            txtNoSurat.Location = new Point(624, 232);
            txtNoSurat.Name = "txtNoSurat";
            txtNoSurat.Size = new Size(285, 27);
            txtNoSurat.TabIndex = 21;
            // 
            // dtpTanggalLahir
            // 
            dtpTanggalLahir.Anchor = AnchorStyles.None;
            dtpTanggalLahir.Location = new Point(153, 251);
            dtpTanggalLahir.Name = "dtpTanggalLahir";
            dtpTanggalLahir.Size = new Size(273, 27);
            dtpTanggalLahir.TabIndex = 7;
            // 
            // rbLK
            // 
            rbLK.Anchor = AnchorStyles.None;
            rbLK.AutoSize = true;
            rbLK.Location = new Point(158, 142);
            rbLK.Name = "rbLK";
            rbLK.Size = new Size(85, 24);
            rbLK.TabIndex = 16;
            rbLK.TabStop = true;
            rbLK.Text = "Laki-laki";
            rbLK.UseVisualStyleBackColor = true;
            // 
            // btnCetakPDF
            // 
            btnCetakPDF.Anchor = AnchorStyles.None;
            btnCetakPDF.BackColor = Color.FromArgb(72, 126, 176);
            btnCetakPDF.FlatStyle = FlatStyle.Flat;
            btnCetakPDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCetakPDF.ForeColor = Color.White;
            btnCetakPDF.Location = new Point(624, 312);
            btnCetakPDF.Name = "btnCetakPDF";
            btnCetakPDF.Size = new Size(158, 65);
            btnCetakPDF.TabIndex = 20;
            btnCetakPDF.Text = "CETAK PDF";
            btnCetakPDF.UseVisualStyleBackColor = false;
            btnCetakPDF.Click += btnCetakPDF_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(17, 215);
            label3.Name = "label3";
            label3.Size = new Size(104, 23);
            label3.TabIndex = 6;
            label3.Text = "Tempat lahir";
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.Anchor = AnchorStyles.None;
            txtNamaLengkap.Location = new Point(153, 107);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(273, 27);
            txtNamaLengkap.TabIndex = 2;
            // 
            // rbPR
            // 
            rbPR.Anchor = AnchorStyles.None;
            rbPR.AutoSize = true;
            rbPR.Location = new Point(279, 142);
            rbPR.Name = "rbPR";
            rbPR.Size = new Size(104, 24);
            rbPR.TabIndex = 17;
            rbPR.TabStop = true;
            rbPR.Text = "Perempuan";
            rbPR.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(17, 178);
            label8.Name = "label8";
            label8.Size = new Size(112, 23);
            label8.TabIndex = 19;
            label8.Text = "Warganegara";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(19, 107);
            label2.Name = "label2";
            label2.Size = new Size(56, 23);
            label2.TabIndex = 5;
            label2.Text = "Nama";
            // 
            // txtTempatLahir
            // 
            txtTempatLahir.Anchor = AnchorStyles.None;
            txtTempatLahir.Location = new Point(153, 212);
            txtTempatLahir.Name = "txtTempatLahir";
            txtTempatLahir.Size = new Size(273, 27);
            txtTempatLahir.TabIndex = 3;
            // 
            // txtWarganegara
            // 
            txtWarganegara.Anchor = AnchorStyles.None;
            txtWarganegara.Location = new Point(153, 175);
            txtWarganegara.Name = "txtWarganegara";
            txtWarganegara.Size = new Size(273, 27);
            txtWarganegara.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(191, 223, 210);
            panel2.Controls.Add(label19);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(959, 71);
            panel2.TabIndex = 39;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(185, 13);
            label19.Name = "label19";
            label19.Size = new Size(597, 41);
            label19.TabIndex = 0;
            label19.Text = "FORMULIR SURAT KETERANGAN USAHA";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(965, 623);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "📜 Riwayat";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(lblPerBulanKategori);
            panel6.Controls.Add(lblTotalTahunKategori);
            panel6.Controls.Add(label24);
            panel6.Controls.Add(comboBoxTahun);
            panel6.Controls.Add(comboBoxBulan);
            panel6.Controls.Add(label39);
            panel6.Controls.Add(label41);
            panel6.Controls.Add(label42);
            panel6.Location = new Point(16, 452);
            panel6.Name = "panel6";
            panel6.Size = new Size(935, 159);
            panel6.TabIndex = 133;
            // 
            // lblPerBulanKategori
            // 
            lblPerBulanKategori.Anchor = AnchorStyles.None;
            lblPerBulanKategori.AutoSize = true;
            lblPerBulanKategori.Font = new Font("Segoe UI", 10.2F);
            lblPerBulanKategori.Location = new Point(349, 83);
            lblPerBulanKategori.Name = "lblPerBulanKategori";
            lblPerBulanKategori.Size = new Size(435, 23);
            lblPerBulanKategori.TabIndex = 26;
            lblPerBulanKategori.Text = "Jumlah pengajuan Surat Keterangan Usaha [Pilih Bulan]";
            // 
            // lblTotalTahunKategori
            // 
            lblTotalTahunKategori.Anchor = AnchorStyles.None;
            lblTotalTahunKategori.AutoSize = true;
            lblTotalTahunKategori.Font = new Font("Segoe UI", 10.2F);
            lblTotalTahunKategori.Location = new Point(349, 117);
            lblTotalTahunKategori.Name = "lblTotalTahunKategori";
            lblTotalTahunKategori.Size = new Size(438, 23);
            lblTotalTahunKategori.TabIndex = 27;
            lblTotalTahunKategori.Text = "Jumlah pengajuan Surat Keterangan Usaha [Pilih Tahun]";
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.None;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(20, 43);
            label24.Name = "label24";
            label24.Size = new Size(104, 28);
            label24.TabIndex = 23;
            label24.Text = "Filter Data";
            // 
            // comboBoxTahun
            // 
            comboBoxTahun.Anchor = AnchorStyles.None;
            comboBoxTahun.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTahun.FormattingEnabled = true;
            comboBoxTahun.Items.AddRange(new object[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030" });
            comboBoxTahun.Location = new Point(132, 117);
            comboBoxTahun.Name = "comboBoxTahun";
            comboBoxTahun.Size = new Size(174, 28);
            comboBoxTahun.TabIndex = 22;
            comboBoxTahun.SelectedIndexChanged += comboBoxTahun_SelectedIndexChanged;
            // 
            // comboBoxBulan
            // 
            comboBoxBulan.Anchor = AnchorStyles.None;
            comboBoxBulan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBulan.FormattingEnabled = true;
            comboBoxBulan.Items.AddRange(new object[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" });
            comboBoxBulan.Location = new Point(132, 82);
            comboBoxBulan.Name = "comboBoxBulan";
            comboBoxBulan.Size = new Size(174, 28);
            comboBoxBulan.TabIndex = 18;
            comboBoxBulan.SelectedIndexChanged += comboBoxBulan_SelectedIndexChanged;
            // 
            // label39
            // 
            label39.Anchor = AnchorStyles.None;
            label39.AutoSize = true;
            label39.Font = new Font("Segoe UI", 10.2F);
            label39.Location = new Point(27, 117);
            label39.Name = "label39";
            label39.Size = new Size(56, 23);
            label39.TabIndex = 21;
            label39.Text = "Tahun";
            // 
            // label41
            // 
            label41.Anchor = AnchorStyles.None;
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 10.2F);
            label41.Location = new Point(27, 83);
            label41.Name = "label41";
            label41.Size = new Size(53, 23);
            label41.TabIndex = 20;
            label41.Text = "Bulan";
            // 
            // label42
            // 
            label42.Anchor = AnchorStyles.Top;
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label42.Location = new Point(246, 9);
            label42.Name = "label42";
            label42.Size = new Size(437, 30);
            label42.TabIndex = 6;
            label42.Text = "Jumlah Pengajuan Surat Keterangan Usaha";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(label22);
            panel4.Controls.Add(dataGridView1);
            panel4.Controls.Add(label29);
            panel4.Controls.Add(txtNomorSurat);
            panel4.Location = new Point(16, 79);
            panel4.Name = "panel4";
            panel4.Size = new Size(935, 359);
            panel4.TabIndex = 132;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.FromArgb(198, 67, 72);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(27, 311);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 36);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Hapus Riwayat";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.Location = new Point(127, 25);
            label22.Name = "label22";
            label22.Size = new Size(427, 20);
            label22.TabIndex = 18;
            label22.Text = "Masukkan Nama / Nomor Surat / Tanggal Surat (YYYY-MM-DD)";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(218, 237, 228);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(191, 223, 210);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(85, 130, 110);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(242, 248, 245);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(125, 171, 150);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(85, 130, 110);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(191, 223, 210);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(85, 130, 110);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(191, 223, 210);
            dataGridView1.Location = new Point(28, 88);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(884, 216);
            dataGridView1.TabIndex = 3;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = Color.Transparent;
            label29.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(22, 18);
            label29.Name = "label29";
            label29.Size = new Size(99, 28);
            label29.TabIndex = 17;
            label29.Text = "Cari Surat";
            // 
            // txtNomorSurat
            // 
            txtNomorSurat.Location = new Point(28, 50);
            txtNomorSurat.Margin = new Padding(4);
            txtNomorSurat.Name = "txtNomorSurat";
            txtNomorSurat.PlaceholderText = "🔎";
            txtNomorSurat.Size = new Size(526, 27);
            txtNomorSurat.TabIndex = 4;
            txtNomorSurat.TextChanged += txtNomorSurat_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(191, 223, 210);
            panel3.Controls.Add(label12);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(959, 63);
            panel3.TabIndex = 40;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(199, 9);
            label12.Name = "label12";
            label12.Size = new Size(573, 41);
            label12.TabIndex = 0;
            label12.Text = "RIWAYAT SURAT KETERANGAN USAHA";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormSKU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 673);
            Controls.Add(tabControl1);
            Name = "FormSKU";
            Padding = new Padding(7);
            Text = "Pengajuan Surat Keterangan Usaha";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel2;
        private Label label19;
        private Panel panel1;
        private Panel panel8;
        private Label label40;
        private Button btnTambahData;
        private ComboBox cmbBoxCari;
        private Label label27;
        private Label label26;
        private RichTextBox txtAlamat;
        private TextBox txtKades;
        private TextBox txtPekerjaan;
        private Label label11;
        private Label label5;
        private Label label6;
        private Label label1;
        private TextBox txtAgama;
        private Label label9;
        private Label label7;
        private TextBox txtNIK;
        private Label label4;
        private TextBox txtNoSurat;
        private DateTimePicker dtpTanggalLahir;
        private RadioButton rbLK;
        private Button btnCetakPDF;
        private Label label3;
        private TextBox txtNamaLengkap;
        private RadioButton rbPR;
        private Label label8;
        private Label label2;
        private TextBox txtTempatLahir;
        private TextBox txtWarganegara;
        private TextBox txtSejak;
        private Label label10;
        private Panel panel3;
        private Label label12;
        private Panel panel6;
        private Label lblPerBulanKategori;
        private Label lblTotalTahunKategori;
        private Label label24;
        private ComboBox comboBoxTahun;
        private ComboBox comboBoxBulan;
        private Label label39;
        private Label label41;
        private Label label42;
        private Panel panel4;
        private Button btnDelete;
        private Label label22;
        private DataGridView dataGridView1;
        private Label label29;
        private TextBox txtNomorSurat;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TextBox txtJenisUsaha;
        private Label label14;
        private RichTextBox txtLokasiUsaha;
        private Label label13;
        private TextBox txtSampai;
        private Label label15;
    }
}