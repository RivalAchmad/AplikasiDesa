using AplikasiDesa.Forms;
using System.Security.Cryptography;

namespace AplikasiDesa.Utils
{
    public static class EncryptionUtil
    {
        private static readonly Lazy<byte[]> _encryptionKey = new Lazy<byte[]>(() =>
            GetOrCreateEncryptionKey());

        private static readonly Lazy<byte[]> _encryptionIV = new Lazy<byte[]>(() =>
            GetOrCreateEncryptionIV());

        // Mendapatkan kunci enkripsi dari konfigurasi atau generate baru
        private static byte[] GetOrCreateEncryptionKey()
        {
            var config = Program.Configuration;
            string keyFromConfig = config.GetSection("EncryptionSettings:Key").Value;

            if (!string.IsNullOrEmpty(keyFromConfig))
                return Convert.FromBase64String(keyFromConfig);

            // Generate kunci baru jika tidak ada di konfigurasi
            using (var rng = RandomNumberGenerator.Create())
            {
                var keyBytes = new byte[32]; // 256 bits untuk AES-256
                rng.GetBytes(keyBytes);

                // Simpan kunci baru ke appsettings.json
                SaveEncryptionKey(Convert.ToBase64String(keyBytes));

                return keyBytes;
            }
        }

        // Mendapatkan IV dari konfigurasi atau generate baru
        private static byte[] GetOrCreateEncryptionIV()
        {
            var config = Program.Configuration;
            string ivFromConfig = config.GetSection("EncryptionSettings:IV").Value;

            if (!string.IsNullOrEmpty(ivFromConfig))
                return Convert.FromBase64String(ivFromConfig);

            // Generate IV baru jika tidak ada di konfigurasi
            using (var rng = RandomNumberGenerator.Create())
            {
                var ivBytes = new byte[16]; // 128 bits untuk AES
                rng.GetBytes(ivBytes);

                // Simpan IV baru ke appsettings.json
                SaveEncryptionIV(Convert.ToBase64String(ivBytes));

                return ivBytes;
            }
        }

        // Simpan kunci enkripsi ke file konfigurasi
        private static void SaveEncryptionKey(string key)
        {
            try
            {
                var configFile = "appsettings.json";
                var json = File.ReadAllText(configFile);
                dynamic config = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                if (config.EncryptionSettings == null)
                {
                    config.EncryptionSettings = new Newtonsoft.Json.Linq.JObject();
                }

                config.EncryptionSettings.Key = key;

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(configFile, output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error menyimpan kunci enkripsi: {ex.Message}");
            }
        }

        // Simpan IV enkripsi ke file konfigurasi
        private static void SaveEncryptionIV(string iv)
        {
            try
            {
                var configFile = "appsettings.json";
                var json = File.ReadAllText(configFile);
                dynamic config = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                if (config.EncryptionSettings == null)
                {
                    config.EncryptionSettings = new Newtonsoft.Json.Linq.JObject();
                }

                config.EncryptionSettings.IV = iv;

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(configFile, output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error menyimpan IV enkripsi: {ex.Message}");
            }
        }

        /// <summary>
        /// Mengenkripsi string menggunakan algoritma AES-256
        /// </summary>
        /// <param name="plainText">Text yang akan dienkripsi</param>
        /// <returns>String terenkripsi dalam format Base64</returns>
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            try
            {
                byte[] keyBytes = _encryptionKey.Value;
                byte[] ivBytes = _encryptionIV.Value;

                using (var aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aes.CreateEncryptor())
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        using (var writer = new StreamWriter(cs))
                        {
                            writer.Write(plainText);
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Encryption error: {ex.Message}");
                throw new Exception("Gagal mengenkripsi data. Lihat log untuk detail.");
            }
        }

        /// <summary>
        /// Mendekripsi string yang dienkripsi dengan AES-256
        /// </summary>
        /// <param name="cipherText">String terenkripsi (Base64)</param>
        /// <returns>Teks asli yang terdekripsi</returns>
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] keyBytes = _encryptionKey.Value;
                byte[] ivBytes = _encryptionIV.Value;

                using (var aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aes.CreateDecryptor())
                    using (var ms = new MemoryStream(cipherBytes))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (FormatException)
            {
                // Mungkin data belum terenkripsi
                return cipherText;
            }
            catch (CryptographicException)
            {
                // Kemungkinan data tidak terenkripsi atau menggunakan kunci berbeda
                return cipherText;
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Decryption error: {ex.Message}");
                throw new Exception("Gagal mendekripsi data. Lihat log untuk detail.");
            }
        }

