using Microsoft.Extensions.Configuration;
using System.IO;

namespace LagerStatusEksamen
{
    public static class Secret
    {
        public static string ConnectionString { get; }

        static Secret()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            ConnectionString = config.GetConnectionString("LocalDB"); // change to ServerDB or LocalDB.
        }
    }
}