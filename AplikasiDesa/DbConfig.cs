using Microsoft.Extensions.Configuration;

namespace AplikasiDesa
{
    public static class DbConfig
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ConnectionString =>
            _configuration.GetConnectionString("DefaultConnection");
    }
}