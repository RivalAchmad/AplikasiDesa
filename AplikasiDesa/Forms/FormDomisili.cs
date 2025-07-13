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
using Timer = System.Windows.Forms.Timer;

namespace AplikasiDesa.Forms
{
    public partial class FormDomisili : Form
    {
        private Timer typingTimer;
        private Timer sessionTimer;

        public FormDomisili()
        {
            InitializeComponent();
            VerifySession();
            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypeTimerTick;
            txtNoSurat.Text = GenerateNomorSurat();
            CultureInfo culture = new CultureInfo("id-ID");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            sessionTimer = new Timer();
            sessionTimer.Interval = 600000; // Periksa setiap 10 menit
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
            LoadSKD();
            LoadStatistikSKD();
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadSKD();
                LoadStatistikSKD();
            }
        }

        #region Formulir
        private void cmbBoxCari_KeyDown(object sender, KeyEventArgs e)
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

        private void PopulateComboBox()
        {
            string filter = cmbBoxCari.Text;

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
                        string currentText = cmbBoxCari.Text;
                        int selectionStart = cmbBoxCari.SelectionStart;

                        cmbBoxCari.BeginUpdate();
                        cmbBoxCari.Items.Clear();
                        foreach (var record in filteredRecords)
                        {
                            cmbBoxCari.Items.Add($"{record.NIK}, {record.Nama_Lengkap}");
                        }
                        cmbBoxCari.EndUpdate();

                        cmbBoxCari.Text = currentText;
                        cmbBoxCari.SelectionStart = selectionStart;

                        if (cmbBoxCari.Focused)
                        {
                            cmbBoxCari.DroppedDown = true;
                        }
                    }
                    else
                    {
                        cmbBoxCari.DroppedDown = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading names: {ex.Message}");
            }
        }

        private void cmbBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxCari.SelectedItem != null)
            {
                string selectedItem = cmbBoxCari.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                LoadPersonDataByNIK(selectedNIK);
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
                        txtNamaLengkap.Text = result.Nama_Lengkap;
                        txtNIK.Text = nik;
                        txtAgama.Text = result.Agama;
                        string alamatLengkap = $"{result.alamat}, RT {result.rt} RW {result.rw}, Desa {result.nama_desa}, Kecamatan {result.nama_kecamatan}, Kabupaten {result.nama_kabupaten}, {result.nama_provinsi}";
                        txtAlamat.Text = alamatLengkap;
                        txtWarganegara.Text = result.Kewarganegaraan;
                        string pilihan_pekerjaan = result.Jenis_Pekerjaan;
                        if (!string.IsNullOrEmpty(result.Jenis_Pekerjaan) && result.Jenis_Pekerjaan.Contains("."))
                        {
                            string pekerjaan = result.Jenis_Pekerjaan.Split('.')[1].Trim();
                            txtPekerjaan.Text = pekerjaan;
                        }
                        else
                        {
                            txtPekerjaan.Text = pilihan_pekerjaan;
                        }

                        txtTempatLahir.Text = result.Tempat_Lahir;
                        dtpTanggalLahir.Value = (DateTime)result.Tanggal_Lahir;
                        if (result.Jenis_Kelamin.Equals("Laki-laki", StringComparison.OrdinalIgnoreCase))
                        {
                            rbLK.Checked = true;
                        }
                        else if (result.Jenis_Kelamin.Equals("Perempuan", StringComparison.OrdinalIgnoreCase))
                        {
                            rbPR.Checked = true;
                        }
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
                    string query = @"SELECT No_Surat FROM sk_domisili
                         WHERE no_surat LIKE '470/SKD-%/%/" + tahunSekarang + @"' 
                         ORDER BY id DESC LIMIT 1";

                    var result = connection.ExecuteScalar(query);

                    if (result != null)
                    {
                        string lastNumber = result.ToString();
                        if (lastNumber.Contains("SKD-"))
                        {
                            int start = lastNumber.IndexOf("SKD-") + 4;
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

            string newNomor = $"470/SKD-{nextNumber:D3}/{bulanRomawi}/{tahunSekarang}";
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

        private void SetFieldValue(IDictionary<string, PdfFormField> fields, string fieldName, string value, PdfFont font, bool multiline = false)
        {
            if (fields.ContainsKey(fieldName))
            {
                PdfFormField field = fields[fieldName];
                field.SetValue(value);
                field.SetFont(font);
                field.SetFontSize(12);
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
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
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

            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string nomorSurat = txtNoSurat.Text;

                string sqlCheck = "SELECT COUNT(*) FROM sk_domisili WHERE No_Surat = @NoSurat";
                int count = connection.ExecuteScalar<int>(sqlCheck, new { NoSurat = nomorSurat });

                if (count > 0)
                {
                    MessageBox.Show("Nomor surat sudah ada di database. Harap masukkan nomor surat yang berbeda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string archiveDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Arsip Surat",
                "Surat Keterangan Domisili");

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Surat_Keterangan_Domisili_{txtNamaLengkap.Text}_{txtNIK.Text}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfTemplatePath = "Format_Suket_Domisili.pdf";
                string pdfPath = saveFileDialog.FileName;
                string saveDirectory = Path.GetDirectoryName(pdfPath);

                using (PdfReader reader = new PdfReader(pdfTemplatePath))
                using (PdfWriter writer = new PdfWriter(pdfPath))
                using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
                {
                    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                    IDictionary<string, PdfFormField> fields = form.GetAllFormFields();

                    var regularFontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Arial Narrow.ttf");
                    var boldFontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Arial Narrow Bold.ttf");

                    PdfFont regularFont = PdfFontFactory.CreateFont(regularFontPath, PdfEncodings.IDENTITY_H);
                    PdfFont boldFont = PdfFontFactory.CreateFont(boldFontPath, PdfEncodings.IDENTITY_H);

                    SetFieldValue(fields, "nama", txtNamaLengkap.Text.ToUpper(), boldFont);
                    string jenisKelamin = rbLK.Checked ? "Laki-Laki" : rbPR.Checked ? "Perempuan" : "";
                    SetFieldValue(fields, "JenisKelamin", jenisKelamin, regularFont);
                    string tempatTanggalLahir = $"{txtTempatLahir.Text}, {dtpTanggalLahir.Value.ToString("dd-MM-yyyy")}";
                    SetFieldValue(fields, "ttl", tempatTanggalLahir, regularFont);
                    SetFieldValue(fields, "warganegara", txtWarganegara.Text, regularFont);
                    SetFieldValue(fields, "agama", CapitalizeWords(txtAgama.Text), regularFont);
                    SetFieldValue(fields, "pekerjaan", CapitalizeWords(txtPekerjaan.Text), regularFont);
                    SetFieldValue(fields, "alamat", txtAlamat.Text, regularFont, true);
                    SetFieldValue(fields, "nama5", CapitalizeWords(txtNIK.Text), regularFont);
                    string alamatsingkat = txtAlamat.Text.Split(", RT")[0].Trim();
                    SetFieldValue(fields, "domisili", CapitalizeWords(alamatsingkat), regularFont);
                    SetFieldValue(fields, "petugas", txtKades.Text.ToUpper(), boldFont);
                    SetFieldValue(fields, "namart", txtKetuaRT.Text.ToUpper(), boldFont);
                    string RT = txtAlamat.Text.Split("RT")[1].Split("RW")[0].Trim();
                    string RW = txtAlamat.Text.Split("RW")[1].Split(",")[0].Trim();
                    string rtRw = $"Ketua RT {RT}/{RW}";
                    SetFieldValue(fields, "mengetahuirt", rtRw, regularFont);
                    string nomorSurat = $"NOMOR : {txtNoSurat.Text}";
                    SetFieldValue(fields, "nosurat", nomorSurat, regularFont);
                    string tanggalHariIni = DateTime.Today.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
                    string teksMengetahui = $"Desa Cibeuteung Muara, {tanggalHariIni}";
                    SetFieldValue(fields, "pembuatan", CapitalizeWords(teksMengetahui), regularFont);

                    form.FlattenFields();
                }

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sqlInsert = "INSERT INTO sk_domisili (No_Surat, Tanggal_Terbit, Nama_Pemohon, Petugas) VALUES (@NoSurat, @TanggalTerbit, @NamaPemohon, @Petugas)";
                    var parameters = new
                    {
                        NoSurat = InputSanitizer.SanitizeInput(txtNoSurat.Text),
                        TanggalTerbit = DateTime.Now,
                        NamaPemohon = InputSanitizer.SanitizeInput(txtNamaLengkap.Text),
                        Petugas = InputSanitizer.SanitizeInput(txtKades.Text)
                    };
                    connection.Execute(sqlInsert, parameters);
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

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }
        #endregion Formulir

        #region Riwayat
        private void LoadSKD()
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = "SELECT * FROM sk_domisili ORDER BY Tanggal_Terbit DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void txtNomorSurat_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtNomorSurat.Text.Trim();

            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = @"SELECT * FROM sk_domisili
                 WHERE Nama_Pemohon LIKE @keyword 
                 OR No_Surat LIKE @keyword
                 OR Tanggal_Terbit LIKE @keyword
                 ORDER BY Tanggal_Terbit DESC";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void LoadStatistikSKD()
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
                            FROM sk_domisili
                            WHERE MONTH(Tanggal_Terbit) = @Bulan
                            AND YEAR(Tanggal_Terbit) = @Tahun";

                        string queryFilterTahun = @"
                            SELECT COUNT(*) 
                            FROM sk_domisili
                            WHERE YEAR(Tanggal_Terbit) = @Tahun";

                        int jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                            new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                        int jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                            new { Tahun = tahunDipilih });

                        lblPerBulanKategori.Text = $"Jumlah pengajuan Surat Keterangan Domisili bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                        lblTotalTahunKategori.Text = $"Jumlah pengajuan Surat Keterangan Domisili tahun {tahunDipilih}: {jumlahFilterTahun}";
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
            LoadStatistikSKD();
        }

        private void comboBoxTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistikSKD();
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
            int Id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].Value);

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
                        connection.Execute("DELETE FROM sk_domisili WHERE Id = @Id", new { Id });
                        LoadSKD();
                        LoadStatistikSKD();
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
        #endregion Riwayat

        private void FormDomisili_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
