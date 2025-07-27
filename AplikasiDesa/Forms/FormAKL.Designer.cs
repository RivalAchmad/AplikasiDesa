namespace AplikasiDesa.Forms
{
    partial class FormAKL
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
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel8 = new Panel();
            label40 = new Label();
            btnTambahData = new Button();
            panel5 = new Panel();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            txtNamaBapak = new TextBox();
            label5 = new Label();
            label46 = new Label();
            label1 = new Label();
            cmbBoxBapak = new ComboBox();
            txtNIKBapak = new TextBox();
            label47 = new Label();
            txtNamaIbu = new TextBox();
            cmbBoxIbu = new ComboBox();
            label44 = new Label();
            txtNIKIbu = new TextBox();
            label43 = new Label();
            textBoxTempatTanggalLahirIbu = new TextBox();
            label12 = new Label();
            textBoxAlamatIbu = new TextBox();
            textBoxAgamaIbu = new TextBox();
            textBoxPekerjaanIbu = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            textBoxTempatTanggalLahirBapak = new TextBox();
            textBoxAlamatBapak = new TextBox();
            textBoxAgamaBapak = new TextBox();
            textBoxPekerjaanBapak = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label2 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label27 = new Label();
            dtpJam = new DateTimePicker();
            textBoxAnakKe = new NumericUpDown();
            label19 = new Label();
            NamaAnak = new TextBox();
            dtpHariTgl = new DateTimePicker();
            TempatLahir = new TextBox();
            Kewarganegaraan = new ComboBox();
            label20 = new Label();
            JenisKelamin = new ComboBox();
            label21 = new Label();
            Dari = new NumericUpDown();
            label22 = new Label();
            label23 = new Label();
            label26 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            panel4 = new Panel();
            label32 = new Label();
            dtpPembuatan = new DateTimePicker();
            buttonGeneratePDF = new Button();
            Jabatan = new ComboBox();
            textBoxNomorSurat = new TextBox();
            textBoxAtasNama = new ComboBox();
            TempatSurat = new TextBox();
            label38 = new Label();
            label18 = new Label();
            label37 = new Label();
            label33 = new Label();
            label36 = new Label();
            label34 = new Label();
            label35 = new Label();
            tabPage2 = new TabPage();
            panel6 = new Panel();
            lblPerBulanKategori = new Label();
            lblTotalTahunKategori = new Label();
            label25 = new Label();
            comboBoxTahun = new ComboBox();
            comboBoxBulan = new ComboBox();
            label39 = new Label();
            label41 = new Label();
            label42 = new Label();
            panel1 = new Panel();
            label17 = new Label();
            label24 = new Label();
            textCariSurat = new TextBox();
            dataGridViewPenduduk = new DataGridView();
            buttonDeletePenduduk = new Button();
            label45 = new Label();
            panel7 = new Panel();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxAnakKe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dari).BeginInit();
            panel4.SuspendLayout();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPenduduk).BeginInit();
            panel7.SuspendLayout();
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
            tabControl1.Size = new Size(1265, 839);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(iconButton1);
            tabPage1.Controls.Add(panel8);
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1257, 803);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📝 Formulir";
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton1.BackColor = Color.WhiteSmoke;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(1199, 745);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(55, 55);
            iconButton1.TabIndex = 201;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.BackColor = Color.WhiteSmoke;
            panel8.Controls.Add(label40);
            panel8.Controls.Add(btnTambahData);
            panel8.Location = new Point(990, 658);
            panel8.Name = "panel8";
            panel8.Size = new Size(264, 142);
            panel8.TabIndex = 195;
            panel8.Visible = false;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label40.Location = new Point(7, 8);
            label40.Name = "label40";
            label40.Size = new Size(253, 69);
            label40.TabIndex = 49;
            label40.Text = "Tambah data baru apabila data \r\npenduduk yang diinginkan \r\nbelum ada pada database";
            // 
            // btnTambahData
            // 
            btnTambahData.BackColor = SystemColors.ActiveCaption;
            btnTambahData.FlatStyle = FlatStyle.Flat;
            btnTambahData.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahData.Location = new Point(8, 88);
            btnTambahData.Name = "btnTambahData";
            btnTambahData.Size = new Size(196, 45);
            btnTambahData.TabIndex = 47;
            btnTambahData.Text = "Tambah Data Penduduk";
            btnTambahData.UseVisualStyleBackColor = false;
            btnTambahData.Click += btnTambahData_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(245, 214, 117);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Top;
            panel5.ForeColor = Color.Black;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1251, 87);
            panel5.TabIndex = 199;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(485, 10);
            label3.Name = "label3";
            label3.Size = new Size(274, 38);
            label3.TabIndex = 125;
            label3.Text = "FORMULIR DIGITAL";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(424, 46);
            label4.Name = "label4";
            label4.Size = new Size(379, 31);
            label4.TabIndex = 126;
            label4.Text = "SURAT KETERANGAN KELAHIRAN";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel4, 2, 0);
            tableLayoutPanel1.Location = new Point(3, 94);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 7, 0, 7);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1251, 706);
            tableLayoutPanel1.TabIndex = 200;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(txtNamaBapak);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label46);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbBoxBapak);
            panel2.Controls.Add(txtNIKBapak);
            panel2.Controls.Add(label47);
            panel2.Controls.Add(txtNamaIbu);
            panel2.Controls.Add(cmbBoxIbu);
            panel2.Controls.Add(label44);
            panel2.Controls.Add(txtNIKIbu);
            panel2.Controls.Add(label43);
            panel2.Controls.Add(textBoxTempatTanggalLahirIbu);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(textBoxAlamatIbu);
            panel2.Controls.Add(textBoxAgamaIbu);
            panel2.Controls.Add(textBoxPekerjaanIbu);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(textBoxTempatTanggalLahirBapak);
            panel2.Controls.Add(textBoxAlamatBapak);
            panel2.Controls.Add(textBoxAgamaBapak);
            panel2.Controls.Add(textBoxPekerjaanBapak);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(10, 10);
            panel2.Margin = new Padding(10, 3, 10, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(397, 686);
            panel2.TabIndex = 196;
            // 
            // txtNamaBapak
            // 
            txtNamaBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNamaBapak.Location = new Point(169, 142);
            txtNamaBapak.Margin = new Padding(4, 5, 4, 5);
            txtNamaBapak.Name = "txtNamaBapak";
            txtNamaBapak.Size = new Size(186, 27);
            txtNamaBapak.TabIndex = 197;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(32, 53);
            label5.Name = "label5";
            label5.Size = new Size(182, 28);
            label5.TabIndex = 127;
            label5.Text = "DATA DIRI BAPAK";
            // 
            // label46
            // 
            label46.Anchor = AnchorStyles.Left;
            label46.AutoSize = true;
            label46.Font = new Font("Segoe UI", 9F);
            label46.Location = new Point(34, 144);
            label46.Name = "label46";
            label46.Size = new Size(49, 20);
            label46.TabIndex = 198;
            label46.Text = "Nama";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.Location = new Point(72, 10);
            label1.Name = "label1";
            label1.Size = new Size(270, 31);
            label1.TabIndex = 120;
            label1.Text = "FORMULIR ORANG TUA";
            // 
            // cmbBoxBapak
            // 
            cmbBoxBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbBoxBapak.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBoxBapak.FormattingEnabled = true;
            cmbBoxBapak.Location = new Point(169, 106);
            cmbBoxBapak.Name = "cmbBoxBapak";
            cmbBoxBapak.Size = new Size(186, 28);
            cmbBoxBapak.TabIndex = 193;
            cmbBoxBapak.SelectedIndexChanged += cmbBoxBapak_SelectedIndexChanged;
            cmbBoxBapak.TextChanged += cmbBoxBapak_TextChanged;
            cmbBoxBapak.KeyDown += cmbBoxBapak_KeyDown;
            // 
            // txtNIKBapak
            // 
            txtNIKBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNIKBapak.Location = new Point(169, 179);
            txtNIKBapak.Margin = new Padding(4, 5, 4, 5);
            txtNIKBapak.Name = "txtNIKBapak";
            txtNIKBapak.Size = new Size(186, 27);
            txtNIKBapak.TabIndex = 195;
            // 
            // label47
            // 
            label47.Anchor = AnchorStyles.Left;
            label47.AutoSize = true;
            label47.Font = new Font("Segoe UI", 9F);
            label47.Location = new Point(34, 182);
            label47.Name = "label47";
            label47.Size = new Size(33, 20);
            label47.TabIndex = 196;
            label47.Text = "NIK";
            // 
            // txtNamaIbu
            // 
            txtNamaIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNamaIbu.Location = new Point(169, 456);
            txtNamaIbu.Margin = new Padding(4, 5, 4, 5);
            txtNamaIbu.Name = "txtNamaIbu";
            txtNamaIbu.Size = new Size(186, 27);
            txtNamaIbu.TabIndex = 185;
            // 
            // cmbBoxIbu
            // 
            cmbBoxIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbBoxIbu.FormattingEnabled = true;
            cmbBoxIbu.Location = new Point(168, 417);
            cmbBoxIbu.Name = "cmbBoxIbu";
            cmbBoxIbu.Size = new Size(187, 28);
            cmbBoxIbu.TabIndex = 194;
            cmbBoxIbu.SelectedIndexChanged += cmbBoxIbu_SelectedIndexChanged;
            cmbBoxIbu.TextChanged += cmbBoxIbu_TextChanged;
            cmbBoxIbu.KeyDown += cmbBoxIbu_KeyDown;
            // 
            // label44
            // 
            label44.Anchor = AnchorStyles.Left;
            label44.AutoSize = true;
            label44.Font = new Font("Segoe UI", 9F);
            label44.Location = new Point(34, 460);
            label44.Name = "label44";
            label44.Size = new Size(49, 20);
            label44.TabIndex = 186;
            label44.Text = "Nama";
            // 
            // txtNIKIbu
            // 
            txtNIKIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNIKIbu.Location = new Point(168, 493);
            txtNIKIbu.Margin = new Padding(4, 5, 4, 5);
            txtNIKIbu.Name = "txtNIKIbu";
            txtNIKIbu.Size = new Size(186, 27);
            txtNIKIbu.TabIndex = 183;
            // 
            // label43
            // 
            label43.Anchor = AnchorStyles.Left;
            label43.AutoSize = true;
            label43.Font = new Font("Segoe UI", 9F);
            label43.Location = new Point(33, 496);
            label43.Name = "label43";
            label43.Size = new Size(33, 20);
            label43.TabIndex = 184;
            label43.Text = "NIK";
            // 
            // textBoxTempatTanggalLahirIbu
            // 
            textBoxTempatTanggalLahirIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxTempatTanggalLahirIbu.Location = new Point(168, 530);
            textBoxTempatTanggalLahirIbu.Margin = new Padding(4, 5, 4, 5);
            textBoxTempatTanggalLahirIbu.Name = "textBoxTempatTanggalLahirIbu";
            textBoxTempatTanggalLahirIbu.Size = new Size(186, 27);
            textBoxTempatTanggalLahirIbu.TabIndex = 114;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(33, 414);
            label12.Name = "label12";
            label12.Size = new Size(128, 40);
            label12.TabIndex = 183;
            label12.Text = "Cari Data\r\n(Masukkan Nama)";
            // 
            // textBoxAlamatIbu
            // 
            textBoxAlamatIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxAlamatIbu.Location = new Point(168, 644);
            textBoxAlamatIbu.Margin = new Padding(4, 5, 4, 5);
            textBoxAlamatIbu.Name = "textBoxAlamatIbu";
            textBoxAlamatIbu.Size = new Size(186, 27);
            textBoxAlamatIbu.TabIndex = 117;
            // 
            // textBoxAgamaIbu
            // 
            textBoxAgamaIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxAgamaIbu.Location = new Point(168, 605);
            textBoxAgamaIbu.Margin = new Padding(4, 5, 4, 5);
            textBoxAgamaIbu.Name = "textBoxAgamaIbu";
            textBoxAgamaIbu.Size = new Size(186, 27);
            textBoxAgamaIbu.TabIndex = 116;
            // 
            // textBoxPekerjaanIbu
            // 
            textBoxPekerjaanIbu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPekerjaanIbu.Location = new Point(168, 568);
            textBoxPekerjaanIbu.Margin = new Padding(4, 5, 4, 5);
            textBoxPekerjaanIbu.Name = "textBoxPekerjaanIbu";
            textBoxPekerjaanIbu.Size = new Size(186, 27);
            textBoxPekerjaanIbu.TabIndex = 115;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Left;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F);
            label16.Location = new Point(33, 534);
            label16.Name = "label16";
            label16.Size = new Size(121, 20);
            label16.TabIndex = 179;
            label16.Text = "Tempat/Tgl Lahir";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Left;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F);
            label15.Location = new Point(33, 568);
            label15.Name = "label15";
            label15.Size = new Size(72, 20);
            label15.TabIndex = 180;
            label15.Text = "Pekerjaan";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F);
            label14.Location = new Point(33, 608);
            label14.Name = "label14";
            label14.Size = new Size(57, 20);
            label14.TabIndex = 181;
            label14.Text = "Agama";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F);
            label13.Location = new Point(33, 645);
            label13.Name = "label13";
            label13.Size = new Size(57, 20);
            label13.TabIndex = 182;
            label13.Text = "Alamat";
            // 
            // textBoxTempatTanggalLahirBapak
            // 
            textBoxTempatTanggalLahirBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxTempatTanggalLahirBapak.Location = new Point(169, 216);
            textBoxTempatTanggalLahirBapak.Margin = new Padding(4, 5, 4, 5);
            textBoxTempatTanggalLahirBapak.Name = "textBoxTempatTanggalLahirBapak";
            textBoxTempatTanggalLahirBapak.Size = new Size(186, 27);
            textBoxTempatTanggalLahirBapak.TabIndex = 108;
            // 
            // textBoxAlamatBapak
            // 
            textBoxAlamatBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxAlamatBapak.Location = new Point(169, 328);
            textBoxAlamatBapak.Margin = new Padding(4, 5, 4, 5);
            textBoxAlamatBapak.Name = "textBoxAlamatBapak";
            textBoxAlamatBapak.Size = new Size(186, 27);
            textBoxAlamatBapak.TabIndex = 111;
            // 
            // textBoxAgamaBapak
            // 
            textBoxAgamaBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxAgamaBapak.Location = new Point(169, 292);
            textBoxAgamaBapak.Margin = new Padding(4, 5, 4, 5);
            textBoxAgamaBapak.Name = "textBoxAgamaBapak";
            textBoxAgamaBapak.Size = new Size(186, 27);
            textBoxAgamaBapak.TabIndex = 110;
            // 
            // textBoxPekerjaanBapak
            // 
            textBoxPekerjaanBapak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPekerjaanBapak.Location = new Point(169, 254);
            textBoxPekerjaanBapak.Margin = new Padding(4, 5, 4, 5);
            textBoxPekerjaanBapak.Name = "textBoxPekerjaanBapak";
            textBoxPekerjaanBapak.Size = new Size(186, 27);
            textBoxPekerjaanBapak.TabIndex = 109;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(34, 220);
            label7.Name = "label7";
            label7.Size = new Size(121, 20);
            label7.TabIndex = 129;
            label7.Text = "Tempat/Tgl Lahir";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(34, 256);
            label8.Name = "label8";
            label8.Size = new Size(72, 20);
            label8.TabIndex = 130;
            label8.Text = "Pekerjaan";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(34, 295);
            label9.Name = "label9";
            label9.Size = new Size(57, 20);
            label9.TabIndex = 131;
            label9.Text = "Agama";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(34, 332);
            label10.Name = "label10";
            label10.Size = new Size(57, 20);
            label10.TabIndex = 132;
            label10.Text = "Alamat";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(32, 378);
            label2.Name = "label2";
            label2.Size = new Size(150, 28);
            label2.TabIndex = 121;
            label2.Text = "DATA DIRI IBU";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(32, 102);
            label6.Name = "label6";
            label6.Size = new Size(128, 40);
            label6.TabIndex = 128;
            label6.Text = "Cari Data\r\n(Masukkan Nama)";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(label27);
            panel3.Controls.Add(dtpJam);
            panel3.Controls.Add(textBoxAnakKe);
            panel3.Controls.Add(label19);
            panel3.Controls.Add(NamaAnak);
            panel3.Controls.Add(dtpHariTgl);
            panel3.Controls.Add(TempatLahir);
            panel3.Controls.Add(Kewarganegaraan);
            panel3.Controls.Add(label20);
            panel3.Controls.Add(JenisKelamin);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(Dari);
            panel3.Controls.Add(label22);
            panel3.Controls.Add(label23);
            panel3.Controls.Add(label26);
            panel3.Controls.Add(label28);
            panel3.Controls.Add(label29);
            panel3.Controls.Add(label30);
            panel3.Controls.Add(label31);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(427, 10);
            panel3.Margin = new Padding(10, 3, 10, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(397, 686);
            panel3.TabIndex = 197;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Left;
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F);
            label27.Location = new Point(37, 372);
            label27.Name = "label27";
            label27.Size = new Size(98, 20);
            label27.TabIndex = 143;
            label27.Text = "Jenis Kelamin";
            // 
            // dtpJam
            // 
            dtpJam.Anchor = AnchorStyles.Left;
            dtpJam.CustomFormat = "HH:mm";
            dtpJam.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpJam.Format = DateTimePickerFormat.Custom;
            dtpJam.Location = new Point(166, 325);
            dtpJam.Name = "dtpJam";
            dtpJam.ShowUpDown = true;
            dtpJam.Size = new Size(196, 27);
            dtpJam.TabIndex = 191;
            // 
            // textBoxAnakKe
            // 
            textBoxAnakKe.Anchor = AnchorStyles.Left;
            textBoxAnakKe.Location = new Point(292, 449);
            textBoxAnakKe.Margin = new Padding(3, 2, 3, 2);
            textBoxAnakKe.Name = "textBoxAnakKe";
            textBoxAnakKe.Size = new Size(71, 27);
            textBoxAnakKe.TabIndex = 170;
            textBoxAnakKe.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label19.Location = new Point(35, 11);
            label19.Name = "label19";
            label19.Size = new Size(328, 31);
            label19.TabIndex = 135;
            label19.Text = "FORMULIR PIHAK TERLAPOR";
            // 
            // NamaAnak
            // 
            NamaAnak.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            NamaAnak.Location = new Point(167, 209);
            NamaAnak.Margin = new Padding(4, 5, 4, 5);
            NamaAnak.Name = "NamaAnak";
            NamaAnak.Size = new Size(192, 27);
            NamaAnak.TabIndex = 122;
            // 
            // dtpHariTgl
            // 
            dtpHariTgl.Anchor = AnchorStyles.Left;
            dtpHariTgl.CustomFormat = "";
            dtpHariTgl.Location = new Point(167, 285);
            dtpHariTgl.Name = "dtpHariTgl";
            dtpHariTgl.Size = new Size(196, 27);
            dtpHariTgl.TabIndex = 190;
            // 
            // TempatLahir
            // 
            TempatLahir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TempatLahir.Location = new Point(167, 246);
            TempatLahir.Margin = new Padding(3, 2, 3, 2);
            TempatLahir.Name = "TempatLahir";
            TempatLahir.Size = new Size(192, 27);
            TempatLahir.TabIndex = 124;
            // 
            // Kewarganegaraan
            // 
            Kewarganegaraan.Anchor = AnchorStyles.Left;
            Kewarganegaraan.DropDownStyle = ComboBoxStyle.DropDownList;
            Kewarganegaraan.FormattingEnabled = true;
            Kewarganegaraan.Items.AddRange(new object[] { "WNI", "WNA" });
            Kewarganegaraan.Location = new Point(203, 409);
            Kewarganegaraan.Margin = new Padding(3, 2, 3, 2);
            Kewarganegaraan.Name = "Kewarganegaraan";
            Kewarganegaraan.Size = new Size(160, 28);
            Kewarganegaraan.TabIndex = 177;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Left;
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label20.Location = new Point(37, 165);
            label20.Name = "label20";
            label20.Size = new Size(174, 28);
            label20.TabIndex = 136;
            label20.Text = "DATA DIRI ANAK";
            // 
            // JenisKelamin
            // 
            JenisKelamin.Anchor = AnchorStyles.Left;
            JenisKelamin.DropDownStyle = ComboBoxStyle.DropDownList;
            JenisKelamin.FormattingEnabled = true;
            JenisKelamin.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });
            JenisKelamin.Location = new Point(203, 369);
            JenisKelamin.Margin = new Padding(3, 2, 3, 2);
            JenisKelamin.Name = "JenisKelamin";
            JenisKelamin.Size = new Size(160, 28);
            JenisKelamin.TabIndex = 172;
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Left;
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F);
            label21.Location = new Point(37, 212);
            label21.Name = "label21";
            label21.Size = new Size(49, 20);
            label21.TabIndex = 137;
            label21.Text = "Nama";
            // 
            // Dari
            // 
            Dari.Anchor = AnchorStyles.Left;
            Dari.Location = new Point(79, 482);
            Dari.Margin = new Padding(3, 2, 3, 2);
            Dari.Name = "Dari";
            Dari.Size = new Size(67, 27);
            Dari.TabIndex = 171;
            Dari.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Left;
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F);
            label22.Location = new Point(37, 287);
            label22.Name = "label22";
            label22.Size = new Size(86, 20);
            label22.TabIndex = 138;
            label22.Text = "Waktu Lahir";
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Left;
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F);
            label23.Location = new Point(37, 249);
            label23.Name = "label23";
            label23.Size = new Size(95, 20);
            label23.TabIndex = 139;
            label23.Text = "Tempat Lahir";
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Left;
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F);
            label26.Location = new Point(125, 326);
            label26.Name = "label26";
            label26.Size = new Size(35, 20);
            label26.TabIndex = 142;
            label26.Text = "Jam";
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Left;
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 9F);
            label28.Location = new Point(37, 409);
            label28.Name = "label28";
            label28.Size = new Size(129, 20);
            label28.TabIndex = 144;
            label28.Text = "Kewarganegaraan";
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Left;
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F);
            label29.Location = new Point(37, 449);
            label29.Name = "label29";
            label29.Size = new Size(233, 20);
            label29.TabIndex = 145;
            label29.Text = "Pihak terlapor merupakan anak ke";
            // 
            // label30
            // 
            label30.Anchor = AnchorStyles.Left;
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F);
            label30.Location = new Point(37, 483);
            label30.Name = "label30";
            label30.Size = new Size(35, 20);
            label30.TabIndex = 146;
            label30.Text = "dari";
            // 
            // label31
            // 
            label31.Anchor = AnchorStyles.Left;
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 9F);
            label31.Location = new Point(151, 483);
            label31.Name = "label31";
            label31.Size = new Size(86, 20);
            label31.TabIndex = 147;
            label31.Text = "bersaudara.";
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(label32);
            panel4.Controls.Add(dtpPembuatan);
            panel4.Controls.Add(buttonGeneratePDF);
            panel4.Controls.Add(Jabatan);
            panel4.Controls.Add(textBoxNomorSurat);
            panel4.Controls.Add(textBoxAtasNama);
            panel4.Controls.Add(TempatSurat);
            panel4.Controls.Add(label38);
            panel4.Controls.Add(label18);
            panel4.Controls.Add(label37);
            panel4.Controls.Add(label33);
            panel4.Controls.Add(label36);
            panel4.Controls.Add(label34);
            panel4.Controls.Add(label35);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(844, 10);
            panel4.Margin = new Padding(10, 3, 10, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(397, 686);
            panel4.TabIndex = 198;
            // 
            // label32
            // 
            label32.Anchor = AnchorStyles.Top;
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label32.Location = new Point(44, 11);
            label32.Name = "label32";
            label32.Size = new Size(311, 31);
            label32.TabIndex = 148;
            label32.Text = "FORMULIR ADMINISTRATIF";
            // 
            // dtpPembuatan
            // 
            dtpPembuatan.Anchor = AnchorStyles.Left;
            dtpPembuatan.CustomFormat = "";
            dtpPembuatan.Location = new Point(181, 283);
            dtpPembuatan.Name = "dtpPembuatan";
            dtpPembuatan.Size = new Size(197, 27);
            dtpPembuatan.TabIndex = 192;
            // 
            // buttonGeneratePDF
            // 
            buttonGeneratePDF.Anchor = AnchorStyles.Left;
            buttonGeneratePDF.BackColor = Color.FromArgb(72, 126, 176);
            buttonGeneratePDF.FlatStyle = FlatStyle.Flat;
            buttonGeneratePDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonGeneratePDF.ForeColor = Color.White;
            buttonGeneratePDF.Location = new Point(22, 482);
            buttonGeneratePDF.Margin = new Padding(4, 5, 4, 5);
            buttonGeneratePDF.Name = "buttonGeneratePDF";
            buttonGeneratePDF.Size = new Size(147, 54);
            buttonGeneratePDF.TabIndex = 119;
            buttonGeneratePDF.Text = "CETAK PDF";
            buttonGeneratePDF.UseVisualStyleBackColor = false;
            buttonGeneratePDF.Click += buttonGeneratePDF_Click;
            // 
            // Jabatan
            // 
            Jabatan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Jabatan.FormattingEnabled = true;
            Jabatan.Items.AddRange(new object[] { "Kepala Desa Cibeuteung Muara", "Sekertaris Desa", "Kepala Seksi Pemerintahan", "Kepala Seksi Pelayanan", "Kepala Seksi Kesejahteraan", "Kepala Urusan Tata Usaha dan Umum", "Kepala Urusan Keuangan", "Kepala Urusan Perencanaan", "Staf Desa" });
            Jabatan.Location = new Point(104, 424);
            Jabatan.Margin = new Padding(3, 2, 3, 2);
            Jabatan.Name = "Jabatan";
            Jabatan.Size = new Size(267, 28);
            Jabatan.TabIndex = 169;
            // 
            // textBoxNomorSurat
            // 
            textBoxNomorSurat.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxNomorSurat.Location = new Point(181, 209);
            textBoxNomorSurat.Margin = new Padding(4, 5, 4, 5);
            textBoxNomorSurat.Name = "textBoxNomorSurat";
            textBoxNomorSurat.Size = new Size(191, 27);
            textBoxNomorSurat.TabIndex = 106;
            // 
            // textBoxAtasNama
            // 
            textBoxAtasNama.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxAtasNama.FormattingEnabled = true;
            textBoxAtasNama.Items.AddRange(new object[] { "Asep Suhendar", "Ediya Permana" });
            textBoxAtasNama.Location = new Point(104, 390);
            textBoxAtasNama.Margin = new Padding(3, 2, 3, 2);
            textBoxAtasNama.Name = "textBoxAtasNama";
            textBoxAtasNama.Size = new Size(267, 28);
            textBoxAtasNama.TabIndex = 168;
            // 
            // TempatSurat
            // 
            TempatSurat.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TempatSurat.Location = new Point(181, 245);
            TempatSurat.Margin = new Padding(4, 5, 4, 5);
            TempatSurat.Name = "TempatSurat";
            TempatSurat.Size = new Size(191, 27);
            TempatSurat.TabIndex = 123;
            TempatSurat.Text = "Ciebeuteung Muara";
            // 
            // label38
            // 
            label38.Anchor = AnchorStyles.Left;
            label38.AutoSize = true;
            label38.Font = new Font("Segoe UI", 9F);
            label38.Location = new Point(22, 393);
            label38.Name = "label38";
            label38.Size = new Size(49, 20);
            label38.TabIndex = 154;
            label38.Text = "Nama";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Left;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F);
            label18.Location = new Point(18, 212);
            label18.Name = "label18";
            label18.Size = new Size(94, 20);
            label18.TabIndex = 134;
            label18.Text = "Nomor Surat";
            // 
            // label37
            // 
            label37.Anchor = AnchorStyles.Left;
            label37.AutoSize = true;
            label37.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label37.Location = new Point(22, 347);
            label37.Name = "label37";
            label37.Size = new Size(157, 28);
            label37.TabIndex = 153;
            label37.Text = "PETUGAS DESA";
            // 
            // label33
            // 
            label33.Anchor = AnchorStyles.Left;
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI", 9F);
            label33.Location = new Point(18, 249);
            label33.Name = "label33";
            label33.Size = new Size(137, 20);
            label33.TabIndex = 149;
            label33.Text = "Tempat Pembuatan";
            // 
            // label36
            // 
            label36.Anchor = AnchorStyles.Left;
            label36.AutoSize = true;
            label36.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label36.Location = new Point(18, 165);
            label36.Name = "label36";
            label36.Size = new Size(134, 28);
            label36.TabIndex = 152;
            label36.Text = "DATA SURAT";
            // 
            // label34
            // 
            label34.Anchor = AnchorStyles.Left;
            label34.AutoSize = true;
            label34.Font = new Font("Segoe UI", 9F);
            label34.Location = new Point(18, 285);
            label34.Name = "label34";
            label34.Size = new Size(139, 20);
            label34.TabIndex = 150;
            label34.Text = "Tanggal Pembuatan";
            // 
            // label35
            // 
            label35.Anchor = AnchorStyles.Left;
            label35.AutoSize = true;
            label35.Font = new Font("Segoe UI", 9F);
            label35.Location = new Point(22, 427);
            label35.Name = "label35";
            label35.Size = new Size(60, 20);
            label35.TabIndex = 151;
            label35.Text = "Jabatan";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(panel7);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1257, 803);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "📜 Riwayat Surat";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(lblPerBulanKategori);
            panel6.Controls.Add(lblTotalTahunKategori);
            panel6.Controls.Add(label25);
            panel6.Controls.Add(comboBoxTahun);
            panel6.Controls.Add(comboBoxBulan);
            panel6.Controls.Add(label39);
            panel6.Controls.Add(label41);
            panel6.Controls.Add(label42);
            panel6.Location = new Point(8, 586);
            panel6.Name = "panel6";
            panel6.Size = new Size(1241, 211);
            panel6.TabIndex = 129;
            // 
            // lblPerBulanKategori
            // 
            lblPerBulanKategori.Anchor = AnchorStyles.None;
            lblPerBulanKategori.AutoSize = true;
            lblPerBulanKategori.Font = new Font("Segoe UI", 10.2F);
            lblPerBulanKategori.Location = new Point(474, 106);
            lblPerBulanKategori.Name = "lblPerBulanKategori";
            lblPerBulanKategori.Size = new Size(459, 23);
            lblPerBulanKategori.TabIndex = 26;
            lblPerBulanKategori.Text = "Jumlah pengajuan Surat Keterangan Kelahiran [Pilih Bulan]";
            // 
            // lblTotalTahunKategori
            // 
            lblTotalTahunKategori.Anchor = AnchorStyles.None;
            lblTotalTahunKategori.AutoSize = true;
            lblTotalTahunKategori.Font = new Font("Segoe UI", 10.2F);
            lblTotalTahunKategori.Location = new Point(474, 136);
            lblTotalTahunKategori.Name = "lblTotalTahunKategori";
            lblTotalTahunKategori.Size = new Size(462, 23);
            lblTotalTahunKategori.TabIndex = 27;
            lblTotalTahunKategori.Text = "Jumlah pengajuan Surat Keterangan Kelahiran [Pilih Tahun]";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.None;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.Location = new Point(120, 70);
            label25.Name = "label25";
            label25.Size = new Size(104, 28);
            label25.TabIndex = 23;
            label25.Text = "Filter Data";
            // 
            // comboBoxTahun
            // 
            comboBoxTahun.Anchor = AnchorStyles.None;
            comboBoxTahun.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTahun.FormattingEnabled = true;
            comboBoxTahun.Items.AddRange(new object[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030" });
            comboBoxTahun.Location = new Point(232, 140);
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
            comboBoxBulan.Location = new Point(232, 106);
            comboBoxBulan.Name = "comboBoxBulan";
            comboBoxBulan.Size = new Size(189, 28);
            comboBoxBulan.TabIndex = 18;
            comboBoxBulan.SelectedIndexChanged += comboBoxBulan_SelectedIndexChanged;
            // 
            // label39
            // 
            label39.Anchor = AnchorStyles.None;
            label39.AutoSize = true;
            label39.Font = new Font("Segoe UI", 9F);
            label39.Location = new Point(127, 143);
            label39.Name = "label39";
            label39.Size = new Size(47, 20);
            label39.TabIndex = 21;
            label39.Text = "Tahun";
            // 
            // label41
            // 
            label41.Anchor = AnchorStyles.None;
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 9F);
            label41.Location = new Point(127, 109);
            label41.Name = "label41";
            label41.Size = new Size(46, 20);
            label41.TabIndex = 20;
            label41.Text = "Bulan";
            // 
            // label42
            // 
            label42.Anchor = AnchorStyles.Top;
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label42.Location = new Point(358, 10);
            label42.Name = "label42";
            label42.Size = new Size(522, 32);
            label42.TabIndex = 6;
            label42.Text = "Jumlah Pengajuan Surat Keterangan Kelahiran";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label24);
            panel1.Controls.Add(textCariSurat);
            panel1.Controls.Add(dataGridViewPenduduk);
            panel1.Controls.Add(buttonDeletePenduduk);
            panel1.Controls.Add(label45);
            panel1.Location = new Point(8, 97);
            panel1.Margin = new Padding(8);
            panel1.Name = "panel1";
            panel1.Size = new Size(1241, 478);
            panel1.TabIndex = 128;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(231, 72);
            label17.Name = "label17";
            label17.Size = new Size(567, 20);
            label17.TabIndex = 17;
            label17.Text = "Masukkan Nama Anak / Nama Bapak / No. Surat / Tanggal Pembuatan(yyyy-mm-dd)";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(126, 65);
            label24.Name = "label24";
            label24.Size = new Size(99, 28);
            label24.TabIndex = 16;
            label24.Text = "Cari Surat";
            // 
            // textCariSurat
            // 
            textCariSurat.Location = new Point(132, 96);
            textCariSurat.Name = "textCariSurat";
            textCariSurat.PlaceholderText = "🔎";
            textCariSurat.Size = new Size(662, 27);
            textCariSurat.TabIndex = 15;
            textCariSurat.TextChanged += textCariSurat_TextChanged;
            // 
            // dataGridViewPenduduk
            // 
            dataGridViewPenduduk.AllowUserToAddRows = false;
            dataGridViewPenduduk.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(253, 250, 240);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(101, 67, 33);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(253, 242, 191);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(204, 165, 44);
            dataGridViewPenduduk.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewPenduduk.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPenduduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewPenduduk.BackgroundColor = Color.FromArgb(253, 250, 240);
            dataGridViewPenduduk.BorderStyle = BorderStyle.None;
            dataGridViewPenduduk.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewPenduduk.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(245, 214, 117);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(101, 67, 33);
            dataGridViewCellStyle2.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 165, 44);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewPenduduk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewPenduduk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(101, 67, 33);
            dataGridViewCellStyle3.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(253, 242, 191);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(204, 165, 44);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewPenduduk.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewPenduduk.EnableHeadersVisualStyles = false;
            dataGridViewPenduduk.GridColor = Color.FromArgb(240, 220, 160);
            dataGridViewPenduduk.Location = new Point(132, 129);
            dataGridViewPenduduk.Name = "dataGridViewPenduduk";
            dataGridViewPenduduk.ReadOnly = true;
            dataGridViewPenduduk.RowHeadersVisible = false;
            dataGridViewPenduduk.RowHeadersWidth = 51;
            dataGridViewPenduduk.RowTemplate.Height = 35;
            dataGridViewPenduduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPenduduk.Size = new Size(994, 277);
            dataGridViewPenduduk.TabIndex = 8;
            // 
            // buttonDeletePenduduk
            // 
            buttonDeletePenduduk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDeletePenduduk.BackColor = Color.FromArgb(198, 67, 72);
            buttonDeletePenduduk.FlatStyle = FlatStyle.Flat;
            buttonDeletePenduduk.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDeletePenduduk.ForeColor = Color.White;
            buttonDeletePenduduk.Location = new Point(132, 412);
            buttonDeletePenduduk.Name = "buttonDeletePenduduk";
            buttonDeletePenduduk.Size = new Size(128, 41);
            buttonDeletePenduduk.TabIndex = 11;
            buttonDeletePenduduk.Text = "Hapus Riwayat";
            buttonDeletePenduduk.UseVisualStyleBackColor = false;
            buttonDeletePenduduk.Click += buttonDeletePenduduk_Click;
            // 
            // label45
            // 
            label45.Anchor = AnchorStyles.Top;
            label45.AutoSize = true;
            label45.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label45.Location = new Point(497, 17);
            label45.Name = "label45";
            label45.Size = new Size(251, 32);
            label45.TabIndex = 14;
            label45.Text = "Tabel Data Pengajuan";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(245, 214, 117);
            panel7.Controls.Add(label11);
            panel7.Dock = DockStyle.Top;
            panel7.ForeColor = Color.Black;
            panel7.Location = new Point(3, 3);
            panel7.Margin = new Padding(8);
            panel7.Name = "panel7";
            panel7.Size = new Size(1251, 87);
            panel7.TabIndex = 200;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(350, 22);
            label11.Name = "label11";
            label11.Size = new Size(594, 38);
            label11.TabIndex = 127;
            label11.Text = "RIWAYAT SURAT KETERANGAN KELAHIRAN";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormAKL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 853);
            Controls.Add(tabControl1);
            Name = "FormAKL";
            Padding = new Padding(7);
            Text = "Pengajuan Surat Keterangan Kelahiran";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxAnakKe).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dari).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPenduduk).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private ComboBox Kewarganegaraan;
        private ComboBox JenisKelamin;
        private NumericUpDown Dari;
        private NumericUpDown textBoxAnakKe;
        private ComboBox Jabatan;
        private ComboBox textBoxAtasNama;
        private Label label38;
        private Label label37;
        private Label label36;
        private Label label35;
        private Label label34;
        private Label label33;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox TempatLahir;
        private TextBox TempatSurat;
        private TextBox NamaAnak;
        private Label label2;
        private TextBox textBoxNomorSurat;
        private TextBox textBoxTempatTanggalLahirBapak;
        private TextBox textBoxPekerjaanBapak;
        private TextBox textBoxAgamaBapak;
        private TextBox textBoxAlamatBapak;
        private TextBox textBoxTempatTanggalLahirIbu;
        private TextBox textBoxPekerjaanIbu;
        private TextBox textBoxAgamaIbu;
        private TextBox textBoxAlamatIbu;
        private Button buttonGeneratePDF;
        private Label label45;
        private Button buttonDeletePenduduk;
        private DataGridView dataGridViewPenduduk;
        private DateTimePicker dtpHariTgl;
        private DateTimePicker dtpJam;
        private DateTimePicker dtpPembuatan;
        private ComboBox cmbBoxBapak;
        private ComboBox cmbBoxIbu;
        private Label label11;
        private Panel panel1;
        private Label label17;
        private Label label24;
        private TextBox textCariSurat;
        private Panel panel6;
        private Label lblPerBulanKategori;
        private Label lblTotalTahunKategori;
        private Label label25;
        private ComboBox comboBoxTahun;
        private ComboBox comboBoxBulan;
        private Label label39;
        private Label label41;
        private Label label42;
        private Panel panel8;
        private Label label40;
        private Button btnTambahData;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TextBox txtNamaBapak;
        private Label label46;
        private TextBox txtNIKBapak;
        private Label label47;
        private TextBox txtNamaIbu;
        private Label label44;
        private TextBox txtNIKIbu;
        private Label label43;
        private Panel panel5;
        private Panel panel7;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}