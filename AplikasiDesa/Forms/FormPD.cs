using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System.Data;
using System.Globalization;
using Timer = System.Windows.Forms.Timer;

namespace AplikasiDesa
{
    public partial class FormPD : Form
    {
        private Timer typingTimer;

        public FormPD()
        {
            ExcelPackage.License.SetNonCommercialPersonal("<Rival>");

            InitializeComponent();
            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypeTimerTick;
            LoadProvinsi();
            LoadData();
            LoadStatisticsPD();
            txtNoSurat.Text = GenerateNomorSurat();
            txtPetugas.Text = Session1.LoggedInUserName;
        }

        #region Form Surat
        private void comboBoxNomorKK_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBoxNomorKK_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxNomorKK.Text))
            {
                comboBoxNomorKK.DroppedDown = false;
                return;
            }

            typingTimer.Stop();
            typingTimer.Start();
        }

        private void PopulateComboBox()
        {
            string filter = comboBoxNomorKK.Text;

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
                        string currentText = comboBoxNomorKK.Text;
                        int selectionStart = comboBoxNomorKK.SelectionStart;

                        comboBoxNomorKK.BeginUpdate();
                        comboBoxNomorKK.Items.Clear();
                        foreach (var record in filteredRecords)
                        {
                            comboBoxNomorKK.Items.Add($"{record.NIK}, {record.Nama_Lengkap}");
                        }
                        comboBoxNomorKK.EndUpdate();

                        comboBoxNomorKK.Text = currentText;
                        comboBoxNomorKK.SelectionStart = selectionStart;

                        if (comboBoxNomorKK.Focused)
                        {
                            comboBoxNomorKK.DroppedDown = true;
                        }
                    }
                    else
                    {
                        comboBoxNomorKK.DroppedDown = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading names: {ex.Message}");
            }
        }

        private void comboBoxNomorKK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNomorKK.SelectedItem != null)
            {
                string selectedItem = comboBoxNomorKK.SelectedItem.ToString();
                string selectedNIK = selectedItem.Split(',')[0].Trim();
                string selectedNama = selectedItem.Split(',')[1].Trim();
                textBoxNamaKepalaKeluarga.Text = selectedNama;
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
                        txtNoKK.Text = result.Nomor_KK;
                        textBoxAlamat.Text = result.alamat;
                        textBoxRT.Text = result.rt;
                        textBoxRW.Text = result.rw;
                    }
                }
                LoadAnggotaKeluarga(txtNoKK.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void LoadAnggotaKeluarga(string nomorKK)
        {
            checkedListBoxAnggotaKeluarga.Items.Clear();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT NIK, Nama_Lengkap, Status_Hubungan_Dalam_Keluarga FROM gabungan_keluarga WHERE Nomor_KK = @Nomor_KK";
                    var anggotaList = connection.QueryWithDecryption<PendudukModel>(query, new { Nomor_KK = nomorKK });

                    foreach (var anggota in anggotaList)
                    {
                        string status = GetStatusCode(anggota.Status_Hubungan_Dalam_Keluarga);
                        checkedListBoxAnggotaKeluarga.Items.Add(new Tuple<string, string, string>(
                            anggota.NIK, anggota.Nama_Lengkap, status));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading anggota keluarga: {ex.Message}");
            }
        }

        private string GetStatusCode(string hubungan)
        {
            if (string.IsNullOrEmpty(hubungan))
                return "0";

            Dictionary<string, string> statusCodes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Kepala Keluarga", "1" },
                { "Suami", "2" },
                { "Istri", "3" },
                { "Anak", "4" },
                { "Menantu", "5" },
                { "Cucu", "6" },
                { "Orang Tua", "7" },
                { "Mertua", "8" },
                { "Famili Lain", "9" },
                { "Pembantu", "10" },
                { "Lainnya", "11" }
            };

            return statusCodes.TryGetValue(hubungan, out string code) ? code : "0";
        }

        private void LoadProvinsi()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT DISTINCT provinsi FROM tbl_kodepos ORDER BY provinsi";
                    var provinsi = connection.Query<string>(query);
                    comboBoxProv.Items.Clear();
                    foreach (var prov in provinsi)
                    {
                        comboBoxProv.Items.Add(prov);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading provinsi: {ex.Message}");
            }
        }

        private void comboBoxProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKota.Enabled = true;
            comboBoxKota.Items.Clear();
            comboBoxKecamatan.Items.Clear();
            comboBoxDesa.Items.Clear();
            comboBoxKodePos.Items.Clear();

            string selectedProvinsi = comboBoxProv.SelectedItem.ToString();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT DISTINCT kabupaten FROM tbl_kodepos WHERE provinsi = @provinsi ORDER BY kabupaten";
                    var kabupaten = connection.Query<string>(query, new { provinsi = selectedProvinsi });

                    foreach (var kab in kabupaten)
                    {
                        comboBoxKota.Items.Add(kab);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading kabupaten: {ex.Message}");
            }
        }

        private void comboBoxKota_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKecamatan.Enabled = true;
            comboBoxKecamatan.Items.Clear();
            comboBoxDesa.Items.Clear();
            comboBoxKodePos.Items.Clear();

            string selectedKota = comboBoxKota.SelectedItem.ToString();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT DISTINCT kecamatan FROM tbl_kodepos WHERE kabupaten = @kabupaten ORDER BY kecamatan";
                    var kecamatan = connection.Query<string>(query, new { kabupaten = selectedKota });

                    foreach (var kec in kecamatan)
                    {
                        comboBoxKecamatan.Items.Add(kec);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading kecamatan: {ex.Message}");
            }
        }

        private void comboBoxKecamatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDesa.Enabled = true;
            comboBoxDesa.Items.Clear();
            comboBoxKodePos.Items.Clear();

            string selectedKecamatan = comboBoxKecamatan.SelectedItem.ToString();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT DISTINCT kelurahan FROM tbl_kodepos WHERE kecamatan = @kecamatan ORDER BY kelurahan";
                    var kelurahan = connection.Query<string>(query, new { kecamatan = selectedKecamatan });

                    foreach (var kel in kelurahan)
                    {
                        comboBoxDesa.Items.Add(kel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading kelurahan: {ex.Message}");
            }
        }

        private void comboBoxDesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKodePos.Enabled = true;
            comboBoxKodePos.Items.Clear();

            string selectedDesa = comboBoxDesa.SelectedItem.ToString();

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT kodepos FROM tbl_kodepos WHERE kelurahan = @kelurahan";
                    var kodepos = connection.Query<string>(query, new { kelurahan = selectedDesa });

                    foreach (var kp in kodepos)
                    {
                        comboBoxKodePos.Items.Add(kp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading kodepos: {ex.Message}");
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
                    string query = @"SELECT nomor_surat FROM data_pindah 
                         WHERE nomor_surat LIKE '477/SKPD-%/%/" + tahunSekarang + @"' 
                         ORDER BY id DESC LIMIT 1";

                    var result = connection.ExecuteScalar<string>(query);

                    if (!string.IsNullOrEmpty(result) && result.Contains("SKPD-"))
                    {
                        int start = result.IndexOf("SKPD-") + 5;
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

            return $"477/SKPD-{nextNumber:D3}/{bulanRomawi}/{tahunSekarang}";
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

        private string CapitalizeWords(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFields())
            {
                MessageBox.Show("Harap lengkapi semua field sebelum menyimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!InputSanitizer.ValidateNIK(txtNoKK.Text))
            {
                MessageBox.Show("No. KK harus terdiri dari 16 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!InputSanitizer.ValidateRT_RW(textBoxRT.Text) || !InputSanitizer.ValidateRT_RW(textBoxRW.Text) || !InputSanitizer.ValidateRT_RW(textRTBaru.Text) || !InputSanitizer.ValidateRT_RW(textRWBaru.Text))
            {
                MessageBox.Show("RT dan RW harus terdiri dari 3 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noKartuKeluarga = txtNoKK.Text;
            string namaKepalaKeluarga = textBoxNamaKepalaKeluarga.Text;
            string alamat = textBoxAlamat.Text;
            string rt = textBoxRT.Text;
            string rw = textBoxRW.Text;
            string alamatBaru = richAlamatBaru.Text;
            string rtBaru = textRTBaru.Text;
            string rwBaru = textRWBaru.Text;
            string desa = CapitalizeWords(comboBoxDesa.Text);
            string kecamatan = CapitalizeWords(comboBoxKecamatan.Text);
            string kabupaten = CapitalizeWords(comboBoxKota.Text);
            string provinsi = CapitalizeWords(comboBoxProv.Text);
            string kodePos = comboBoxKodePos.Text;
            string alasanPindah = (comboBoxAlasanPindah.SelectedIndex + 1).ToString();
            string alasan = comboBoxAlasanPindah.Text;
            string klasifikasiPindah = (comboBoxKlasifikasiPindah.SelectedIndex + 1).ToString();
            string klasifikasi = comboBoxKlasifikasiPindah.Text;
            string jenisKepindahan = (comboBoxJenisKepindahan.SelectedIndex + 1).ToString();
            string jenis = comboBoxJenisKepindahan.Text;
            string statusKK = (comboBoxStatusKK.SelectedIndex + 1).ToString();
            string statuskk = comboBoxStatusKK.Text;
            string statusYangPindah = (comboBoxStatusYangPindah.SelectedIndex + 1).ToString();
            string statuspindah = comboBoxStatusYangPindah.Text;
            DateTime tanggalPindah = dateTimePickerTanggalPindah.Value;
            string NoSurat = txtNoSurat.Text;
            string petugas = txtPetugas.Text;

            using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
            {
                string checkSql = "SELECT COUNT(*) FROM data_pindah WHERE nomor_surat = @nomor_surat";
                int count = db.ExecuteScalar<int>(checkSql, new { nomor_surat = NoSurat });
                if (count > 0)
                {
                    MessageBox.Show("Nomor Surat sudah ada. Harap gunakan Nomor Surat yang lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            List<Tuple<string, string, string>> anggotaYangPindah = new List<Tuple<string, string, string>>();
            foreach (var item in checkedListBoxAnggotaKeluarga.CheckedItems)
            {
                anggotaYangPindah.Add((Tuple<string, string, string>)item);
            }

            using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string query = @"INSERT INTO data_pindah (
                                nomor_kk, nama_kepala_keluarga, nomor_surat, 
                                Tanggal_Terbit, alasan_pindah, klasifikasi_pindah, 
                                jenis_kepindahan, status_kk, status_yang_pindah, 
                                tanggal_pindah, anggota_yang_pindah) 
                                VALUES (
                                @Nomor_KK, @nama_kepala_keluarga, @nomor_surat, 
                                @Tanggal_Terbit, @alasan_pindah, @klasifikasi_pindah, 
                                @jenis_kepindahan, @status_kk, @status_yang_pindah, 
                                @tanggal_pindah, @anggota_yang_pindah)";

                var parameters = new
                {
                    Nomor_KK = InputSanitizer.SanitizeInput(noKartuKeluarga),
                    nama_kepala_keluarga = InputSanitizer.SanitizeInput(namaKepalaKeluarga),
                    nomor_surat = InputSanitizer.SanitizeInput(NoSurat),
                    Tanggal_Terbit = DateTime.Now,
                    alasan_pindah = alasan,
                    klasifikasi_pindah = klasifikasi,
                    jenis_kepindahan = jenis,
                    status_kk = statuskk,
                    status_yang_pindah = statuspindah,
                    tanggal_pindah = tanggalPindah.ToString("yyyy-MM-dd"),
                    anggota_yang_pindah = string.Join(",", anggotaYangPindah.Select(item => item.Item2))
                };

                connection.Execute(query, parameters);
            }

            string archiveDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Arsip Surat",
                "Surat Keterangan Pindah Datang");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = $"Surat_Pindah_Datang_{textBoxNamaKepalaKeluarga.Text}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var templatePath = "formatPD.xlsx";
                string penyimpanan = saveFileDialog.FileName;
                string saveDirectory = Path.GetDirectoryName(penyimpanan);

                var fileInfo = new FileInfo(templatePath);

                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    string EnsureThreeDigits(string input)
                    {
                        return input.PadLeft(3, '0');
                    }

                    string EnsureTwoDigits(string input)
                    {
                        return input.PadLeft(2, '0');
                    }

                    worksheet.Cells["I7"].Value = namaKepalaKeluarga;

                    for (int i = 0; i < noKartuKeluarga.Length && i < 16; i++)
                    {
                        worksheet.Cells[5, 9 + i].Value = noKartuKeluarga[i].ToString();
                    }

                    worksheet.Cells["I9"].Value = alamat;

                    rt = EnsureThreeDigits(rt);
                    if (rt.Length >= 3)
                    {
                        worksheet.Cells["U9"].Value = rt[0].ToString();
                        worksheet.Cells["V9"].Value = rt[1].ToString();
                        worksheet.Cells["W9"].Value = rt[2].ToString();
                    }

                    rw = EnsureThreeDigits(rw);
                    if (rw.Length >= 3)
                    {
                        worksheet.Cells["AB9"].Value = rw[0].ToString();
                        worksheet.Cells["AC9"].Value = rw[1].ToString();
                        worksheet.Cells["AD9"].Value = rw[2].ToString();
                    }

                    worksheet.Cells["I20"].Value = alamatBaru;
                    worksheet.Cells["I22"].Value = desa;
                    worksheet.Cells["I24"].Value = kecamatan;
                    worksheet.Cells["V22"].Value = kabupaten;
                    worksheet.Cells["V24"].Value = provinsi;
                    for (int i = 0; i < kodePos.Length && i < 5; i++)
                    {
                        worksheet.Cells[26, 12 + i].Value = kodePos[i].ToString();
                    }

                    rtBaru = EnsureThreeDigits(rtBaru);
                    if (rtBaru.Length >= 3)
                    {
                        worksheet.Cells["U20"].Value = rtBaru[0].ToString();
                        worksheet.Cells["V20"].Value = rtBaru[1].ToString();
                        worksheet.Cells["W20"].Value = rtBaru[2].ToString();
                    }

                    rwBaru = EnsureThreeDigits(rwBaru);
                    if (rwBaru.Length >= 3)
                    {
                        worksheet.Cells["AB20"].Value = rwBaru[0].ToString();
                        worksheet.Cells["AC20"].Value = rwBaru[1].ToString();
                        worksheet.Cells["AD20"].Value = rwBaru[2].ToString();
                    }

                    worksheet.Cells["I17"].Value = alasanPindah;
                    worksheet.Cells["I27"].Value = klasifikasiPindah;
                    worksheet.Cells["I30"].Value = jenisKepindahan;
                    worksheet.Cells["I33"].Value = statusKK;
                    worksheet.Cells["I37"].Value = statusYangPindah;

                    string day = tanggalPindah.Day.ToString("D2");
                    string month = tanggalPindah.Month.ToString("D2");
                    string year = tanggalPindah.Year.ToString();

                    worksheet.Cells["I40"].Value = day[0].ToString();
                    worksheet.Cells["J40"].Value = day[1].ToString();
                    worksheet.Cells["L40"].Value = month[0].ToString();
                    worksheet.Cells["M40"].Value = month[1].ToString();
                    worksheet.Cells["O40"].Value = year[0].ToString();
                    worksheet.Cells["P40"].Value = year[1].ToString();
                    worksheet.Cells["Q40"].Value = year[2].ToString();
                    worksheet.Cells["R40"].Value = year[3].ToString();

                    int startRow = 44;
                    for (int i = 0; i < anggotaYangPindah.Count; i++)
                    {
                        worksheet.Cells[startRow + i, 2].Value = i + 1;
                        string nik = anggotaYangPindah[i].Item1;
                        for (int j = 0; j < nik.Length && j < 16; j++)
                        {
                            worksheet.Cells[startRow + i, 4 + j].Value = nik[j].ToString();
                        }
                        worksheet.Cells[startRow + i, 20].Value = anggotaYangPindah[i].Item2;
                        string kodeStatus = anggotaYangPindah[i].Item3;
                        kodeStatus = EnsureTwoDigits(kodeStatus);
                        if (kodeStatus.Length >= 2)
                        {
                            worksheet.Cells[startRow + i, 29].Value = kodeStatus[0].ToString();
                            worksheet.Cells[startRow + i, 30].Value = kodeStatus[1].ToString();
                        }
                    }

                    worksheet.Cells["U52"].Value = $"No : {NoSurat}";
                    worksheet.Cells["L56"].Value = anggotaYangPindah[0].Item2;
                    worksheet.Cells["U56"].Value = petugas;

                    package.SaveAs(new FileInfo(penyimpanan));
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

                        string archiveFileName = Path.GetFileName(penyimpanan);
                        string archiveFilePath = Path.Combine(archiveDirectory, archiveFileName);

                        File.Copy(penyimpanan, archiveFilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"File Excel telah tersimpan di {penyimpanan}, tetapi gagal menyimpan salinan arsip: {ex.Message}",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNoSurat.Text = GenerateNomorSurat();
                        return;
                    }
                }

                MessageBox.Show($"File Excel telah tersimpan di {penyimpanan}" +
                    (!savedToArchiveDirectory ? $"\nSalinan arsip tersimpan di {archiveDirectory}" : ""),
                    "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNoSurat.Text = GenerateNomorSurat();
            }
        }

        private bool ValidateInputFields()
        {
            return !string.IsNullOrWhiteSpace(textBoxNamaKepalaKeluarga.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxAlamat.Text) &&
                   !string.IsNullOrWhiteSpace(richAlamatBaru.Text) && comboBoxDesa.SelectedItem != null &&
                   comboBoxKecamatan.SelectedItem != null &&
                   comboBoxKota.SelectedItem != null &&
                   comboBoxProv.SelectedItem != null &&
                   comboBoxKodePos.SelectedItem != null &&
                   comboBoxAlasanPindah.SelectedIndex >= 0 &&
                   comboBoxKlasifikasiPindah.SelectedIndex >= 0 &&
                   comboBoxJenisKepindahan.SelectedIndex >= 0 &&
                   comboBoxStatusKK.SelectedIndex >= 0 &&
                   comboBoxStatusYangPindah.SelectedIndex >= 0 &&
                   !string.IsNullOrWhiteSpace(txtNoSurat.Text) &&
                   !string.IsNullOrWhiteSpace(txtPetugas.Text) &&
                   checkedListBoxAnggotaKeluarga.CheckedItems.Count > 0;
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }
        #endregion Form Surat

        #region Riwayat Surat
        private void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string query = "SELECT * FROM data_pindah ORDER BY Tanggal_Terbit DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void txtNomorSurat_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtNomorSurat.Text.Trim();

            using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sql = @"SELECT * FROM data_pindah 
                               WHERE nomor_surat LIKE @keyword
                               OR nomor_kk LIKE @keyword
                               OR nama_kepala_keluarga LIKE @keyword
                               OR anggota_yang_pindah LIKE @keyword
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
                        db.Execute("DELETE FROM data_pindah WHERE id = @id", new { id });
                        LoadData();
                        LoadStatisticsPD();
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

        private void LoadStatisticsPD()
        {
            try
            {
                string[] namaBulan =
                {
                    "Januari", "Februari", "Maret", "April",
                    "Mei", "Juni", "Juli", "Agustus",
                    "September", "Oktober", "November", "Desember"
                };

                if (comboBoxBulan.SelectedItem == null || comboBoxTahun.SelectedItem == null)
                    return;

                int bulanDipilih = comboBoxBulan.SelectedIndex + 1;
                int tahunDipilih = Convert.ToInt32(comboBoxTahun.SelectedItem.ToString());

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string queryFilter = @"
                        SELECT COUNT(*) 
                        FROM data_pindah
                        WHERE MONTH(Tanggal_Terbit) = @Bulan 
                        AND YEAR(Tanggal_Terbit) = @Tahun";

                    string queryFilterTahun = @"
                        SELECT COUNT(*) 
                        FROM data_pindah
                        WHERE YEAR(Tanggal_Terbit) = @Tahun";

                    int jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                        new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                    int jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                        new { Tahun = tahunDipilih });

                    lblPerBulanKategori.Text = $"Jumlah pengajuan Surat Keterangan Pindah Datang bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                    lblTotalTahunKategori.Text = $"Total pengajuan Surat Keterangan Pindah Datang tahun {tahunDipilih}: {jumlahFilterTahun}";
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
            LoadStatisticsPD();
        }

        private void comboBoxTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatisticsPD();
        }
        #endregion Riwayat Surat

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadData();
                LoadStatisticsPD();
            }
        }

        bool visible = false;

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (visible == false)
            {
                panel8.Visible = true;
                visible = true;
            }
            else
            {
                panel8.Visible = false;
                visible = false;
            }
        }
    }
}
