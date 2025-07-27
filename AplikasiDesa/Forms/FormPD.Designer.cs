namespace AplikasiDesa
{
    partial class FormPD
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
            comboBoxNomorKK = new ComboBox();
            textBoxNamaKepalaKeluarga = new TextBox();
            comboBoxAlasanPindah = new ComboBox();
            comboBoxKlasifikasiPindah = new ComboBox();
            comboBoxJenisKepindahan = new ComboBox();
            comboBoxStatusYangPindah = new ComboBox();
            dateTimePickerTanggalPindah = new DateTimePicker();
            checkedListBoxAnggotaKeluarga = new CheckedListBox();
            btnExportToExcel = new Button();
            textBoxAlamat = new RichTextBox();
            textBoxRT = new TextBox();
            textBoxRW = new TextBox();
            KEPINDAHAN = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            textRWBaru = new TextBox();
            textRTBaru = new TextBox();
            richAlamatBaru = new RichTextBox();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            kodepos = new Label();
            comboBoxDesa = new ComboBox();
            comboBoxKecamatan = new ComboBox();
            comboBoxKota = new ComboBox();
            comboBoxProv = new ComboBox();
            comboBoxKodePos = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel2 = new Panel();
            panel1 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel8 = new Panel();
            label40 = new Label();
            btnTambahData = new Button();
            label23 = new Label();
            txtPetugas = new TextBox();
            label21 = new Label();
            txtNoSurat = new TextBox();
            label20 = new Label();
            txtNoKK = new TextBox();
            label19 = new Label();
            comboBoxStatusKK = new ComboBox();
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
            panel3 = new Panel();
            lblRiwayat = new Label();
            panel4 = new Panel();
            btnDelete = new Button();
            label22 = new Label();
            dataGridView1 = new DataGridView();
            label29 = new Label();
            txtNomorSurat = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxNomorKK
            // 
            comboBoxNomorKK.Anchor = AnchorStyles.None;
            comboBoxNomorKK.FormattingEnabled = true;
            comboBoxNomorKK.Location = new Point(147, 51);
            comboBoxNomorKK.Margin = new Padding(4);
            comboBoxNomorKK.Name = "comboBoxNomorKK";
            comboBoxNomorKK.Size = new Size(247, 28);
            comboBoxNomorKK.TabIndex = 0;
            comboBoxNomorKK.SelectedIndexChanged += comboBoxNomorKK_SelectedIndexChanged;
            comboBoxNomorKK.TextChanged += comboBoxNomorKK_TextChanged;
            comboBoxNomorKK.KeyDown += comboBoxNomorKK_KeyDown;
            // 
            // textBoxNamaKepalaKeluarga
            // 
            textBoxNamaKepalaKeluarga.Anchor = AnchorStyles.None;
            textBoxNamaKepalaKeluarga.Location = new Point(147, 91);
            textBoxNamaKepalaKeluarga.Margin = new Padding(4);
            textBoxNamaKepalaKeluarga.Name = "textBoxNamaKepalaKeluarga";
            textBoxNamaKepalaKeluarga.Size = new Size(247, 27);
            textBoxNamaKepalaKeluarga.TabIndex = 1;
            // 
            // comboBoxAlasanPindah
            // 
            comboBoxAlasanPindah.Anchor = AnchorStyles.None;
            comboBoxAlasanPindah.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlasanPindah.FormattingEnabled = true;
            comboBoxAlasanPindah.Items.AddRange(new object[] { "Pekerjaan", "Pendidikan", "Keamanan", "Kesehatan", "Perumahan", "Keluarga" });
            comboBoxAlasanPindah.Location = new Point(158, 380);
            comboBoxAlasanPindah.Margin = new Padding(4);
            comboBoxAlasanPindah.Name = "comboBoxAlasanPindah";
            comboBoxAlasanPindah.Size = new Size(458, 28);
            comboBoxAlasanPindah.TabIndex = 2;
            // 
            // comboBoxKlasifikasiPindah
            // 
            comboBoxKlasifikasiPindah.Anchor = AnchorStyles.None;
            comboBoxKlasifikasiPindah.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKlasifikasiPindah.FormattingEnabled = true;
            comboBoxKlasifikasiPindah.Items.AddRange(new object[] { "Dalam satu Desa/Kelurahan", "Antar Desa/Kelurahan", "Antar Kecamatan", "Antar Kab/Kota", "Antar Provinsi" });
            comboBoxKlasifikasiPindah.Location = new Point(158, 421);
            comboBoxKlasifikasiPindah.Margin = new Padding(4);
            comboBoxKlasifikasiPindah.Name = "comboBoxKlasifikasiPindah";
            comboBoxKlasifikasiPindah.Size = new Size(458, 28);
            comboBoxKlasifikasiPindah.TabIndex = 3;
            // 
            // comboBoxJenisKepindahan
            // 
            comboBoxJenisKepindahan.Anchor = AnchorStyles.None;
            comboBoxJenisKepindahan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJenisKepindahan.FormattingEnabled = true;
            comboBoxJenisKepindahan.Items.AddRange(new object[] { "Kep. Keluarga", "Kep. Keluarga & Seluruh Angg. Keluarga", "Kep. Keluarga & Sbg. Angg. Keluarga", "Angg. Keluarga" });
            comboBoxJenisKepindahan.Location = new Point(158, 463);
            comboBoxJenisKepindahan.Margin = new Padding(4);
            comboBoxJenisKepindahan.Name = "comboBoxJenisKepindahan";
            comboBoxJenisKepindahan.Size = new Size(458, 28);
            comboBoxJenisKepindahan.TabIndex = 4;
            // 
            // comboBoxStatusYangPindah
            // 
            comboBoxStatusYangPindah.Anchor = AnchorStyles.None;
            comboBoxStatusYangPindah.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusYangPindah.FormattingEnabled = true;
            comboBoxStatusYangPindah.Items.AddRange(new object[] { "Numpang KK", "Membuat KK Baru", "Nama Kep. Keluarga dan Nomor Keluarga Tetap" });
            comboBoxStatusYangPindah.Location = new Point(158, 546);
            comboBoxStatusYangPindah.Margin = new Padding(4);
            comboBoxStatusYangPindah.Name = "comboBoxStatusYangPindah";
            comboBoxStatusYangPindah.Size = new Size(458, 28);
            comboBoxStatusYangPindah.TabIndex = 6;
            // 
            // dateTimePickerTanggalPindah
            // 
            dateTimePickerTanggalPindah.Anchor = AnchorStyles.None;
            dateTimePickerTanggalPindah.Location = new Point(158, 587);
            dateTimePickerTanggalPindah.Margin = new Padding(4);
            dateTimePickerTanggalPindah.Name = "dateTimePickerTanggalPindah";
            dateTimePickerTanggalPindah.Size = new Size(236, 27);
            dateTimePickerTanggalPindah.TabIndex = 7;
            // 
            // checkedListBoxAnggotaKeluarga
            // 
            checkedListBoxAnggotaKeluarga.Anchor = AnchorStyles.None;
            checkedListBoxAnggotaKeluarga.FormattingEnabled = true;
            checkedListBoxAnggotaKeluarga.HorizontalScrollbar = true;
            checkedListBoxAnggotaKeluarga.Location = new Point(422, 51);
            checkedListBoxAnggotaKeluarga.Margin = new Padding(4);
            checkedListBoxAnggotaKeluarga.Name = "checkedListBoxAnggotaKeluarga";
            checkedListBoxAnggotaKeluarga.Size = new Size(486, 136);
            checkedListBoxAnggotaKeluarga.TabIndex = 8;
            // 
            // btnExportToExcel
            // 
            btnExportToExcel.Anchor = AnchorStyles.None;
            btnExportToExcel.BackColor = Color.FromArgb(72, 126, 176);
            btnExportToExcel.FlatStyle = FlatStyle.Flat;
            btnExportToExcel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportToExcel.ForeColor = Color.White;
            btnExportToExcel.Location = new Point(681, 627);
            btnExportToExcel.Margin = new Padding(4);
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(161, 54);
            btnExportToExcel.TabIndex = 9;
            btnExportToExcel.Text = "CETAK EXCEL";
            btnExportToExcel.UseVisualStyleBackColor = false;
            btnExportToExcel.Click += btnExportToExcel_Click;
            // 
            // textBoxAlamat
            // 
            textBoxAlamat.Anchor = AnchorStyles.None;
            textBoxAlamat.Location = new Point(158, 221);
            textBoxAlamat.Margin = new Padding(2);
            textBoxAlamat.Name = "textBoxAlamat";
            textBoxAlamat.Size = new Size(202, 116);
            textBoxAlamat.TabIndex = 10;
            textBoxAlamat.Text = "";
            // 
            // textBoxRT
            // 
            textBoxRT.Anchor = AnchorStyles.None;
            textBoxRT.Location = new Point(158, 346);
            textBoxRT.Margin = new Padding(2);
            textBoxRT.Name = "textBoxRT";
            textBoxRT.Size = new Size(74, 27);
            textBoxRT.TabIndex = 11;
            // 
            // textBoxRW
            // 
            textBoxRW.Anchor = AnchorStyles.None;
            textBoxRW.Location = new Point(286, 345);
            textBoxRW.Margin = new Padding(2);
            textBoxRW.Name = "textBoxRW";
            textBoxRW.Size = new Size(74, 27);
            textBoxRW.TabIndex = 12;
            // 
            // KEPINDAHAN
            // 
            KEPINDAHAN.Anchor = AnchorStyles.None;
            KEPINDAHAN.AutoSize = true;
            KEPINDAHAN.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            KEPINDAHAN.ForeColor = Color.White;
            KEPINDAHAN.Location = new Point(314, 9);
            KEPINDAHAN.Margin = new Padding(2, 0, 2, 0);
            KEPINDAHAN.Name = "KEPINDAHAN";
            KEPINDAHAN.Size = new Size(483, 41);
            KEPINDAHAN.TabIndex = 13;
            KEPINDAHAN.Text = "FORMULIR SURAT KEPINDAHAN";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(53, 43);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 40);
            label1.TabIndex = 14;
            label1.Text = "Cari Kepala\r\nKeluarga";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(23, 94);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 15;
            label2.Text = "Kepala Keluarga";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(158, 200);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 16;
            label3.Text = "Alamat Lama";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(129, 350);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(25, 20);
            label4.TabIndex = 17;
            label4.Text = "RT";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(251, 348);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 18;
            label5.Text = "RW";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(52, 381);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 19;
            label6.Text = "Alasan Pindah";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(81, 415);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(74, 40);
            label7.TabIndex = 20;
            label7.Text = "Klasifikasi\r\nPindah";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(34, 465);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(123, 20);
            label8.TabIndex = 21;
            label8.Text = "Jenis Kepindahan";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Location = new Point(34, 548);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(120, 20);
            label9.TabIndex = 22;
            label9.Text = "Status KK Pindah";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Location = new Point(81, 508);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 23;
            label10.Text = "Status KK";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Location = new Point(42, 591);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(110, 20);
            label11.TabIndex = 24;
            label11.Text = "Tanggal Pindah";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Location = new Point(508, 348);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(32, 20);
            label12.TabIndex = 30;
            label12.Text = "RW";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.Location = new Point(386, 350);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(25, 20);
            label13.TabIndex = 29;
            label13.Text = "RT";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.Location = new Point(414, 200);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(91, 20);
            label14.TabIndex = 28;
            label14.Text = "Alamat Baru";
            // 
            // textRWBaru
            // 
            textRWBaru.Anchor = AnchorStyles.None;
            textRWBaru.Location = new Point(542, 345);
            textRWBaru.Margin = new Padding(2);
            textRWBaru.Name = "textRWBaru";
            textRWBaru.Size = new Size(74, 27);
            textRWBaru.TabIndex = 27;
            // 
            // textRTBaru
            // 
            textRTBaru.Anchor = AnchorStyles.None;
            textRTBaru.Location = new Point(414, 346);
            textRTBaru.Margin = new Padding(2);
            textRTBaru.Name = "textRTBaru";
            textRTBaru.Size = new Size(74, 27);
            textRTBaru.TabIndex = 26;
            // 
            // richAlamatBaru
            // 
            richAlamatBaru.Anchor = AnchorStyles.None;
            richAlamatBaru.Location = new Point(414, 221);
            richAlamatBaru.Margin = new Padding(2);
            richAlamatBaru.Name = "richAlamatBaru";
            richAlamatBaru.Size = new Size(202, 116);
            richAlamatBaru.TabIndex = 25;
            richAlamatBaru.Text = "";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.None;
            label15.AutoSize = true;
            label15.Location = new Point(681, 412);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(114, 20);
            label15.TabIndex = 35;
            label15.Text = "Desa/Kelurahan";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.None;
            label16.AutoSize = true;
            label16.Location = new Point(681, 350);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(83, 20);
            label16.TabIndex = 36;
            label16.Text = "Kecamatan";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.None;
            label17.AutoSize = true;
            label17.Location = new Point(681, 285);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(72, 20);
            label17.TabIndex = 37;
            label17.Text = "Kab/Kota";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.None;
            label18.AutoSize = true;
            label18.Location = new Point(681, 221);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(60, 20);
            label18.TabIndex = 38;
            label18.Text = "Provinsi";
            // 
            // kodepos
            // 
            kodepos.Anchor = AnchorStyles.None;
            kodepos.AutoSize = true;
            kodepos.Location = new Point(681, 478);
            kodepos.Margin = new Padding(2, 0, 2, 0);
            kodepos.Name = "kodepos";
            kodepos.Size = new Size(70, 20);
            kodepos.TabIndex = 40;
            kodepos.Text = "Kode Pos";
            // 
            // comboBoxDesa
            // 
            comboBoxDesa.Anchor = AnchorStyles.None;
            comboBoxDesa.Enabled = false;
            comboBoxDesa.FormattingEnabled = true;
            comboBoxDesa.Location = new Point(681, 435);
            comboBoxDesa.Name = "comboBoxDesa";
            comboBoxDesa.Size = new Size(341, 28);
            comboBoxDesa.TabIndex = 41;
            comboBoxDesa.SelectedIndexChanged += comboBoxDesa_SelectedIndexChanged;
            // 
            // comboBoxKecamatan
            // 
            comboBoxKecamatan.Anchor = AnchorStyles.None;
            comboBoxKecamatan.Enabled = false;
            comboBoxKecamatan.FormattingEnabled = true;
            comboBoxKecamatan.Location = new Point(681, 373);
            comboBoxKecamatan.Name = "comboBoxKecamatan";
            comboBoxKecamatan.Size = new Size(341, 28);
            comboBoxKecamatan.TabIndex = 42;
            comboBoxKecamatan.SelectedIndexChanged += comboBoxKecamatan_SelectedIndexChanged;
            // 
            // comboBoxKota
            // 
            comboBoxKota.Anchor = AnchorStyles.None;
            comboBoxKota.Enabled = false;
            comboBoxKota.FormattingEnabled = true;
            comboBoxKota.Location = new Point(681, 308);
            comboBoxKota.Name = "comboBoxKota";
            comboBoxKota.Size = new Size(341, 28);
            comboBoxKota.TabIndex = 43;
            comboBoxKota.SelectedIndexChanged += comboBoxKota_SelectedIndexChanged;
            // 
            // comboBoxProv
            // 
            comboBoxProv.Anchor = AnchorStyles.None;
            comboBoxProv.FormattingEnabled = true;
            comboBoxProv.Location = new Point(681, 244);
            comboBoxProv.Name = "comboBoxProv";
            comboBoxProv.Size = new Size(341, 28);
            comboBoxProv.TabIndex = 44;
            comboBoxProv.SelectedIndexChanged += comboBoxProv_SelectedIndexChanged;
            // 
            // comboBoxKodePos
            // 
            comboBoxKodePos.Anchor = AnchorStyles.None;
            comboBoxKodePos.Enabled = false;
            comboBoxKodePos.FormattingEnabled = true;
            comboBoxKodePos.Location = new Point(681, 501);
            comboBoxKodePos.Name = "comboBoxKodePos";
            comboBoxKodePos.Size = new Size(151, 28);
            comboBoxKodePos.TabIndex = 45;
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
            tabControl1.Size = new Size(1103, 811);
            tabControl1.TabIndex = 46;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1095, 775);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📝 Formulir";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(75, 80, 105);
            panel2.Controls.Add(KEPINDAHAN);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1089, 60);
            panel2.TabIndex = 46;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(iconButton1);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(label23);
            panel1.Controls.Add(txtPetugas);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(txtNoSurat);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(txtNoKK);
            panel1.Controls.Add(comboBoxKodePos);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(dateTimePickerTanggalPindah);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBoxNamaKepalaKeluarga);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBoxAlasanPindah);
            panel1.Controls.Add(comboBoxNomorKK);
            panel1.Controls.Add(kodepos);
            panel1.Controls.Add(checkedListBoxAnggotaKeluarga);
            panel1.Controls.Add(textRWBaru);
            panel1.Controls.Add(textBoxAlamat);
            panel1.Controls.Add(textBoxRT);
            panel1.Controls.Add(textBoxRW);
            panel1.Controls.Add(textRTBaru);
            panel1.Controls.Add(richAlamatBaru);
            panel1.Controls.Add(comboBoxDesa);
            panel1.Controls.Add(comboBoxKecamatan);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(btnExportToExcel);
            panel1.Controls.Add(comboBoxStatusYangPindah);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(comboBoxStatusKK);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(comboBoxProv);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(comboBoxKlasifikasiPindah);
            panel1.Controls.Add(comboBoxKota);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(comboBoxJenisKepindahan);
            panel1.Controls.Add(label13);
            panel1.Location = new Point(6, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(1083, 697);
            panel1.TabIndex = 47;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton1.BackColor = Color.WhiteSmoke;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(1028, 642);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(55, 55);
            iconButton1.TabIndex = 200;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.Control;
            panel8.Controls.Add(label40);
            panel8.Controls.Add(btnTambahData);
            panel8.Location = new Point(823, 573);
            panel8.Name = "panel8";
            panel8.Size = new Size(260, 124);
            panel8.TabIndex = 197;
            panel8.Visible = false;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label40.Location = new Point(4, 5);
            label40.Name = "label40";
            label40.Size = new Size(221, 60);
            label40.TabIndex = 49;
            label40.Text = "Tambah data baru apabila data \r\npenduduk yang diinginkan \r\nbelum ada pada database";
            // 
            // btnTambahData
            // 
            btnTambahData.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTambahData.BackColor = SystemColors.ActiveCaption;
            btnTambahData.FlatStyle = FlatStyle.Flat;
            btnTambahData.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahData.Location = new Point(7, 69);
            btnTambahData.Name = "btnTambahData";
            btnTambahData.Size = new Size(194, 43);
            btnTambahData.TabIndex = 47;
            btnTambahData.Text = "Tambah Data Penduduk";
            btnTambahData.UseVisualStyleBackColor = false;
            btnTambahData.Click += btnTambahData_Click;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.None;
            label23.AutoSize = true;
            label23.Location = new Point(422, 27);
            label23.Margin = new Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new Size(240, 20);
            label23.TabIndex = 50;
            label23.Text = "Piih anggota keluarga yang pindah";
            // 
            // txtPetugas
            // 
            txtPetugas.Anchor = AnchorStyles.None;
            txtPetugas.Location = new Point(757, 583);
            txtPetugas.Margin = new Padding(4);
            txtPetugas.Name = "txtPetugas";
            txtPetugas.Size = new Size(265, 27);
            txtPetugas.TabIndex = 48;
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.None;
            label21.AutoSize = true;
            label21.Location = new Point(681, 586);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(60, 20);
            label21.TabIndex = 49;
            label21.Text = "Petugas";
            // 
            // txtNoSurat
            // 
            txtNoSurat.Anchor = AnchorStyles.None;
            txtNoSurat.Location = new Point(757, 548);
            txtNoSurat.Margin = new Padding(4);
            txtNoSurat.Name = "txtNoSurat";
            txtNoSurat.Size = new Size(265, 27);
            txtNoSurat.TabIndex = 46;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.None;
            label20.AutoSize = true;
            label20.Location = new Point(681, 551);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(70, 20);
            label20.TabIndex = 47;
            label20.Text = "No. Surat";
            // 
            // txtNoKK
            // 
            txtNoKK.Anchor = AnchorStyles.None;
            txtNoKK.Location = new Point(147, 126);
            txtNoKK.Margin = new Padding(4);
            txtNoKK.Name = "txtNoKK";
            txtNoKK.Size = new Size(247, 27);
            txtNoKK.TabIndex = 16;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.Location = new Point(86, 129);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(54, 20);
            label19.TabIndex = 17;
            label19.Text = "No. KK";
            // 
            // comboBoxStatusKK
            // 
            comboBoxStatusKK.Anchor = AnchorStyles.None;
            comboBoxStatusKK.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusKK.FormattingEnabled = true;
            comboBoxStatusKK.Items.AddRange(new object[] { "Numpang KK", "Membuat KK Baru", "Tidak ada anggota keluarga yang tinggal", "Nomor KK Tetap" });
            comboBoxStatusKK.Location = new Point(158, 504);
            comboBoxStatusKK.Margin = new Padding(4);
            comboBoxStatusKK.Name = "comboBoxStatusKK";
            comboBoxStatusKK.Size = new Size(458, 28);
            comboBoxStatusKK.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(panel4);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1095, 775);
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
            panel6.Location = new Point(15, 588);
            panel6.Name = "panel6";
            panel6.Size = new Size(1066, 171);
            panel6.TabIndex = 131;
            // 
            // lblPerBulanKategori
            // 
            lblPerBulanKategori.Anchor = AnchorStyles.None;
            lblPerBulanKategori.AutoSize = true;
            lblPerBulanKategori.Font = new Font("Segoe UI", 10.2F);
            lblPerBulanKategori.Location = new Point(393, 96);
            lblPerBulanKategori.Name = "lblPerBulanKategori";
            lblPerBulanKategori.Size = new Size(502, 23);
            lblPerBulanKategori.TabIndex = 26;
            lblPerBulanKategori.Text = "Jumlah pengajuan Surat Keterangan Pindah Datang [Pilih Bulan]";
            // 
            // lblTotalTahunKategori
            // 
            lblTotalTahunKategori.Anchor = AnchorStyles.None;
            lblTotalTahunKategori.AutoSize = true;
            lblTotalTahunKategori.Font = new Font("Segoe UI", 10.2F);
            lblTotalTahunKategori.Location = new Point(393, 130);
            lblTotalTahunKategori.Name = "lblTotalTahunKategori";
            lblTotalTahunKategori.Size = new Size(505, 23);
            lblTotalTahunKategori.TabIndex = 27;
            lblTotalTahunKategori.Text = "Jumlah pengajuan Surat Keterangan Pindah Datang [Pilih Tahun]";
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.None;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(39, 56);
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
            comboBoxTahun.Location = new Point(151, 130);
            comboBoxTahun.Name = "comboBoxTahun";
            comboBoxTahun.Size = new Size(189, 28);
            comboBoxTahun.TabIndex = 22;
            comboBoxTahun.SelectedIndexChanged += comboBoxTahun_SelectedIndexChanged;
            // 
            // comboBoxBulan
            // 
            comboBoxBulan.Anchor = AnchorStyles.None;
            comboBoxBulan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBulan.FormattingEnabled = true;
            comboBoxBulan.Items.AddRange(new object[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" });
            comboBoxBulan.Location = new Point(151, 95);
            comboBoxBulan.Name = "comboBoxBulan";
            comboBoxBulan.Size = new Size(189, 28);
            comboBoxBulan.TabIndex = 18;
            comboBoxBulan.SelectedIndexChanged += comboBoxBulan_SelectedIndexChanged;
            // 
            // label39
            // 
            label39.Anchor = AnchorStyles.None;
            label39.AutoSize = true;
            label39.Font = new Font("Segoe UI", 10.2F);
            label39.Location = new Point(46, 130);
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
            label41.Location = new Point(46, 96);
            label41.Name = "label41";
            label41.Size = new Size(53, 23);
            label41.TabIndex = 20;
            label41.Text = "Bulan";
            // 
            // label42
            // 
            label42.Anchor = AnchorStyles.None;
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label42.Location = new Point(264, 12);
            label42.Name = "label42";
            label42.Size = new Size(581, 32);
            label42.TabIndex = 6;
            label42.Text = "Jumlah Pengajuan Surat Keterangan Pindah Datang";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 80, 105);
            panel3.Controls.Add(lblRiwayat);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1089, 60);
            panel3.TabIndex = 47;
            // 
            // lblRiwayat
            // 
            lblRiwayat.Anchor = AnchorStyles.None;
            lblRiwayat.AutoSize = true;
            lblRiwayat.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRiwayat.ForeColor = Color.White;
            lblRiwayat.Location = new Point(339, 9);
            lblRiwayat.Margin = new Padding(2, 0, 2, 0);
            lblRiwayat.Name = "lblRiwayat";
            lblRiwayat.Size = new Size(459, 41);
            lblRiwayat.TabIndex = 14;
            lblRiwayat.Text = "RIWAYAT SURAT KEPINDAHAN";
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
            panel4.Location = new Point(15, 79);
            panel4.Name = "panel4";
            panel4.Size = new Size(1066, 491);
            panel4.TabIndex = 48;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.FromArgb(198, 67, 72);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(28, 419);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 45);
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 248, 250);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(158, 163, 181);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(75, 80, 105);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(235, 237, 241);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(75, 80, 105);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 56, 73);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(158, 163, 181);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(75, 80, 105);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(158, 163, 181);
            dataGridView1.Location = new Point(28, 88);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1011, 324);
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
            // FormPD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 825);
            Controls.Add(tabControl1);
            Margin = new Padding(4);
            Name = "FormPD";
            Padding = new Padding(7);
            Text = "Pengajuan Surat Keterangan Kepindahan";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxNomorKK;
        private TextBox textBoxNamaKepalaKeluarga;
        private ComboBox comboBoxAlasanPindah;
        private ComboBox comboBoxKlasifikasiPindah;
        private ComboBox comboBoxJenisKepindahan;
        private ComboBox comboBoxStatusYangPindah;
        private DateTimePicker dateTimePickerTanggalPindah;
        private CheckedListBox checkedListBoxAnggotaKeluarga;
        private Button btnExportToExcel;
        private RichTextBox textBoxAlamat;
        private TextBox textBoxRT;
        private TextBox textBoxRW;
        private Label KEPINDAHAN;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox textRWBaru;
        private TextBox textRTBaru;
        private RichTextBox richAlamatBaru;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label kodepos;
        private ComboBox comboBoxDesa;
        private ComboBox comboBoxKecamatan;
        private ComboBox comboBoxKota;
        private ComboBox comboBoxProv;
        private ComboBox comboBoxKodePos;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblRiwayat;
        private TextBox txtNomorSurat;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Panel panel1;
        private TextBox txtNoKK;
        private Label label19;
        private TextBox txtNoSurat;
        private Label label20;
        private TextBox txtPetugas;
        private Label label21;
        private Label label22;
        private Label label29;
        private Panel panel3;
        private Panel panel4;
        private ComboBox comboBoxStatusKK;
        private Label label23;
        private Button btnDelete;
        private Panel panel6;
        private Label lblPerBulanKategori;
        private Label lblTotalTahunKategori;
        private Label label24;
        private ComboBox comboBoxTahun;
        private ComboBox comboBoxBulan;
        private Label label39;
        private Label label41;
        private Label label42;
        private Panel panel8;
        private Label label40;
        private Button btnTambahData;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
