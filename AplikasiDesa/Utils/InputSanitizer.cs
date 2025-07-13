using System.Text.RegularExpressions;

namespace AplikasiDesa.Utils
{
    public static class InputSanitizer
    {
        /// <summary>
        /// Membersihkan input dari karakter khusus yang berbahaya
        /// </summary>
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Menghapus karakter berbahaya untuk mencegah XSS dan injeksi
            string sanitized = Regex.Replace(input, @"[<>()&;'`""]", "");

            return sanitized;
        }

        /// <summary>
        /// Validasi NIK dan No. KK harus berisi 16 digit angka
        /// </summary>
        public static bool ValidateNIK(string nik)
        {
            return !string.IsNullOrEmpty(nik) && Regex.IsMatch(nik, @"^\d{16}$");
        }

        /// <summary>
        /// Validasi nomor RT/RW (3 digit)
        /// </summary>
        public static bool ValidateRT_RW(string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^\d{3}$");
        }

        /// <summary>
        /// Validasi alamat email dengan format yang benar
        /// </summary>
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true; // Email opsional

            return Regex.IsMatch(email,
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        /// <summary>
        /// Validasi nomor telepon (hanya angka dan tanda + di awal)
        /// </summary>
        public static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return true; // Nomor telepon opsional

            return Regex.IsMatch(phone, @"^(\+\d{1,3})?\d{6,15}$");
        }
    }
}
