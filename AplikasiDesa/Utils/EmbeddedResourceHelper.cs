using System.Reflection;

namespace AplikasiDesa.Utils
{
    public static class EmbeddedResourceHelper
    {
        /// <summary>
        /// Mendapatkan stream dari resource yang diembed
        /// </summary>
        /// <param name="resourceName">Nama resource atau bagian akhir dari nama resource</param>
        /// <returns>Stream dari resource atau null jika tidak ditemukan</returns>
        public static Stream GetEmbeddedResourceStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Coba cari nama resource yang tepat
            var fullResourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(name => name.EndsWith(resourceName));

            if (fullResourceName == null)
                return null;

            return assembly.GetManifestResourceStream(fullResourceName);
        }

        /// <summary>
        /// Membaca isi resource yang diembed sebagai string
        /// </summary>
        /// <param name="resourceName">Nama resource atau bagian akhir dari nama resource</param>
        /// <returns>Isi resource sebagai string atau null jika tidak ditemukan</returns>
        public static string GetEmbeddedResourceContent(string resourceName)
        {
            using (var stream = GetEmbeddedResourceStream(resourceName))
            {
                if (stream == null)
                    return null;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Mendapatkan daftar nama semua resource yang diembed
        /// </summary>
        /// <returns>Array berisi nama-nama resource</returns>
        public static string[] GetAllEmbeddedResourceNames()
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }
}
