using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AplikasiDesa.Utils
{
    public static class ConfigEncryption
    {
        // Menggunakan kunci dan IV yang sudah ada di appsettings.json
        private static readonly string EncryptionKeyBase64 = "U3sqsjXkgoGxb1Rndy+A6VyJH2h+MIXSx4MFRaEhBnc=";
        private static readonly string EncryptionIVBase64 = "Ta98PTh/6w3MNmOTAyTPZA==";

        /// <summary>
        /// Mengenkripsi seluruh file appsettings.json sebelum diembed
        /// </summary>
        /// <param name="jsonContent">Isi file appsettings.json</param>
        /// <returns>Isi file yang terenkripsi</returns>
        public static string EncryptConfig(string jsonContent)
        {
            try
            {
                // Parse JSON untuk mendapatkan ConnectionStrings
                var jsonObject = JObject.Parse(jsonContent);

                // Enkripsi ConnectionStrings section
                if (jsonObject["ConnectionStrings"] != null)
                {
                    string encryptedSection = EncryptSection(jsonObject["ConnectionStrings"].ToString());
                    jsonObject["ConnectionStrings"] = JToken.Parse($"{{\"__encrypted\": \"{encryptedSection}\"}}");
                }

                // Enkripsi EncryptionSettings section
                if (jsonObject["EncryptionSettings"] != null)
                {
                    string encryptedSection = EncryptSection(jsonObject["EncryptionSettings"].ToString());
                    jsonObject["EncryptionSettings"] = JToken.Parse($"{{\"__encrypted\": \"{encryptedSection}\"}}");
                }

                // Enkripsi EmailSettings section
                if (jsonObject["EmailSettings"] != null)
                {
                    string encryptedSection = EncryptSection(jsonObject["EmailSettings"].ToString());
                    jsonObject["EmailSettings"] = JToken.Parse($"{{\"__encrypted\": \"{encryptedSection}\"}}");
                }

                return jsonObject.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error encrypting configuration: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Mendekripsi appsettings.json saat runtime
        /// </summary>
        /// <param name="encryptedJsonContent">Isi file appsettings.json yang terenkripsi</param>
        /// <returns>Isi file yang terdekripsi</returns>
        public static string DecryptConfig(string encryptedJsonContent)
        {
            try
            {
                var jsonObject = JObject.Parse(encryptedJsonContent);

                // Dekripsi ConnectionStrings section
                if (jsonObject["ConnectionStrings"]?["__encrypted"] != null)
                {
                    string encryptedValue = jsonObject["ConnectionStrings"]["__encrypted"].ToString();
                    string decryptedSection = DecryptSection(encryptedValue);
                    jsonObject["ConnectionStrings"] = JToken.Parse(decryptedSection);
                }

                // Dekripsi EncryptionSettings section
                if (jsonObject["EncryptionSettings"]?["__encrypted"] != null)
                {
                    string encryptedValue = jsonObject["EncryptionSettings"]["__encrypted"].ToString();
                    string decryptedSection = DecryptSection(encryptedValue);
                    jsonObject["EncryptionSettings"] = JToken.Parse(decryptedSection);
                }

                // Dekripsi EmailSettings section
                if (jsonObject["EmailSettings"]?["__encrypted"] != null)
                {
                    string encryptedValue = jsonObject["EmailSettings"]["__encrypted"].ToString();
                    string decryptedSection = DecryptSection(encryptedValue);
                    jsonObject["EmailSettings"] = JToken.Parse(decryptedSection);
                }

                return jsonObject.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error decrypting configuration: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Mengenkripsi bagian dari file konfigurasi
        /// </summary>
        private static string EncryptSection(string sectionContent)
        {
            byte[] keyBytes = Convert.FromBase64String(EncryptionKeyBase64);
            byte[] ivBytes = Convert.FromBase64String(EncryptionIVBase64);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(sectionContent);

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
                    {
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cs.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Mendekripsi bagian dari file konfigurasi
        /// </summary>
        private static string DecryptSection(string encryptedContent)
        {
            byte[] keyBytes = Convert.FromBase64String(EncryptionKeyBase64);
            byte[] ivBytes = Convert.FromBase64String(EncryptionIVBase64);
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedContent);

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(cipherTextBytes))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Menyiapkan appsettings.json untuk embedding - Membaca, enkripsi, dan simpan
        /// </summary>
        /// <param name="inputPath">Path ke file appsettings.json asli</param>
        /// <param name="outputPath">Path untuk menyimpan file terenkripsi (opsional)</param>
        /// <returns>Isi file yang terenkripsi</returns>
        public static string PrepareConfigForEmbedding(string inputPath, string outputPath = null)
        {
            try
            {
                // Baca file asli
                string jsonContent = File.ReadAllText(inputPath);

                // Enkripsi konten
                string encryptedContent = EncryptConfig(jsonContent);

                // Simpan file terenkripsi jika outputPath disediakan
                if (!string.IsNullOrEmpty(outputPath))
                {
                    File.WriteAllText(outputPath, encryptedContent);
                }

                return encryptedContent;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error preparing config for embedding: {ex.Message}", ex);
            }
        }
    }
}
