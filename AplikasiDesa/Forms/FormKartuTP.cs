using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace AplikasiDesa
{
    public partial class FormKartuTP : Form
    {
        private Timer typingTimer;

        public FormKartuTP()
        {
            InitializeComponent();
            LoadSKSKTP();
            LoadStatistikSksKtp();
            LoadFormKTP();
            LoadStatistikFormKtp();
            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypeTimerTick;
            txtNoSurat.Text = GenerateNomorSurat();
            txtKades.Text = Session1.LoggedInUserName;
            textBoxPejabatDesa.Text = Session1.LoggedInUserName;
            CultureInfo culture = new CultureInfo("id-ID");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        #region Surat dan Form
        private void cmbBoxCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbCariForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TypeTimerTick(object sender, EventArgs e)
        {
            typingTimer.Stop();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            if (cmbBoxCari.Focused)
            {
                PopulateComboBoxAll(cmbBoxCari);
            }
            else if (cmbCariForm.Focused)
            {
                PopulateComboBoxAll(cmbCariForm);
            }
        }

        private void PopulateComboBoxAll(ComboBox comboBox)
        {
            string filter = comboBox.Text;

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM gabungan_keluarga";
                    var allRecords = connection.QueryWithDecryption<PendudukModel>(sql);

                    var filteredRecords = allRecords.Where(p =>
                        p.Nama_Lengkap != null &&
                        p.Nama_Lengkap.Contains(filter, StringComparison.OrdinalIgnoreCase)
                    ).ToList();

                    if (filteredRecords.Count > 0)
                    {
                        string currentText = comboBox.Text;
                        int selectionStart = comboBox.SelectionStart;

                        comboBox.BeginUpdate();
                        comboBox.Items.Clear();
                        foreach (var record in filteredRecords)
                        {
                            comboBox.Items.Add($"{record.NIK}, {record.Nama_Lengkap}");
                        }
                        comboBox.EndUpdate();

                        comboBox.Text = currentText;
                        comboBox.SelectionStart = selectionStart;

                        if (comboBox.Focused)
                        {
                            comboBox.DroppedDown = true;
                        }
                    }
                    else
                    {
                        comboBox.DroppedDown = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading names: {ex.Message}");
            }
        }

        private void cmbCariForm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCariForm.Text))
            {
                cmbCariForm.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void cmbBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBoxCari.Text))
            {
                cmbBoxCari.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void cmbBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxCari.SelectedItem != null)
            {
                string selectedItem = cmbBoxCari.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadSKDataByNIK(selectedNIK);
            }
        }

        private void cmbCariForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCariForm.SelectedItem != null)
            {
                string selectedItem = cmbCariForm.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadFormDataByNIK(selectedNIK);
            }
        }

        private void LoadSKDataByNIK(string nik)
        {
            using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT * FROM gabungan_keluarga WHERE NIK = @NIK";
                var result = db.QuerySingleOrDefaultWithDecryption<PendudukModel>(sql, new { NIK = nik });

                if (result != null)
                {
                    txtNamaLengkap.Text = result.Nama_Lengkap;
                    txtNIK.Text = nik;
                    txtAgama.Text = result.Agama;
                    string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}, Kecamatan {result.nama_kecamatan}, Kabupaten {result.nama_kabupaten}, {result.nama_provinsi}";
                    txtAlamat.Text = alamatLengkap;
                    txtWarganegara.Text = result.Kewarganegaraan;

                    if (!string.IsNullOrEmpty(result.Jenis_Pekerjaan) && result.Jenis_Pekerjaan.Contains('.'))
                    {
                        string pekerjaan = result.Jenis_Pekerjaan.Split('.')[1].Trim();
                        txtPekerjaan.Text = pekerjaan;
                    }
                    else
                    {
                        txtPekerjaan.Text = result.Jenis_Pekerjaan;
                    }

                    txtTempatLahir.Text = result.Tempat_Lahir;
                    if (result.Tanggal_Lahir.HasValue)
                    {
                        dtpTanggalLahir.Value = result.Tanggal_Lahir.Value;
                    }
                    else
                    {
                        dtpTanggalLahir.Value = DateTime.Now;
                    }
                    if (result.Jenis_Kelamin.Equals("Laki-laki", StringComparison.OrdinalIgnoreCase))
                    {
                        rbLK.Checked = true;
                    }
                    else if (result.Jenis_Kelamin.Equals("Perempuan", StringComparison.OrdinalIgnoreCase))
                    {
                        rbPR.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan.");
                }
            }
        }

        private void LoadFormDataByNIK(string nik)
        {
            using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT * FROM gabungan_keluarga WHERE NIK = @NIK";
                var result = db.QuerySingleOrDefaultWithDecryption<PendudukModel>(sql, new { NIK = nik });

                if (result != null)
                {
                    textBoxNama.Text = result.Nama_Lengkap;
                    textBoxNIK.Text = nik;
                    textBoxKK.Text = result.Nomor_KK;
                    string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}";
                    textBoxAlamat.Text = alamatLengkap;
                    txtRt.Text = result.rt;
                    txtRw.Text = result.rw;

                    if (!string.IsNullOrEmpty(result.Jenis_Pekerjaan) && result.Jenis_Pekerjaan.Contains('.'))
                    {
                        string pekerjaan = result.Jenis_Pekerjaan.Split('.')[1].Trim();
                        textBoxPekerjaan.Text = pekerjaan;
                    }
                    else
                    {
                        textBoxPekerjaan.Text = result.Jenis_Pekerjaan;
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan.");
                }
            }
        }

        private string GenerateNomorSurat()
        {
            int nextNumber = 1;
            int tahunSekarang = DateTime.Now.Year;
            int bulanSekarang = DateTime.Now.Month;
            string bulanRomawi = ConvertToRoman(bulanSekarang);

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = @"SELECT no_surat FROM sks_ktp 
                         WHERE no_surat LIKE '476/SKSKTP-%/%/" + tahunSekarang + @"' 
                         ORDER BY id DESC LIMIT 1";

                    var result = connection.ExecuteScalar<string>(query);

                    if (!string.IsNullOrEmpty(result) && result.Contains("SKSKTP-"))
                    {
                        int start = result.IndexOf("SKSKTP-") + 7;
                        int end = result.IndexOf("/", start);

                        if (end > start)
                        {
                            string numberPart = result.Substring(start, end - start);
                            if (int.TryParse(numberPart, out int lastNum))
                            {
                                nextNumber = lastNum + 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating nomor surat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return $"476/SKSKTP-{nextNumber:D3}/{bulanRomawi}/{tahunSekarang}";
        }

        private string ConvertToRoman(int number)
        {
            if (number < 1 || number > 12)
                return "?";

            string[] romanNumerals = {
                "I", "II", "III", "IV", "V", "VI",
                "VII", "VIII", "IX", "X", "XI", "XII"
            };

            return romanNumerals[number - 1];
        }

        private void SetFieldValue(IDictionary<string, PdfFormField> fields, string fieldName, string value, PdfFont font, bool multiline = false)
        {
            if (fields.ContainsKey(fieldName))
            {
                PdfFormField field = fields[fieldName];
                field.SetValue(value);
                field.SetFont(font);

                if (multiline)
                {
                    field.IsMultiline();
                    field.RegenerateField();
                }
            }
        }

        private string CapitalizeWords(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void btnCetakPDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text) ||
                string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtWarganegara.Text) ||
                string.IsNullOrWhiteSpace(txtAgama.Text) ||
                string.IsNullOrWhiteSpace(txtPekerjaan.Text) ||
                string.IsNullOrWhiteSpace(txtTempatLahir.Text) ||
                string.IsNullOrWhiteSpace(txtKades.Text) ||
                !dtpTanggalLahir.Checked ||
                (rbLK.Checked == false && rbPR.Checked == false)
               )
            {
                MessageBox.Show("Harap isi semua field yang diperlukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!InputSanitizer.ValidateNIK(txtNIK.Text))
            {
                MessageBox.Show("NIK harus terdiri dari 16 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
            {
                string nomorSurat = txtNoSurat.Text;

                string sqlCheck = "SELECT COUNT(*) FROM SKS_KTP WHERE no_surat = @NoSurat";
                int count = db.ExecuteScalar<int>(sqlCheck, new { NoSurat = nomorSurat });

                if (count > 0)
                {
                    MessageBox.Show("Nomor surat sudah ada di database. Harap masukkan nomor surat yang berbeda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string archiveDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Arsip Surat",
                "KTP",
                "Surat Keterangan Sementara KTP");

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Surat_Keterangan_Sementara_KTP_{txtNamaLengkap.Text}_{txtNIK.Text}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfTemplatePath = "Format_SUKET-KTP-SEMENTARA.pdf";
                string pdfPath = saveFileDialog.FileName;
                string saveDirectory = Path.GetDirectoryName(pdfPath);

                using (PdfReader reader = new PdfReader(pdfTemplatePath))
                using (PdfWriter writer = new PdfWriter(pdfPath))
                using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
                {
                    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                    IDictionary<string, PdfFormField> fields = form.GetAllFormFields();

                    var regularFontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "palatino-linotype.ttf");
                    var boldFontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "palab.ttf");

                    PdfFont regularFont = PdfFontFactory.CreateFont(regularFontPath, PdfEncodings.IDENTITY_H);
                    PdfFont boldFont = PdfFontFactory.CreateFont(boldFontPath, PdfEncodings.IDENTITY_H);

                    SetFieldValue(fields, "NamaLengkap", txtNamaLengkap.Text.ToUpper(), boldFont);
                    SetFieldValue(fields, "NamaTtd", txtNamaLengkap.Text.ToUpper(), boldFont);

                    string jenisKelamin = rbLK.Checked ? "Laki-Laki" : rbPR.Checked ? "Perempuan" : "";
                    SetFieldValue(fields, "JenisKelamin", jenisKelamin, regularFont);

                    string tempatTanggalLahir = $"{txtTempatLahir.Text}, {dtpTanggalLahir.Value.ToString("dd-MM-yyyy")}";
                    SetFieldValue(fields, "TempatTanggalLahir", tempatTanggalLahir, regularFont);
                    SetFieldValue(fields, "Warganegara", txtWarganegara.Text, regularFont);
                    SetFieldValue(fields, "Agama", CapitalizeWords(txtAgama.Text), regularFont);
                    SetFieldValue(fields, "Pekerjaan", txtPekerjaan.Text, regularFont);
                    SetFieldValue(fields, "Alamat", txtAlamat.Text, regularFont, true);
                    SetFieldValue(fields, "NoNik", CapitalizeWords(txtNIK.Text), regularFont);
                    SetFieldValue(fields, "Nama", CapitalizeWords(txtNamaLengkap.Text), boldFont);
                    SetFieldValue(fields, "Kades", txtKades.Text.ToUpper(), boldFont);

                    string nomorSurat = $"NOMOR : {txtNoSurat.Text}";
                    SetFieldValue(fields, "NoSurat", nomorSurat, regularFont);

                    string tanggalHariIni = DateTime.Today.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
                    string teksMengetahui = $"Desa Cibeuteung Muara, {tanggalHariIni}";
                    SetFieldValue(fields, "Tanggal", CapitalizeWords(teksMengetahui), regularFont);

                    form.FlattenFields();
                }

                using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sqlInsert = "INSERT INTO SKS_KTP (no_surat, tanggal_dikeluarkan, nama_pemohon, petugas) VALUES (@NoSurat, @TanggalDikeluarkan, @NamaPemohon, @Petugas)";
                    var parameters = new
                    {
                        NoSurat = InputSanitizer.SanitizeInput(txtNoSurat.Text),
                        TanggalDikeluarkan = DateTime.Now,
                        NamaPemohon = InputSanitizer.SanitizeInput(txtNamaLengkap.Text),
                        Petugas = Session1.LoggedInUserName
                    };
                    db.Execute(sqlInsert, parameters);
                }

                bool savedToArchiveDirectory = saveDirectory.Equals(archiveDirectory, StringComparison.OrdinalIgnoreCase);

                if (!savedToArchiveDirectory)
                {
                    try
                    {
                        if (!Directory.Exists(archiveDirectory))
                        {
                            Directory.CreateDirectory(archiveDirectory);
                        }

                        string archiveFileName = Path.GetFileName(pdfPath);
                        string archiveFilePath = Path.Combine(archiveDirectory, archiveFileName);

                        File.Copy(pdfPath, archiveFilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"File PDF telah tersimpan di {pdfPath}, tetapi gagal menyimpan salinan arsip: {ex.Message}",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNoSurat.Text = GenerateNomorSurat();
                        return;
                    }
                }

                MessageBox.Show($"File PDF telah tersimpan di {pdfPath}" +
                    (!savedToArchiveDirectory ? $"\nSalinan arsip tersimpan di {archiveDirectory}" : ""),
                    "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNoSurat.Text = GenerateNomorSurat();
            }
            else
            {
                MessageBox.Show("Penyimpanan file PDF gagal.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ExcelPackage.License.SetNonCommercialPersonal("<Rival>");

            if (ValidateForm())
            {
                string nik = textBoxNIK.Text;
                string kk = textBoxKK.Text;
                string nama = textBoxNama.Text;
                string alamat = textBoxAlamat.Text;
                string rt = txtRt.Text;
                string rw = txtRw.Text;
                string pekerjaan = textBoxPekerjaan.Text;
                string opsi = GetSelectedOpsi();
                string pejabatDesa = textBoxPejabatDesa.Text;
                string petugas = Session1.LoggedInUserName;

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "INSERT INTO form_ktp (NIK, nama_lengkap, jenis_pengajuan, tanggal_dikeluarkan, petugas) VALUES (@NIK, @Nama, @JenisPengajuan, @TanggalDikeluarkan, @Petugas)";
                    connection.Execute(query, new
                    {
                        NIK = nik,
                        Nama = InputSanitizer.SanitizeInput(nama),
                        JenisPengajuan = opsi,
                        TanggalDikeluarkan = DateTime.Now,
                        Petugas = InputSanitizer.SanitizeInput(petugas)
                    });
                }

                string archiveDirectory2 = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Arsip Surat",
                    "KTP",
                    "Formulir Pengajuan KTP");

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"Formulir KTP_{nama}_{opsi}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputPath = saveFileDialog.FileName;
                    string saveDirectory2 = Path.GetDirectoryName(outputPath);
                    var templatePath = "format.xlsx";
                    var fileInfo = new FileInfo(templatePath);
                    using (var package = new ExcelPackage(fileInfo))
                    {
                        var worksheet = package.Workbook.Worksheets[0];

                        string EnsureThreeDigits(string input)
                        {
                            return input.PadLeft(3, '0');
                        }

                        for (int i = 0; i < nik.Length && i < 16; i++)
                        {
                            worksheet.Cells[21, 7 + i].Value = nik[i].ToString();
                        }
                        for (int i = 0; i < kk.Length && i < 16; i++)
                        {
                            worksheet.Cells[19, 7 + i].Value = kk[i].ToString();
                        }
                        worksheet.Cells["G17"].Value = nama.ToUpper();
                        worksheet.Cells["G23"].Value = alamat.ToUpper();

                        rt = EnsureThreeDigits(rt);
                        if (rt.Length >= 3)
                        {
                            worksheet.Cells["J27"].Value = rt[0].ToString();
                            worksheet.Cells["K27"].Value = rt[1].ToString();
                            worksheet.Cells["L27"].Value = rt[2].ToString();
                        }

                        rw = EnsureThreeDigits(rw);
                        if (rw.Length >= 3)
                        {
                            worksheet.Cells["R27"].Value = rw[0].ToString();
                            worksheet.Cells["S27"].Value = rw[1].ToString();
                            worksheet.Cells["T27"].Value = rw[2].ToString();
                        }
                        worksheet.Cells["G25"].Value = pekerjaan.ToUpper();

                        worksheet.Cells["W29"].Value = $"Cibeuteung Muara, {DateTime.Now.ToString("dd MMMM", new CultureInfo("id-ID"))} 2024";

                        if (radioPerpanjangan.Checked)
                        {
                            worksheet.Cells["N15"].Value = "X";
                        }
                        else if (radioPenggantian.Checked)
                        {
                            worksheet.Cells["T15"].Value = "X";
                        }
                        else if (radioBaru.Checked)
                        {
                            worksheet.Cells["H15"].Value = "X";
                        }
                        worksheet.Cells["W34"].Value = nama.ToUpper();
                        worksheet.Cells["X38"].Value = pejabatDesa.ToUpper();
                        package.SaveAs(new FileInfo(outputPath));
                    }

                    bool savedToArchiveDirectory2 = saveDirectory2.Equals(archiveDirectory2, StringComparison.OrdinalIgnoreCase);

                    if (!savedToArchiveDirectory2)
                    {
                        try
                        {
                            if (!Directory.Exists(archiveDirectory2))
                            {
                                Directory.CreateDirectory(archiveDirectory2);
                            }

                            string archiveFileName2 = Path.GetFileName(outputPath);
                            string archiveFilePath2 = Path.Combine(archiveDirectory2, archiveFileName2);

                            File.Copy(outputPath, archiveFilePath2, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"File Excel telah tersimpan di {outputPath}, tetapi gagal menyimpan salinan arsip: {ex.Message}",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    MessageBox.Show($"File Excel telah tersimpan di {outputPath}" +
                        (!savedToArchiveDirectory2 ? $"\nSalinan arsip tersimpan di {archiveDirectory2}" : ""),
                        "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Penyimpanan file Excel gagal.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Harap isi semua field yang diperlukan dengan format yang sesuai (16 digit angka untuk NIK/No.KK dan 3 Digit Angka untuk RT/RW).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetSelectedOpsi()
        {
            if (radioBaru.Checked) return "Baru";
            if (radioPerpanjangan.Checked) return "Perpanjangan";
            if (radioPenggantian.Checked) return "Penggantian";
            return string.Empty;
        }

        private bool ValidateForm()
        {
            return !string.IsNullOrEmpty(textBoxNIK.Text) && Regex.IsMatch(textBoxNIK.Text, @"^\d{16}$") &&
                   !string.IsNullOrEmpty(textBoxKK.Text) && Regex.IsMatch(textBoxKK.Text, @"^\d{16}$") &&
                   !string.IsNullOrEmpty(textBoxNama.Text) &&
                   !string.IsNullOrEmpty(textBoxAlamat.Text) &&
                   !string.IsNullOrEmpty(textBoxPekerjaan.Text) &&
                   !string.IsNullOrEmpty(textBoxPejabatDesa.Text) &&
                   !string.IsNullOrEmpty(txtRt.Text) && Regex.IsMatch(txtRt.Text, @"^\d{3}$") &&
                   !string.IsNullOrEmpty(txtRw.Text) && Regex.IsMatch(txtRw.Text, @"^\d{3}$") &&
            (radioBaru.Checked || radioPerpanjangan.Checked || radioPenggantian.Checked);
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }

        private void btnTambahDataForm_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }

        #endregion Surat dan Form

        #region Riwayat
        private void ConfigureSKSData()
        {
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["no_surat"].HeaderText = "Nomor Surat";
            dataGridView1.Columns["tanggal_dikeluarkan"].HeaderText = "Tanggal Terbit";
            dataGridView1.Columns["nama_pemohon"].HeaderText = "Nama Pemohon";
            dataGridView1.Columns["petugas"].HeaderText = "Nama Petugas";
        }

        private void ConfigureFormData()
        {
            dataGridView2.Columns["id"].HeaderText = "ID";
            dataGridView2.Columns["nama_lengkap"].HeaderText = "Nama Pemohon";
            dataGridView2.Columns["jenis_pengajuan"].HeaderText = "Jenis Pengajuan";
            dataGridView2.Columns["tanggal_dikeluarkan"].HeaderText = "Tanggal Terbit";
            dataGridView2.Columns["petugas"].HeaderText = "Nama Petugas";
        }

        private void LoadSKSKTP()
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT * FROM sks_ktp ORDER BY tanggal_dikeluarkan DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                ConfigureSKSData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = @"SELECT * FROM sks_ktp
                 WHERE nama_pemohon LIKE @keyword 
                 OR no_surat LIKE @keyword
                 OR tanggal_dikeluarkan LIKE @keyword
                 ORDER BY tanggal_dikeluarkan DESC";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                ConfigureSKSData();
            }
        }

        private void LoadStatistikSksKtp()
        {
            try
            {
                string[] namaBulan =
                {
                    "Januari", "Februari", "Maret", "April",
                    "Mei", "Juni", "Juli", "Agustus",
                    "September", "Oktober", "November", "Desember"
                };

                if (comboBoxMonth.SelectedItem == null || comboBoxTahunSks.SelectedItem == null)
                {
                    return;
                }

                int bulanDipilih = comboBoxMonth.SelectedIndex + 1;
                int tahunDipilih = Convert.ToInt32(comboBoxTahunSks.SelectedItem.ToString());

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string queryFilter = @"
                        SELECT COUNT(*) 
                        FROM sks_ktp
                        WHERE MONTH(tanggal_dikeluarkan) = @Bulan
                        AND YEAR(tanggal_dikeluarkan) = @Tahun";

                    string queryFilterTahun = @"
                        SELECT COUNT(*) 
                        FROM sks_ktp
                        WHERE YEAR(tanggal_dikeluarkan) = @Tahun";

                    int jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                        new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                    int jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                        new { Tahun = tahunDipilih });

                    lblBulan.Text = $"Jumlah pengajuan Surat Keterangan Sementara bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                    lblTahun.Text = $"Jumlah pengajuan Surat Keterangan Sementara tahun {tahunDipilih}: {jumlahFilterTahun}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat statistik: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistikSksKtp();
        }

        private void comboBoxTahunSks_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistikSksKtp();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridView1.SelectedRows[0].Index;
            int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan menghapus riwayat dengan Id: {id}?",
                "Konfirmasi Hapus Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        db.Execute("DELETE FROM sks_ktp WHERE id = @id", new { id });
                        LoadSKSKTP();
                        LoadStatistikSksKtp();
                        MessageBox.Show($"Data berhasil dihapus.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtNoSurat.Text = GenerateNomorSurat();
            }
        }

        private void LoadFormKTP()
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT * FROM form_ktp ORDER BY tanggal_dikeluarkan DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;
                ConfigureFormData();
            }
        }

        private void txtCariForm_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariForm.Text.Trim();

            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = @"SELECT * FROM form_ktp
                 WHERE nama_lengkap LIKE @keyword 
                 OR NIK LIKE @keyword
                 OR tanggal_dikeluarkan LIKE @keyword
                 OR jenis_pengajuan LIKE @keyword
                 ORDER BY tanggal_dikeluarkan DESC";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;
                ConfigureFormData();
            }
        }

        private void LoadStatistikFormKtp()
        {
            try
            {
                string[] namaBulan =
                {
                    "Januari", "Februari", "Maret", "April",
                    "Mei", "Juni", "Juli", "Agustus",
                    "September", "Oktober", "November", "Desember"
                };

                if (comboBoxOpsi.SelectedItem == null ||
                    comboBoxBulanForm.SelectedItem == null ||
                    comboBoxTahun.SelectedItem == null)
                {
                    return;
                }

                string jenisPengajuan = comboBoxOpsi.SelectedItem.ToString();
                int bulanDipilih = comboBoxBulanForm.SelectedIndex + 1;
                int tahunDipilih = Convert.ToInt32(comboBoxTahun.SelectedItem.ToString());

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string queryFilter;
                    string queryFilterTahun;
                    int jumlahFilterBulan;
                    int jumlahFilterTahun;

                    if (jenisPengajuan == "Semua")
                    {
                        queryFilter = @"
                            SELECT COUNT(*) 
                            FROM form_ktp 
                            WHERE MONTH(tanggal_dikeluarkan) = @Bulan
                            AND YEAR(tanggal_dikeluarkan) = @Tahun";

                        queryFilterTahun = @"
                            SELECT COUNT(*) 
                            FROM form_ktp 
                            WHERE YEAR(tanggal_dikeluarkan) = @Tahun";

                        jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                            new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                        jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                            new { Tahun = tahunDipilih });

                        lblPerBulanKategori.Text = $"Jumlah pengajuan [Semua Jenis] bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                        lblTotalTahunKategori.Text = $"Total pengajuan [Semua Jenis] tahun {tahunDipilih}: {jumlahFilterTahun}";
                    }
                    else
                    {
                        queryFilter = @"
                            SELECT COUNT(*) 
                            FROM form_ktp 
                            WHERE jenis_pengajuan = @JenisPengajuan
                            AND MONTH(tanggal_dikeluarkan) = @Bulan 
                            AND YEAR(tanggal_dikeluarkan) = @Tahun";

                        queryFilterTahun = @"
                            SELECT COUNT(*) 
                            FROM form_ktp
                            WHERE jenis_pengajuan = @JenisPengajuan 
                            AND YEAR(tanggal_dikeluarkan) = @Tahun";

                        jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                            new { JenisPengajuan = jenisPengajuan, Bulan = bulanDipilih, Tahun = tahunDipilih });

                        jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                            new { JenisPengajuan = jenisPengajuan, Tahun = tahunDipilih });

                        lblPerBulanKategori.Text = $"Jumlah pengajuan {jenisPengajuan} bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                        lblTotalTahunKategori.Text = $"Total pengajuan {jenisPengajuan} tahun {tahunDipilih}: {jumlahFilterTahun}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat statistik: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxOpsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistikFormKtp();
        }

        private void comboBoxBulanForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistikFormKtp();
        }

        private void comboBoxTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistikFormKtp();
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0 && dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridView2.SelectedRows[0].Index;
            int id = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells["id"].Value);

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan menghapus riwayat dengan Id: {id}?",
                "Konfirmasi Hapus Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        db.Execute("DELETE FROM form_ktp WHERE id = @id", new { id });
                        LoadFormKTP();
                        LoadStatistikFormKtp();
                        MessageBox.Show($"Data berhasil dihapus.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion Riwayat

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                LoadSKSKTP();
                LoadStatistikSksKtp();
                LoadFormKTP();
                LoadStatistikFormKtp();
            }
        }

        bool visible1 = false;
        bool visible2 = false;

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (visible1 == false)
            {
                panel8.Visible = true;
                visible1 = true;
            }
            else
            {
                panel8.Visible = false;
                visible1 = false;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (visible2 == false)
            {
                panel3.Visible = true;
                visible2 = true;
            }
            else
            {
                panel3.Visible = false;
                visible2 = false;
            }
        }
    }
}
