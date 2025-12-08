using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;

namespace LagerStatusEksamen.Services
{
    public class UDPreciever : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceShelf _db;
        private readonly int _port = 55010;
        private readonly string _serverUrl = "http://localhost:5155/api/shelves";


        public UDPreciever(IHttpClientFactory httpClientFactory, IServiceShelf db)
        {
            _httpClientFactory = httpClientFactory;
            _db = db;   
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var udpClient = new UdpClient(_port);
            Console.WriteLine($"UDP server listening on port {_port}...");

            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await udpClient.ReceiveAsync(stoppingToken);
                var msg = Encoding.UTF8.GetString(result.Buffer);

                try
                {
                    DataPackage? package = System.Text.Json.JsonSerializer.Deserialize<DataPackage>(msg);

                    if (package != null)
                    {
                        Console.WriteLine($"Received: {package.Status} from {result.RemoteEndPoint} (MAC: {package.MAC})");
                        //--------
                        bool preExisting = _db.GetByMAC(package.MAC) != null;
                        Shelf? shelf;
                        if (preExisting)
                        {
                            shelf = _db.UpdateStatus(package.MAC, package.Status);
                            Console.WriteLine($"UDPreciever ||  Updated Status of MAC: {package.MAC}  to  Status: {package.Status}");
                        }
                        else
                        {                           
                            shelf = new Shelf(package.MAC, null, package.Status);
                            shelf = _db.Add(shelf);
                            Console.WriteLine($"UDPreciever ||  Added a new shelf as MAC: {package.MAC} isn't yet added//  with  status: {package.Status}");
                        }

                        //----------------
                        //Console.WriteLine("UDPreciever tried to post with : " + package.Status);

                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error parsing or posting data: " + ex.Message);
                    Console.WriteLine("Raw data: " + msg);
                }
            }
        }
    }
}
