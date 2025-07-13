using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace AplikasiDesa
{
    public partial class FormAKM : Form
    {
        private Timer typingTimer;
        private Timer sessionTimer;

        public FormAKM()
        {
            InitializeComponent();
            VerifySession();
            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypeTimerTick;
            CultureInfo culture = new CultureInfo("id-ID");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            txtNomorSurat.Text = GenerateNomorSurat();
            string loggedInUserName = Session1.LoggedInUserName;
            txtNamaPetugas.Text = loggedInUserName;
            sessionTimer = new Timer();
            sessionTimer.Interval = 600000; // Periksa setiap 10 menit
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();

            LoadIssuedSuratHistory();
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

        #region Pelaporan Kematian
        private void comboBoxNama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void comboBoxNonSurat_KeyDown(object sender, KeyEventArgs e)
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
            if (comboBoxNama.Focused)
            {
                PopulateComboBoxAll(comboBoxNama);
            }
            else if (comboBoxNonSurat.Focused)
            {
                PopulateComboBoxAll(comboBoxNonSurat);
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

        private void comboBoxNama_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxNama.Text))
            {
                comboBoxNama.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void comboBoxNonSurat_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxNonSurat.Text))
            {
                comboBoxNonSurat.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void comboBoxNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNama.SelectedItem != null)
            {
                string selectedItem = comboBoxNama.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadPersonDataByNIK(selectedNIK);
            }
        }

        private void comboBoxNonSurat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNonSurat.SelectedItem != null)
            {
                string selectedItem = comboBoxNonSurat.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadNonSuratDataByNIK(selectedNIK);
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
                        string selectedItem = comboBoxNama.SelectedItem.ToString();
                        string nama = selectedItem.Split(',')[1].Trim();
                        textBoxNama.Text = nama;
                        txtWarganegara.Text = result.Kewarganegaraan;
                        txtAgama.Text = result.Agama;
                        string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}, Kecamatan {result.nama_kecamatan}, Kabupaten {result.nama_kabupaten}, {result.nama_provinsi}";
                        richTextBoxAlamat.Text = alamatLengkap;

                        if (result.Jenis_Kelamin.Equals("Laki-Laki", StringComparison.OrdinalIgnoreCase))
                        {
                            radioButtonLK.Checked = true;
                        }
                        else if (result.Jenis_Kelamin.Equals("Perempuan", StringComparison.OrdinalIgnoreCase))
                        {
                            radioButtonPR.Checked = true;
                        }

                        var umur = CalculateAge((DateTime)result.Tanggal_Lahir);
                        numericUpDownUmur.Value = umur;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void LoadNonSuratDataByNIK(string nik)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM gabungan_keluarga WHERE NIK = @NIK";
                    var result = connection.QuerySingleOrDefaultWithDecryption<PendudukModel>(sql, new { NIK = nik });

                    if (result != null)
                    {
                        txtWarganegaraNonSurat.Text = result.Kewarganegaraan;
                        txtAgamaNonSurat.Text = result.Agama;
                        string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}, Kecamatan {result.nama_kecamatan}, Kabupaten {result.nama_kabupaten}, {result.nama_provinsi}";
                        richTextBoxAlamatNonSurat.Text = alamatLengkap;

                        if (result.Jenis_Kelamin.Equals("Laki-Laki", StringComparison.OrdinalIgnoreCase))
                        {
                            radioButtonLKNonSurat.Checked = true;
                        }
                        else if (result.Jenis_Kelamin.Equals("Perempuan", StringComparison.OrdinalIgnoreCase))
                        {
                            radioButtonPRNonSurat.Checked = true;
                        }

                        var umur = CalculateAge((DateTime)result.Tanggal_Lahir);
                        numericUpDownUmurNonSurat.Value = umur;
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
                    string query = @"SELECT Nomor_Surat FROM daftar_surat_kematian 
                         WHERE Nomor_Surat LIKE '475/SKK-%/%/" + tahunSekarang + @"' 
                         ORDER BY id DESC LIMIT 1";

                    var result = connection.ExecuteScalar(query);

                    if (result != null)
                    {
                        string lastNumber = result.ToString();
                        if (lastNumber.Contains("SKK-"))
                        {
                            int start = lastNumber.IndexOf("SKK-") + 4;
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

            string newNomor = $"475/SKK-{nextNumber:D3}/{bulanRomawi}/{tahunSekarang}";
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

        private void btnLapor_Click(object sender, EventArgs e)
        {
            if (comboBoxNonSurat.SelectedItem == null ||
                dtpHariTglNonSurat.Value == null)
            {
                MessageBox.Show("Silakan pilih nama dan tanggal kematian terlebih dahulu.",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nama_nonsurat = comboBoxNonSurat.SelectedItem.ToString().Split(',')[1].Trim();

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan mengubah status {nama_nonsurat} menjadi MENINGGAL?",
                "Konfirmasi Ubah Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string nik_nonsurat = comboBoxNonSurat.SelectedItem.ToString().Split(',')[0].Trim();
                    UpdateStatusPenduduk(nik_nonsurat, "MENINGGAL", dtpHariTglNonSurat.Value);
                    MessageBox.Show("Status penduduk berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating data: {ex.Message}");
                }
            }
        }

        private void UpdateStatusPenduduk(string nik, string status, DateTime tglKematian)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "UPDATE gabungan_keluarga SET Status_Kependudukan = @Status, Tgl_Kematian = @TglKematian WHERE NIK = @NIK";
                connection.Execute(sql, new { Status = status, TglKematian = tglKematian, NIK = nik });
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string checkSql = "SELECT COUNT(*) FROM daftar_surat_kematian WHERE Nomor_Surat = @Nomor_Surat";
                int count = connection.ExecuteScalar<int>(checkSql, new { Nomor_Surat = txtNomorSurat.Text });
                if (count > 0)
                {
                    MessageBox.Show("Nomor Surat sudah ada. Harap gunakan Nomor Surat yang lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(textBoxNama.Text) ||
                string.IsNullOrWhiteSpace(txtWarganegara.Text) ||
                string.IsNullOrWhiteSpace(txtAgama.Text) ||
                string.IsNullOrWhiteSpace(richTextBoxAlamat.Text) ||
                string.IsNullOrWhiteSpace(richTextBoxLokasiKematian.Text) ||
                string.IsNullOrWhiteSpace(txtNamaPelapor.Text) ||
                string.IsNullOrWhiteSpace(txtHubungan.Text) ||
                string.IsNullOrWhiteSpace(txtNomorSurat.Text) ||
                string.IsNullOrWhiteSpace(txtNamaPetugas.Text) ||
                string.IsNullOrWhiteSpace(txtNamaKepalaDesa.Text) ||
                string.IsNullOrWhiteSpace(cmbPenyebab.Text))
            {
                MessageBox.Show("Harap isi semua field yang diperlukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string archiveDirectory = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Arsip Surat",
                "Surat Keterangan Kematian");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Surat_Keterangan_Kematian_{textBoxNama.Text}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfTemplatePath = "Form Suket Kematian_Form.pdf";
                string Penyimpanan = saveFileDialog.FileName;

                string saveDirectory = System.IO.Path.GetDirectoryName(Penyimpanan);

                using (PdfReader reader = new PdfReader(pdfTemplatePath))
                using (PdfWriter writer = new PdfWriter(Penyimpanan))
                using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
                {
                    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                    IDictionary<string, PdfFormField> fields = form.GetAllFormFields();

                    PdfFont regularFont = PdfFontFactory.CreateFont("Arial Narrow.ttf", PdfEncodings.IDENTITY_H);
                    PdfFont boldFont = PdfFontFactory.CreateFont("Arial Narrow Bold.ttf", PdfEncodings.IDENTITY_H);

                    SetFieldValue(fields, "NamaLengkap", textBoxNama.Text.ToUpper(), boldFont);

                    string jenisKelamin = radioButtonLK.Checked ? "Laki-Laki" : radioButtonPR.Checked ? "Perempuan" : "";

                    SetFieldValue(fields, "JenisKelamin", jenisKelamin, regularFont);

                    var umur = numericUpDownUmur.Value;
                    SetFieldValue(fields, "Umur", $"{umur} Tahun", regularFont);

                    SetFieldValue(fields, "Warganegara", CapitalizeWords(txtWarganegara.Text), regularFont);
                    SetFieldValue(fields, "Agama", CapitalizeWords(txtAgama.Text), regularFont);

                    SetFieldValue(fields, "Alamat", richTextBoxAlamat.Text, regularFont, true);
                    SetFieldValue(fields, "LokasiKematian", CapitalizeWords(richTextBoxLokasiKematian.Text), regularFont, true);

                    DateTime selectedDate = dtpHariTgl.Value;
                    string hari = selectedDate.ToString("dddd", new CultureInfo("id-ID")).ToUpper();
                    SetFieldValue(fields, "Hari", hari, boldFont);

                    string tanggal = selectedDate.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
                    SetFieldValue(fields, "Tanggal", tanggal, regularFont);

                    string jam = dtpJam.Value.ToString("HH:mm") + " WIB";
                    jam = jam.Replace('.', ':');
                    SetFieldValue(fields, "Jam", jam, regularFont);

                    string namaPelapor = txtNamaPelapor.Text.ToUpper();
                    string hubungan = "  ( " + CapitalizeWords(txtHubungan.Text) + " )";
                    SetFieldValue(fields, "Pelapor", namaPelapor + hubungan, boldFont);

                    SetFieldValue(fields, "Penyebab", cmbPenyebab.Text, regularFont);
                    SetFieldValue(fields, "TanggalSurat", DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("id-ID")), regularFont);
                    string nomorSurat = $"No : {txtNomorSurat.Text}";
                    SetFieldValue(fields, "NomorSurat", nomorSurat, regularFont);

                    string namaKepalaDesa = txtNamaKepalaDesa.Text.ToUpper();
                    SetFieldValue(fields, "NamaKepalaDesa", namaKepalaDesa, boldFont);

                    form.FlattenFields();
                    pdfDoc.Close();
                }

                SaveSuratDetailsToDatabase();
                if (comboBoxNama.SelectedItem != null || !string.IsNullOrWhiteSpace(comboBoxNama.Text))
                {
                    string nik_terlapor = comboBoxNama.SelectedItem.ToString().Split(',')[0].Trim();
                    UpdateStatusPenduduk(nik_terlapor, "MENINGGAL", dtpHariTgl.Value);
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

                        string archiveFileName = System.IO.Path.GetFileName(Penyimpanan);
                        string archiveFilePath = System.IO.Path.Combine(archiveDirectory, archiveFileName);

                        File.Copy(Penyimpanan, archiveFilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"File PDF telah tersimpan di {Penyimpanan}, tetapi gagal menyimpan salinan arsip: {ex.Message}",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNomorSurat.Text = GenerateNomorSurat();
                        return;
                    }
                }

                MessageBox.Show($"File PDF telah tersimpan di {Penyimpanan}" +
                    (!savedToArchiveDirectory ? $"\nSalinan arsip tersimpan di {archiveDirectory}" : ""),
                    "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNomorSurat.Text = GenerateNomorSurat();
            }
            else
            {
                MessageBox.Show("Penyimpanan file PDF gagal.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private int SaveSuratDetailsToDatabase()
        {
            string nik_terlapor = string.Empty;
            if (comboBoxNama.SelectedItem != null)
            {
                nik_terlapor = comboBoxNama.SelectedItem.ToString().Split(',')[0].Trim();
            }
            string tanggal_kematian = dtpHariTgl.Value.ToString("yyyy-MM-dd");

            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = @"INSERT INTO daftar_surat_kematian (Tanggal_Terbit, Nomor_Surat,  
                      NIK_Terlapor, Nama_Terlapor, Tanggal_Kematian,  
                      Penyebab_Kematian, Nama_Pelapor, Nama_Petugas) VALUES (@Tanggal_Terbit,  
                      @Nomor_Surat, @NIK_Terlapor, @Nama_Terlapor, @Tanggal_Kematian,  
                      @Penyebab_Kematian, @Nama_Pelapor, @Nama_Petugas)";

                var parameters = new
                {
                    Tanggal_Terbit = DateTime.Now,
                    Nomor_Surat = InputSanitizer.SanitizeInput(txtNomorSurat.Text),
                    NIK_Terlapor = nik_terlapor,
                    Nama_Terlapor = InputSanitizer.SanitizeInput(textBoxNama.Text),
                    Tanggal_Kematian = tanggal_kematian,
                    Penyebab_Kematian = InputSanitizer.SanitizeInput(cmbPenyebab.Text),
                    Nama_Pelapor = InputSanitizer.SanitizeInput(txtNamaPelapor.Text),
                    Nama_Petugas = InputSanitizer.SanitizeInput(txtNamaPetugas.Text),
                };

                return connection.Execute(sql, parameters);
            }
        }


        private void SetFieldValue(IDictionary<string, PdfFormField> fields, string fieldName, string value, PdfFont font, bool multiline = false)
        {
            if (fields.ContainsKey(fieldName))
            {
                var field = fields[fieldName];
                field.SetValue(value);
                field.SetFont(font);
                field.SetFontSize(12);
                if (multiline)
                {
                    field.RegenerateField();
                }
            }
        }

        private string CapitalizeWords(string input)
        {
            return Regex.Replace(input.ToLower(), @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }

        private decimal CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }
        #endregion Pelaporan Kematian

        #region Riwayat Kematian
        private void LoadIssuedSuratHistory()
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT * FROM daftar_surat_kematian ORDER BY Tanggal_Terbit DESC";
                var result = connection.Query<DaftarSurat>(sql);
                dataGridViewSurat.DataSource = result;
                //dataGridViewSurat.Columns["Nama_Petugas"].HeaderText = "Nama Petugas";
                //dataGridViewSurat.Columns["Nama_Terlapor"].HeaderText = "Nama Terlapor"; // Add this line
            }
        }

        private int GetJumlahOrangMeninggal(DateTime startDate, DateTime endDate)
        {
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT COUNT(*) FROM gabungan_keluarga WHERE Status_Kependudukan = 'MENINGGAL' AND DATE(Tgl_Kematian) >= DATE(@StartDate) AND DATE(Tgl_Kematian) <= DATE(@EndDate);";
                return connection.ExecuteScalar<int>(sql, new { StartDate = startDate, EndDate = endDate });
            }
        }

        private void btnJumlahOrangMeninggal_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            int jumlahMeninggal = GetJumlahOrangMeninggal(startDate, endDate);
            MessageBox.Show($"Jumlah orang meninggal dari {startDate.ToString("dd MMMM yyyy")} hingga {endDate.ToString("dd MMMM yyyy")} adalah {jumlahMeninggal}.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text;
            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = @"SELECT * FROM daftar_surat_kematian 
                               WHERE Nomor_Surat LIKE @Filter
                               OR NIK_Terlapor LIKE @Filter
                               OR Nama_Terlapor LIKE @Filter
                               OR Nama_Pelapor LIKE @Filter
                               OR Tanggal_Terbit LIKE @Filter";

                var result = connection.Query<DaftarSurat>(sql, new { Filter = "%" + filter + "%" });
                dataGridViewSurat.DataSource = result;
            }
        }

        private void buttonDeletePenduduk_Click(object sender, EventArgs e)
        {
            if (dataGridViewSurat.SelectedRows.Count == 0 && dataGridViewSurat.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridViewSurat.SelectedRows[0].Index;
            int Id = Convert.ToInt32(dataGridViewSurat.Rows[rowIndex].Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan menghapus riwayat dengan Id: {Id}?",
                "Konfirmasi Hapus Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        connection.Execute("DELETE FROM daftar_surat_kematian WHERE Id = @Id", new { Id });
                        LoadIssuedSuratHistory();
                        LoadStatisticsKK();
                        MessageBox.Show($"Data berhasil dihapus.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtNomorSurat.Text = GenerateNomorSurat();
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
                            FROM daftar_surat_kematian
                            WHERE MONTH(Tanggal_Terbit) = @Bulan 
                            AND YEAR(Tanggal_Terbit) = @Tahun";

                        string queryFilterTahun = @"
                            SELECT COUNT(*) 
                            FROM daftar_surat_kematian
                            WHERE YEAR(Tanggal_Terbit) = @Tahun";

                        int jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                            new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                        int jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                            new { Tahun = tahunDipilih });

                        lblPerBulanKategori.Text = $"Jumlah pengajuan Surat Keterangan Kematian bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                        lblTotalTahunKategori.Text = $"Total pengajuan Surat Keterangan Kematian tahun {tahunDipilih}: {jumlahFilterTahun}";
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
        #endregion Riwayat Surat Kematian

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadIssuedSuratHistory();
                LoadStatisticsKK();
            }
        }

        private void FormAKM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
