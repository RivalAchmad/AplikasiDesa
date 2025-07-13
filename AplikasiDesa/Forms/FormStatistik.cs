using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace AplikasiDesa.Forms
{
    public partial class FormStatistik : Form
    {
        private bool isLoading = false;
        private System.Windows.Forms.Timer sessionTimer;

        public FormStatistik()
        {
            InitializeComponent();
            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 600000; // Periksa setiap 10 menit
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
            VerifySession();
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

        private void FormStatistik_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            if (isLoading) return;
            isLoading = true;

            try
            {
                LoadTotalPenduduk();
                LoadTotalKK();
                LoadJenisKelaminChart();
                LoadUsiaDistribusiChart();
                LoadDusunDistribusiChart();
                LoadRTRW();
                LoadNumpang();
                LoadPendidikanChart();
                LoadPekerjaanChart();
                LoadAgamaChart();
                LoadPerkawinanChart();
                LoadGolonganDarahChart();
                LoadKelainanFisikChart();
                LoadDisabilitasChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        #region Data Loading Methods

        private void LoadTotalPenduduk()
        {
            string sql = "SELECT COUNT(*) FROM gabungan_keluarga WHERE Status_Kependudukan = 'HIDUP'";

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    int total = connection.ExecuteScalar<int>(sql);
                    lblTotalPenduduk.Text = total.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat total penduduk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTotalKK()
        {
            string sql = "SELECT COUNT(DISTINCT Nomor_KK) FROM gabungan_keluarga WHERE Nomor_KK IS NOT NULL AND Nomor_KK != ''";

            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    int total = connection.ExecuteScalar<int>(sql);
                    lblTotalKK.Text = total.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat total KK: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJenisKelaminChart()
        {
            string sql = @"
                SELECT 
                    Jenis_Kelamin, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Jenis_Kelamin";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartJenisKelamin.Series[0].Points.Clear();

                    // Set chart properties
                    chartJenisKelamin.Series[0].ChartType = SeriesChartType.Pie;
                    chartJenisKelamin.Series[0].IsValueShownAsLabel = true;
                    chartJenisKelamin.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string jenisKelamin = row["Jenis_Kelamin"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        // Default value if null or empty
                        if (string.IsNullOrEmpty(jenisKelamin))
                        {
                            jenisKelamin = "Tidak Diketahui";
                        }

                        int pointIndex = chartJenisKelamin.Series[0].Points.AddY(jumlah);
                        chartJenisKelamin.Series[0].Points[pointIndex].LegendText = jenisKelamin;
                        chartJenisKelamin.Series[0].Points[pointIndex].Label = $"{jumlah} ({jenisKelamin})";

                        // Set colors for pie slices
                        if (jenisKelamin.Equals("Laki-laki", StringComparison.OrdinalIgnoreCase))
                        {
                            chartJenisKelamin.Series[0].Points[pointIndex].Color = Color.CornflowerBlue;
                        }
                        else if (jenisKelamin.Equals("Perempuan", StringComparison.OrdinalIgnoreCase))
                        {
                            chartJenisKelamin.Series[0].Points[pointIndex].Color = Color.LightPink;
                        }
                    }

                    // Configure the chart appearance
                    chartJenisKelamin.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartJenisKelamin.ChartAreas[0].Area3DStyle.Inclination = 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data jenis kelamin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsiaDistribusiChart()
        {
            string sql = @"
                SELECT 
                    CASE 
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 0 AND 5 THEN '0-5'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 6 AND 12 THEN '6-12'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 13 AND 17 THEN '13-17'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 18 AND 25 THEN '18-25'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 26 AND 40 THEN '26-40'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 41 AND 60 THEN '41-60'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) > 60 THEN '>60'
                        ELSE 'Tidak Diketahui'
                    END as KelompokUsia,
                    COUNT(*) as Jumlah
                FROM 
                    gabungan_keluarga
                WHERE 
                    Status_Kependudukan = 'HIDUP' 
                    AND Tanggal_Lahir IS NOT NULL
                GROUP BY 
                    CASE 
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 0 AND 5 THEN '0-5'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 6 AND 12 THEN '6-12'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 13 AND 17 THEN '13-17'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 18 AND 25 THEN '18-25'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 26 AND 40 THEN '26-40'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) BETWEEN 41 AND 60 THEN '41-60'
                        WHEN TIMESTAMPDIFF(YEAR, Tanggal_Lahir, CURDATE()) > 60 THEN '>60'
                        ELSE 'Tidak Diketahui'
                    END
                ORDER BY 
                    CASE KelompokUsia
                        WHEN '0-5' THEN 1
                        WHEN '6-12' THEN 2
                        WHEN '13-17' THEN 3
                        WHEN '18-25' THEN 4
                        WHEN '26-40' THEN 5
                        WHEN '41-60' THEN 6
                        WHEN '>60' THEN 7
                        ELSE 8
                    END";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartUsiaDistribusi.Series[0].Points.Clear();

                    // Set chart properties - Changed to Pie chart
                    chartUsiaDistribusi.Series[0].ChartType = SeriesChartType.Pie;
                    chartUsiaDistribusi.Series[0].IsValueShownAsLabel = true;
                    chartUsiaDistribusi.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string kelompokUsia = row["KelompokUsia"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartUsiaDistribusi.Series[0].Points.AddY(jumlah);
                        chartUsiaDistribusi.Series[0].Points[pointIndex].LegendText = kelompokUsia;
                        chartUsiaDistribusi.Series[0].Points[pointIndex].Label = $"{jumlah} ({kelompokUsia})";

                        // Apply gradient colors based on age groups
                        if (kelompokUsia == "0-5")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.LightSkyBlue;
                        else if (kelompokUsia == "6-12")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.SkyBlue;
                        else if (kelompokUsia == "13-17")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.DeepSkyBlue;
                        else if (kelompokUsia == "18-25")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.RoyalBlue;
                        else if (kelompokUsia == "26-40")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.MediumBlue;
                        else if (kelompokUsia == "41-60")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.DarkBlue;
                        else if (kelompokUsia == ">60")
                            chartUsiaDistribusi.Series[0].Points[pointIndex].Color = Color.Navy;
                    }

                    // Configure chart appearance
                    chartUsiaDistribusi.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartUsiaDistribusi.ChartAreas[0].Area3DStyle.Inclination = 30;
                    chartUsiaDistribusi.Legends[0].Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data distribusi usia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDusunDistribusiChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(nama_dusun, 'Tidak Diketahui') as Dusun, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY nama_dusun";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartDusunDistribusi.Series[0].Points.Clear();

                    // Set chart properties
                    chartDusunDistribusi.Series[0].ChartType = SeriesChartType.Pie;
                    chartDusunDistribusi.Series[0].IsValueShownAsLabel = true;
                    chartDusunDistribusi.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string namaDusun = row["Dusun"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartDusunDistribusi.Series[0].Points.AddY(jumlah);
                        chartDusunDistribusi.Series[0].Points[pointIndex].LegendText = namaDusun;
                        chartDusunDistribusi.Series[0].Points[pointIndex].Label = $"{jumlah} ({namaDusun})";
                    }

                    // Configure chart appearance
                    chartDusunDistribusi.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartDusunDistribusi.ChartAreas[0].Area3DStyle.Inclination = 30;
                    chartDusunDistribusi.Palette = ChartColorPalette.BrightPastel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data distribusi dusun: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRTRW()
        {
            try
            {
                if (comboBoxRT.SelectedItem == null || comboBoxRW.SelectedItem == null)
                    return;

                string rtDipilih = comboBoxRT.SelectedItem.ToString();
                string rwDipilih = comboBoxRW.SelectedItem.ToString();

                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string queryFilterRT = @"
                        SELECT COUNT(*) 
                        FROM gabungan_keluarga 
                        WHERE rt = @RT
                        AND rw = @RW
                        AND Status_Kependudukan = 'HIDUP'";

                    string queryFilterRW = @"
                        SELECT COUNT(*) 
                        FROM gabungan_keluarga 
                        WHERE rw = @RW
                        AND Status_Kependudukan = 'HIDUP'";

                    int jumlahFilterRT = connection.ExecuteScalar<int>(queryFilterRT,
                        new { RT = rtDipilih, RW = rwDipilih });

                    int jumlahFilterRW = connection.ExecuteScalar<int>(queryFilterRW,
                        new { RW = rwDipilih });

                    lblRT.Text = $"Jumlah penduduk RT {rtDipilih} RW {rwDipilih}: {jumlahFilterRT}";
                    lblRW.Text = $"Total penduduk RW {rwDipilih}: {jumlahFilterRW}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat statistik RT/RW: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRTRW();
        }

        private void comboBoxRW_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRTRW();
        }

        private void LoadNumpang()
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
                        FROM gabungan_keluarga 
                        WHERE MONTH(Tanggal_Masuk) = @Bulan 
                        AND YEAR(Tanggal_Masuk) = @Tahun
                        AND Status_Kependudukan = 'MENUMPANG'";

                    string queryFilterTahun = @"
                        SELECT COUNT(*) 
                        FROM gabungan_keluarga
                        WHERE YEAR(Tanggal_Masuk) = @Tahun
                        AND Status_Kependudukan = 'MENUMPANG'";

                    int jumlahFilterBulan = connection.ExecuteScalar<int>(queryFilter,
                        new { Bulan = bulanDipilih, Tahun = tahunDipilih });

                    int jumlahFilterTahun = connection.ExecuteScalar<int>(queryFilterTahun,
                        new { Tahun = tahunDipilih });

                    lblBulan.Text = $"Jumlah penduduk masuk bulan {namaBulan[bulanDipilih - 1]} {tahunDipilih}: {jumlahFilterBulan}";
                    lblTahun.Text = $"Total penduduk masuk tahun {tahunDipilih}: {jumlahFilterTahun}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat statistik penduduk numpang: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNumpang();
        }

        private void comboBoxTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNumpang();
        }

        private void LoadPendidikanChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Pendidikan_Terakhir, 'Tidak Diketahui') as Pendidikan, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Pendidikan_Terakhir 
                ORDER BY COUNT(*) DESC";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartPendidikan.Series[0].Points.Clear();

                    // Set chart properties
                    chartPendidikan.Series[0].ChartType = SeriesChartType.Pie;
                    chartPendidikan.Series[0].IsValueShownAsLabel = true;
                    chartPendidikan.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string pendidikan = row["Pendidikan"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartPendidikan.Series[0].Points.AddY(jumlah);
                        chartPendidikan.Series[0].Points[pointIndex].LegendText = pendidikan;
                        chartPendidikan.Series[0].Points[pointIndex].Label = $"{jumlah}";
                    }

                    // Configure chart appearance
                    chartPendidikan.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartPendidikan.ChartAreas[0].Area3DStyle.Inclination = 30;
                    chartPendidikan.Palette = ChartColorPalette.BrightPastel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data pendidikan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPekerjaanChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Jenis_Pekerjaan, 'Tidak Diketahui') as Pekerjaan, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Jenis_Pekerjaan 
                ORDER BY COUNT(*) DESC 
                LIMIT 15";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartPekerjaan.Series[0].Points.Clear();

                    // Set chart properties - Changed to Pie chart
                    chartPekerjaan.Series[0].ChartType = SeriesChartType.Pie;
                    chartPekerjaan.Series[0].IsValueShownAsLabel = true;
                    chartPekerjaan.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string pekerjaan = row["Pekerjaan"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        // Trim long occupation names
                        string displayPekerjaan = pekerjaan;

                        int dotIndex = pekerjaan.IndexOf('.');
                        if (dotIndex > 0 && dotIndex < pekerjaan.Length - 1)
                        {
                            // Ambil bagian setelah titik dan trim whitespace
                            displayPekerjaan = pekerjaan.Substring(dotIndex + 1).Trim();
                        }

                        if (pekerjaan.Length > 30)
                        {
                            displayPekerjaan = pekerjaan.Substring(0, 27) + "...";
                        }

                        int pointIndex = chartPekerjaan.Series[0].Points.AddY(jumlah);
                        chartPekerjaan.Series[0].Points[pointIndex].LegendText = displayPekerjaan;
                        chartPekerjaan.Series[0].Points[pointIndex].Label = $"{jumlah}";
                    }

                    // Configure chart appearance
                    chartPekerjaan.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartPekerjaan.ChartAreas[0].Area3DStyle.Inclination = 30;
                    chartPekerjaan.Palette = ChartColorPalette.EarthTones;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data pekerjaan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAgamaChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Agama, 'Tidak Diketahui') as Agama, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Agama 
                ORDER BY COUNT(*) DESC";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartAgama.Series[0].Points.Clear();

                    // Set chart properties
                    chartAgama.Series[0].ChartType = SeriesChartType.Pie;
                    chartAgama.Series[0].IsValueShownAsLabel = true;
                    chartAgama.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string agama = row["Agama"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartAgama.Series[0].Points.AddY(jumlah);
                        chartAgama.Series[0].Points[pointIndex].LegendText = agama;
                        chartAgama.Series[0].Points[pointIndex].Label = $"{jumlah} ({agama})";
                    }

                    // Configure chart appearance
                    chartAgama.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartAgama.ChartAreas[0].Area3DStyle.Inclination = 30;
                    chartAgama.Palette = ChartColorPalette.Berry;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data agama: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPerkawinanChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Status_Perkawinan, 'Tidak Diketahui') as StatusPerkawinan, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Status_Perkawinan 
                ORDER BY COUNT(*) DESC";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartPerkawinan.Series[0].Points.Clear();

                    // Set chart properties
                    chartPerkawinan.Series[0].ChartType = SeriesChartType.Pie;
                    chartPerkawinan.Series[0].IsValueShownAsLabel = true;
                    chartPerkawinan.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string statusPerkawinan = row["StatusPerkawinan"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartPerkawinan.Series[0].Points.AddY(jumlah);
                        chartPerkawinan.Series[0].Points[pointIndex].LegendText = statusPerkawinan;
                        chartPerkawinan.Series[0].Points[pointIndex].Label = $"{jumlah} ({statusPerkawinan})";

                        // Set colors based on status
                        if (statusPerkawinan.Equals("Belum Kawin", StringComparison.OrdinalIgnoreCase))
                        {
                            chartPerkawinan.Series[0].Points[pointIndex].Color = Color.LightBlue;
                        }
                        else if (statusPerkawinan.Equals("Kawin", StringComparison.OrdinalIgnoreCase))
                        {
                            chartPerkawinan.Series[0].Points[pointIndex].Color = Color.LightGreen;
                        }
                        else if (statusPerkawinan.Contains("Cerai"))
                        {
                            chartPerkawinan.Series[0].Points[pointIndex].Color = Color.LightCoral;
                        }
                    }

                    // Configure chart appearance
                    chartPerkawinan.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartPerkawinan.ChartAreas[0].Area3DStyle.Inclination = 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data status perkawinan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGolonganDarahChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Golongan_Darah, 'Tidak Diketahui') as GolonganDarah, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Golongan_Darah 
                ORDER BY GolonganDarah";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartGolonganDarah.Series[0].Points.Clear();

                    // Set chart properties - Changed to Pie chart
                    chartGolonganDarah.Series[0].ChartType = SeriesChartType.Pie;
                    chartGolonganDarah.Series[0].IsValueShownAsLabel = true;
                    chartGolonganDarah.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string golonganDarah = row["GolonganDarah"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartGolonganDarah.Series[0].Points.AddY(jumlah);
                        chartGolonganDarah.Series[0].Points[pointIndex].LegendText = golonganDarah;
                        chartGolonganDarah.Series[0].Points[pointIndex].Label = $"{jumlah}";
                    }

                    // Configure chart appearance
                    chartGolonganDarah.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartGolonganDarah.ChartAreas[0].Area3DStyle.Inclination = 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data golongan darah: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKelainanFisikChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Kelainan_Fisik_dan_Mental, 'Tidak Diketahui') as KelainanFisik, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP'
                GROUP BY Kelainan_Fisik_dan_Mental";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartKelainanFisik.Series[0].Points.Clear();

                    // Set chart properties
                    chartKelainanFisik.Series[0].ChartType = SeriesChartType.Pie;
                    chartKelainanFisik.Series[0].IsValueShownAsLabel = true;
                    chartKelainanFisik.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string kelainanFisik = row["KelainanFisik"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartKelainanFisik.Series[0].Points.AddY(jumlah);
                        chartKelainanFisik.Series[0].Points[pointIndex].LegendText = kelainanFisik;
                        chartKelainanFisik.Series[0].Points[pointIndex].Label = $"{jumlah} ({kelainanFisik})";

                        // Set different colors
                        if (kelainanFisik.Equals("Ada", StringComparison.OrdinalIgnoreCase))
                        {
                            chartKelainanFisik.Series[0].Points[pointIndex].Color = Color.LightCoral;
                        }
                        else if (kelainanFisik.Equals("Tidak Ada", StringComparison.OrdinalIgnoreCase))
                        {
                            chartKelainanFisik.Series[0].Points[pointIndex].Color = Color.LightGreen;
                        }
                    }

                    // Configure chart appearance
                    chartKelainanFisik.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartKelainanFisik.ChartAreas[0].Area3DStyle.Inclination = 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data kelainan fisik/mental: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDisabilitasChart()
        {
            string sql = @"
                SELECT 
                    COALESCE(Penyandang_Cacat, 'Tidak Ada') as JenisDisabilitas, 
                    COUNT(*) as Jumlah 
                FROM 
                    gabungan_keluarga 
                WHERE 
                    Status_Kependudukan = 'HIDUP' 
                    AND Kelainan_Fisik_dan_Mental = 'Ada'
                GROUP BY Penyandang_Cacat 
                ORDER BY COUNT(*) DESC";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing data
                    chartDisabilitas.Series[0].Points.Clear();

                    // Set chart properties - Changed to Pie chart
                    chartDisabilitas.Series[0].ChartType = SeriesChartType.Pie;
                    chartDisabilitas.Series[0].IsValueShownAsLabel = true;
                    chartDisabilitas.Series[0].LabelFormat = "{0} ({1:P1})";

                    // Add data points
                    foreach (DataRow row in dt.Rows)
                    {
                        string jenisDisabilitas = row["JenisDisabilitas"].ToString();
                        int jumlah = Convert.ToInt32(row["Jumlah"]);

                        int pointIndex = chartDisabilitas.Series[0].Points.AddY(jumlah);
                        chartDisabilitas.Series[0].Points[pointIndex].LegendText = jenisDisabilitas;
                        chartDisabilitas.Series[0].Points[pointIndex].Label = $"{jumlah} ({jenisDisabilitas})";
                    }

                    // Configure chart appearance
                    chartDisabilitas.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartDisabilitas.ChartAreas[0].Area3DStyle.Inclination = 30;
                    chartDisabilitas.Palette = ChartColorPalette.Pastel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data jenis disabilitas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void FormStatistik_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
