using System.Text.RegularExpressions;

namespace AplikasiDesa.Utils
{
    public static class InputSanitizer
    {
        private static readonly Regex SanitizeRegex = new Regex(
            @"[<>()&;'`""=]",
            RegexOptions.Compiled | RegexOptions.NonBacktracking,
            TimeSpan.FromMilliseconds(100));

        private static readonly Regex NikRegex = new Regex(
            @"^\d{16}$",
            RegexOptions.Compiled | RegexOptions.NonBacktracking,
            TimeSpan.FromMilliseconds(100));

        private static readonly Regex RtRwRegex = new Regex(
            @"^\d{3}$",
            RegexOptions.Compiled | RegexOptions.NonBacktracking,
            TimeSpan.FromMilliseconds(100));

        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.NonBacktracking,
            TimeSpan.FromMilliseconds(100));

        private static readonly Regex PhoneRegex = new Regex(
            @"^(\+\d{1,3})?\d{6,15}$",
            RegexOptions.Compiled | RegexOptions.NonBacktracking,
            TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// Membersihkan input dari karakter khusus yang berbahaya
        /// </summary>
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Batasi panjang input untuk mencegah DoS
            if (input.Length > 1000)
            {
                input = input.Substring(0, 1000);
            }

            try
            {
                // Menghapus karakter berbahaya untuk mencegah XSS dan injeksi
                string sanitized = SanitizeRegex.Replace(input, "");
                return sanitized;
            }
            catch (RegexMatchTimeoutException)
            {
                // Fallback jika regex timeout
                return input.Replace("<", "")
                           .Replace(">", "")
                           .Replace("(", "")
                           .Replace(")", "")
                           .Replace("&", "")
                           .Replace(";", "")
                           .Replace("'", "")
                           .Replace("`", "")
                           .Replace("\"", "")
                           .Replace("=", "");
            }
        }

        /// <summary>
        /// Validasi NIK dan No. KK harus berisi 16 digit angka
        /// </summary>
        public static bool ValidateNIK(string nik)
        {
            if (string.IsNullOrEmpty(nik) || nik.Length != 16)
                return false;

            try
            {
                return NikRegex.IsMatch(nik);
            }
            catch (RegexMatchTimeoutException)
            {
                // Fallback validation tanpa regex
                return nik.All(char.IsDigit);
            }
        }

        /// <summary>
        /// Validasi nomor RT/RW (3 digit)
        /// </summary>
        public static bool ValidateRT_RW(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 3)
                return false;

            try
            {
                return RtRwRegex.IsMatch(value);
            }
            catch (RegexMatchTimeoutException)
            {
                // Fallback validation tanpa regex
                return value.All(char.IsDigit);
            }
        }

        /// <summary>
        /// Validasi alamat email dengan format yang benar
        /// </summary>
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true; // Email opsional

            // Batasi panjang email
            if (email.Length > 254)
                return false;

            try
            {
                return EmailRegex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                // Fallback validation menggunakan MailAddress
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Validasi nomor telepon (hanya angka dan tanda + di awal)
        /// </summary>
        public static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return true; // Nomor telepon opsional

            // Batasi panjang nomor telepon
            if (phone.Length > 18)
                return false;

            try
            {
                return PhoneRegex.IsMatch(phone);
            }
            catch (RegexMatchTimeoutException)
            {
                // Fallback validation tanpa regex
                if (phone.StartsWith("+"))
                {
                    return phone.Length >= 7 && phone.Substring(1).All(char.IsDigit);
                }
                return phone.Length >= 6 && phone.All(char.IsDigit);
            }
        }
    }
}