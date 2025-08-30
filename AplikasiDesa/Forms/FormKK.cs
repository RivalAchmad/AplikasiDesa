using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Timer = System.Windows.Forms.Timer;

namespace AplikasiDesa.Forms
{
    public partial class FormKK : Form
    {
        private Timer typingTimer;

        public FormKK()
        {
            InitializeComponent();
            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypeTimerTick;
            LoadPengajuanKK();
            LoadStatisticsKK();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadPengajuanKK();
                LoadStatisticsKK();
            }
        }

        #region formulir Biodata Keluarga
        private void comboBoxNama_KeyDown(object sender, KeyEventArgs e)
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

        private void ConfigureDataGridViewKK()
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Status_Hubungan_Dalam_Keluarga";
            comboBoxColumn.Name = "Status_Hubungan_Dalam_Keluarga";
            comboBoxColumn.DataPropertyName = "Status_Hubungan_Dalam_Keluarga";
            comboBoxColumn.Items.AddRange(new string[] {
                "Kepala Keluarga", "Suami", "Isteri", "Anak", "Menantu", "Cucu", "Orang Tua", "Mertua", "Famili Lain", "Pembantu", "Lainnya"
            });

            if (dataGridViewKK.Columns.Contains("Status_Hubungan_Dalam_Keluarga"))
            {
                int columnIndex = dataGridViewKK.Columns["Status_Hubungan_Dalam_Keluarga"].Index;
                dataGridViewKK.Columns.Remove("Status_Hubungan_Dalam_Keluarga");
                dataGridViewKK.Columns.Insert(columnIndex, comboBoxColumn);
            }
            else
            {
                dataGridViewKK.Columns.Add(comboBoxColumn);
            }
        }

        private void dataGridViewKK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (e.Exception is ArgumentException && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = dataGridViewKK.Columns[e.ColumnIndex];
                if (column is DataGridViewComboBoxColumn)
                {
                    dataGridViewKK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
            e.Cancel = true;
        }

        private void PopulateComboBox()
        {
            string filter = comboBoxNama.Text;

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = "SELECT NIK, Nama_Lengkap FROM gabungan_keluarga";
                    var allRecords = connection.QueryWithDecryption<PendudukModel>(sql);

                    var filteredRecords = allRecords.Where(p =>
                        p.Nama_Lengkap != null &&
                        p.Nama_Lengkap.Contains(filter, StringComparison.OrdinalIgnoreCase)
                    ).ToList();

                    if (filteredRecords.Count > 0)
                    {
                        string currentText = comboBoxNama.Text;
                        int selectionStart = comboBoxNama.SelectionStart;

                        comboBoxNama.BeginUpdate();
                        comboBoxNama.Items.Clear();
                        foreach (var record in filteredRecords)
                        {
                            comboBoxNama.Items.Add($"{record.NIK}, {record.Nama_Lengkap}");
                        }
                        comboBoxNama.EndUpdate();

                        comboBoxNama.Text = currentText;
                        comboBoxNama.SelectionStart = selectionStart;

                        if (comboBoxNama.Focused)
                        {
                            comboBoxNama.DroppedDown = true;
                        }
                    }
                    else
                    {
                        comboBoxNama.DroppedDown = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading names: {ex.Message}");
            }
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

        private void HideUnneededColumns()
        {
            List<string> UnneededColumns = new List<string>
            {
                "Nomor_KK","alamat", "kode_pos", "rt", "rw", "no_hp", "email",
                "nama_provinsi", "nama_kabupaten", "nama_kecamatan", "nama_desa",
                "nama_dusun", "alamat_luar_negeri", "kota_luar_negeri",
                "provinsi_negara_bagian_luar_negeri","kode_pos_luar_negeri",
                "kode_negara", "nama_negara", "kode_perwakilan_ri", "nama_perwakilan_ri",
                "Status_Kependudukan", "Tgl_Kematian", "Tanggal_Masuk"
            };

            foreach (DataGridViewColumn column in dataGridViewKK.Columns)
            {
                if (!UnneededColumns.Contains(column.Name))
                {
                    column.Visible = true;
                }
                else
                {
                    column.Visible = false;
                }
            }

            foreach (DataGridViewColumn column in dataGridViewAnggota.Columns)
            {
                if (!UnneededColumns.Contains(column.Name))
                {
                    column.Visible = true;
                }
                else
                {
                    column.Visible = false;
                }
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
                        textBox1.Text = result.alamat;
                        textBox2.Text = result.kode_pos;
                        textBox3.Text = result.rt;
                        textBox4.Text = result.rw;
                        textBox14.Text = result.nama_dusun;
                        textBox6.Text = result.no_hp;
                        textBox7.Text = result.email;

                        textBox12.Text = result.alamat_luar_negeri;
                        textBox13.Text = result.kota_luar_negeri;
                        textBox11.Text = result.provinsi_negara_bagian_luar_negeri;
                        textBox10.Text = result.kode_pos_luar_negeri;
                        textBox9.Text = result.nama_negara;
                        textBox15.Text = result.no_hp;
                        textBox8.Text = result.email;
                        textBox5.Text = result.kode_negara;
                        textBox17.Text = result.nama_negara;
                        textBox16.Text = result.kode_perwakilan_ri;
                        textBox18.Text = result.nama_perwakilan_ri;

                        DataTable dt = new DataTable();
                        foreach (var prop in typeof(PendudukModel).GetProperties())
                        {
                            var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                            dt.Columns.Add(prop.Name, type);
                        }

                        DataRow row = dt.NewRow();
                        foreach (var prop in typeof(PendudukModel).GetProperties())
                        {
                            var value = prop.GetValue(result);
                            if (value != null)
                                row[prop.Name] = value;
                        }
                        dt.Rows.Add(row);

                        dataGridViewKK.DataSource = dt;
                        dataGridViewKK.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        ConfigureDataGridViewKK();
                        HideUnneededColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text;
            try
            {
                using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                {
                    if (long.TryParse(filter, out _))
                    {
                        string sqlNIK = @"SELECT * FROM gabungan_keluarga 
                            WHERE NIK LIKE @Filter";

                        var resultNIK = db.QueryWithDecryption<PendudukModel>(sqlNIK, new { Filter = "%" + filter + "%" });
                        dataGridViewAnggota.DataSource = resultNIK.ToList();
                    }
                    else if (!string.IsNullOrWhiteSpace(filter))
                    {
                        string sqlAll = "SELECT * FROM gabungan_keluarga";
                        var allRecords = db.QueryWithDecryption<PendudukModel>(sqlAll);

                        var filteredRecords = allRecords.Where(p =>
                            (p.Nama_Lengkap != null && p.Nama_Lengkap.Contains(filter, StringComparison.OrdinalIgnoreCase)) ||
                            (p.NIK != null && p.NIK.Contains(filter))
                        ).ToList();

                        dataGridViewAnggota.DataSource = filteredRecords;
                    }

                    ConfigureDataGridViewKK();
                    HideUnneededColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewAnggota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridViewAnggota.Rows[e.RowIndex];

                    DataTable dt = dataGridViewKK.DataSource as DataTable;

                    if (dt == null)
                    {
                        dt = new DataTable();
                        foreach (var prop in typeof(PendudukModel).GetProperties())
                        {
                            var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                            dt.Columns.Add(prop.Name, type);
                        }
                        dataGridViewKK.DataSource = dt;
                    }

                    string selectedNik = selectedRow.Cells["NIK"].Value?.ToString();

                    bool isDuplicate = false;
                    foreach (DataRow existingRow in dt.Rows)
                    {
                        if (existingRow["NIK"].ToString() == selectedNik)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    if (isDuplicate)
                    {
                        MessageBox.Show("Data dengan NIK ini sudah ada dalam daftar anggota keluarga.",
                                        "Duplikat Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataRow newRow = dt.NewRow();

                    foreach (DataGridViewColumn column in dataGridViewAnggota.Columns)
                    {
                        if (column.Index > 0)
                        {
                            string columnName = column.Name;
                            if (dt.Columns.Contains(columnName) && selectedRow.Cells[columnName].Value != null)
                            {
                                newRow[columnName] = selectedRow.Cells[columnName].Value;
                            }
                        }
                    }
                    dt.Rows.Add(newRow);
                    dataGridViewKK.Refresh();
                    dataGridViewKK.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    ConfigureDataGridViewKK();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat menambahkan data: {ex.Message}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewKK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow selectedRow = dataGridViewKK.Rows[e.RowIndex];
                DataTable dt = dataGridViewKK.DataSource as DataTable;
                if (dt != null)
                {
                    dt.Rows.RemoveAt(e.RowIndex);
                    dataGridViewKK.Refresh();
                    dataGridViewKK.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Silakan pilih salah satu jenis formulir (Kepala Keluarga WNI, Orang Asing, atau WNI Luar Negeri).",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxNama.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih Kepala Keluarga terlebih dahulu.",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Alamat tidak boleh kosong.",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Kode Pos tidak boleh kosong.",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (!InputSanitizer.ValidateRT_RW(textBox3.Text) || !InputSanitizer.ValidateRT_RW(textBox4.Text))
            {
                MessageBox.Show("RT dan RW harus terdiri dari 3 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Masukkan jumlah anggota keluarga.",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox14.Text))
            {
                MessageBox.Show("Dusun tidak boleh kosong.",
                               "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox14.Focus();
                return;
            }

            if (!InputSanitizer.ValidatePhone(textBox6.Text))
            {
                MessageBox.Show("Format nomor telepon tidak valid.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = dataGridViewKK.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridViewKK.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridViewKK.Rows[i];
                    if (row.Cells["Status_Hubungan_Dalam_Keluarga"].Value == null ||
                        string.IsNullOrWhiteSpace(row.Cells["Status_Hubungan_Dalam_Keluarga"].Value.ToString()))
                    {
                        MessageBox.Show($"Status hubungan dalam keluarga pada baris {i + 1} tidak boleh kosong.",
                                       "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridViewKK.CurrentCell = row.Cells["Status_Hubungan_Dalam_Keluarga"];
                        dataGridViewKK.Focus();
                        return;
                    }
                }
            }

            string templatePath = "FI.01 Form KK.xlsx";

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx|PDF Files|*.pdf",
                    Title = "Simpan hasil cetak FI.01 Form KK",
                    FileName = $"FI.01 Form KK-{comboBoxNama.Text}",
                    DefaultExt = "xlsx"
                };

                string archiveDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Arsip Surat",
                    "Formulir Biodata Keluarga");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = saveFileDialog.FileName;
                    string saveDirectory = Path.GetDirectoryName(saveFilePath);
                    string extension = Path.GetExtension(saveFilePath).ToLower();

                    string excelFilePath = extension == ".xlsx" ?
                        saveFilePath :
                        Path.ChangeExtension(saveFilePath, ".xlsx");

                    string generatedExcelFile = SaveDataGridViewToExcel(templatePath, excelFilePath);

                    string pdfFilePath = extension == ".pdf" ?
                        saveFilePath :
                        Path.ChangeExtension(saveFilePath, ".pdf");

                    ConvertExcelToPdf(generatedExcelFile, pdfFilePath);

                    int idPengajuan = SimpanPengajuanKK();

                    bool savedToArchiveDirectory = saveDirectory.Equals(archiveDirectory, StringComparison.OrdinalIgnoreCase);

                    if (!savedToArchiveDirectory)
                    {
                        try
                        {
                            if (!Directory.Exists(archiveDirectory))
                            {
                                Directory.CreateDirectory(archiveDirectory);
                            }

                            string archiveFileName = Path.GetFileName(saveFilePath);
                            string archiveFilePath = Path.Combine(archiveDirectory, archiveFileName);

                            File.Copy(saveFilePath, archiveFilePath, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"File telah tersimpan di {saveFilePath}, tetapi gagal menyimpan salinan arsip: {ex.Message}",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (idPengajuan > 0)
                    {
                        MessageBox.Show($"File PDF dan Excel telah tersimpan di {saveFilePath}" +
                        (!savedToArchiveDirectory ? $"\nSalinan arsip tersimpan di {archiveDirectory}" : ""),
                        "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"File berhasil disimpan sebagai Excel dan PDF: {excelFilePath} & {pdfFilePath}, " +
                                      "tetapi gagal menyimpan data pengajuan ke database.",
                                      "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memproses file: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveDataGridViewToExcel(string templatePath, string outputPath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                File.Copy(templatePath, outputPath, true);

                workbook = excelApp.Workbooks.Open(outputPath);
                worksheet = workbook.Sheets[1];

                string FormatDate(object date)
                {
                    if (date is DateTime dateTime)
                        return dateTime.ToString("dd-MM-yyyy");
                    else if (DateTime.TryParse(date?.ToString(), out dateTime))
                        return dateTime.ToString("dd-MM-yyyy");
                    return " ";
                }

                string SafeGetCellValue(DataGridViewRow row, string columnName)
                {
                    var cell = row.Cells[columnName];
                    return cell?.Value?.ToString().ToUpper() ?? " ";
                }

                string EnsureThreeDigits(string input)
                {
                    return input.PadLeft(3, '0');
                }

                string EnsureTwoDigits(string input)
                {
                    return input.PadLeft(2, '0');
                }

                if (radioButton1.Checked)
                {
                    foreach (Excel.Shape shape in worksheet.Shapes)
                    {
                        if (shape.Name == "Rectangle 4")
                        {
                            shape.TextFrame.Characters().Text = "✔";
                            break;
                        }
                    }
                }
                else if (radioButton2.Checked)
                {
                    foreach (Excel.Shape shape in worksheet.Shapes)
                    {
                        if (shape.Name == "Rectangle 2")
                        {
                            shape.TextFrame.Characters().Text = "✔";
                            break;
                        }
                    }
                }
                else if (radioButton3.Checked)
                {
                    foreach (Excel.Shape shape in worksheet.Shapes)
                    {
                        if (shape.Name == "Rectangle 3")
                        {
                            shape.TextFrame.Characters().Text = "✔";
                            break;
                        }
                    }
                }

                string nama_kepala_keluarga = comboBoxNama.SelectedItem.ToString().Split(',')[1].Trim().ToUpper();
                string alamat = textBox1.Text.ToUpper();

                worksheet.Range[$"S14"].Value = nama_kepala_keluarga;
                worksheet.Range[$"S16"].Value = alamat;

                string rt = textBox3.Text;
                rt = EnsureThreeDigits(rt);
                if (rt.Length >= 3)
                {
                    worksheet.Range[$"AB20"].Value = rt[0].ToString();
                    worksheet.Range[$"AC20"].Value = rt[1].ToString();
                    worksheet.Range[$"AD20"].Value = rt[2].ToString();
                }

                string rw = textBox4.Text;
                rw = EnsureThreeDigits(rw);
                if (rw.Length >= 3)
                {
                    worksheet.Range[$"AI20"].Value = rw[0].ToString();
                    worksheet.Range[$"AJ20"].Value = rw[1].ToString();
                    worksheet.Range[$"AK20"].Value = rw[2].ToString();
                }

                string jumlahAnggotaKeluarga = numericUpDown1.Value.ToString();
                jumlahAnggotaKeluarga = EnsureThreeDigits(jumlahAnggotaKeluarga);
                if (jumlahAnggotaKeluarga.Length >= 3)
                {
                    worksheet.Range[$"AX20"].Value = jumlahAnggotaKeluarga[0].ToString();
                    worksheet.Range[$"AY20"].Value = jumlahAnggotaKeluarga[1].ToString();
                    worksheet.Range[$"AZ20"].Value = jumlahAnggotaKeluarga[2].ToString();
                }

                worksheet.Range[$"S22"].Value = textBox6.Text; // telepon
                worksheet.Range[$"S24"].Value = textBox7.Text; // email
                worksheet.Range[$"S35"].Value = textBox14.Text.ToUpper(); // nama dusun
                worksheet.Range[$"N37"].Value = textBox12.Text.ToUpper(); // alamat luar negeri
                worksheet.Range[$"N39"].Value = textBox13.Text.ToUpper(); // kota luar negeri
                worksheet.Range[$"AL39"].Value = textBox11.Text.ToUpper(); // provinsi
                worksheet.Range[$"N41"].Value = textBox9.Text.ToUpper(); // negara luar negeri
                worksheet.Range[$"N43"].Value = textBox10.Text; // kode pos luar negeri

                string jumlahAnggotaKeluargaLN = numericUpDown2.Value.ToString();
                jumlahAnggotaKeluargaLN = EnsureTwoDigits(jumlahAnggotaKeluargaLN);
                if (jumlahAnggotaKeluargaLN.Length >= 2)
                {
                    worksheet.Range[$"AM43"].Value = jumlahAnggotaKeluargaLN[0].ToString();
                    worksheet.Range[$"AN43"].Value = jumlahAnggotaKeluargaLN[1].ToString();
                }

                string teleponLuarNegeri = textBox15.Text;
                for (int a = 0; a < teleponLuarNegeri.Length; a++)
                {
                    int targetColumn = 78 + a; // 78 is ASCII for 'N'
                    if (targetColumn > 90) break; // Stop if it goes past 'Z'
                    worksheet.Range[$"{(char)targetColumn}45"].Value = teleponLuarNegeri[a].ToString();
                }

                worksheet.Range[$"N47"].Value = textBox8.Text; // email luar negeri

                string kodenegara = textBox5.Text;
                kodenegara = EnsureThreeDigits(kodenegara);
                if (kodenegara.Length >= 3)
                {
                    worksheet.Range[$"N49"].Value = kodenegara[0].ToString();
                    worksheet.Range[$"O49"].Value = kodenegara[1].ToString();
                    worksheet.Range[$"P49"].Value = kodenegara[2].ToString();
                }

                worksheet.Range[$"S49"].Value = textBox17.Text.ToUpper(); // nama negara

                string kodeperwakilan = textBox16.Text;
                kodeperwakilan = EnsureTwoDigits(kodeperwakilan);
                if (kodeperwakilan.Length >= 2)
                {
                    worksheet.Range[$"N51"].Value = kodeperwakilan[0].ToString();
                    worksheet.Range[$"O51"].Value = kodeperwakilan[1].ToString();
                }

                worksheet.Range[$"S51"].Value = textBox18.Text.ToUpper(); // nama perwakilan ri
                worksheet.Range[$"AN145"].Value = nama_kepala_keluarga;

                // Loop through DataGridView rows
                for (int i = 0; i < dataGridViewKK.Rows.Count && i < 10; i++)
                {
                    var row = dataGridViewKK.Rows[i];
                    if (row == null) continue; // Skip null rows

                    worksheet.Range[$"B{64 + i}"].Value = SafeGetCellValue(row, "Nama_Lengkap");
                    worksheet.Range[$"S{64 + i}"].Value = SafeGetCellValue(row, "Gelar_Depan");
                    worksheet.Range[$"W{64 + i}"].Value = SafeGetCellValue(row, "Gelar_Belakang");
                    worksheet.Range[$"AA{64 + i}"].Value = SafeGetCellValue(row, "Passport_Number");
                    worksheet.Range[$"AH{64 + i}"].Value = FormatDate(row.Cells["Tgl_Berakhir_Paspor"].Value);
                    worksheet.Range[$"AP{64 + i}"].Value = SafeGetCellValue(row, "Nama_Sponsor");
                    worksheet.Range[$"B{78 + i}"].Value = SafeGetCellValue(row, "Tipe_Sponsor");
                    worksheet.Range[$"G{78 + i}"].Value = SafeGetCellValue(row, "Alamat_Sponsor");
                    worksheet.Range[$"O{78 + i}"].Value = SafeGetCellValue(row, "Jenis_Kelamin");
                    worksheet.Range[$"U{78 + i}"].Value = SafeGetCellValue(row, "Tempat_Lahir");
                    worksheet.Range[$"AB{78 + i}"].Value = FormatDate(row.Cells["Tanggal_Lahir"].Value);
                    worksheet.Range[$"AK{78 + i}"].Value = SafeGetCellValue(row, "Kewarganegaraan");
                    worksheet.Range[$"AR{78 + i}"].Value = SafeGetCellValue(row, "No_SK_Penetapan_WNI");
                    worksheet.Range[$"B{98 + i}"].Value = SafeGetCellValue(row, "Nomor_Akta_Kelahiran");
                    worksheet.Range[$"I{98 + i}"].Value = SafeGetCellValue(row, "Golongan_Darah");
                    worksheet.Range[$"M{98 + i}"].Value = SafeGetCellValue(row, "Agama");
                    worksheet.Range[$"Q{98 + i}"].Value = SafeGetCellValue(row, "Nama_Organisasi_Kepercayaan");
                    worksheet.Range[$"AD{98 + i}"].Value = SafeGetCellValue(row, "Status_Perkawinan");
                    worksheet.Range[$"AK{98 + i}"].Value = SafeGetCellValue(row, "Akta_Perkawinan");
                    worksheet.Range[$"AP{98 + i}"].Value = SafeGetCellValue(row, "Nomor_Akta_Perkawinan");
                    worksheet.Range[$"AY{98 + i}"].Value = FormatDate(row.Cells["Tanggal_Perkawinan"].Value);
                    worksheet.Range[$"B{112 + i}"].Value = SafeGetCellValue(row, "Akta_Cerai");
                    worksheet.Range[$"E{112 + i}"].Value = SafeGetCellValue(row, "Nomor_Akta_Cerai");
                    worksheet.Range[$"J{112 + i}"].Value = FormatDate(row.Cells["Tanggal_Perceraian"].Value);
                    worksheet.Range[$"M{112 + i}"].Value = SafeGetCellValue(row, "Status_Hubungan_Dalam_Keluarga");
                    worksheet.Range[$"T{112 + i}"].Value = SafeGetCellValue(row, "Kelainan_Fisik_dan_Mental");
                    worksheet.Range[$"AA{112 + i}"].Value = SafeGetCellValue(row, "Penyandang_Cacat");
                    worksheet.Range[$"AF{112 + i}"].Value = SafeGetCellValue(row, "Pendidikan_Terakhir");
                    string jenisPekerjaan = SafeGetCellValue(row, "Jenis_Pekerjaan").Split('.')[0];
                    worksheet.Range[$"AK{112 + i}"].Value = jenisPekerjaan;
                    worksheet.Range[$"AO{112 + i}"].Value = SafeGetCellValue(row, "Nomor_ITAS_ITAP");
                    worksheet.Range[$"AV{112 + i}"].Value = FormatDate(row.Cells["Tempat_Terbit_ITAS_ITAP"].Value);
                    worksheet.Range[$"B{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Range[$"G{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Akhir_ITAS_ITAP"].Value);
                    worksheet.Range[$"K{126 + i}"].Value = SafeGetCellValue(row, "Tempat_Datang_Pertama");
                    worksheet.Range[$"S{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Kedatangan_Pertama"].Value);
                    worksheet.Range[$"Z{126 + i}"].Value = SafeGetCellValue(row, "NIK_Ibu");
                    worksheet.Range[$"AG{126 + i}"].Value = SafeGetCellValue(row, "Nama_Ibu");
                    worksheet.Range[$"AO{126 + i}"].Value = SafeGetCellValue(row, "NIK_Ayah");
                    worksheet.Range[$"AU{126 + i}"].Value = SafeGetCellValue(row, "Nama_Ayah");
                }

                // Save and close
                workbook.Save();

                return outputPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving Excel file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Clean up all COM objects
                if (worksheet != null) ReleaseObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(true);
                    ReleaseObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    ReleaseObject(excelApp);
                }

                // Force garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void ConvertExcelToPdf(string excelFilePath, string pdfFilePath)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfFilePath);

            workbook.Close(false);
            excelApp.Quit();

            ReleaseObject(workbook);
            ReleaseObject(excelApp);
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private int SimpanPengajuanKK()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string selectedItem = comboBoxNama.SelectedItem.ToString();
                        string nikKepala = selectedItem.Split(',')[0].Trim();

                        string jenisFormulir = "";
                        if (radioButton1.Checked) jenisFormulir = "WNI";
                        else if (radioButton2.Checked) jenisFormulir = "Orang Asing";
                        else if (radioButton3.Checked) jenisFormulir = "WNI Luar Negeri";

                        string sqlHeader = @"INSERT INTO pengajuan_kk (tanggal_pengajuan, nik_kepala, jenis_formulir) 
                            VALUES (@tanggal, @nik, @jenis);
                            SELECT LAST_INSERT_ID();";

                        MySqlCommand cmdHeader = new MySqlCommand(sqlHeader, connection, transaction);
                        cmdHeader.Parameters.AddWithValue("@tanggal", DateTime.Now);
                        cmdHeader.Parameters.AddWithValue("@nik", nikKepala);
                        cmdHeader.Parameters.AddWithValue("@jenis", jenisFormulir);

                        // Dapatkan ID pengajuan yang baru dibuat
                        int idPengajuan = Convert.ToInt32(cmdHeader.ExecuteScalar());

                        // 2. Simpan anggota keluarga dari dataGridViewKK
                        string sqlAnggota = @"INSERT INTO anggota_pengajuan_kk (id_pengajuan, nik, nama_lengkap, status_hubungan) 
                             VALUES (@id_pengajuan, @nik, @nama, @status)";

                        MySqlCommand cmdAnggota = new MySqlCommand(sqlAnggota, connection, transaction);

                        // Ambil data dari dataGridViewKK
                        DataTable dt = dataGridViewKK.DataSource as DataTable;
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                // Reset parameter untuk setiap baris
                                cmdAnggota.Parameters.Clear();

                                string nik = row["NIK"].ToString();
                                string nama = row["Nama_Lengkap"].ToString();
                                string status = row["Status_Hubungan_Dalam_Keluarga"]?.ToString() ?? "";

                                // Enkripsi nama_lengkap sebelum disimpan ke database
                                var namaModel = new PendudukModel
                                {
                                    Nama_Lengkap = nama
                                };
                                var encryptedNamaModel = namaModel.EncryptModel();
                                string encryptedNama = encryptedNamaModel.Nama_Lengkap;

                                cmdAnggota.Parameters.AddWithValue("@id_pengajuan", idPengajuan);
                                cmdAnggota.Parameters.AddWithValue("@nik", nik);
                                cmdAnggota.Parameters.AddWithValue("@nama", encryptedNama);
                                cmdAnggota.Parameters.AddWithValue("@status", status);

                                cmdAnggota.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return idPengajuan;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saat menyimpan pengajuan KK: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error koneksi database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        private void btnTambahData_Click(object sender, EventArgs e)
        {
            FormTambahPenduduk form = new FormTambahPenduduk();
            form.ShowDialog();
        }
        #endregion Formulir Biodata Keluarga

        #region Pengelolaan Kartu Keluarta
        private void LoadPengajuanKK()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    string sql = @"SELECT p.id, p.tanggal_pengajuan, p.nik_kepala, 
                                 (SELECT nama_lengkap FROM gabungan_keluarga WHERE NIK = p.nik_kepala LIMIT 1) AS nama_kepala, 
                                 p.jenis_formulir, p.status, p.nomor_kk_baru,
                                 (SELECT COUNT(*) FROM anggota_pengajuan_kk WHERE id_pengajuan = p.id) AS jumlah_anggota
                                 FROM pengajuan_kk p
                                 ORDER BY p.tanggal_pengajuan DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["nama_kepala"] != DBNull.Value)
                        {
                            string encryptedNama = row["nama_kepala"].ToString();
                            var namaModel = new PendudukModel
                            {
                                Nama_Lengkap = encryptedNama
                            };
                            var decryptedNamaModel = namaModel.DecryptModel();
                            row["nama_kepala"] = decryptedNamaModel.Nama_Lengkap;
                        }
                    }

                    dataGridViewPengajuan.DataSource = dt;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridViewPengajuan.Columns.Count == 0) return;

            dataGridViewPengajuan.Columns["id"].HeaderText = "ID";
            dataGridViewPengajuan.Columns["tanggal_pengajuan"].HeaderText = "Tanggal Pengajuan";
            dataGridViewPengajuan.Columns["nik_kepala"].HeaderText = "NIK Kepala";
            dataGridViewPengajuan.Columns["nama_kepala"].HeaderText = "Nama Kepala";
            dataGridViewPengajuan.Columns["jenis_formulir"].HeaderText = "Jenis Formulir";
            dataGridViewPengajuan.Columns["status"].HeaderText = "Status";
            dataGridViewPengajuan.Columns["nomor_kk_baru"].HeaderText = "Nomor KK Baru";
            dataGridViewPengajuan.Columns["jumlah_anggota"].HeaderText = "Jumlah Anggota";

            dataGridViewPengajuan.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void textCariSurat_TextChanged(object sender, EventArgs e)
        {
            string keyword = textCariSurat.Text.Trim();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    string sql = @"SELECT p.id, p.tanggal_pengajuan, p.nik_kepala, 
                     (SELECT nama_lengkap FROM gabungan_keluarga WHERE NIK = p.nik_kepala LIMIT 1) AS nama_kepala, 
                     p.jenis_formulir, p.status, p.nomor_kk_baru,
                     (SELECT COUNT(*) FROM anggota_pengajuan_kk WHERE id_pengajuan = p.id) AS jumlah_anggota
                     FROM pengajuan_kk p
                     WHERE p.nik_kepala LIKE @keyword 
                     OR p.jenis_formulir LIKE @keyword
                     OR p.tanggal_pengajuan LIKE @keyword
                     OR EXISTS (SELECT 1 FROM gabungan_keluarga WHERE NIK = p.nik_kepala AND nama_lengkap LIKE @keyword)
                     ORDER BY p.tanggal_pengajuan DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewPengajuan.DataSource = dt;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridViewPengajuan.SelectedRows.Count > 0)
            {
                int idPengajuan = Convert.ToInt32(dataGridViewPengajuan.SelectedRows[0].Cells["id"].Value);
                FormDetailPengajuanKK form = new FormDetailPengajuanKK(idPengajuan);
                form.ShowDialog();

                LoadPengajuanKK();
            }
            else
            {
                MessageBox.Show("Pilih data pengajuan terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateNomorKK_Click(object sender, EventArgs e)
        {
            if (dataGridViewPengajuan.SelectedRows.Count > 0)
            {
                int idPengajuan = Convert.ToInt32(dataGridViewPengajuan.SelectedRows[0].Cells["id"].Value);
                string nikKepala = dataGridViewPengajuan.SelectedRows[0].Cells["nik_kepala"].Value.ToString();

                // Tampilkan form input nomor KK baru
                using (FormInputNomorKK form = new FormInputNomorKK())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string nomorKKBaru = form.NomorKK;

                        UpdatePengajuanKK(idPengajuan, nomorKKBaru);

                        UpdateNomorKKAnggota(idPengajuan, nomorKKBaru);

                        LoadPengajuanKK();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data pengajuan terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridViewPengajuan.SelectedRows.Count == 0 && dataGridViewPengajuan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridViewPengajuan.SelectedRows[0].Index;
            int id = Convert.ToInt32(dataGridViewPengajuan.Rows[rowIndex].Cells["id"].Value);

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan menghapus riwayat dengan Id: {id}?",
                "Konfirmasi Hapus Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        connection.Open();
                        MySqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            string deleteAnggotaQuery = "DELETE FROM anggota_pengajuan_kk WHERE id_pengajuan = @id";
                            MySqlCommand cmdDeleteAnggota = new MySqlCommand(deleteAnggotaQuery, connection, transaction);
                            cmdDeleteAnggota.Parameters.AddWithValue("@id", id);
                            cmdDeleteAnggota.ExecuteNonQuery();

                            string deletePengajuanQuery = "DELETE FROM pengajuan_kk WHERE id = @id";
                            MySqlCommand cmdDeletePengajuan = new MySqlCommand(deletePengajuanQuery, connection, transaction);
                            cmdDeletePengajuan.Parameters.AddWithValue("@id", id);
                            cmdDeletePengajuan.ExecuteNonQuery();

                            transaction.Commit();
                            LoadPengajuanKK();
                            LoadStatisticsKK();
                            MessageBox.Show($"Data pengajuan dan anggota pengajuan berhasil dihapus.",
                                           "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error saat menghapus data: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdatePengajuanKK(int idPengajuan, string nomorKK)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = @"UPDATE pengajuan_kk 
                          SET nomor_kk_baru = @nomor_kk,
                              status = 'Selesai' 
                          WHERE id = @id";

                    connection.Execute(sql, new
                    {
                        nomor_kk = nomorKK,
                        id = idPengajuan
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating pengajuan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNomorKKAnggota(int idPengajuan, string nomorKK)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sqlAnggota = @"SELECT nik, status_hubungan 
                                     FROM anggota_pengajuan_kk 
                                     WHERE id_pengajuan = @id";

                        MySqlCommand cmdAnggota = new MySqlCommand(sqlAnggota, connection, transaction);
                        cmdAnggota.Parameters.AddWithValue("@id", idPengajuan);

                        Dictionary<string, string> anggotaData = new Dictionary<string, string>();

                        using (MySqlDataReader reader = cmdAnggota.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nik = reader.GetString(0);
                                string statusHubungan = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                anggotaData.Add(nik, statusHubungan);
                            }
                        }

                        string sqlUpdate = @"UPDATE gabungan_keluarga 
                                   SET nomor_kk = @nomor_kk, 
                                       Status_Hubungan_Dalam_Keluarga = @status_hubungan 
                                   WHERE NIK = @nik";

                        MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, connection, transaction);

                        int count = 0;
                        foreach (var pair in anggotaData)
                        {
                            string nik = pair.Key;
                            string statusHubungan = pair.Value;

                            cmdUpdate.Parameters.Clear();
                            cmdUpdate.Parameters.AddWithValue("@nomor_kk", nomorKK);
                            cmdUpdate.Parameters.AddWithValue("@status_hubungan", statusHubungan);
                            cmdUpdate.Parameters.AddWithValue("@nik", nik);

                            count += cmdUpdate.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show($"Berhasil mengupdate nomor KK dan status hubungan untuk {count} anggota keluarga",
                                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mengupdate data anggota keluarga: " + ex.Message,
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (comboBoxJenisFormulir.SelectedItem != null &&
                    comboBoxBulan.SelectedItem != null &&
                    comboBoxTahun.SelectedItem != null)
                {
                    string jenisFormulir = comboBoxJenisFormulir.SelectedItem.ToString();
                    int bulanDipilih = comboBoxBulan.SelectedIndex + 1;
                    int tahunDipilih = Convert.ToInt32(comboBoxTahun.SelectedItem.ToString());

                    using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        string queryFilter;
                        string queryFilterTahun;
                        int jumlahFilterBulan;
                        int jumlahFilterTahun;

                        if (jenisFormulir == "Semua")
                        {
                            queryFilter = @"
                                SELECT COUNT(*) 
                                FROM pengajuan_kk 
                                WHERE MONTH(tanggal_pengajuan) = @Bulan 
                                AND YEAR(tanggal_pengajuan) = @Tahun";

                            queryFilterTahun = @"
                                SELECT COUNT(*) 
                                FROM pengajuan_kk 
                                WHERE YEAR(tanggal_pengajuan) = @Tahun";

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
                                FROM pengajuan_kk 
                                WHERE jenis_formulir = @JenisFormulir 
                                AND MONTH(tanggal_pengajuan) = @Bulan 
                                AND YEAR(tanggal_pengajuan) = @Tahun";

                            queryFilterTahun = @"
                                SELECT COUNT(*) 
                                FROM pengajuan_kk 
                                WHERE jenis_formulir = @JenisFormulir 
                                AND YEAR(tanggal_pengajuan) = @Tahun";

                            jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                                new { JenisFormulir = jenisFormulir, Bulan = bulanDipilih, Tahun = tahunDipilih });

                            jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                                new { JenisFormulir = jenisFormulir, Tahun = tahunDipilih });

                            lblPerBulanKategori.Text = $"Jumlah pengajuan {jenisFormulir} bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                            lblTotalTahunKategori.Text = $"Total pengajuan {jenisFormulir} tahun {tahunDipilih}: {jumlahFilterTahun}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat statistik: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxJenisFormulir_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatisticsKK();
        }

        private void comboBoxBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatisticsKK();
        }

        private void comboBoxTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatisticsKK();
        }
        #endregion Pengelolaan Kartu Keluarga
    }
}
