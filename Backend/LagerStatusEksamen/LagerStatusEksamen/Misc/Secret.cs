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
            ConnectionString = config.GetConnectionString("ServerDB");
        }
    }
}


//namespace LagerStatusEksamen
//{
//    public class Secret
//    {
//        public static string ConnectionString { get { return _connectionString; } }
//        private static string _connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LagerStatusDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
//    }
//}