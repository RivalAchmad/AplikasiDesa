using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using Timer = System.Windows.Forms.Timer;

namespace AplikasiDesa.Forms
{
    public partial class FormAKL : Form
    {
        private Timer typingTimer;
        private Timer sessionTimer;

        public FormAKL()
        {
            InitializeComponent();
            VerifySession();
            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypeTimerTick;
            CultureInfo culture = new CultureInfo("id-ID");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            textBoxNomorSurat.Text = GenerateNomorSurat();
            sessionTimer = new Timer();
            sessionTimer.Interval = 600000; // Periksa setiap 10 menit
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
            string loggedInUserName = Session1.LoggedInUserName;
            textBoxAtasNama.Text = loggedInUserName;

            LoadPendudukData();
            LoadStatisticsKK();
        }

        private void VerifySession()
        {
            if (!Session1.IsSessionValid())
            {
                Session1.ClearSession();
                MessageBox.Show("Sesi Anda telah berakhir. Silakan login kembali.",
                              "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.BeginInvoke(new Action(() =>
                {
                    this.Close();

                    using (var loginForm = new LoginForm())
                    {
                        if (loginForm.ShowDialog() == DialogResult.OK)
                        {
                            FormMainMenu mainMenu = new FormMainMenu();
                            mainMenu.Show();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }));
            }
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            VerifySession();
        }

        #region Formulir
        private void cmbBoxBapak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbBoxIbu_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbBoxBapak_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBoxBapak.Text))
            {
                cmbBoxBapak.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void cmbBoxIbu_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBoxIbu.Text))
            {
                cmbBoxIbu.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void PopulateComboBox()
        {
            if (cmbBoxBapak.Focused)
            {
                PopulateComboBoxByType(cmbBoxBapak);
            }
            else if (cmbBoxIbu.Focused)
            {
                PopulateComboBoxByType(cmbBoxIbu);
            }
        }

        private void PopulateComboBoxByType(ComboBox comboBox)
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

        private void cmbBoxBapak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxBapak.SelectedItem != null)
            {
                string selectedItem = cmbBoxBapak.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadPersonDataByNIK(selectedNIK);
            }
        }

        private void cmbBoxIbu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxIbu.SelectedItem != null)
            {
                string selectedItem = cmbBoxIbu.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadIbuDataByNIK(selectedNIK);
            }
        }

        private void LoadPersonDataByNIK(string nik)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM gabungan_keluarga WHERE NIK = @NIK";
                    var result = connection.QuerySingleOrDefaultWithDecryption<PendudukModel>(sql, new { NIK = nik });

                    if (result != null)
                    {
                        string selectedItem = cmbBoxBapak.SelectedItem.ToString();
                        string nama_bapak = selectedItem.Split(',')[1].Trim();
                        txtNamaBapak.Text = nama_bapak;
                        string nik_bapak = selectedItem.Split(',')[0].Trim();
                        txtNIKBapak.Text = nik_bapak;
                        string tempatLahirBapak = result.Tempat_Lahir;
                        DateTime tanggalLahirBapak = Convert.ToDateTime(result.Tanggal_Lahir);
                        string formattedTanggalLahirBapak = tanggalLahirBapak.ToString("dd-MM-yyyy");
                        string tempatTanggalLahirBapak = $"{tempatLahirBapak}, {formattedTanggalLahirBapak}";
                        textBoxTempatTanggalLahirBapak.Text = tempatTanggalLahirBapak;
                        string pilihan_pekerjaan = result.Jenis_Pekerjaan;
                        if (!string.IsNullOrEmpty(result.Jenis_Pekerjaan) && result.Jenis_Pekerjaan.Contains("."))
                        {
                            string pekerjaan = result.Jenis_Pekerjaan.Split('.')[1].Trim();
                            textBoxPekerjaanBapak.Text = pekerjaan;
                        }
                        else
                        {
                            textBoxPekerjaanBapak.Text = pilihan_pekerjaan;
                        }

                        textBoxAgamaBapak.Text = result.Agama;
                        string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}, Kecamatan {result.nama_kecamatan}, Kabupaten {result.nama_kabupaten}, {result.nama_provinsi}";
                        textBoxAlamatBapak.Text = alamatLengkap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void LoadIbuDataByNIK(string nik)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM gabungan_keluarga WHERE NIK = @NIK";
                    var result = connection.QuerySingleOrDefaultWithDecryption<PendudukModel>(sql, new { NIK = nik });

                    if (result != null)
                    {
                        string selectedItem = cmbBoxIbu.SelectedItem.ToString();
                        string nama_ibu = selectedItem.Split(',')[1].Trim();
                        txtNamaIbu.Text = nama_ibu;
                        string nik_ibu = selectedItem.Split(',')[0].Trim();
                        txtNIKIbu.Text = nik_ibu;
                        string tempatLahirIbu = result.Tempat_Lahir;
                        DateTime tanggalLahirIbu = Convert.ToDateTime(result.Tanggal_Lahir);
                        string formattedTanggalLahirIbu = tanggalLahirIbu.ToString("dd-MM-yyyy");
                        string tempatTanggalLahirIbu = $"{tempatLahirIbu}, {formattedTanggalLahirIbu}";
                        textBoxTempatTanggalLahirIbu.Text = tempatTanggalLahirIbu;
                        string pilihan_pekerjaan = result.Jenis_Pekerjaan;
                        if (!string.IsNullOrEmpty(result.Jenis_Pekerjaan) && result.Jenis_Pekerjaan.Contains("."))
                        {
                            string pekerjaan = result.Jenis_Pekerjaan.Split('.')[1].Trim();
                            textBoxPekerjaanIbu.Text = pekerjaan;
                        }
                        else
                        {
                            textBoxPekerjaanIbu.Text = pilihan_pekerjaan;
                        }
                        textBoxAgamaIbu.Text = result.Agama;
                        string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}, Kecamatan {result.nama_kecamatan}, Kabupaten {result.nama_kabupaten}, {result.nama_provinsi}";
                        textBoxAlamatIbu.Text = alamatLengkap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
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
                    string query = @"SELECT nomor_surat FROM surat 
                             WHERE nomor_surat LIKE '474/SKL-%/%/" + tahunSekarang + @"' 
                             ORDER BY id DESC LIMIT 1";

                    var result = connection.ExecuteScalar(query);

                    if (result != null)
                    {
                        string lastNumber = result.ToString();
                        if (lastNumber.Contains("SKL-"))
                        {
                            int start = lastNumber.IndexOf("SKL-") + 4;
                            int end = lastNumber.IndexOf("/", start);

                            if (end > start)
                            {
                                string numberPart = lastNumber.Substring(start, end - start);
                                if (int.TryParse(numberPart, out int lastNum))
                                {
                                    nextNumber = lastNum + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        nextNumber = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating nomor surat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string newNomor = $"474/SKL-{nextNumber:D3}/{bulanRomawi}/{tahunSekarang}";
            return newNomor;
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

        private void buttonGeneratePDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBapak.Text) ||
                string.IsNullOrWhiteSpace(txtNamaIbu.Text) ||
                string.IsNullOrWhiteSpace(textBoxNomorSurat.Text) ||
                string.IsNullOrWhiteSpace(textBoxTempatTanggalLahirBapak.Text) ||
                string.IsNullOrWhiteSpace(textBoxPekerjaanBapak.Text) ||
                string.IsNullOrWhiteSpace(textBoxAgamaBapak.Text) ||
                string.IsNullOrWhiteSpace(textBoxAlamatBapak.Text) ||
                string.IsNullOrWhiteSpace(textBoxTempatTanggalLahirIbu.Text) ||
                string.IsNullOrWhiteSpace(textBoxPekerjaanIbu.Text) ||
                string.IsNullOrWhiteSpace(textBoxAgamaIbu.Text) ||
                string.IsNullOrWhiteSpace(textBoxAlamatIbu.Text) ||
                string.IsNullOrWhiteSpace(textBoxAtasNama.Text) ||
                string.IsNullOrWhiteSpace(NamaAnak.Text) ||
                JenisKelamin.SelectedItem == null ||
                Kewarganegaraan.SelectedItem == null ||
                string.IsNullOrWhiteSpace(TempatSurat.Text) ||
                string.IsNullOrWhiteSpace(Jabatan.Text) ||
                string.IsNullOrWhiteSpace(TempatLahir.Text))
            {
                MessageBox.Show("Harap isi semua field yang diperlukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!InputSanitizer.ValidateNIK(txtNIKBapak.Text) || !InputSanitizer.ValidateNIK(txtNIKIbu.Text))
            {
                MessageBox.Show("NIK harus terdiri dari 16 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string checkSql = "SELECT COUNT(*) FROM daftar_surat_kematian WHERE Nomor_Surat = @Nomor_Surat";
                int count = connection.ExecuteScalar<int>(checkSql, new { Nomor_Surat = textBoxNomorSurat.Text });
                if (count > 0)
                {
                    MessageBox.Show("Nomor Surat sudah ada. Harap gunakan Nomor Surat yang lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string archiveDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Arsip Surat",
                "Surat Keterangan Kelahiran");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save PDF Document";
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Surat_Keterangan_Kelahiran_{NamaAnak.Text}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                string saveDirectory = Path.GetDirectoryName(filePath);

                string pdfTemplate = Path.Combine("Form_Suket_Kelahiran.pdf");
                string newFile = saveFileDialog.FileName;

                PdfReader pdfReader = new PdfReader(pdfTemplate);
                PdfWriter pdfWriter = new PdfWriter(newFile);
                PdfDocument pdfDoc = new PdfDocument(pdfReader, pdfWriter);

                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);

                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                SetField(form, "NomorSurat", textBoxNomorSurat.Text, regularFont, 11);
                SetField(form, "AnakKe", textBoxAnakKe.Text, regularFont, 11);
                SetField(form, "NamaBapak", txtNamaBapak.Text, boldFont, 11);
                SetField(form, "TtlBapak", textBoxTempatTanggalLahirBapak.Text, regularFont, 11);
                SetField(form, "PekerjaanBapak", textBoxPekerjaanBapak.Text, regularFont, 11);
                SetField(form, "AgamaBapak", textBoxAgamaBapak.Text, regularFont, 11);
                SetField(form, "AlamatBapak", textBoxAlamatBapak.Text, regularFont, 11);
                SetField(form, "NikBapak", txtNIKBapak.Text, regularFont, 11);
                SetField(form, "NamaIbu", txtNamaIbu.Text, boldFont, 11);
                SetField(form, "TtlIbu", textBoxTempatTanggalLahirIbu.Text, regularFont, 11);
                SetField(form, "PekerjaanIbu", textBoxPekerjaanIbu.Text, regularFont, 11);
                SetField(form, "AgamaIbu", textBoxAgamaIbu.Text, regularFont, 11);
                SetField(form, "AlamatIbu", textBoxAlamatIbu.Text, regularFont, 11);
                SetField(form, "NikIbu", txtNIKIbu.Text, regularFont, 11);
                DateTime selectedDate = dtpHariTgl.Value;
                string hari = selectedDate.ToString("dddd", new CultureInfo("id-ID"));
                SetField(form, "HariLahir", hari, boldFont, 11);
                string tanggal = selectedDate.ToString("dd-MM-yyyy");
                SetField(form, "TanggalLahir", tanggal, boldFont, 11);
                string jam = dtpJam.Value.ToString("HH:mm");
                jam = jam.Replace('.', ':');
                SetField(form, "JamLahir", jam, boldFont, 11);
                DateTime tglPembuatan = dtpPembuatan.Value;
                string tgl = tglPembuatan.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
                SetField(form, "TanggalSurat", tgl, regularFont, 11);
                SetField(form, "Tertanda", textBoxAtasNama.Text, boldFont, 11);
                SetField(form, "NamaAnak", NamaAnak.Text, boldFont, 11);
                SetField(form, "JkAnak", JenisKelamin.Text, boldFont, 10);
                SetField(form, "Kewarganegaraan", Kewarganegaraan.Text, regularFont, 11);
                SetField(form, "Dari", Dari.Text, regularFont, 11);
                SetField(form, "TempatSurat", TempatSurat.Text, regularFont, 11);
                SetField(form, "Mengetahui", Jabatan.Text, regularFont, 11);
                SetField(form, "TempatLahir", TempatLahir.Text, boldFont, 11);

                form.FlattenFields();

                pdfDoc.Close();

                SaveDataToDatabase();

                bool savedToArchiveDirectory = saveDirectory.Equals(archiveDirectory, StringComparison.OrdinalIgnoreCase);

                if (!savedToArchiveDirectory)
                {
                    try
                    {
                        if (!Directory.Exists(archiveDirectory))
                        {
                            Directory.CreateDirectory(archiveDirectory);
                        }

                        string archiveFileName = Path.GetFileName(filePath);
                        string archiveFilePath = Path.Combine(archiveDirectory, archiveFileName);

                        File.Copy(filePath, archiveFilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"File PDF telah tersimpan di {filePath}, tetapi gagal menyimpan salinan arsip: {ex.Message}",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxNomorSurat.Text = GenerateNomorSurat();
                        return;
                    }
                }

                MessageBox.Show($"File PDF telah tersimpan di {filePath}" +
                    (!savedToArchiveDirectory ? $"\nSalinan arsip tersimpan di {archiveDirectory}" : ""),
                    "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxNomorSurat.Text = GenerateNomorSurat();
            }
            else
            {
                MessageBox.Show("Penyimpanan file PDF gagal.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void SetField(PdfAcroForm form, string fieldName, string value, PdfFont font, float fontSize)
        {
            if (form.GetField(fieldName) != null)
            {
                PdfFormField field = form.GetField(fieldName);
                field.SetValue(value);
                field.SetFont(font);
                field.SetFontSize(fontSize);

                if (value.Contains("\n"))
                {
                    field.SetFieldFlag(PdfFormField.FF_MULTILINE, true);
                }
            }
        }

        private void SaveDataToDatabase()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = @"INSERT INTO surat (nomor_surat, anak_ke, nama_bapak, 
                                 nama_ibu, hari_lahir, tanggal_lahir, jam_lahir, tanggal_pembuatan_surat, atas_nama, 
                                 nama_anak, jenis_kelamin, kewarganegaraan, dari, tempat_lahir) 
                                 VALUES (@nomor_surat, @anak_ke, @nama_bapak, 
                                 @nama_ibu, @hari_lahir, @tanggal_lahir, @jam_lahir, @tanggal_pembuatan_surat, @atas_nama,
                                 @nama_anak, @jenis_kelamin, @kewarganegaraan, @dari, @tempat_lahir)";

                    DateTime selectedDate = dtpHariTgl.Value;
                    string hari = selectedDate.ToString("dddd", new CultureInfo("id-ID"));
                    string tanggal = selectedDate.ToString("yyyy-MM-dd", new CultureInfo("id-ID"));
                    string jam = dtpJam.Value.ToString("HH:mm");
                    jam = jam.Replace('.', ':');
                    DateTime tglPembuatan = dtpPembuatan.Value;

                    var parameters = new
                    {
                        nomor_surat = InputSanitizer.SanitizeInput(textBoxNomorSurat.Text),
                        anak_ke = textBoxAnakKe.Text,
                        nama_bapak = InputSanitizer.SanitizeInput(txtNamaBapak.Text),
                        nama_ibu = InputSanitizer.SanitizeInput(txtNamaIbu.Text),
                        hari_lahir = hari,
                        tanggal_lahir = tanggal,
                        jam_lahir = jam,
                        tanggal_pembuatan_surat = tglPembuatan,
                        atas_nama = InputSanitizer.SanitizeInput(textBoxAtasNama.Text),
                        nama_anak = InputSanitizer.SanitizeInput(NamaAnak.Text),
                        jenis_kelamin = JenisKelamin.Text,
                        kewarganegaraan = Kewarganegaraan.Text,
                        dari = Dari.Text,
                        tempat_lahir = InputSanitizer.SanitizeInput(TempatLahir.Text)
                    };

                    connection.Execute(query, parameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error menyimpan data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }
        #endregion

        #region Riwayat Surat
        private void LoadPendudukData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM surat ORDER BY tanggal_pembuatan_surat DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewPenduduk.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeletePenduduk_Click(object sender, EventArgs e)
        {
            if (dataGridViewPenduduk.SelectedRows.Count == 0 && dataGridViewPenduduk.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridViewPenduduk.SelectedRows[0].Index;
            int id = Convert.ToInt32(dataGridViewPenduduk.Rows[rowIndex].Cells["id"].Value);

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan menghapus riwayat dengan Id: {id}?",
                "Konfirmasi Hapus Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        connection.Execute("DELETE FROM surat WHERE id = @id", new { id });
                        LoadPendudukData();
                        LoadStatisticsKK();
                        MessageBox.Show($"Data berhasil dihapus.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBoxNomorSurat.Text = GenerateNomorSurat();
            }
        }

        private void textCariSurat_TextChanged(object sender, EventArgs e)
        {
            string keyword = textCariSurat.Text.Trim();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = @"SELECT * FROM surat
                        WHERE nama_anak LIKE @keyword 
                        OR nomor_surat LIKE @keyword
                        OR nama_bapak LIKE @keyword
                        OR tanggal_pembuatan_surat LIKE @keyword
                        ORDER BY tanggal_pembuatan_surat DESC";

                    var result = connection.Query(sql, new { keyword = $"%{keyword}%" });
                    dataGridViewPenduduk.DataSource = result.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error mencari data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatisticsKK()
        {
            try
            {
                string[] namaBulan =
                {
                    "Januari", "Februari", "Maret", "April",
                    "Mei", "Juni", "Juli", "Agustus",
                    "September", "Oktober", "November", "Desember"
                };

                if (comboBoxBulan.SelectedItem != null &&
                    comboBoxTahun.SelectedItem != null)
                {
                    int bulanDipilih = comboBoxBulan.SelectedIndex + 1;
                    int tahunDipilih = Convert.ToInt32(comboBoxTahun.SelectedItem.ToString());

                    using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        string queryFilter = @"
                            SELECT COUNT(*) 
                            FROM surat 
                            WHERE MONTH(tanggal_pembuatan_surat) = @Bulan 
                            AND YEAR(tanggal_pembuatan_surat) = @Tahun";

                        string queryFilterTahun = @"
                            SELECT COUNT(*) 
                            FROM surat 
                            WHERE YEAR(tanggal_pembuatan_surat) = @Tahun";

                        int jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                            new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                        int jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                            new { Tahun = tahunDipilih });

                        lblPerBulanKategori.Text = $"Jumlah pengajuan Surat Keterangan Kelahiran bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                        lblTotalTahunKategori.Text = $"Total pengajuan Surat Keterangan Kelahiran tahun {tahunDipilih}: {jumlahFilterTahun}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat statistik: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatisticsKK();
        }

        private void comboBoxTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatisticsKK();
        }
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadPendudukData();
                LoadStatisticsKK();
            }
        }

        private void FormAKL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