        /// <summary>
        /// Mencoba mendekripsi string, mengembalikan string asli jika bukan data terenkripsi
        /// </summary>
        /// <param name="possiblyEncryptedText">Teks yang mungkin terenkripsi</param>
        /// <returns>Teks yang didekripsi atau teks asli jika bukan data terenkripsi</returns>
        public static string TryDecrypt(string possiblyEncryptedText)
        {
            if (string.IsNullOrEmpty(possiblyEncryptedText))
                return possiblyEncryptedText;

            try
            {
                return Decrypt(possiblyEncryptedText);
            }
            catch
            {
                // Jika dekripsi gagal, kembalikan teks asli
                return possiblyEncryptedText;
            }
        }

        ///// <summary>
        ///// Kode untuk mengenkripsi ulang field-field yang seharusnya terenkripsi pada tabel gabungan_keluarga
        ///// </summary>
        ///// <returns>Jumlah record yang berhasil diupdate</returns>
        //public static int ReencryptPendudukFields()
        //{
        //    int totalUpdated = 0;

        //    try
        //    {
        //        using (var connection = new MySqlConnection(DbConfig.ConnectionString))
        //        {
        //            connection.Open();

        //            // 1. Ambil semua data dari tabel
        //            string selectQuery = "SELECT NIK, Passport_Number, no_hp, NIK_Ibu, NIK_Ayah FROM gabungan_keluarga";
        //            var records = connection.Query(selectQuery).ToList();

        //            Console.WriteLine($"Ditemukan {records.Count} record untuk diproses");

        //            foreach (var record in records)
        //            {
        //                // Persiapkan parameter untuk update
        //                var parameters = new DynamicParameters();
        //                parameters.Add("@NIK", record.NIK);

        //                // Buat SQL untuk update
        //                var updateParts = new List<string>();

        //                // Proses field Passport_Number
        //                if (record.Passport_Number != null)
        //                {
        //                    string decrypted = EncryptionUtil.TryDecrypt(record.Passport_Number.ToString());
        //                    string encrypted = EncryptionUtil.Encrypt(decrypted);

        //                    if (encrypted != record.Passport_Number.ToString())
        //                    {
        //                        updateParts.Add("Passport_Number = @Passport_Number");
        //                        parameters.Add("@Passport_Number", encrypted);
        //                    }
        //                }

        //                // Proses field no_hp
        //                if (record.no_hp != null)
        //                {
        //                    string decrypted = EncryptionUtil.TryDecrypt(record.no_hp.ToString());
        //                    string encrypted = EncryptionUtil.Encrypt(decrypted);

        //                    if (encrypted != record.no_hp.ToString())
        //                    {
        //                        updateParts.Add("no_hp = @no_hp");
        //                        parameters.Add("@no_hp", encrypted);
        //                    }
        //                }

        //                // Proses field NIK_Ibu
        //                if (record.NIK_Ibu != null)
        //                {
        //                    string decrypted = EncryptionUtil.TryDecrypt(record.NIK_Ibu.ToString());
        //                    string encrypted = EncryptionUtil.Encrypt(decrypted);

        //                    if (encrypted != record.NIK_Ibu.ToString())
        //                    {
        //                        updateParts.Add("NIK_Ibu = @NIK_Ibu");
        //                        parameters.Add("@NIK_Ibu", encrypted);
        //                    }
        //                }

        //                // Proses field NIK_Ayah
        //                if (record.NIK_Ayah != null)
        //                {
        //                    string decrypted = EncryptionUtil.TryDecrypt(record.NIK_Ayah.ToString());
        //                    string encrypted = EncryptionUtil.Encrypt(decrypted);

        //                    if (encrypted != record.NIK_Ayah.ToString())
        //                    {
        //                        updateParts.Add("NIK_Ayah = @NIK_Ayah");
        //                        parameters.Add("@NIK_Ayah", encrypted);
        //                    }
        //                }

        //                // Jika ada field yang perlu diupdate
        //                if (updateParts.Count > 0)
        //                {
        //                    string updateQuery = $"UPDATE gabungan_keluarga SET {string.Join(", ", updateParts)} WHERE NIK = @NIK";
        //                    int affected = connection.Execute(updateQuery, parameters);
        //                    totalUpdated += affected;
        //                }
        //            }

        //            Console.WriteLine($"Total {totalUpdated} record berhasil diupdate");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error saat mengenkripsi ulang data: {ex.Message}");
        //        throw new Exception($"Gagal mengenkripsi ulang data: {ex.Message}", ex);
        //    }

        //    return totalUpdated;
        //}
    }
}
