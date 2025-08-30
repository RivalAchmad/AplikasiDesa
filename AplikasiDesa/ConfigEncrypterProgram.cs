using AplikasiDesa.Forms;

namespace AplikasiDesa
{
    static class ConfigEncrypterProgram
    {
        /// <summary>
        /// Program utama untuk menjalankan tool enkripsi konfigurasi
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormConfigEncrypter());
        }
    }
}
