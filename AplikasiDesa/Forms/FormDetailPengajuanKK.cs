using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace AplikasiDesa.Forms
{
    public partial class FormDetailPengajuanKK : Form
    {
        private int idPengajuan;

        public FormDetailPengajuanKK(int id)
        {
            InitializeComponent();
            idPengajuan = id;
            LoadDetailPengajuan();
            LoadAnggotaKeluarga();
        }

        private void LoadDetailPengajuan()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = @"SELECT p.*, 
                                 (SELECT g.Nama_Lengkap FROM gabungan_keluarga g WHERE g.NIK = p.nik_kepala LIMIT 1) AS nama_kepala
                                 FROM pengajuan_kk p 
                                 WHERE p.id = @id";

                    var pengajuan = connection.QuerySingleOrDefault(sql, new { id = idPengajuan });
                    string nama_lengkap = pengajuan.nama_kepala;

                    var namaModel = new PendudukModel
                    {
                        Nama_Lengkap = nama_lengkap
                    };

                    // Encrypt the token
                    var decryptedNamaModel = namaModel.DecryptModel();

                    if (pengajuan != null)
                    {
                        lblIDValue.Text = pengajuan.id.ToString();
                        lblTanggalValue.Text = Convert.ToDateTime(pengajuan.tanggal_pengajuan).ToString("dd/MM/yyyy HH:mm");
                        lblNIKValue.Text = pengajuan.nik_kepala;
                        lblNamaValue.Text = decryptedNamaModel.Nama_Lengkap;
                        lblJenisValue.Text = pengajuan.jenis_formulir;
                        lblStatusValue.Text = pengajuan.status;
                        lblNomorKKValue.Text = pengajuan.nomor_kk_baru ?? "-";
                    }
                    else
                    {
                        MessageBox.Show("Data pengajuan tidak ditemukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAnggotaKeluarga()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string sql = @"SELECT a.nik, a.nama_lengkap, a.status_hubungan,
                                  g.jenis_kelamin, g.tempat_lahir, g.tanggal_lahir, g.pendidikan_terakhir
                                  FROM anggota_pengajuan_kk a
                                  LEFT JOIN gabungan_keluarga g ON a.nik = g.NIK
                                  WHERE a.id_pengajuan = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", idPengajuan);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["nama_lengkap"] != DBNull.Value)
                        {
                            string encryptedNama = row["nama_lengkap"].ToString();
                            var namaModel = new PendudukModel
                            {
                                Nama_Lengkap = encryptedNama
                            };
                            var decryptedNamaModel = namaModel.DecryptModel();
                            row["nama_lengkap"] = decryptedNamaModel.Nama_Lengkap;
                        }

                        if (row["tempat_lahir"] != DBNull.Value)
                        {
                            string encryptedTempatLahir = row["tempat_lahir"].ToString();
                            var namaModel = new PendudukModel
                            {
                                Tempat_Lahir = encryptedTempatLahir
                            };
                            var decryptedNamaModel = namaModel.DecryptModel();
                            row["tempat_lahir"] = decryptedNamaModel.Tempat_Lahir;
                        }
                    }

                    dataGridViewAnggota.DataSource = dt;

                    if (dataGridViewAnggota.Columns.Count > 0)
                    {
                        dataGridViewAnggota.Columns["nik"].HeaderText = "NIK";
                        dataGridViewAnggota.Columns["nama_lengkap"].HeaderText = "Nama Lengkap";
                        dataGridViewAnggota.Columns["status_hubungan"].HeaderText = "Status dalam Keluarga";
                        dataGridViewAnggota.Columns["jenis_kelamin"].HeaderText = "Jenis Kelamin";
                        dataGridViewAnggota.Columns["tempat_lahir"].HeaderText = "Tempat Lahir";
                        dataGridViewAnggota.Columns["tanggal_lahir"].HeaderText = "Tanggal Lahir";
                        dataGridViewAnggota.Columns["pendidikan_terakhir"].HeaderText = "Pendidikan";

                        dataGridViewAnggota.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading anggota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
