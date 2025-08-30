using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace AplikasiDesa
{
    public partial class FormTambahPenduduk : Form
    {
        private System.Windows.Forms.Timer searchTimer;
        private CancellationTokenSource searchCancellationTokenSource;
        private int currentPage = 1;
        private int pageSize = 25;
        private int totalRecords = 0;
        private int totalPages = 0;
        private string currentSearchFilter = "";

        public FormTambahPenduduk()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("id-ID");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            InitializeSearchTimer();
            InitializePagination();
            LoadDatabasePenduduk();
        }

        private void InitializeSearchTimer()
        {
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 500; // 500ms delay
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void InitializePagination()
        {
            cmbPageSize.SelectedItem = "25";
            pageSize = 25;
            currentPage = 1;
            UpdatePaginationControls();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PerformSearch();
        }

        private async void PerformSearch()
        {
            // Cancel previous search if it's still running
            searchCancellationTokenSource?.Cancel();
            searchCancellationTokenSource = new CancellationTokenSource();

            currentPage = 1; // Reset to first page when searching
            await LoadDatabasePendudukAsync(searchCancellationTokenSource.Token);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 1)
            {
                LoadDatabasePenduduk();
            }
        }

        #region Tambah Data Penduduk
        private void UpdateFieldsBasedOnRadioSelection()
        {
            if (radioWNI.Checked)
            {
                txtSKWNI.Enabled = true;
                cmbWargaNegara.SelectedIndex = 0;
                dtpTanggalMasuk.Enabled = false;
                txtAlamatLuar.Enabled = false;
                txtAlamatLuar.Clear();
                txtKotaLuar.Enabled = false;
                txtKotaLuar.Clear();
                txtProvLuar.Enabled = false;
                txtProvLuar.Clear();
                txtPostal.Enabled = false;
                txtPostal.Clear();
                txtNamaSponsor.Enabled = false;
                txtNamaSponsor.Clear();
                cmbBoxTipeSponsor.Enabled = false;
                cmbBoxTipeSponsor.SelectedIndex = -1;
                txtAlamatSponsor.Enabled = false;
                txtAlamatSponsor.Clear();
                txtKodeNegara.Enabled = false;
                txtKodeNegara.Clear();
                txtNegaraLuar.Enabled = false;
                txtNegaraLuar.Clear();
                txtKodePerwakilan.Enabled = false;
                txtKodePerwakilan.Clear();
                txtNamaPerwakilan.Enabled = false;
                txtNamaPerwakilan.Clear();
                txtITAS.Enabled = false;
                txtITAS.Clear();
                txtTempatITAS.Enabled = false;
                txtTempatITAS.Clear();
                dtpTerbitITAS.Enabled = false;
                dtpAkhirITAS.Enabled = false;
                txtTempatDatang.Enabled = false;
                txtTempatDatang.Clear();
                dtpKedatangan.Enabled = false;
            }
            else if (radioMenumpang.Checked)
            {
                txtSKWNI.Enabled = true;
                dtpTanggalMasuk.Enabled = true;
                cmbWargaNegara.SelectedIndex = 0;
                txtAlamatLuar.Enabled = false;
                txtAlamatLuar.Clear();
                txtKotaLuar.Enabled = false;
                txtKotaLuar.Clear();
                txtProvLuar.Enabled = false;
                txtProvLuar.Clear();
                txtPostal.Enabled = false;
                txtPostal.Clear();
                txtNamaSponsor.Enabled = false;
                txtNamaSponsor.Clear();
                cmbBoxTipeSponsor.Enabled = false;
                cmbBoxTipeSponsor.SelectedIndex = -1;
                txtAlamatSponsor.Enabled = false;
                txtAlamatSponsor.Clear();
                txtKodeNegara.Enabled = false;
                txtKodeNegara.Clear();
                txtNegaraLuar.Enabled = false;
                txtNegaraLuar.Clear();
                txtKodePerwakilan.Enabled = false;
                txtKodePerwakilan.Clear();
                txtNamaPerwakilan.Enabled = false;
                txtNamaPerwakilan.Clear();
                txtITAS.Enabled = false;
                txtITAS.Clear();
                txtTempatITAS.Enabled = false;
                txtTempatITAS.Clear();
                dtpTerbitITAS.Enabled = false;
                dtpAkhirITAS.Enabled = false;
                txtTempatDatang.Enabled = false;
                txtTempatDatang.Clear();
                dtpKedatangan.Enabled = false;
            }
            else if (radioWNILuar.Checked)
            {
                txtSKWNI.Enabled = true;
                cmbWargaNegara.SelectedIndex = 0;
                dtpTanggalMasuk.Enabled = false;
                txtAlamatLuar.Enabled = true;
                txtKotaLuar.Enabled = true;
                txtProvLuar.Enabled = true;
                txtPostal.Enabled = true;
                txtNamaSponsor.Enabled = true;
                cmbBoxTipeSponsor.Enabled = true;
                txtAlamatSponsor.Enabled = true;
                txtKodeNegara.Enabled = true;
                txtNegaraLuar.Enabled = true;
                txtKodePerwakilan.Enabled = true;
                txtNamaPerwakilan.Enabled = true;
                txtITAS.Enabled = false;
                txtITAS.Clear();
                txtTempatITAS.Enabled = false;
                txtTempatITAS.Clear();
                dtpTerbitITAS.Enabled = false;
                dtpAkhirITAS.Enabled = false;
                txtTempatDatang.Enabled = false;
                txtTempatDatang.Clear();
                dtpKedatangan.Enabled = false;
            }
            else if (radioWNA.Checked)
            {
                txtSKWNI.Enabled = false;
                cmbWargaNegara.SelectedIndex = 1;
                dtpTanggalMasuk.Enabled = false;
                txtAlamatLuar.Enabled = true;
                txtKotaLuar.Enabled = true;
                txtProvLuar.Enabled = true;
                txtPostal.Enabled = true;
                txtNamaSponsor.Enabled = true;
                cmbBoxTipeSponsor.Enabled = true;
                txtAlamatSponsor.Enabled = true;
                txtKodeNegara.Enabled = true;
                txtNegaraLuar.Enabled = true;
                txtKodePerwakilan.Enabled = true;
                txtNamaPerwakilan.Enabled = true;
                txtITAS.Enabled = true;
                txtTempatDatang.Enabled = true;
                dtpKedatangan.Enabled = true;
            }
        }

        private void radioWNI_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFieldsBasedOnRadioSelection();
        }

        private void radioMenumpang_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFieldsBasedOnRadioSelection();
        }

        private void radioWNILuar_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFieldsBasedOnRadioSelection();
        }

        private void radioWNA_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFieldsBasedOnRadioSelection();
        }

        private void txtNoPaspor_TextChanged(object sender, EventArgs e)
        {
            if (txtNoPaspor.Text.Length > 0)
            {
                dtpPaspor.Enabled = true;
            }
            else
            {
                dtpPaspor.Enabled = false;
            }
        }

        private void comboBoxStatusKawin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStatusKawin.SelectedIndex == 0)
            {
                dtpPerkawinan.Enabled = false;
                dtpCerai.Enabled = false;
                comboBoxAktaKawin.Enabled = false;
                comboBoxAktaKawin.SelectedIndex = -1;
                textNoAktaKawin.Enabled = false;
                textNoAktaKawin.Clear();
                comboBoxAktaCerai.Enabled = false;
                comboBoxAktaCerai.SelectedIndex = -1;
                txtNoAktaCerai.Enabled = false;
                txtNoAktaCerai.Clear();
            }
            else if (comboBoxStatusKawin.SelectedIndex == 1)
            {
                dtpPerkawinan.Enabled = true;
                dtpCerai.Enabled = false;
                comboBoxAktaKawin.Enabled = true;
                textNoAktaKawin.Enabled = false;
                comboBoxAktaCerai.Enabled = false;
                comboBoxAktaCerai.SelectedIndex = -1;
                txtNoAktaCerai.Enabled = false;
                txtNoAktaCerai.Clear();
            }
            else if (comboBoxStatusKawin.SelectedIndex == 2)
            {
                dtpPerkawinan.Enabled = true;
                dtpCerai.Enabled = true;
                comboBoxAktaKawin.Enabled = true;
                textNoAktaKawin.Enabled = false;
                comboBoxAktaCerai.Enabled = true;
                txtNoAktaCerai.Enabled = false;
            }
            else
            {
                dtpPerkawinan.Enabled = true;
                dtpCerai.Enabled = true;
                comboBoxAktaKawin.Enabled = true;
                textNoAktaKawin.Enabled = true;
                comboBoxAktaCerai.Enabled = true;
                txtNoAktaCerai.Enabled = true;
            }
        }

        private void KelainanFisikDanMental_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKelainan.SelectedIndex == 0)
            {
                comboBoxCacat.Enabled = true;
            }
            else
            {
                comboBoxCacat.Enabled = false;
                comboBoxCacat.SelectedIndex = -1;
            }
        }

        private void comboBoxAktaLahir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAktaLahir.SelectedIndex == 0)
            {
                txtNoAktaLahir.Enabled = true;
            }
            else
            {
                txtNoAktaLahir.Enabled = false;
                txtNoAktaLahir.Clear();
            }
        }

        private void comboBoxAktaKawin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAktaKawin.SelectedIndex == 0)
            {
                textNoAktaKawin.Enabled = true;
            }
            else
            {
                textNoAktaKawin.Enabled = false;
                textNoAktaKawin.Clear();
            }
        }

        private void comboBoxAktaCerai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAktaCerai.SelectedIndex == 0)
            {
                txtNoAktaCerai.Enabled = true;
            }
            else
            {
                txtNoAktaCerai.Enabled = false;
                txtNoAktaCerai.Clear();
            }
        }

        private void txtITAS_TextChanged(object sender, EventArgs e)
        {
            if (txtITAS.Text.Length > 0)
            {
                dtpTerbitITAS.Enabled = true;
                dtpAkhirITAS.Enabled = true;
                txtTempatITAS.Enabled = true;
            }
            else
            {
                dtpTerbitITAS.Enabled = false;
                dtpAkhirITAS.Enabled = false;
                txtTempatITAS.Enabled = false;
                txtTempatITAS.Clear();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtTempatLahir.Text) ||
                cmbWargaNegara.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtAlamat.Text) ||
                (!rbLakiLaki.Checked && !rbPerempuan.Checked))
            {
                MessageBox.Show("Isi semua kolom wajib", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!InputSanitizer.ValidateNIK(txtNIK.Text) || !string.IsNullOrEmpty(txtNIKAyah.Text) && !InputSanitizer.ValidateNIK(txtNIKAyah.Text) || !string.IsNullOrEmpty(txtNIKIbu.Text) && !InputSanitizer.ValidateNIK(txtNIKIbu.Text))
            {
                MessageBox.Show("NIK harus terdiri dari 16 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtKK.Text) && !InputSanitizer.ValidateNIK(txtKK.Text))
            {
                MessageBox.Show("No. KK harus terdiri dari 16 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!InputSanitizer.ValidateRT_RW(textBoxRT.Text) || !InputSanitizer.ValidateRT_RW(textBoxRW.Text))
            {
                MessageBox.Show("RT dan RW harus terdiri dari 3 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !InputSanitizer.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Format email tidak valid.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtTelp.Text) && !InputSanitizer.ValidatePhone(txtTelp.Text))
            {
                MessageBox.Show("Format nomor telepon tidak valid.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
            {
                string sqlCheckNIK = "SELECT COUNT(*) FROM gabungan_keluarga WHERE NIK = @NIK";
                int count = db.ExecuteScalar<int>(sqlCheckNIK, new { NIK = txtNIK.Text });

                if (count > 0)
                {
                    MessageBox.Show("NIK sudah ada pada database, periksa kembali data anda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tentukan jenis kelamin
                string jenisKelamin;
                if (rbLakiLaki.Checked)
                {
                    jenisKelamin = "Laki-laki";
                }
                else if (rbPerempuan.Checked)
                {
                    jenisKelamin = "Perempuan";
                }
                else
                {
                    MessageBox.Show("Please select a gender.");
                    return;
                }

                // Tentukan status kependudukan
                string kependudukan;
                if (radioMenumpang.Checked)
                {
                    kependudukan = "MENUMPANG";
                }
                else if (radioWNA.Checked)
                {
                    kependudukan = "WNA";
                }
                else
                {
                    kependudukan = "HIDUP";
                }

                // Cek dan set nilai date nullable
                DateTime? pasporDate = dtpPaspor.Enabled ? dtpPaspor.Value : null;
                DateTime? perkawinanDate = dtpPerkawinan.Enabled ? dtpPerkawinan.Value : null;
                DateTime? ceraiDate = dtpCerai.Enabled ? dtpCerai.Value : null;
                DateTime? tglMasuk = dtpTanggalMasuk.Enabled ? dtpTanggalMasuk.Value : null;
                DateTime? terbitITAS = dtpTerbitITAS.Enabled ? dtpTerbitITAS.Value : null;
                DateTime? akhirITAS = dtpAkhirITAS.Enabled ? dtpAkhirITAS.Value : null;
                DateTime? kedatanganDate = dtpKedatangan.Enabled ? dtpKedatangan.Value : null;

                // Buat model penduduk
                var penduduk = new PendudukModel
                {
                    NIK = txtNIK.Text,
                    Nomor_KK = txtKK.Text,
                    Nama_Lengkap = InputSanitizer.SanitizeInput(txtNama.Text),
                    Jenis_Kelamin = jenisKelamin,
                    Tempat_Lahir = InputSanitizer.SanitizeInput(txtTempatLahir.Text),
                    Tanggal_Lahir = dtpTanggalLahir.Value,
                    Kewarganegaraan = cmbWargaNegara.Text,
                    Jenis_Pekerjaan = comboBoxPekerjaan.Text,
                    alamat = InputSanitizer.SanitizeInput(txtAlamat.Text),
                    rt = textBoxRT.Text,
                    rw = textBoxRW.Text,
                    nama_dusun = comboBoxDusun.Text,
                    Agama = comboBoxAgama.Text,
                    Pendidikan_Terakhir = comboBoxPendidikan.Text,
                    Gelar_Depan = InputSanitizer.SanitizeInput(txtGlrDpn.Text),
                    Gelar_Belakang = InputSanitizer.SanitizeInput(txtGlrBlkg.Text),
                    no_hp = string.IsNullOrWhiteSpace(txtTelp.Text) ? null : txtTelp.Text,
                    email = txtEmail.Text,
                    Passport_Number = InputSanitizer.SanitizeInput(txtNoPaspor.Text),
                    Tgl_Berakhir_Paspor = pasporDate,
                    No_SK_Penetapan_WNI = InputSanitizer.SanitizeInput(txtSKWNI.Text),
                    Akta_Lahir = comboBoxAktaLahir.Text,
                    Nomor_Akta_Kelahiran = InputSanitizer.SanitizeInput(txtNoAktaLahir.Text),
                    Golongan_Darah = comboBoxDarah.Text,
                    Nama_Organisasi_Kepercayaan = InputSanitizer.SanitizeInput(txtOrganisasi.Text),
                    Status_Perkawinan = comboBoxStatusKawin.Text,
                    Tanggal_Perkawinan = perkawinanDate,
                    Akta_Perkawinan = comboBoxAktaKawin.Text,
                    Nomor_Akta_Perkawinan = InputSanitizer.SanitizeInput(textNoAktaKawin.Text),
                    Akta_Cerai = comboBoxAktaCerai.Text,
                    Nomor_Akta_Cerai = InputSanitizer.SanitizeInput(txtNoAktaCerai.Text),
                    Tanggal_Perceraian = ceraiDate,
                    Status_Hubungan_Dalam_Keluarga = comboStatus.Text,
                    Kelainan_Fisik_dan_Mental = comboBoxKelainan.Text,
                    Penyandang_Cacat = comboBoxCacat.Text,
                    NIK_Ibu = txtNIKIbu.Text,
                    Nama_Ibu = InputSanitizer.SanitizeInput(txtNamaIbu.Text),
                    NIK_Ayah = txtNIKAyah.Text,
                    Nama_Ayah = InputSanitizer.SanitizeInput(txtNamaAyah.Text),
                    Tanggal_Masuk = tglMasuk,
                    alamat_luar_negeri = InputSanitizer.SanitizeInput(txtAlamatLuar.Text),
                    kota_luar_negeri = InputSanitizer.SanitizeInput(txtKotaLuar.Text),
                    provinsi_negara_bagian_luar_negeri = InputSanitizer.SanitizeInput(txtProvLuar.Text),
                    kode_pos_luar_negeri = InputSanitizer.SanitizeInput(txtPostal.Text),
                    Nama_Sponsor = InputSanitizer.SanitizeInput(txtNamaSponsor.Text),
                    Tipe_Sponsor = cmbBoxTipeSponsor.Text,
                    Alamat_Sponsor = InputSanitizer.SanitizeInput(txtAlamatSponsor.Text),
                    kode_negara = InputSanitizer.SanitizeInput(txtKodeNegara.Text),
                    nama_negara = InputSanitizer.SanitizeInput(txtNegaraLuar.Text),
                    kode_perwakilan_ri = InputSanitizer.SanitizeInput(txtKodePerwakilan.Text),
                    nama_perwakilan_ri = InputSanitizer.SanitizeInput(txtNamaPerwakilan.Text),
                    Nomor_ITAS_ITAP = InputSanitizer.SanitizeInput(txtITAS.Text),
                    Tempat_Terbit_ITAS_ITAP = InputSanitizer.SanitizeInput(txtTempatITAS.Text),
                    Tanggal_Terbit_ITAS_ITAP = terbitITAS,
                    Tanggal_Akhir_ITAS_ITAP = akhirITAS,
                    Tempat_Datang_Pertama = InputSanitizer.SanitizeInput(txtTempatDatang.Text),
                    Tanggal_Kedatangan_Pertama = kedatanganDate,
                    Status_Kependudukan = kependudukan
                };

                try
                {
                    var encryptedPenduduk = penduduk.EncryptModel();

                    string sqlInsert = @"
                        INSERT INTO gabungan_keluarga (
                            NIK, Nomor_KK, Nama_Lengkap, Jenis_Kelamin, Tempat_Lahir, Tanggal_Lahir, Kewarganegaraan, 
                            Jenis_Pekerjaan, alamat, rt, rw, nama_dusun, Agama, Pendidikan_Terakhir, Gelar_Depan, Gelar_Belakang, no_hp, email, Passport_Number, Tgl_Berakhir_Paspor,
                            No_SK_Penetapan_WNI, Akta_Lahir, Nomor_Akta_Kelahiran, Golongan_Darah, Nama_Organisasi_Kepercayaan, Status_Perkawinan, Tanggal_Perkawinan, Akta_Perkawinan,
                            Nomor_Akta_Perkawinan, Akta_Cerai, Nomor_Akta_Cerai, Tanggal_Perceraian, Status_Hubungan_Dalam_Keluarga, Kelainan_Fisik_dan_Mental, Penyandang_Cacat, 
                            NIK_Ibu, Nama_Ibu, NIK_Ayah, Nama_Ayah, Tanggal_Masuk, alamat_luar_negeri, kota_luar_negeri, provinsi_negara_bagian_luar_negeri, kode_pos_luar_negeri, 
                            Nama_Sponsor, Tipe_Sponsor, Alamat_Sponsor, kode_negara, nama_negara, kode_perwakilan_ri, nama_perwakilan_ri, Nomor_ITAS_ITAP, Tempat_Terbit_ITAS_ITAP, 
                            Tanggal_Terbit_ITAS_ITAP, Tanggal_Akhir_ITAS_ITAP, Tempat_Datang_Pertama, Tanggal_Kedatangan_Pertama, Status_Kependudukan
                        ) VALUES (
                            @NIK, @Nomor_KK, @Nama_Lengkap, @Jenis_Kelamin, @Tempat_Lahir, @Tanggal_Lahir, @Kewarganegaraan, 
                            @Jenis_Pekerjaan, @alamat, @rt, @rw, @nama_dusun, @Agama, @Pendidikan_Terakhir, @Gelar_Depan, @Gelar_Belakang, @no_hp, @email, @Passport_Number, @Tgl_Berakhir_Paspor,
                            @No_SK_Penetapan_WNI, @Akta_Lahir, @Nomor_Akta_Kelahiran, @Golongan_Darah, @Nama_Organisasi_Kepercayaan, @Status_Perkawinan, @Tanggal_Perkawinan, @Akta_Perkawinan,
                            @Nomor_Akta_Perkawinan, @Akta_Cerai, @Nomor_Akta_Cerai, @Tanggal_Perceraian, @Status_Hubungan_Dalam_Keluarga, @Kelainan_Fisik_dan_Mental, @Penyandang_Cacat, 
                            @NIK_Ibu, @Nama_Ibu, @NIK_Ayah, @Nama_Ayah, @Tanggal_Masuk, @alamat_luar_negeri, @kota_luar_negeri, @provinsi_negara_bagian_luar_negeri, @kode_pos_luar_negeri,
                            @Nama_Sponsor, @Tipe_Sponsor, @Alamat_Sponsor, @kode_negara, @nama_negara, @kode_perwakilan_ri, @nama_perwakilan_ri, @Nomor_ITAS_ITAP, @Tempat_Terbit_ITAS_ITAP,
                            @Tanggal_Terbit_ITAS_ITAP, @Tanggal_Akhir_ITAS_ITAP, @Tempat_Datang_Pertama, @Tanggal_Kedatangan_Pertama, @Status_Kependudukan
                        )";

                    // Eksekusi query dengan model yang sudah terenkripsi
                    db.Execute(sqlInsert, encryptedPenduduk);
                    MessageBox.Show("Data berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form setelah berhasil
                    btnReset_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNIK.Clear();
            txtKK.Clear();
            txtNama.Clear();
            rbLakiLaki.Checked = false;
            rbPerempuan.Checked = false;
            txtTempatLahir.Clear();
            dtpTanggalLahir.Value = DateTime.Now;
            cmbWargaNegara.SelectedIndex = -1;
            comboBoxPekerjaan.SelectedIndex = -1;
            txtAlamat.Clear();
            textBoxRT.Clear();
            textBoxRW.Clear();
            comboBoxDusun.SelectedIndex = -1;
            comboBoxAgama.SelectedIndex = -1;
            comboBoxPendidikan.SelectedIndex = -1;
            txtGlrDpn.Clear();
            txtGlrBlkg.Clear();
            txtTelp.Clear();
            txtEmail.Clear();
            txtNoPaspor.Clear();
            dtpPaspor.Value = DateTime.Now;
            txtSKWNI.Clear();
            comboBoxAktaLahir.SelectedIndex = -1;
            txtNoAktaLahir.Clear();
            comboBoxDarah.SelectedIndex = -1;
            txtOrganisasi.Clear();
            comboBoxStatusKawin.SelectedIndex = -1;
            dtpPerkawinan.Value = DateTime.Now;
            comboBoxAktaKawin.SelectedIndex = -1;
            textNoAktaKawin.Clear();
            comboBoxAktaCerai.SelectedIndex = -1;
            txtNoAktaCerai.Clear();
            dtpCerai.Value = DateTime.Now;
            comboStatus.SelectedIndex = -1;
            comboBoxKelainan.SelectedIndex = -1;
            comboBoxCacat.SelectedIndex = -1;
            txtNIKIbu.Clear();
            txtNamaIbu.Clear();
            txtNIKAyah.Clear();
            txtNamaAyah.Clear();
            dtpTanggalMasuk.Value = DateTime.Now;
            txtAlamatLuar.Clear();
            txtKotaLuar.Clear();
            txtProvLuar.Clear();
            txtPostal.Clear();
            txtNamaSponsor.Clear();
            cmbBoxTipeSponsor.SelectedIndex = -1;
            txtAlamatSponsor.Clear();
            txtKodeNegara.Clear();
            txtNegaraLuar.Clear();
            txtKodePerwakilan.Clear();
            txtNamaPerwakilan.Clear();
            txtITAS.Clear();
            txtTempatITAS.Clear();
            dtpTerbitITAS.Value = DateTime.Now;
            dtpAkhirITAS.Value = DateTime.Now;
            txtTempatDatang.Clear();
            dtpKedatangan.Value = DateTime.Now;
            radioWNI.Checked = true;
        }
        #endregion Tambah Data Penduduk

        #region Manajemen Database Penduduk
        private void ConfigureDataGridViewKK()
        {
            DataGridViewComboBoxColumn comboStatusColumn = new DataGridViewComboBoxColumn
            {
                Name = "Status_Hubungan_Dalam_Keluarga",
                HeaderText = "Status Hubungan Dalam Keluarga",
                DataPropertyName = "Status_Hubungan_Dalam_Keluarga",
                DataSource = new string[] {
                    "Kepala Keluarga", "Suami", "Istri", "Anak", "Menantu", "Cucu",
                    "Orang Tua", "Mertua", "Famili Lain", "Pembantu", "Lainnya"
                }
            };
            int statusHubunganIndex = dataGridViewDB.Columns["Status_Hubungan_Dalam_Keluarga"].Index;
            dataGridViewDB.Columns.RemoveAt(statusHubunganIndex);
            dataGridViewDB.Columns.Insert(statusHubunganIndex, comboStatusColumn);

            DataGridViewComboBoxColumn comboagamaColumn = new DataGridViewComboBoxColumn
            {
                Name = "Agama",
                HeaderText = "Agama",
                DataPropertyName = "Agama",
                DataSource = new string[] { "Islam", "Kristen", "Katholik", "Hindu", "Budha", "Konghucu", "Lainnya" }
            };
            int genderagamaIndex = dataGridViewDB.Columns["Agama"].Index;
            dataGridViewDB.Columns.RemoveAt(genderagamaIndex);
            dataGridViewDB.Columns.Insert(genderagamaIndex, comboagamaColumn);

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "Jenis_Kelamin",
                HeaderText = "Jenis Kelamin",
                DataPropertyName = "Jenis_Kelamin",
                DataSource = new string[] { "Laki-laki", "Perempuan" }
            };
            int genderColumnIndex = dataGridViewDB.Columns["Jenis_Kelamin"].Index;
            dataGridViewDB.Columns.RemoveAt(genderColumnIndex);
            dataGridViewDB.Columns.Insert(genderColumnIndex, comboBoxColumn);

            DataGridViewComboBoxColumn combogoldarColumn = new DataGridViewComboBoxColumn
            {
                Name = "Golongan_Darah",
                HeaderText = "Golongan Darah",
                DataPropertyName = "Golongan_Darah",
                DataSource = new string[] { "A", "B", "AB", "O", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-", "Tidak Tahu" }
            };
            int goldarColumnIndex = dataGridViewDB.Columns["Golongan_Darah"].Index;
            dataGridViewDB.Columns.RemoveAt(goldarColumnIndex);
            dataGridViewDB.Columns.Insert(goldarColumnIndex, combogoldarColumn);

            DataGridViewComboBoxColumn combostatuskawinColumn = new DataGridViewComboBoxColumn
            {
                Name = "Status_Perkawinan",
                HeaderText = "Status Perkawinan",
                DataPropertyName = "Status_Perkawinan",
                DataSource = new string[] { "Belum Kawin", "Kawin", "Cerai Hidup", "Cerai Mati" }
            };
            int statuskawinColumnIndex = dataGridViewDB.Columns["Status_Perkawinan"].Index;
            dataGridViewDB.Columns.RemoveAt(statuskawinColumnIndex);
            dataGridViewDB.Columns.Insert(statuskawinColumnIndex, combostatuskawinColumn);

            DataGridViewComboBoxColumn combopekerjaanColumn = new DataGridViewComboBoxColumn
            {
                Name = "Jenis_Pekerjaan",
                HeaderText = "Jenis Pekerjaan",
                DataPropertyName = "Jenis_Pekerjaan",
                DataSource = new string[]
                {
                    "1. Belum/Tidak Bekerja", "2. Mengurus Rumah Tangga", "3. Pelajar/Mahasiswa", "4. Pensiunan", "5. Pegawai Negeri Sipil (PNS)", "6. Tentara Nasional Indonesia (TNI)", "7. Kepolisian RI (POLRI)", "8. Perdagangan", "9. Petani/Pekebun", "10. Peternak", "11. Nelayan/Perikanan", "12. Industri", "13. Konstruksi", "14. Transportasi", "15. Karyawan Swasta", "16. Karyawan BUMN", "17. Karyawan BUMD", "18. Karyawan Honorer", "19. Buruh Harian Lepas", "20. Buruh Tani/Perkebunan", "21. Buruh Nelayan/Perikanan", "22. Buruh Peternakan",
                    "23. Pembantu Rumah Tangga", "24. Tukang Cukur", "25. Tukang Listrik", "26. Tukang Batu", "27. Tukang Kayu", "28. Tukang Sol Sepatu", "29. Tukang Las/Pandai Besi", "30. Tukang Jahit", "31. Tukang Gigi", "32. Penata Rias", "33. Penata Busana", "34. Penata Rambut", "35. Mekanik", "36. Seniman", "37. Tabib", "38. Paraji", "39. Perancang Busana", "40. Penterjemah", "41. Imam Masjid", "42. Pendeta", "43. Pastor", "44. Wartawan",
                    "45. Ustadz/Mubaligh", "46. Juru Masak", "47. Promotor Acara", "48. Anggota DPR-RI", "49. Anggota DPD", "50. Anggota BPK", "51. Presiden", "52. Wakil Presiden", "53. Anggota Mahkamah Konstitusi", "54. Anggota Kabinet/Kementrian", "55. Duta Besar", "56. Gubernur", "57. Wakil Gubernur", "58. Bupati", "59. Wakil Bupati", "60. Walikota", "61. Wakil Walikota", "62. Anggota DPRD Prop.", "63. Anggota DPRD Kab./Kota", "64. Dosen", "65. Guru", "66. Pilot",
                    "67. Pengacara", "68. Notaris", "69. Arsitek", "70. Akuntan", "71. Konsultan", "72. Dokter", "73. Bidan", "74. Perawat", "75. Apoteker", "76. Psikiater/Psikolog", "77. Penyiar Televisi", "78. Penyiar Radio", "79. Pelaut", "80. Peneliti", "81. Sopir", "82. Pialang", "83. Paranormal", "84. Pedagang", "85. Perangkat Desa", "86. Kepala Desa", "87. Biarawati", "88. Wiraswasta"
                   }
            };
            int pekerjaanColumnIndex = dataGridViewDB.Columns["Jenis_Pekerjaan"].Index;
            dataGridViewDB.Columns.RemoveAt(pekerjaanColumnIndex);
            dataGridViewDB.Columns.Insert(pekerjaanColumnIndex, combopekerjaanColumn);

            DataGridViewComboBoxColumn combodusunColumn = new DataGridViewComboBoxColumn
            {
                Name = "nama_dusun",
                HeaderText = "Dusun",
                DataPropertyName = "nama_dusun",
                DataSource = new string[] { "Dusun I", "Dusun II", "Dusun III" }
            };
            int dusunColumnIndex = dataGridViewDB.Columns["nama_dusun"].Index;
            dataGridViewDB.Columns.RemoveAt(dusunColumnIndex);
            dataGridViewDB.Columns.Insert(dusunColumnIndex, combodusunColumn);

            DataGridViewComboBoxColumn combopendidikanColumn = new DataGridViewComboBoxColumn
            {
                Name = "Pendidikan_Terakhir",
                HeaderText = "Pendidikan Terakhir",
                DataPropertyName = "Pendidikan_Terakhir",
                DataSource = new string[]
                {
                    "Tidak/Belum Sekolah", "Tamat SD/Sederajat", "SLTP/Sederajat", "SLTA/Sederajat", "Diploma I/II", "Akademi/Diploma III/Sarjana Muda", "Diploma IV/Strata I", "Strata II", "Strata III"
                }
            };
            int pendidikanColumnIndex = dataGridViewDB.Columns["Pendidikan_Terakhir"].Index;
            dataGridViewDB.Columns.RemoveAt(pendidikanColumnIndex);
            dataGridViewDB.Columns.Insert(pendidikanColumnIndex, combopendidikanColumn);

            DataGridViewComboBoxColumn comboaktalahirColumn = new DataGridViewComboBoxColumn
            {
                Name = "Akta_Lahir",
                HeaderText = "Akta Lahir",
                DataPropertyName = "Akta_Lahir",
                DataSource = new string[] { "Ada", "Tidak Ada" }
            };
            int aktalahirColumnIndex = dataGridViewDB.Columns["Akta_Lahir"].Index;
            dataGridViewDB.Columns.RemoveAt(aktalahirColumnIndex);
            dataGridViewDB.Columns.Insert(aktalahirColumnIndex, comboaktalahirColumn);

            DataGridViewComboBoxColumn comboaktakawinColumn = new DataGridViewComboBoxColumn
            {
                Name = "Akta_Perkawinan",
                HeaderText = "Akta Perkawinan",
                DataPropertyName = "Akta_Perkawinan",
                DataSource = new string[] { "Ada", "Tidak Ada" }
            };
            int aktakawinColumnIndex = dataGridViewDB.Columns["Akta_Perkawinan"].Index;
            dataGridViewDB.Columns.RemoveAt(aktakawinColumnIndex);
            dataGridViewDB.Columns.Insert(aktakawinColumnIndex, comboaktakawinColumn);

            DataGridViewComboBoxColumn comboaktaceraiColumn = new DataGridViewComboBoxColumn
            {
                Name = "Akta_Cerai",
                HeaderText = "Akta Cerai",
                DataPropertyName = "Akta_Cerai",
                DataSource = new string[] { "Ada", "Tidak Ada" }
            };
            int aktaceraiColumnIndex = dataGridViewDB.Columns["Akta_Cerai"].Index;
            dataGridViewDB.Columns.RemoveAt(aktaceraiColumnIndex);
            dataGridViewDB.Columns.Insert(aktaceraiColumnIndex, comboaktaceraiColumn);

            DataGridViewComboBoxColumn combokelainanColumn = new DataGridViewComboBoxColumn
            {
                Name = "Kelainan_Fisik_dan_Mental",
                HeaderText = "Kelainan Fisik dan Mental",
                DataPropertyName = "Kelainan_Fisik_dan_Mental",
                DataSource = new string[] { "Ada", "Tidak Ada" }
            };
            int kelainanColumnIndex = dataGridViewDB.Columns["Kelainan_Fisik_dan_Mental"].Index;
            dataGridViewDB.Columns.RemoveAt(kelainanColumnIndex);
            dataGridViewDB.Columns.Insert(kelainanColumnIndex, combokelainanColumn);

            DataGridViewComboBoxColumn combocacatColumn = new DataGridViewComboBoxColumn
            {
                Name = "Penyandang_Cacat",
                HeaderText = "Penyandang Cacat",
                DataPropertyName = "Penyandang_Cacat",
                DataSource = new string[] { "Fisik", "Netra/Buta", "Rungu/Wicara", "Mental/Jiwa", "Fisik dan Mental", "Lainnya" }
            };
            int cacatColumnIndex = dataGridViewDB.Columns["Penyandang_Cacat"].Index;
            dataGridViewDB.Columns.RemoveAt(cacatColumnIndex);
            dataGridViewDB.Columns.Insert(cacatColumnIndex, combocacatColumn);

            DataGridViewComboBoxColumn combotipeSponsorColumn = new DataGridViewComboBoxColumn
            {
                Name = "Tipe_Sponsor",
                HeaderText = "Tipe Sponsor",
                DataPropertyName = "Tipe_Sponsor",
                DataSource = new string[] { "Organisasi Internasional", "Pemerintah", "Perusahaan", "Perorangan" }
            };
            int tipeSponsorColumnIndex = dataGridViewDB.Columns["Tipe_Sponsor"].Index;
            dataGridViewDB.Columns.RemoveAt(tipeSponsorColumnIndex);
            dataGridViewDB.Columns.Insert(tipeSponsorColumnIndex, combotipeSponsorColumn);

            DataGridViewComboBoxColumn comboWargaNegaraColumn = new DataGridViewComboBoxColumn
            {
                Name = "Kewarganegaraan",
                HeaderText = "Kewarganegaraan",
                DataPropertyName = "Kewarganegaraan",
                DataSource = new string[] { "WNI", "WNA" }
            };
            int wargaNegaraColumnIndex = dataGridViewDB.Columns["Kewarganegaraan"].Index;
            dataGridViewDB.Columns.RemoveAt(wargaNegaraColumnIndex);
            dataGridViewDB.Columns.Insert(wargaNegaraColumnIndex, comboWargaNegaraColumn);
        }

        private void LoadDatabasePenduduk()
        {
            _ = LoadDatabasePendudukAsync(CancellationToken.None);
        }

        private async Task LoadDatabasePendudukAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // Show loading indicator
                dataGridViewDB.DataSource = null;

                using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                {
                    // Get total count for pagination
                    string countSql = "SELECT COUNT(*) FROM gabungan_keluarga";
                    if (!string.IsNullOrWhiteSpace(currentSearchFilter))
                    {
                        if (long.TryParse(currentSearchFilter, out _))
                        {
                            countSql += " WHERE NIK LIKE @Filter";
                        }
                        else
                        {
                            // For name search, we need to get all records to filter after decryption
                            countSql = "SELECT COUNT(*) FROM gabungan_keluarga";
                        }
                    }

                    if (string.IsNullOrWhiteSpace(currentSearchFilter) || long.TryParse(currentSearchFilter, out _))
                    {
                        var parameters = string.IsNullOrWhiteSpace(currentSearchFilter) ? null : new { Filter = "%" + currentSearchFilter + "%" };
                        totalRecords = await db.QuerySingleAsync<int>(countSql, parameters);
                    }
                    else
                    {
                        // For name search, get total from memory filtering
                        string sqlAll = "SELECT * FROM gabungan_keluarga";
                        var allRecords = db.QueryWithDecryption<PendudukModel>(sqlAll);
                        totalRecords = allRecords.Count(p =>
                            (p.Nama_Lengkap != null && p.Nama_Lengkap.Contains(currentSearchFilter, StringComparison.OrdinalIgnoreCase)) ||
                            (p.NIK != null && p.NIK.Contains(currentSearchFilter))
                        );
                    }

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                    // Check for cancellation
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    // Get paginated data
                    string sql;
                    IEnumerable<PendudukModel> result;

                    if (string.IsNullOrWhiteSpace(currentSearchFilter))
                    {
                        // No filter - direct pagination
                        sql = $"SELECT * FROM gabungan_keluarga LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";
                        result = db.QueryWithDecryption<PendudukModel>(sql);
                    }
                    else if (long.TryParse(currentSearchFilter, out _))
                    {
                        // NIK search - can paginate directly
                        sql = $@"SELECT * FROM gabungan_keluarga 
                        WHERE NIK LIKE @Filter
                        LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";
                        result = db.QueryWithDecryption<PendudukModel>(sql, new { Filter = "%" + currentSearchFilter + "%" });
                    }
                    else
                    {
                        // Name search - need to filter in memory then paginate
                        string sqlAll = "SELECT * FROM gabungan_keluarga";
                        var allRecords = db.QueryWithDecryption<PendudukModel>(sqlAll);

                        var filteredRecords = allRecords.Where(p =>
                            (p.Nama_Lengkap != null && p.Nama_Lengkap.Contains(currentSearchFilter, StringComparison.OrdinalIgnoreCase)) ||
                            (p.NIK != null && p.NIK.Contains(currentSearchFilter))
                        ).Skip((currentPage - 1) * pageSize).Take(pageSize);

                        result = filteredRecords;
                    }

                    // Check for cancellation before updating UI
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    // Update UI on main thread
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            dataGridViewDB.DataSource = result.ToList();
                            ConfigureDataGridViewKK();
                            UpdatePaginationControls();
                        }));
                    }
                    else
                    {
                        dataGridViewDB.DataSource = result.ToList();
                        ConfigureDataGridViewKK();
                        UpdatePaginationControls();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Search was cancelled, ignore
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                        MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ));
                }
                else
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdatePaginationControls()
        {
            lblPageInfo.Text = $"Halaman {currentPage} dari {Math.Max(totalPages, 1)}";
            lblTotalRecords.Text = $"Total Data: {totalRecords}";
            btnFirstPage.Enabled = currentPage > 1;
            btnPreviousPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
            btnLastPage.Enabled = currentPage < totalPages;
        }

        private void txtCariData_TextChanged(object sender, EventArgs e)
        {
            currentSearchFilter = txtCariData.Text;

            // Cancel the previous timer
            searchTimer.Stop();

            // Start the timer for delayed search
            searchTimer.Start();
        }

        private async void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                await LoadDatabasePendudukAsync();
            }
        }

        private async void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await LoadDatabasePendudukAsync();
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                await LoadDatabasePendudukAsync();
            }
        }

        private async void btnLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage = totalPages;
                await LoadDatabasePendudukAsync();
            }
        }

        private async void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbPageSize.SelectedItem.ToString(), out int newPageSize))
            {
                pageSize = newPageSize;
                currentPage = 1; // Reset to first page
                await LoadDatabasePendudukAsync();
            }
        }

        private void dataGridViewDB_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (e.Exception is ArgumentException && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = dataGridViewDB.Columns[e.ColumnIndex];
                if (column is DataGridViewComboBoxColumn)
                {
                    dataGridViewDB.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
            e.Cancel = true;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridViewDB.SelectedRows.Count == 0 && dataGridViewDB.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridViewDB.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridViewDB.Rows[rowIndex];

            string nik = selectedRow.Cells["NIK"].Value?.ToString();

            if (string.IsNullOrEmpty(nik))
            {
                MessageBox.Show("NIK tidak valid atau kosong.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan menghapus data dengan NIK: {nik}?",
                "Konfirmasi Hapus Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        string sqlDelete = "DELETE FROM gabungan_keluarga WHERE NIK = @NIK";
                        db.Execute(sqlDelete, new { NIK = nik });

                        MessageBox.Show("Data berhasil dihapus.", "Informasi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDatabasePenduduk();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewDB.SelectedRows.Count == 0 && dataGridViewDB.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diupdate terlebih dahulu.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridViewDB.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridViewDB.Rows[rowIndex];

            string nik = selectedRow.Cells["NIK"].Value?.ToString();

            if (string.IsNullOrEmpty(nik))
            {
                MessageBox.Show("NIK tidak valid atau kosong.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin akan mengupdate data dengan NIK: {nik}?",
                "Konfirmasi Update Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection db = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        // Buat objek PendudukModel dari baris yang dipilih
                        var penduduk = new PendudukModel
                        {
                            NIK = nik,
                            Nomor_KK = GetCellValueOrNull(selectedRow, "Nomor_KK")?.ToString(),
                            Nama_Lengkap = GetCellValueOrNull(selectedRow, "Nama_Lengkap")?.ToString(),
                            Jenis_Kelamin = GetCellValueOrNull(selectedRow, "Jenis_Kelamin")?.ToString(),
                            Tempat_Lahir = GetCellValueOrNull(selectedRow, "Tempat_Lahir")?.ToString(),
                            Tanggal_Lahir = GetDateValueOrNull(selectedRow, "Tanggal_Lahir"),
                            Kewarganegaraan = GetCellValueOrNull(selectedRow, "Kewarganegaraan")?.ToString(),
                            Jenis_Pekerjaan = GetCellValueOrNull(selectedRow, "Jenis_Pekerjaan")?.ToString(),
                            alamat = GetCellValueOrNull(selectedRow, "alamat")?.ToString(),
                            rt = GetCellValueOrNull(selectedRow, "rt")?.ToString(),
                            rw = GetCellValueOrNull(selectedRow, "rw")?.ToString(),
                            nama_dusun = GetCellValueOrNull(selectedRow, "nama_dusun")?.ToString(),
                            Agama = GetCellValueOrNull(selectedRow, "Agama")?.ToString(),
                            Pendidikan_Terakhir = GetCellValueOrNull(selectedRow, "Pendidikan_Terakhir")?.ToString(),
                            Gelar_Depan = GetCellValueOrNull(selectedRow, "Gelar_Depan")?.ToString(),
                            Gelar_Belakang = GetCellValueOrNull(selectedRow, "Gelar_Belakang")?.ToString(),
                            no_hp = GetCellValueOrNull(selectedRow, "no_hp")?.ToString(),
                            email = GetCellValueOrNull(selectedRow, "email")?.ToString(),
                            Passport_Number = GetCellValueOrNull(selectedRow, "Passport_Number")?.ToString(),
                            Tgl_Berakhir_Paspor = GetDateValueOrNull(selectedRow, "Tgl_Berakhir_Paspor"),
                            No_SK_Penetapan_WNI = GetCellValueOrNull(selectedRow, "No_SK_Penetapan_WNI")?.ToString(),
                            Akta_Lahir = GetCellValueOrNull(selectedRow, "Akta_Lahir")?.ToString(),
                            Nomor_Akta_Kelahiran = GetCellValueOrNull(selectedRow, "Nomor_Akta_Kelahiran")?.ToString(),
                            Golongan_Darah = GetCellValueOrNull(selectedRow, "Golongan_Darah")?.ToString(),
                            Nama_Organisasi_Kepercayaan = GetCellValueOrNull(selectedRow, "Nama_Organisasi_Kepercayaan")?.ToString(),
                            Status_Perkawinan = GetCellValueOrNull(selectedRow, "Status_Perkawinan")?.ToString(),
                            Tanggal_Perkawinan = GetDateValueOrNull(selectedRow, "Tanggal_Perkawinan"),
                            Akta_Perkawinan = GetCellValueOrNull(selectedRow, "Akta_Perkawinan")?.ToString(),
                            Nomor_Akta_Perkawinan = GetCellValueOrNull(selectedRow, "Nomor_Akta_Perkawinan")?.ToString(),
                            Akta_Cerai = GetCellValueOrNull(selectedRow, "Akta_Cerai")?.ToString(),
                            Nomor_Akta_Cerai = GetCellValueOrNull(selectedRow, "Nomor_Akta_Cerai")?.ToString(),
                            Tanggal_Perceraian = GetDateValueOrNull(selectedRow, "Tanggal_Perceraian"),
                            Status_Hubungan_Dalam_Keluarga = GetCellValueOrNull(selectedRow, "Status_Hubungan_Dalam_Keluarga")?.ToString(),
                            Kelainan_Fisik_dan_Mental = GetCellValueOrNull(selectedRow, "Kelainan_Fisik_dan_Mental")?.ToString(),
                            Penyandang_Cacat = GetCellValueOrNull(selectedRow, "Penyandang_Cacat")?.ToString(),
                            NIK_Ibu = GetCellValueOrNull(selectedRow, "NIK_Ibu")?.ToString(),
                            Nama_Ibu = GetCellValueOrNull(selectedRow, "Nama_Ibu")?.ToString(),
                            NIK_Ayah = GetCellValueOrNull(selectedRow, "NIK_Ayah")?.ToString(),
                            Nama_Ayah = GetCellValueOrNull(selectedRow, "Nama_Ayah")?.ToString(),
                            Tanggal_Masuk = GetDateValueOrNull(selectedRow, "Tanggal_Masuk"),
                            alamat_luar_negeri = GetCellValueOrNull(selectedRow, "alamat_luar_negeri")?.ToString(),
                            kota_luar_negeri = GetCellValueOrNull(selectedRow, "kota_luar_negeri")?.ToString(),
                            provinsi_negara_bagian_luar_negeri = GetCellValueOrNull(selectedRow, "provinsi_negara_bagian_luar_negeri")?.ToString(),
                            kode_pos_luar_negeri = GetCellValueOrNull(selectedRow, "kode_pos_luar_negeri")?.ToString(),
                            Nama_Sponsor = GetCellValueOrNull(selectedRow, "Nama_Sponsor")?.ToString(),
                            Tipe_Sponsor = GetCellValueOrNull(selectedRow, "Tipe_Sponsor")?.ToString(),
                            Alamat_Sponsor = GetCellValueOrNull(selectedRow, "Alamat_Sponsor")?.ToString(),
                            kode_negara = GetCellValueOrNull(selectedRow, "kode_negara")?.ToString(),
                            nama_negara = GetCellValueOrNull(selectedRow, "nama_negara")?.ToString(),
                            kode_perwakilan_ri = GetCellValueOrNull(selectedRow, "kode_perwakilan_ri")?.ToString(),
                            nama_perwakilan_ri = GetCellValueOrNull(selectedRow, "nama_perwakilan_ri")?.ToString(),
                            Nomor_ITAS_ITAP = GetCellValueOrNull(selectedRow, "Nomor_ITAS_ITAP")?.ToString(),
                            Tempat_Terbit_ITAS_ITAP = GetCellValueOrNull(selectedRow, "Tempat_Terbit_ITAS_ITAP")?.ToString(),
                            Tanggal_Terbit_ITAS_ITAP = GetDateValueOrNull(selectedRow, "Tanggal_Terbit_ITAS_ITAP"),
                            Tanggal_Akhir_ITAS_ITAP = GetDateValueOrNull(selectedRow, "Tanggal_Akhir_ITAS_ITAP"),
                            Tempat_Datang_Pertama = GetCellValueOrNull(selectedRow, "Tempat_Datang_Pertama")?.ToString(),
                            Tanggal_Kedatangan_Pertama = GetDateValueOrNull(selectedRow, "Tanggal_Kedatangan_Pertama"),
                            Status_Kependudukan = GetCellValueOrNull(selectedRow, "Status_Kependudukan")?.ToString(),
                            kode_pos = GetCellValueOrNull(selectedRow, "kode_pos")?.ToString(),
                            nama_provinsi = GetCellValueOrNull(selectedRow, "nama_provinsi")?.ToString(),
                            nama_kabupaten = GetCellValueOrNull(selectedRow, "nama_kabupaten")?.ToString(),
                            nama_kecamatan = GetCellValueOrNull(selectedRow, "nama_kecamatan")?.ToString(),
                            nama_desa = GetCellValueOrNull(selectedRow, "nama_desa")?.ToString(),
                            Tgl_Kematian = GetDateValueOrNull(selectedRow, "Tgl_Kematian")
                        };

                        // Enkripsi data sebelum update
                        var encryptedPenduduk = penduduk.EncryptModel();

                        string sqlUpdate = @"
                            UPDATE gabungan_keluarga SET 
                                Nomor_KK = @Nomor_KK,
                                Nama_Lengkap = @Nama_Lengkap,
                                Jenis_Kelamin = @Jenis_Kelamin,
                                Tempat_Lahir = @Tempat_Lahir,
                                Tanggal_Lahir = @Tanggal_Lahir,
                                Kewarganegaraan = @Kewarganegaraan,
                                Jenis_Pekerjaan = @Jenis_Pekerjaan,
                                alamat = @alamat,
                                rt = @rt,
                                rw = @rw,
                                nama_dusun = @nama_dusun,
                                Agama = @Agama,
                                Pendidikan_Terakhir = @Pendidikan_Terakhir,
                                Gelar_Depan = @Gelar_Depan,
                                Gelar_Belakang = @Gelar_Belakang,
                                no_hp = @no_hp,
                                email = @email,
                                Passport_Number = @Passport_Number,
                                Tgl_Berakhir_Paspor = @Tgl_Berakhir_Paspor,
                                No_SK_Penetapan_WNI = @No_SK_Penetapan_WNI,
                                Akta_Lahir = @Akta_Lahir,
                                Nomor_Akta_Kelahiran = @Nomor_Akta_Kelahiran,
                                Golongan_Darah = @Golongan_Darah,
                                Nama_Organisasi_Kepercayaan = @Nama_Organisasi_Kepercayaan,
                                Status_Perkawinan = @Status_Perkawinan,
                                Tanggal_Perkawinan = @Tanggal_Perkawinan,
                                Akta_Perkawinan = @Akta_Perkawinan,
                                Nomor_Akta_Perkawinan = @Nomor_Akta_Perkawinan,
                                Akta_Cerai = @Akta_Cerai,
                                Nomor_Akta_Cerai = @Nomor_Akta_Cerai,
                                Tanggal_Perceraian = @Tanggal_Perceraian,
                                Status_Hubungan_Dalam_Keluarga = @Status_Hubungan_Dalam_Keluarga,
                                Kelainan_Fisik_dan_Mental = @Kelainan_Fisik_dan_Mental,
                                Penyandang_Cacat = @Penyandang_Cacat,
                                NIK_Ibu = @NIK_Ibu,
                                Nama_Ibu = @Nama_Ibu,
                                NIK_Ayah = @NIK_Ayah,
                                Nama_Ayah = @Nama_Ayah,
                                Tanggal_Masuk = @Tanggal_Masuk,
                                Nama_Sponsor = @Nama_Sponsor,
                                Tipe_Sponsor = @Tipe_Sponsor,
                                Alamat_Sponsor = @Alamat_Sponsor,
                                kode_negara = @kode_negara,
                                nama_negara = @nama_negara,
                                kode_perwakilan_ri = @kode_perwakilan_ri,
                                nama_perwakilan_ri = @nama_perwakilan_ri,
                                Nomor_ITAS_ITAP = @Nomor_ITAS_ITAP,
                                Tempat_Terbit_ITAS_ITAP = @Tempat_Terbit_ITAS_ITAP,
                                Tanggal_Terbit_ITAS_ITAP = @Tanggal_Terbit_ITAS_ITAP,
                                Tanggal_Akhir_ITAS_ITAP = @Tanggal_Akhir_ITAS_ITAP,
                                Tempat_Datang_Pertama = @Tempat_Datang_Pertama,
                                Tanggal_Kedatangan_Pertama = @Tanggal_Kedatangan_Pertama,
                                alamat_luar_negeri = @alamat_luar_negeri,
                                kota_luar_negeri = @kota_luar_negeri,
                                provinsi_negara_bagian_luar_negeri = @provinsi_negara_bagian_luar_negeri,
                                kode_pos_luar_negeri = @kode_pos_luar_negeri,
                                Status_Kependudukan = @Status_Kependudukan
                            WHERE NIK = @NIK";

                        int rowsAffected = db.Execute(sqlUpdate, encryptedPenduduk);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diupdate.", "Informasi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDatabasePenduduk();
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data yang diupdate.", "Informasi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat mengupdate data: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private object GetCellValueOrNull(DataGridViewRow row, string columnName)
        {
            if (row.Cells[columnName].Value == null || row.Cells[columnName].Value == DBNull.Value ||
                (row.Cells[columnName].Value is string && string.IsNullOrEmpty((string)row.Cells[columnName].Value)))
            {
                return null;
            }
            return row.Cells[columnName].Value;
        }

        private DateTime? GetDateValueOrNull(DataGridViewRow row, string columnName)
        {
            if (row.Cells[columnName].Value == null || row.Cells[columnName].Value == DBNull.Value)
            {
                return null;
            }

            try
            {
                return (DateTime?)Convert.ChangeType(row.Cells[columnName].Value, typeof(DateTime?));
            }
            catch
            {
                return null;
            }
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            using (var formImportExcel = new Forms.FormImportExcel())
            {
                if (formImportExcel.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the database view after successful import
                    LoadDatabasePenduduk();
                }
            }
        }

        private void FormTambahPenduduk_FormClosed(object sender, FormClosedEventArgs e)
        {
            searchTimer?.Stop();
            searchTimer?.Dispose();
            searchCancellationTokenSource?.Cancel();
            searchCancellationTokenSource?.Dispose();
        }
        #endregion Manajemen Database Penduduk

        //// Kode untuk mengenkripsi ulang field tertentu pada tabel Penduduk
        //private void EncryptPendudukFields()
        //{
        //    try
        //    {
        //        // Tampilkan confirmation dialog
        //        DialogResult result = MessageBox.Show(
        //            "Apakah Anda yakin ingin mengenkripsi ulang field Passport_Number, no_hp, NIK_Ibu, dan NIK_Ayah " +
        //            "pada semua record?\n\nProses ini mungkin memakan waktu tergantung jumlah data.",
        //            "Konfirmasi Enkripsi Data",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);

        //        if (result == DialogResult.Yes)
        //        {
        //            // Tampilkan progress dialog
        //            using (var progressForm = new Form())
        //            {
        //                progressForm.Text = "Mengenkripsi Data...";
        //                progressForm.Size = new Size(300, 100);
        //                progressForm.StartPosition = FormStartPosition.CenterParent;
        //                progressForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //                progressForm.MaximizeBox = false;
        //                progressForm.MinimizeBox = false;
        //                progressForm.ControlBox = false;

        //                var label = new Label
        //                {
        //                    Text = "Sedang mengenkripsi data, mohon tunggu...",
        //                    AutoSize = true,
        //                    Location = new Point(20, 20)
        //                };

        //                progressForm.Controls.Add(label);

        //                // Jalankan enkripsi di thread terpisah
        //                Task.Run(() =>
        //                {
        //                    int updatedCount = 0;

        //                    try
        //                    {
        //                        updatedCount = EncryptionUtil.ReencryptPendudukFields();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        this.Invoke(() =>
        //                        {
        //                            progressForm.Close();
        //                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        });
        //                        return;
        //                    }

        //                    this.Invoke(() =>
        //                    {
        //                        progressForm.Close();
        //                        MessageBox.Show($"{updatedCount} record berhasil dienkripsi ulang.",
        //                            "Enkripsi Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                        // Reload data setelah enkripsi selesai
        //                        if (updatedCount > 0)
        //                        {
        //                            LoadDatabasePenduduk();
        //                        }
        //                    });
        //                });

        //                progressForm.ShowDialog(this);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnEncryptFields_Click(object sender, EventArgs e)
        //{
        //    EncryptPendudukFields();
        //}
    }
}