using AplikasiDesa.Models;
using Dapper;
using System.Data;

namespace AplikasiDesa.Utils
{
    public static class DapperExtensions
    {
        /// <summary>
        /// Enkripsi properti yang ditandai dengan [Encrypt] pada model
        /// </summary>
        public static T EncryptModel<T>(this T model) where T : class
        {
            if (model == null) return null;

            var properties = typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite &&
                            Attribute.IsDefined(p, typeof(EncryptAttribute)) &&
                            p.PropertyType == typeof(string));

            foreach (var property in properties)
            {
                string value = property.GetValue(model) as string;
                if (!string.IsNullOrEmpty(value))
                {
                    string encrypted = EncryptionUtil.Encrypt(value);
                    property.SetValue(model, encrypted);
                }
            }

            return model;
        }

        /// <summary>
        /// Dekripsi properti yang ditandai dengan [Encrypt] pada model
        /// </summary>
        public static T DecryptModel<T>(this T model) where T : class
        {
            if (model == null) return null;

            var properties = typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite &&
                            Attribute.IsDefined(p, typeof(EncryptAttribute)) &&
                            p.PropertyType == typeof(string));

            foreach (var property in properties)
            {
                string value = property.GetValue(model) as string;
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        string decrypted = EncryptionUtil.TryDecrypt(value);
                        property.SetValue(model, decrypted);
                    }
                    catch
                    {
                        // Jika gagal dekripsi, biarkan nilai asli
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// Extension method untuk Dapper: Query dengan dekripsi otomatis
        /// </summary>
        public static IEnumerable<T> QueryWithDecryption<T>(this IDbConnection connection, string sql,
            object param = null, IDbTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
            where T : class
        {
            var results = connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
            return results.Select(r => r.DecryptModel());
        }

        /// <summary>
        /// Extension method untuk Dapper: QuerySingleOrDefault dengan dekripsi otomatis
        /// </summary>
        public static T QuerySingleOrDefaultWithDecryption<T>(this IDbConnection connection, string sql,
            object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
            where T : class
        {
            var result = connection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            return result?.DecryptModel();
        }

        /// <summary>
        /// Extension method untuk Dapper: Execute dengan enkripsi otomatis untuk properti bertanda [Encrypt]
        /// </summary>
        public static int ExecuteWithEncryption<T>(this IDbConnection connection, string sql, T param,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
            where T : class
        {
            var encryptedParam = param.EncryptModel();
            return connection.Execute(sql, encryptedParam, transaction, commandTimeout, commandType);
        }
    }
}
