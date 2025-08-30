using AplikasiDesa.Utils;

namespace AplikasiDesa.Forms
{
    public partial class FormConfigEncrypter : Form
    {
        private string inputPath = "appsettings.json";
        private string outputPath = "appsettings.encrypted.json";
        private string backupPath = "appsettings.original.json";

        public FormConfigEncrypter()
        {
            InitializeComponent();
        }

        private void FormConfigEncrypter_Load(object sender, EventArgs e)
        {
            // Periksa apakah file konfigurasi ada
            if (File.Exists(inputPath))
            {
                lblStatus.Text = $"File konfigurasi ditemukan: {inputPath}";
                btnEncrypt.Enabled = true;
            }
            else
            {
                lblStatus.Text = $"File konfigurasi tidak ditemukan: {inputPath}";
                btnEncrypt.Enabled = false;
            }

            // Periksa apakah sudah ada backup
            if (File.Exists(backupPath))
            {
                btnRestore.Enabled = true;
                lblBackupStatus.Text = $"File backup tersedia: {backupPath}";
            }
            else
            {
                btnRestore.Enabled = false;
                lblBackupStatus.Text = "Tidak ada file backup";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files|*.json",
                Title = "Pilih file appsettings.json"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputPath = openFileDialog.FileName;
                txtInputPath.Text = inputPath;

                // Update status
                lblStatus.Text = $"File konfigurasi dipilih: {inputPath}";
                btnEncrypt.Enabled = true;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // Tampilkan progress
                progressBar.Visible = true;
                progressBar.Value = 10;
                lblStatus.Text = "Membuat backup...";

                // Buat backup
                File.Copy(inputPath, backupPath, true);
                progressBar.Value = 30;

                // Enkripsi file
                lblStatus.Text = "Mengenkripsi file...";
                string encryptedContent = ConfigEncryption.PrepareConfigForEmbedding(inputPath, outputPath);
                progressBar.Value = 70;

                // Ganti file asli dengan file terenkripsi
                lblStatus.Text = "Mengganti file asli...";
                File.Copy(outputPath, inputPath, true);
                progressBar.Value = 90;

                // Update UI
                lblStatus.Text = "Enkripsi selesai!";
                progressBar.Value = 100;
                btnRestore.Enabled = true;
                lblBackupStatus.Text = $"File backup tersedia: {backupPath}";

                // Tampilkan pesan sukses
                MessageBox.Show(
                    $"Enkripsi berhasil! File telah dienkripsi dan siap untuk diembed.\n\n" +
                    $"File terenkripsi: {outputPath}\n" +
                    $"File backup: {backupPath}",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Buka tab Explorer ke lokasi file
                if (chkOpenFolder.Checked)
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + Path.GetFullPath(outputPath));
                }
            }
            catch (Exception ex)
            {
                progressBar.Value = 0;
                lblStatus.Text = $"Error: {ex.Message}";
                MessageBox.Show($"Error saat mengenkripsi file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(backupPath))
                {
                    MessageBox.Show("File backup tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Konfirmasi restore
                DialogResult result = MessageBox.Show(
                    "Mengembalikan file original akan menghapus versi terenkripsi. Lanjutkan?",
                    "Konfirmasi Restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Kembalikan file asli
                    File.Copy(backupPath, inputPath, true);
                    lblStatus.Text = "File asli berhasil dikembalikan.";
                    MessageBox.Show("File asli berhasil dikembalikan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
                MessageBox.Show($"Error saat mengembalikan file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
