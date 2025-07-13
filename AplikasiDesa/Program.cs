using AplikasiDesa.Utils;
using Microsoft.Extensions.Configuration;

namespace AplikasiDesa.Forms
{
    internal static class Program
    {
        // Membuat Configuration sebagai property static agar bisa diakses dari mana saja
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            try
            {
                // Inisialisasi konfigurasi dari embedded resource terenkripsi
                LoadConfigurationFromEncryptedResource();

                // Inisialisasi DbConfig dengan konfigurasi yang dibaca
                DbConfig.Initialize(Configuration);

                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new FormMainMenu());
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing application: {ex.Message}",
                    "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Membaca konfigurasi dari embedded resource terenkripsi
        /// </summary>
        private static void LoadConfigurationFromEncryptedResource()
        {
            // Cari resource appsettings.json
            string resourceName = "appsettings.json";
            string encryptedContent = EmbeddedResourceHelper.GetEmbeddedResourceContent(resourceName);

            if (string.IsNullOrEmpty(encryptedContent))
            {
                throw new Exception("Configuration file not found in embedded resources.");
            }

            // Dekripsi konten
            string decryptedContent = ConfigEncryption.DecryptConfig(encryptedContent);

            // Buat configuration dari content yang sudah didekripsi
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(decryptedContent)))
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
            }
        }
    }
}
