using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace AplikasiDesa.Utils
{
    public static class ConfigEncryption
    {
        private static readonly string EncryptionKeyBase64 = "U3sqsjXkgoGxb1Rndy+A6VyJH2h+MIXSx4MFRaEhBnc=";
        private static readonly string EncryptionIVBase64 = "Ta98PTh/6w3MNmOTAyTPZA==";

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
    }
}
