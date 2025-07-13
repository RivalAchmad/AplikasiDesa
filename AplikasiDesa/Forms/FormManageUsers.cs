using AplikasiDesa.Models;
using AplikasiDesa.Utils;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace AplikasiDesa.Forms
{
    public partial class FormManageUsers : Form
    {
        private int _selectedUserId = 0;
        private string _currentUsername = string.Empty;
        private System.Windows.Forms.Timer sessionTimer;

        public FormManageUsers()
        {
            InitializeComponent();
            VerifySession();
            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 600000; // Check every 10 minutes
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();

            this.Text = "Manajemen Pengguna";

            LoadUserData();
            LoadLoginLogs();
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

        private void LoadUserData()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    _currentUsername = Session1.LoggedInUser;

                    string query = @"SELECT id, username, nama_petugas, jabatan, email, created_at 
                          FROM petugas 
                          ORDER BY created_at DESC";

                    var encryptedUsers = connection.Query(query).ToList();

                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("id", typeof(int));
                    displayTable.Columns.Add("username", typeof(string));
                    displayTable.Columns.Add("nama_petugas", typeof(string));
                    displayTable.Columns.Add("jabatan", typeof(string));
                    displayTable.Columns.Add("email", typeof(string));
                    displayTable.Columns.Add("created_at", typeof(DateTime));

                    foreach (var encryptedUser in encryptedUsers)
                    {
                        var userModel = new PetugasModel
                        {
                            username = encryptedUser.username,
                            nama_petugas = encryptedUser.nama_petugas,
                            email = encryptedUser.email
                        };

                        var decryptedUser = userModel.DecryptModel();

                        DataRow row = displayTable.NewRow();
                        row["id"] = encryptedUser.id;
                        row["username"] = decryptedUser.username;
                        row["nama_petugas"] = decryptedUser.nama_petugas;
                        row["jabatan"] = encryptedUser.jabatan;
                        row["email"] = decryptedUser.email;
                        row["created_at"] = encryptedUser.created_at;

                        displayTable.Rows.Add(row);
                    }

                    dataGridViewUsers.DataSource = displayTable;

                    if (dataGridViewUsers.Columns.Count > 0)
                    {
                        if (dataGridViewUsers.Columns["id"] != null)
                            dataGridViewUsers.Columns["id"].HeaderText = "ID";

                        if (dataGridViewUsers.Columns["username"] != null)
                            dataGridViewUsers.Columns["username"].HeaderText = "Username";

                        if (dataGridViewUsers.Columns["nama_petugas"] != null)
                            dataGridViewUsers.Columns["nama_petugas"].HeaderText = "Nama Petugas";

                        if (dataGridViewUsers.Columns["jabatan"] != null)
                            dataGridViewUsers.Columns["jabatan"].HeaderText = "Jabatan";

                        if (dataGridViewUsers.Columns["email"] != null)
                            dataGridViewUsers.Columns["email"].HeaderText = "Email";

                        if (dataGridViewUsers.Columns["created_at"] != null)
                        {
                            dataGridViewUsers.Columns["created_at"].HeaderText = "Tanggal Dibuat";
                            dataGridViewUsers.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                        }
                    }

                    dataGridViewUsers.ClearSelection();
                    lblTotalUsers.Text = $"Total Pengguna: {displayTable.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data pengguna: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoginLogs()
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                {
                    string query = @"SELECT ll.id, ll.user_id, ll.login_time, ll.ip_address, ll.login_status,
                                           p.username, p.nama_petugas
                                    FROM login_logs ll
                                    LEFT JOIN petugas p ON ll.user_id = p.id
                                    ORDER BY ll.login_time DESC
                                    LIMIT 500";

                    var loginLogs = connection.Query(query).ToList();

                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("id", typeof(int));
                    displayTable.Columns.Add("user_id", typeof(int));
                    displayTable.Columns.Add("username", typeof(string));
                    displayTable.Columns.Add("nama_petugas", typeof(string));
                    displayTable.Columns.Add("login_time", typeof(DateTime));
                    displayTable.Columns.Add("ip_address", typeof(string));
                    displayTable.Columns.Add("login_status", typeof(string));

                    foreach (var log in loginLogs)
                    {
                        DataRow row = displayTable.NewRow();
                        row["id"] = log.id;
                        row["user_id"] = log.user_id ?? (object)DBNull.Value;
                        row["ip_address"] = log.ip_address ?? "";
                        row["login_status"] = log.login_status ?? "";
                        row["login_time"] = log.login_time;

                        // Handle decryption for users that still exist
                        if (log.user_id != null && log.username != null && log.nama_petugas != null)
                        {
                            try
                            {
                                var userModel = new PetugasModel
                                {
                                    username = log.username,
                                    nama_petugas = log.nama_petugas
                                };

                                var decryptedUser = userModel.DecryptModel();
                                row["username"] = decryptedUser.username;
                                row["nama_petugas"] = decryptedUser.nama_petugas;
                            }
                            catch (Exception)
                            {
                                // If decryption fails, show encrypted values
                                row["username"] = log.username;
                                row["nama_petugas"] = log.nama_petugas;
                            }
                        }
                        else
                        {
                            // Handle deleted users or null values
                            row["username"] = "User Deleted";
                            row["nama_petugas"] = "User Deleted";
                        }

                        displayTable.Rows.Add(row);
                    }

                    dataGridViewLoginLogs.DataSource = displayTable;

                    if (dataGridViewLoginLogs.Columns.Count > 0)
                    {
                        if (dataGridViewLoginLogs.Columns["id"] != null)
                            dataGridViewLoginLogs.Columns["id"].HeaderText = "Log ID";

                        if (dataGridViewLoginLogs.Columns["user_id"] != null)
                            dataGridViewLoginLogs.Columns["user_id"].HeaderText = "User ID";

                        if (dataGridViewLoginLogs.Columns["username"] != null)
                            dataGridViewLoginLogs.Columns["username"].HeaderText = "Username";

                        if (dataGridViewLoginLogs.Columns["nama_petugas"] != null)
                            dataGridViewLoginLogs.Columns["nama_petugas"].HeaderText = "Nama Petugas";

                        if (dataGridViewLoginLogs.Columns["login_time"] != null)
                        {
                            dataGridViewLoginLogs.Columns["login_time"].HeaderText = "Waktu Login";
                            dataGridViewLoginLogs.Columns["login_time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        }

                        if (dataGridViewLoginLogs.Columns["ip_address"] != null)
                            dataGridViewLoginLogs.Columns["ip_address"].HeaderText = "IP Address";

                        if (dataGridViewLoginLogs.Columns["login_status"] != null)
                        {
                            dataGridViewLoginLogs.Columns["login_status"].HeaderText = "Status";

                            // Apply conditional formatting for login status
                            foreach (DataGridViewRow row in dataGridViewLoginLogs.Rows)
                            {
                                if (row.Cells["login_status"].Value != null)
                                {
                                    string status = row.Cells["login_status"].Value.ToString();
                                    if (status == "SUCCESS")
                                    {
                                        row.Cells["login_status"].Style.BackColor = Color.LightGreen;
                                        row.Cells["login_status"].Style.ForeColor = Color.DarkGreen;
                                    }
                                    else if (status == "FAILED")
                                    {
                                        row.Cells["login_status"].Style.BackColor = Color.LightCoral;
                                        row.Cells["login_status"].Style.ForeColor = Color.DarkRed;
                                    }
                                }
                            }
                        }
                    }

                    dataGridViewLoginLogs.ClearSelection();
                    lblTotalLogs.Text = $"Total Log: {displayTable.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data login logs: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshLogs_Click(object sender, EventArgs e)
        {
            LoadLoginLogs();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null)
            {
                MessageBox.Show("Pilih pengguna yang akan dihapus terlebih dahulu.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["id"].Value);
            string username = dataGridViewUsers.CurrentRow.Cells["username"].Value.ToString();

            if (username == _currentUsername)
            {
                MessageBox.Show("Anda tidak dapat menghapus akun yang sedang digunakan.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus pengguna '{username}'?",
                "Konfirmasi Hapus Pengguna",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        connection.Open();

                        string query = @"
                            DELETE FROM password_reset_tokens WHERE user_id = @UserId;
                            UPDATE login_logs SET user_id = NULL WHERE user_id = @UserId;
                            DELETE FROM petugas WHERE id = @UserId;
                        ";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Pengguna berhasil dihapus.",
                                                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUserData();
                                LoadLoginLogs();
                            }
                            else
                            {
                                MessageBox.Show("Gagal menghapus pengguna.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus pengguna: {ex.Message}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null)
            {
                MessageBox.Show("Pilih pengguna yang akan diubah jabatannya terlebih dahulu.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["id"].Value);
            string username = dataGridViewUsers.CurrentRow.Cells["username"].Value.ToString();
            string currentRole = dataGridViewUsers.CurrentRow.Cells["jabatan"].Value.ToString();

            if (username == _currentUsername)
            {
                MessageBox.Show("Anda tidak dapat mengubah jabatan akun yang sedang digunakan.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentRole == "Admin Utama")
            {
                MessageBox.Show("Pengguna ini sudah memiliki jabatan Admin Utama.",
                               "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin ingin mengubah jabatan pengguna '{username}' menjadi 'Admin Utama'?",
                "Konfirmasi Ubah Jabatan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (IDbConnection connection = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        string updateQuery = "UPDATE petugas SET jabatan = @Jabatan WHERE id = @Id";
                        int rowsAffected = connection.Execute(updateQuery, new { Jabatan = "Admin Utama", Id = userId });

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Jabatan pengguna berhasil diubah menjadi Admin Utama.",
                                           "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData();
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengubah jabatan pengguna.",
                                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat mengubah jabatan pengguna: {ex.Message}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormManageUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
        }
    }
}
