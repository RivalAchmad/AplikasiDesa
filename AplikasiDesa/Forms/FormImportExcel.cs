using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace AplikasiDesa.Forms
{
    public partial class FormImportExcel : Form
    {
        private string selectedFilePath = "";
        private List<PendudukModel> validDataList = new List<PendudukModel>();
        private List<string> errorList = new List<string>();
        private bool isValidationSuccessful = false;

        public FormImportExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("<Rival>");
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            toolTip.SetToolTip(btnDownloadTemplate, "Download template Excel dengan format dan validasi yang sesuai");
            toolTip.SetToolTip(btnBrowseFile, "Pilih file Excel (.xlsx) yang ingin diimport");
            toolTip.SetToolTip(btnValidate, "Validasi data dalam file Excel sebelum import");
            toolTip.SetToolTip(btnImport, "Import data yang telah divalidasi ke database");
        }

        #region Event Handlers
        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Simpan Template Import Penduduk",
                    FileName = "Template_Import_Penduduk.xlsx",
                    DefaultExt = "xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CreateExcelTemplateFile(saveFileDialog.FileName);
                    MessageBox.Show($"Template Excel berhasil disimpan di:\n{saveFileDialog.FileName}\n\nTemplate sudah dilengkapi dengan:\n- Dropdown validation untuk kolom tertentu\n- Format data yang sesuai\n- Contoh data untuk referensi",
                                    "Template Tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuat template: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                lblSelectedFile.Text = Path.GetFileName(selectedFilePath);
                lblSelectedFile.ForeColor = Color.Black;

                FileInfo fileInfo = new FileInfo(selectedFilePath);
                lblFileInfo.Text = $"Ukuran: {FormatFileSize(fileInfo.Length)} | Dibuat: {fileInfo.CreationTime:dd/MM/yyyy HH:mm}";

                btnValidate.Enabled = true;
                btnImport.Enabled = false;

                ClearValidationResults();
                LoadFilePreview();
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("Pilih file Excel terlebih dahulu.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (backgroundWorkerValidation.IsBusy)
            {
                MessageBox.Show("Validasi sedang berjalan. Harap tunggu hingga selesai.", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearValidationResults();
            lblValidationStatus.Text = "Memulai validasi data...";
            lblValidationStatus.ForeColor = Color.Blue;
            progressBarValidation.Visible = true;
            progressBarValidation.Value = 0;
            btnValidate.Enabled = false;
            btnImport.Enabled = false;
            btnBrowseFile.Enabled = false;
            backgroundWorkerValidation.RunWorkerAsync(selectedFilePath);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!isValidationSuccessful || validDataList.Count == 0)
            {
                MessageBox.Show("Lakukan validasi data terlebih dahulu dan pastikan tidak ada error.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin ingin mengimport {validDataList.Count} record ke database?\n\nProses ini tidak dapat dibatalkan.",
                "Konfirmasi Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (backgroundWorkerImport.IsBusy)
                {
                    MessageBox.Show("Import sedang berjalan. Harap tunggu hingga selesai.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblValidationStatus.Text = "Memulai import data ke database...";
                lblValidationStatus.ForeColor = Color.Blue;
                progressBarValidation.Visible = true;
                progressBarValidation.Value = 0;
                btnValidate.Enabled = false;
                btnImport.Enabled = false;
                btnBrowseFile.Enabled = false;
                backgroundWorkerImport.RunWorkerAsync(validDataList);
            }
        }

        private void FormImportExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerValidation.IsBusy)
            {
                backgroundWorkerValidation.CancelAsync();
            }
            if (backgroundWorkerImport.IsBusy)
            {
                backgroundWorkerImport.CancelAsync();
            }
            CleanupResources();
        }
        #endregion

        #region File Operations
        private void CreateExcelTemplateFile(string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Data Import");

                var headers = new string[]
                {
                    "NIK", "Nomor_KK", "Nama_Lengkap", "Jenis_Kelamin", "Tempat_Lahir", "Tanggal_Lahir",
                    "Kewarganegaraan", "Jenis_Pekerjaan", "alamat", "rt", "rw", "nama_dusun", "Agama",
                    "Pendidikan_Terakhir", "Gelar_Depan", "Gelar_Belakang", "no_hp", "email",
                    "Passport_Number", "Tgl_Berakhir_Paspor", "No_SK_Penetapan_WNI", "Akta_Lahir",
                    "Nomor_Akta_Kelahiran", "Golongan_Darah", "Nama_Organisasi_Kepercayaan",
                    "Status_Perkawinan", "Tanggal_Perkawinan", "Akta_Perkawinan", "Nomor_Akta_Perkawinan",
                    "Akta_Cerai", "Nomor_Akta_Cerai", "Tanggal_Perceraian", "Status_Hubungan_Dalam_Keluarga",
                    "Kelainan_Fisik_dan_Mental", "Penyandang_Cacat", "NIK_Ibu", "Nama_Ibu", "NIK_Ayah",
                    "Nama_Ayah"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                var sampleData = new object[]
                {
                    "CONTOH PENGISIAN", "1234567890123456", "John Doe", "Laki-laki", "Jakarta", "01-01-1990",
                    "WNI", "1. Belum/Tidak Bekerja", "Jl. Contoh No. 1", "001", "001", "Dusun I", "Islam",
                    "SLTA/Sederajat", "H.", "S.T.", "081234567890", "john@example.com",
                    "P123456/05", "01-01-2025", "SK.1234.AH.03.01.2024", "Ada", "19735/TP/2011",
                    "A", "Pahoman Sejati", "Cerai Hidup", "01-01-2020", "Ada", "3175-KW-2025-0001234",
                    "Ada", "205/AC/2020/PA.Sry", "01-01-2024", "Kepala Keluarga", "Ada", "Rungu/Wicara",
                    "1234567890123456", "Jane Doe", "1234567890123456", "John Senior"
                };

                for (int i = 0; i < sampleData.Length; i++)
                {
                    worksheet.Cells[2, i + 1].Value = sampleData[i];
                    worksheet.Cells[2, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[2, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                }

                // Add instructions worksheet
                AddInstructionsWorksheet(package);

                // Add data validation for specific columns
                AddDataValidation(worksheet, headers);

                // Format columns
                FormatColumns(worksheet, headers);

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Save the file
                var fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        private void AddInstructionsWorksheet(ExcelPackage package)
        {
            var instructionsSheet = package.Workbook.Worksheets.Add("Instruksi");

            instructionsSheet.Cells["A1"].Value = "INSTRUKSI PENGISIAN TEMPLATE IMPORT DATA PENDUDUK";
            instructionsSheet.Cells["A1"].Style.Font.Bold = true;
            instructionsSheet.Cells["A1"].Style.Font.Size = 16;

            var instructions = new string[]
            {
                "",
                "KOLOM WAJIB (Harus diisi):",
                "• NIK: 16 digit angka",
                "• Nama_Lengkap: Nama lengkap penduduk",
                "• Jenis_Kelamin: Pilih dari dropdown (Laki-laki/Perempuan)",
                "• Tempat_Lahir: Tempat kelahiran",
                "• Tanggal_Lahir: Format DD-MM-YYYY (contoh: 01-01-1990)",
                "• alamat: Alamat tempat tinggal",
                "• rt: 3 digit angka (contoh: 001)",
                "• rw: 3 digit angka (contoh: 001)",
                "",
                "KETENTUAN FORMAT:",
                "• NIK, No. KK, NIK_Ibu, NIK_Ayah: Harus 16 digit angka",
                "• Tanggal: Format DD-MM-YYYY (hari-bulan-tahun)",
                "• RT/RW: 3 digit angka (001, 012, 123)",
                "• Email: Format email yang valid (contoh@email.com)",
                "• No HP: Format nomor telepon yang valid",
                "",
                "DROPDOWN VALIDATION:",
                "• Kolom tertentu sudah dilengkapi dropdown untuk memudah pengisian",
                "• Pastikan memilih dari dropdown yang tersedia",
                "• Jangan mengetik manual jika ada dropdown",
                "",
                "CARA PENGGUNAAN:",
                "1. Isi data pada sheet 'Data Import' mulai dari baris 3",
                "2. Gunakan contoh data pada baris 2 sebagai referensi",
                "3. Pastikan semua kolom wajib terisi",
                "4. Simpan file setelah selesai mengisi data",
                "5. Upload file ke aplikasi untuk validasi dan import",
                "",
                "CATATAN PENTING:",
                "• Data yang dimasukkan hanya data warga yang termasuk sebagai warga desa Cibeuteung Muara, bukan orang yang menumpang",
                "• Jangan mengubah nama kolom (header) pada baris 1",
                "• Jangan menghapus atau mengubah format template",
                "• Maksimal 1000 baris data per file",
                "• File harus berformat .xlsx",
                "",
                "Jenis Pekerjaan:",
                "1. Belum/Tidak Bekerja",
                "2. Mengurus Rumah Tangga",
                "3. Pelajar/Mahasiswa",
                "4. Pensiunan",
                "5. Pegawai Negeri Sipil (PNS)",
                "6. Tentara Nasional Indonesia (TNI)",
                "7. Kepolisian RI (POLRI)",
                "8. Perdagangan",
                "9. Petani/Pekebun",
                "10. Peternak",
                "11. Nelayan/Perikanan",
                "12. Industri",
                "13. Konstruksi",
                "14. Transportasi",
                "15. Karyawan Swasta",
                "16. Karyawan BUMN",
                "17. Karyawan BUMD",
                "18. Karyawan Honorer",
                "19. Buruh Harian Lepas",
                "20. Buruh Tani/Perkebunan",
                "21. Buruh Nelayan/Perikanan",
                "22. Buruh Peternakan",
                "23. Pembantu Rumah Tangga",
                "24. Tukang Cukur",
                "25. Tukang Listrik",
                "26. Tukang Batu",
                "27. Tukang Kayu",
                "28. Tukang Sol Sepatu",
                "29. Tukang Las/Pandai Besi",
                "30. Tukang Jahit",
                "31. Tukang Gigi",
                "32. Penata Rias",
                "33. Penata Busana",
                "34. Penata Rambut",
                "35. Mekanik",
                "36. Seniman",
                "37. Tabib",
                "38. Paraji",
                "39. Perancang Busana",
                "40. Penterjemah",
                "41. Imam Masjid",
                "42. Pendeta",
                "43. Pastor",
                "44. Wartawan",
                "45. Ustadz/Mubaligh",
                "46. Juru Masak",
                "47. Promotor Acara",
                "48. Anggota DPR-RI",
                "49. Anggota DPD",
                "50. Anggota BPK",
                "51. Presiden",
                "52. Wakil Presiden",
                "53. Anggota Mahkamah Konstitusi",
                "54. Anggota Kabinet/Kementrian",
                "55. Duta Besar",
                "56. Gubernur",
                "57. Wakil Gubernur",
                "58. Bupati",
                "59. Wakil Bupati",
                "60. Walikota",
                "61. Wakil Walikota",
                "62. Anggota DPRD Prop.",
                "63. Anggota DPRD Kab./Kota",
                "64. Dosen",
                "65. Guru",
                "66. Pilot",
                "67. Pengacara",
                "68. Notaris",
                "69. Arsitek",
                "70. Akuntan",
                "71. Konsultan",
                "72. Dokter",
                "73. Bidan",
                "74. Perawat",
                "75. Apoteker",
                "76. Psikiater/Psikolog",
                "77. Penyiar Televisi",
                "78. Penyiar Radio",
                "79. Pelaut",
                "80. Peneliti",
                "81. Sopir",
                "82. Pialang",
                "83. Paranormal",
                "84. Pedagang",
                "85. Perangkat Desa",
                "86. Kepala Desa",
                "87. Biarawati",
                "88. Wiraswasta"
            };

            for (int i = 0; i < instructions.Length; i++)
            {
                instructionsSheet.Cells[i + 2, 1].Value = instructions[i];
                if (instructions[i].EndsWith(":"))
                {
                    instructionsSheet.Cells[i + 2, 1].Style.Font.Bold = true;
                }
            }

            instructionsSheet.Cells[instructionsSheet.Dimension.Address].AutoFitColumns();
        }

        private void AddDataValidation(ExcelWorksheet worksheet, string[] headers)
        {
            var dataRange = $"A3:A1000"; // Start from row 3 for data entry

            for (int col = 1; col <= headers.Length; col++)
            {
                string header = headers[col - 1];
                string columnLetter = GetColumnLetter(col);
                string validationRange = $"{columnLetter}3:{columnLetter}1000";

                switch (header)
                {
                    case "Jenis_Kelamin":
                        var genderValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        genderValidation.Formula.Values.Add("Laki-laki");
                        genderValidation.Formula.Values.Add("Perempuan");
                        genderValidation.ShowErrorMessage = true;
                        genderValidation.ErrorTitle = "Input Tidak Valid";
                        genderValidation.Error = "Pilih 'Laki-laki' atau 'Perempuan'";
                        break;

                    case "Kewarganegaraan":
                        var citizenshipValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        citizenshipValidation.Formula.Values.Add("WNI");
                        citizenshipValidation.Formula.Values.Add("WNA");
                        citizenshipValidation.ShowErrorMessage = true;
                        citizenshipValidation.ErrorTitle = "Input Tidak Valid";
                        citizenshipValidation.Error = "Pilih 'WNI' atau 'WNA'";
                        break;

                    case "Agama":
                        var religionValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        religionValidation.Formula.Values.Add("Islam");
                        religionValidation.Formula.Values.Add("Kristen");
                        religionValidation.Formula.Values.Add("Katholik");
                        religionValidation.Formula.Values.Add("Hindu");
                        religionValidation.Formula.Values.Add("Budha");
                        religionValidation.Formula.Values.Add("Konghucu");
                        religionValidation.Formula.Values.Add("Lainnya");
                        religionValidation.ShowErrorMessage = true;
                        religionValidation.ErrorTitle = "Input Tidak Valid";
                        religionValidation.Error = "Pilih salah satu agama yang tersedia";
                        break;

                    case "Pendidikan_Terakhir":
                        var educationValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        educationValidation.Formula.Values.Add("Tidak/Belum Sekolah");
                        educationValidation.Formula.Values.Add("Tamat SD/Sederajat");
                        educationValidation.Formula.Values.Add("SLTP/Sederajat");
                        educationValidation.Formula.Values.Add("SLTA/Sederajat");
                        educationValidation.Formula.Values.Add("Diploma I/II");
                        educationValidation.Formula.Values.Add("Akademi/Diploma III/Sarjana Muda");
                        educationValidation.Formula.Values.Add("Diploma IV/Strata I");
                        educationValidation.Formula.Values.Add("Strata II");
                        educationValidation.Formula.Values.Add("Strata III");
                        educationValidation.ShowErrorMessage = true;
                        educationValidation.ErrorTitle = "Input Tidak Valid";
                        educationValidation.Error = "Pilih salah satu tingkat pendidikan yang tersedia";
                        break;

                    case "nama_dusun":
                        var dusunValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        dusunValidation.Formula.Values.Add("Dusun I");
                        dusunValidation.Formula.Values.Add("Dusun II");
                        dusunValidation.Formula.Values.Add("Dusun III");
                        dusunValidation.ShowErrorMessage = true;
                        dusunValidation.ErrorTitle = "Input Tidak Valid";
                        dusunValidation.Error = "Pilih salah satu dusun yang tersedia";
                        break;

                    case "Status_Perkawinan":
                        var marriageValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        marriageValidation.Formula.Values.Add("Belum Kawin");
                        marriageValidation.Formula.Values.Add("Kawin");
                        marriageValidation.Formula.Values.Add("Cerai Hidup");
                        marriageValidation.Formula.Values.Add("Cerai Mati");
                        marriageValidation.ShowErrorMessage = true;
                        marriageValidation.ErrorTitle = "Input Tidak Valid";
                        marriageValidation.Error = "Pilih salah satu status perkawinan yang tersedia";
                        break;

                    case "Golongan_Darah":
                        var bloodValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        bloodValidation.Formula.Values.Add("A");
                        bloodValidation.Formula.Values.Add("B");
                        bloodValidation.Formula.Values.Add("AB");
                        bloodValidation.Formula.Values.Add("O");
                        bloodValidation.Formula.Values.Add("A+");
                        bloodValidation.Formula.Values.Add("A-");
                        bloodValidation.Formula.Values.Add("B+");
                        bloodValidation.Formula.Values.Add("B-");
                        bloodValidation.Formula.Values.Add("AB+");
                        bloodValidation.Formula.Values.Add("AB-");
                        bloodValidation.Formula.Values.Add("O+");
                        bloodValidation.Formula.Values.Add("O-");
                        bloodValidation.Formula.Values.Add("Tidak Tahu");
                        bloodValidation.ShowErrorMessage = true;
                        bloodValidation.ErrorTitle = "Input Tidak Valid";
                        bloodValidation.Error = "Pilih salah satu golongan darah yang tersedia";
                        break;

                    case "Status_Hubungan_Dalam_Keluarga":
                        var familyValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        familyValidation.Formula.Values.Add("Kepala Keluarga");
                        familyValidation.Formula.Values.Add("Suami");
                        familyValidation.Formula.Values.Add("Istri");
                        familyValidation.Formula.Values.Add("Anak");
                        familyValidation.Formula.Values.Add("Menantu");
                        familyValidation.Formula.Values.Add("Cucu");
                        familyValidation.Formula.Values.Add("Orang Tua");
                        familyValidation.Formula.Values.Add("Mertua");
                        familyValidation.Formula.Values.Add("Famili Lain");
                        familyValidation.Formula.Values.Add("Pembantu");
                        familyValidation.Formula.Values.Add("Lainnya");
                        familyValidation.ShowErrorMessage = true;
                        familyValidation.ErrorTitle = "Input Tidak Valid";
                        familyValidation.Error = "Pilih salah satu status hubungan dalam keluarga yang tersedia";
                        break;

                    case "Akta_Lahir":
                    case "Akta_Perkawinan":
                    case "Akta_Cerai":
                        var aktaValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        aktaValidation.Formula.Values.Add("Ada");
                        aktaValidation.Formula.Values.Add("Tidak Ada");
                        aktaValidation.ShowErrorMessage = true;
                        aktaValidation.ErrorTitle = "Input Tidak Valid";
                        aktaValidation.Error = "Pilih 'Ada' atau 'Tidak Ada'";
                        break;

                    case "Kelainan_Fisik_dan_Mental":
                        var kelainanValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        kelainanValidation.Formula.Values.Add("Ada");
                        kelainanValidation.Formula.Values.Add("Tidak Ada");
                        kelainanValidation.ShowErrorMessage = true;
                        kelainanValidation.ErrorTitle = "Input Tidak Valid";
                        kelainanValidation.Error = "Pilih 'Ada' atau 'Tidak Ada'";
                        break;

                    case "Penyandang_Cacat":
                        var cacatValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        cacatValidation.Formula.Values.Add("");
                        cacatValidation.Formula.Values.Add("Fisik");
                        cacatValidation.Formula.Values.Add("Netra/Buta");
                        cacatValidation.Formula.Values.Add("Rungu/Wicara");
                        cacatValidation.Formula.Values.Add("Mental/Jiwa");
                        cacatValidation.Formula.Values.Add("Fisik dan Mental");
                        cacatValidation.Formula.Values.Add("Lainnya");
                        cacatValidation.ShowErrorMessage = true;
                        cacatValidation.ErrorTitle = "Input Tidak Valid";
                        cacatValidation.Error = "Pilih salah satu jenis cacat yang tersedia atau kosongkan";
                        break;

                    case "Jenis_Pekerjaan":
                        var pekerjaanValidation = worksheet.DataValidations.AddListValidation(validationRange);
                        pekerjaanValidation.Formula.ExcelFormula = "Instruksi!$A$40:$A$126";
                        pekerjaanValidation.ShowErrorMessage = true;
                        pekerjaanValidation.ErrorTitle = "Input Tidak Valid";
                        pekerjaanValidation.Error = "Pilih salah satu jenis pekerjaan yang tersedia atau kosongkan";
                        break;
                }
            }
        }

        private void FormatColumns(ExcelWorksheet worksheet, string[] headers)
        {
            for (int col = 1; col <= headers.Length; col++)
            {
                string header = headers[col - 1];
                string columnLetter = GetColumnLetter(col);
                string formatRange = $"{columnLetter}2:{columnLetter}1000";

                switch (header)
                {
                    case "Tanggal_Lahir":
                    case "Tgl_Berakhir_Paspor":
                    case "Tanggal_Perkawinan":
                    case "Tanggal_Perceraian":
                    case "Tanggal_Masuk":
                    case "Tanggal_Terbit_ITAS_ITAP":
                    case "Tanggal_Akhir_ITAS_ITAP":
                    case "Tanggal_Kedatangan_Pertama":
                    case "Tgl_Kematian":
                    case "NIK":
                    case "Nomor_KK":
                    case "NIK_Ibu":
                    case "NIK_Ayah":
                    case "no_hp":
                    case "Nomor_Akta_Kelahiran":
                    case "Nomor_Akta_Perkawinan":
                    case "Nomor_Akta_Cerai":
                    case "Nomor_ITAS_ITAP":
                    case "Passport_Number":
                    case "No_SK_Penetapan_WNI":
                    case "rt":
                    case "rw":
                        worksheet.Cells[formatRange].Style.Numberformat.Format = "@"; // Text format to preserve leading zeros
                        break;

                    case "kode_pos":
                        worksheet.Cells[formatRange].Style.Numberformat.Format = "00000"; // 5-digit format
                        break;
                }
            }
        }

        private string GetColumnLetter(int columnNumber)
        {
            string columnName = "";
            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }
            return columnName;
        }

        private void LoadFilePreview()
        {
            try
            {
                var previewData = new DataTable();

                using (var package = new ExcelPackage(new FileInfo(selectedFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        MessageBox.Show("File Excel tidak memiliki worksheet atau kosong.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (worksheet.Dimension == null)
                    {
                        MessageBox.Show("Worksheet Excel kosong.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Get headers from first row
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        var headerValue = worksheet.Cells[1, col].Value?.ToString() ?? $"Column{col}";
                        previewData.Columns.Add(headerValue);
                    }

                    // Read first 10 rows for preview (skip header row)
                    int rowsToRead = Math.Min(10, worksheet.Dimension.End.Row - 2);
                    for (int row = 3; row <= Math.Min(13, worksheet.Dimension.End.Row); row++)
                    {
                        var dataRow = previewData.NewRow();
                        bool hasData = false;

                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;
                            string value = "";

                            if (cellValue != null)
                            {
                                if (cellValue is DateTime dateValue)
                                {
                                    value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    value = cellValue.ToString();
                                }
                                hasData = true;
                            }

                            if (col <= previewData.Columns.Count)
                                dataRow[col - 1] = value;
                        }

                        if (hasData)
                            previewData.Rows.Add(dataRow);
                    }
                }

                dataGridViewPreview.DataSource = previewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat preview file: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Background Workers
        private void backgroundWorkerValidation_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = (string)e.Argument;
            var worker = sender as BackgroundWorker;

            try
            {
                var tempValidData = new List<PendudukModel>();
                var tempErrors = new List<string>();

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null || worksheet.Dimension == null)
                    {
                        tempErrors.Add("File Excel kosong atau tidak valid.");
                        e.Result = new { ValidData = tempValidData, Errors = tempErrors };
                        return;
                    }

                    // Get headers from first row
                    var headers = new List<string>();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        var headerValue = worksheet.Cells[1, col].Value?.ToString() ?? "";
                        headers.Add(headerValue);
                    }

                    // Validasi header
                    List<string> validationErrors = ValidateHeaders(headers);
                    if (validationErrors.Count > 0)
                    {
                        tempErrors.AddRange(validationErrors);
                        e.Result = new { ValidData = tempValidData, Errors = tempErrors };
                        return;
                    }

                    // Count total data rows (exclude header)
                    int totalRows = worksheet.Dimension.End.Row - 2;
                    if (totalRows <= 0)
                    {
                        tempErrors.Add("File Excel tidak memiliki data.");
                        e.Result = new { ValidData = tempValidData, Errors = tempErrors };
                        return;
                    }

                    // Process each data row
                    for (int row = 3; row <= worksheet.Dimension.End.Row; row++)
                    {
                        // Check for cancellation
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        // Report progress
                        int progress = (int)((double)(row - 2) / totalRows * 100);
                        worker.ReportProgress(progress, $"Memvalidasi baris {row - 2} dari {totalRows}");

                        // Check if row has any data
                        bool hasData = false;
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            if (worksheet.Cells[row, col].Value != null &&
                                !string.IsNullOrWhiteSpace(worksheet.Cells[row, col].Value.ToString()))
                            {
                                hasData = true;
                                break;
                            }
                        }

                        if (!hasData) continue; // Skip empty rows

                        // Parse and validate row
                        var values = new List<string>();
                        for (int col = 1; col <= headers.Count && col <= worksheet.Dimension.End.Column; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;
                            string value = "";

                            if (cellValue != null)
                            {
                                if (cellValue is DateTime dateValue)
                                {
                                    value = dateValue.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    value = cellValue.ToString();
                                }
                            }

                            values.Add(value);
                        }

                        var rowErrors = new List<string>();

                        try
                        {
                            var penduduk = CreatePendudukFromExcelRow(headers, values, row, rowErrors);

                            if (rowErrors.Count == 0)
                            {
                                tempValidData.Add(penduduk);
                            }
                            else
                            {
                                tempErrors.AddRange(rowErrors);
                            }
                        }
                        catch (Exception ex)
                        {
                            tempErrors.Add($"Baris {row}: Error parsing data - {ex.Message}");
                        }

                        // Small delay to prevent UI freezing
                        if ((row - 2) % 100 == 0)
                        {
                            Thread.Sleep(10);
                        }
                    }
                }

                e.Result = new { ValidData = tempValidData, Errors = tempErrors };
            }
            catch (Exception ex)
            {
                var tempErrors = new List<string> { $"Error membaca file: {ex.Message}" };
                e.Result = new { ValidData = new List<PendudukModel>(), Errors = tempErrors };
            }
        }

        private void backgroundWorkerValidation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarValidation.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                lblValidationStatus.Text = e.UserState.ToString();
            }
        }

        private void backgroundWorkerValidation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable buttons
            btnValidate.Enabled = true;
            btnBrowseFile.Enabled = true;

            if (e.Cancelled)
            {
                lblValidationStatus.Text = "Validasi dibatalkan.";
                lblValidationStatus.ForeColor = Color.Orange;
                progressBarValidation.Visible = false;
                return;
            }

            if (e.Error != null)
            {
                lblValidationStatus.Text = "Error saat validasi.";
                lblValidationStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error saat validasi: {e.Error.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBarValidation.Visible = false;
                return;
            }

            var result = (dynamic)e.Result;
            validDataList = result.ValidData;
            errorList = result.Errors;

            if (errorList.Count == 0)
            {
                lblValidationStatus.Text = $"✅ Validasi berhasil! {validDataList.Count} record siap untuk diimport.";
                lblValidationStatus.ForeColor = Color.Green;
                btnImport.Enabled = true;
                isValidationSuccessful = true;

                // Hide error section
                lblErrorsTitle.Visible = false;
                richTextBoxErrors.Visible = false;
            }
            else
            {
                lblValidationStatus.Text = $"❌ Validasi selesai dengan {errorList.Count} error. {validDataList.Count} record valid.";
                lblValidationStatus.ForeColor = Color.Red;

                // Show errors
                lblErrorsTitle.Visible = true;
                richTextBoxErrors.Visible = true;
                richTextBoxErrors.Text = string.Join("\n", errorList);

                btnImport.Enabled = validDataList.Count > 0 && errorList.Count == 0;
                isValidationSuccessful = false;
            }

            progressBarValidation.Visible = false;
        }

        private void backgroundWorkerImport_DoWork(object sender, DoWorkEventArgs e)
        {
            var dataToImport = (List<PendudukModel>)e.Argument;
            var worker = sender as BackgroundWorker;
            int successCount = 0;
            var importErrors = new List<string>();

            try
            {
                using (var connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    for (int i = 0; i < dataToImport.Count; i++)
                    {
                        // Check for cancellation
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        // Report progress
                        int progress = (int)((double)(i + 1) / dataToImport.Count * 100);
                        worker.ReportProgress(progress, $"Mengimport record {i + 1} dari {dataToImport.Count}");

                        try
                        {
                            var penduduk = dataToImport[i];

                            // Check for duplicate NIK
                            string checkQuery = "SELECT COUNT(*) FROM gabungan_keluarga WHERE NIK = @NIK";
                            int existingCount = connection.ExecuteScalar<int>(checkQuery, new { NIK = penduduk.NIK });

                            if (existingCount > 0)
                            {
                                importErrors.Add($"NIK {penduduk.NIK} ({penduduk.Nama_Lengkap}) sudah ada dalam database - dilewati");
                                continue;
                            }

                            // Encrypt sensitive data
                            var encryptedPenduduk = penduduk.EncryptModel();

                            // Insert data
                            string insertQuery = GetInsertQuery();
                            connection.Execute(insertQuery, encryptedPenduduk);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            importErrors.Add($"Error mengimport NIK {dataToImport[i].NIK}: {ex.Message}");
                        }

                        // Small delay to prevent overwhelming the database
                        if (i % 50 == 0)
                        {
                            Thread.Sleep(50);
                        }
                    }
                }

                e.Result = new { SuccessCount = successCount, Errors = importErrors };
            }
            catch (Exception ex)
            {
                importErrors.Add($"Error koneksi database: {ex.Message}");
                e.Result = new { SuccessCount = successCount, Errors = importErrors };
            }
        }

        private void backgroundWorkerImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarValidation.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                lblValidationStatus.Text = e.UserState.ToString();
            }
        }

        private void backgroundWorkerImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable buttons
            btnValidate.Enabled = true;
            btnBrowseFile.Enabled = true;
            btnImport.Enabled = false;

            if (e.Cancelled)
            {
                lblValidationStatus.Text = "Import dibatalkan.";
                lblValidationStatus.ForeColor = Color.Orange;
                progressBarValidation.Visible = false;
                return;
            }

            if (e.Error != null)
            {
                lblValidationStatus.Text = "Error saat import.";
                lblValidationStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error saat import: {e.Error.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBarValidation.Visible = false;
                return;
            }

            var result = (dynamic)e.Result;
            int successCount = result.SuccessCount;
            var importErrors = (List<string>)result.Errors;

            string message = $"Import selesai!\n\n✅ Berhasil: {successCount} record\n";

            if (importErrors.Count > 0)
            {
                message += $"⚠️ Error/Dilewati: {importErrors.Count} record\n\nDetail error:\n{string.Join("\n", importErrors.Take(10))}";
                if (importErrors.Count > 10)
                {
                    message += $"\n... dan {importErrors.Count - 10} error lainnya";
                }
            }

            MessageBox.Show(message, "Import Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblValidationStatus.Text = $"Import selesai: {successCount} record berhasil diimport.";
            lblValidationStatus.ForeColor = Color.Green;
            progressBarValidation.Visible = false;

            // Clear form for next import
            ClearForm();
        }

        private void ClearForm()
        {
            selectedFilePath = "";
            lblSelectedFile.Text = "Belum ada file yang dipilih";
            lblSelectedFile.ForeColor = Color.Gray;
            lblFileInfo.Text = "";

            dataGridViewPreview.DataSource = null;

            ClearValidationResults();

            btnValidate.Enabled = false;
            btnImport.Enabled = false;
        }

        #endregion

        #region Data Validation and Creation

        private PendudukModel CreatePendudukFromExcelRow(List<string> headers, List<string> values, int lineNumber, List<string> errors)
        {
            var penduduk = new PendudukModel();

            // Ensure we have enough values
            if (values.Count < headers.Count)
            {
                // Pad with empty strings
                while (values.Count < headers.Count)
                {
                    values.Add("");
                }
            }

            for (int i = 0; i < headers.Count && i < values.Count; i++)
            {
                string header = headers[i];
                string value = values[i]?.Trim() ?? "";

                try
                {
                    switch (header)
                    {
                        case "NIK":
                            if (!InputSanitizer.ValidateNIK(value))
                            {
                                errors.Add($"Baris {lineNumber}: NIK '{value}' tidak valid (harus 16 digit angka)");
                            }
                            else
                            {
                                penduduk.NIK = value;
                            }
                            break;

                        case "Nomor_KK":
                            if (!string.IsNullOrEmpty(value) && !InputSanitizer.ValidateNIK(value))
                            {
                                errors.Add($"Baris {lineNumber}: No. KK '{value}' tidak valid (harus 16 digit angka)");
                            }
                            else
                            {
                                penduduk.Nomor_KK = value;
                            }
                            break;

                        case "Nama_Lengkap":
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                errors.Add($"Baris {lineNumber}: Nama_Lengkap tidak boleh kosong");
                            }
                            else
                            {
                                penduduk.Nama_Lengkap = InputSanitizer.SanitizeInput(value);
                            }
                            break;

                        case "Jenis_Kelamin":
                            if (value != "Laki-laki" && value != "Perempuan")
                            {
                                errors.Add($"Baris {lineNumber}: Jenis_Kelamin harus 'Laki-laki' atau 'Perempuan'");
                            }
                            else
                            {
                                penduduk.Jenis_Kelamin = value;
                            }
                            break;

                        case "Tempat_Lahir":
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                errors.Add($"Baris {lineNumber}: Tempat_Lahir tidak boleh kosong");
                            }
                            else
                            {
                                penduduk.Tempat_Lahir = InputSanitizer.SanitizeInput(value);
                            }
                            break;

                        case "Tanggal_Lahir":
                            if (!DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tanggalLahir))
                            {
                                errors.Add($"Baris {lineNumber}: Tanggal_Lahir '{value}' tidak valid (format: DD-MM-YYYY)");
                            }
                            else
                            {
                                penduduk.Tanggal_Lahir = tanggalLahir;
                            }
                            break;

                        case "alamat":
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                errors.Add($"Baris {lineNumber}: alamat tidak boleh kosong");
                            }
                            else
                            {
                                penduduk.alamat = InputSanitizer.SanitizeInput(value);
                            }
                            break;

                        case "rt":
                            if (!InputSanitizer.ValidateRT_RW(value))
                            {
                                errors.Add($"Baris {lineNumber}: RT '{value}' tidak valid (harus 3 digit angka)");
                            }
                            else
                            {
                                penduduk.rt = value;
                            }
                            break;

                        case "rw":
                            if (!InputSanitizer.ValidateRT_RW(value))
                            {
                                errors.Add($"Baris {lineNumber}: RW '{value}' tidak valid (harus 3 digit angka)");
                            }
                            else
                            {
                                penduduk.rw = value;
                            }
                            break;

                        case "email":
                            if (!string.IsNullOrEmpty(value) && !InputSanitizer.ValidateEmail(value))
                            {
                                errors.Add($"Baris {lineNumber}: Email '{value}' tidak valid");
                            }
                            else
                            {
                                penduduk.email = value;
                            }
                            break;

                        case "no_hp":
                            if (!string.IsNullOrEmpty(value) && !InputSanitizer.ValidatePhone(value))
                            {
                                errors.Add($"Baris {lineNumber}: Nomor HP '{value}' tidak valid");
                            }
                            else
                            {
                                penduduk.no_hp = value;
                            }
                            break;

                        case "NIK_Ibu":
                            if (!string.IsNullOrEmpty(value) && !InputSanitizer.ValidateNIK(value))
                            {
                                errors.Add($"Baris {lineNumber}: NIK_Ibu '{value}' tidak valid (harus 16 digit angka)");
                            }
                            else
                            {
                                penduduk.NIK_Ibu = value;
                            }
                            break;

                        case "NIK_Ayah":
                            if (!string.IsNullOrEmpty(value) && !InputSanitizer.ValidateNIK(value))
                            {
                                errors.Add($"Baris {lineNumber}: NIK_Ayah '{value}' tidak valid (harus 16 digit angka)");
                            }
                            else
                            {
                                penduduk.NIK_Ayah = value;
                            }
                            break;

                        // Date fields
                        case "Tgl_Berakhir_Paspor":
                        case "Tanggal_Perkawinan":
                        case "Tanggal_Perceraian":
                        case "Tanggal_Masuk":
                        case "Tanggal_Terbit_ITAS_ITAP":
                        case "Tanggal_Akhir_ITAS_ITAP":
                        case "Tanggal_Kedatangan_Pertama":
                        case "Tgl_Kematian":
                            if (!string.IsNullOrEmpty(value))
                            {
                                if (DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                                {
                                    SetPropertyValue(penduduk, header, dateValue);
                                }
                                else
                                {
                                    errors.Add($"Baris {lineNumber}: {header} '{value}' tidak valid (format: DD-MM-YYYY)");
                                }
                            }
                            break;

                        // String fields
                        default:
                            SetPropertyValue(penduduk, header, InputSanitizer.SanitizeInput(value));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"Baris {lineNumber}, Kolom {header}: Error - {ex.Message}");
                }
            }

            return penduduk;
        }

        #endregion

        #region Helper Methods

        private List<string> ValidateHeaders(List<string> headers)
        {
            var errors = new List<string>();
            var requiredHeaders = new[] { "NIK", "Nama_Lengkap", "Jenis_Kelamin", "Tempat_Lahir", "Tanggal_Lahir", "alamat", "rt", "rw" };

            var missingHeaders = requiredHeaders.Where(h => !headers.Contains(h)).ToList();
            if (missingHeaders.Any())
            {
                errors.Add($"Header yang diperlukan tidak ditemukan: {string.Join(", ", missingHeaders)}");
            }

            return errors;
        }

        private void SetPropertyValue(PendudukModel penduduk, string propertyName, object value)
        {
            var property = typeof(PendudukModel).GetProperty(propertyName);
            if (property != null && property.CanWrite)
            {
                property.SetValue(penduduk, value);
            }
        }

        private string GetInsertQuery()
        {
            return @"
                INSERT INTO gabungan_keluarga (
                    NIK, Nomor_KK, Nama_Lengkap, Jenis_Kelamin, Tempat_Lahir, Tanggal_Lahir, Kewarganegaraan, 
                    Jenis_Pekerjaan, alamat, rt, rw, nama_dusun, Agama, Pendidikan_Terakhir, Gelar_Depan, Gelar_Belakang, 
                    no_hp, email, Passport_Number, Tgl_Berakhir_Paspor, No_SK_Penetapan_WNI, Akta_Lahir, 
                    Nomor_Akta_Kelahiran, Golongan_Darah, Nama_Organisasi_Kepercayaan, Status_Perkawinan, 
                    Tanggal_Perkawinan, Akta_Perkawinan, Nomor_Akta_Perkawinan, Akta_Cerai, Nomor_Akta_Cerai, 
                    Tanggal_Perceraian, Status_Hubungan_Dalam_Keluarga, Kelainan_Fisik_dan_Mental, Penyandang_Cacat, 
                    NIK_Ibu, Nama_Ibu, NIK_Ayah, Nama_Ayah
                ) VALUES (
                    @NIK, @Nomor_KK, @Nama_Lengkap, @Jenis_Kelamin, @Tempat_Lahir, @Tanggal_Lahir, @Kewarganegaraan, 
                    @Jenis_Pekerjaan, @alamat, @rt, @rw, @nama_dusun, @Agama, @Pendidikan_Terakhir, @Gelar_Depan, @Gelar_Belakang, 
                    @no_hp, @email, @Passport_Number, @Tgl_Berakhir_Paspor, @No_SK_Penetapan_WNI, @Akta_Lahir, 
                    @Nomor_Akta_Kelahiran, @Golongan_Darah, @Nama_Organisasi_Kepercayaan, @Status_Perkawinan, 
                    @Tanggal_Perkawinan, @Akta_Perkawinan, @Nomor_Akta_Perkawinan, @Akta_Cerai, @Nomor_Akta_Cerai, 
                    @Tanggal_Perceraian, @Status_Hubungan_Dalam_Keluarga, @Kelainan_Fisik_dan_Mental, @Penyandang_Cacat, 
                    @NIK_Ibu, @Nama_Ibu, @NIK_Ayah, @Nama_Ayah
                )";
        }

        private void ClearValidationResults()
        {
            lblValidationStatus.Text = "Belum ada validasi yang dijalankan";
            lblValidationStatus.ForeColor = Color.Black;
            richTextBoxErrors.Text = "";
            lblErrorsTitle.Visible = false;
            richTextBoxErrors.Visible = false;
            progressBarValidation.Visible = false;
            progressBarValidation.Value = 0;

            validDataList.Clear();
            errorList.Clear();
            isValidationSuccessful = false;
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }

        private void CleanupResources()
        {
            validDataList?.Clear();
            errorList?.Clear();

            if (dataGridViewPreview.DataSource is DataTable dt)
            {
                dt.Dispose();
            }
        }
        #endregion
    }
}