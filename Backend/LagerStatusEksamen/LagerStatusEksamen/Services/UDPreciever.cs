using LagerStatusEksamen.Models;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Http.Json;

namespace LagerStatusEksamen.Services
{
    public class UDPreciever : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly int _port = 55010;
        private readonly string _serverUrl = "http://localhost:5000/api/shelves";

        public UDPreciever(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                    var package = System.Text.Json.JsonSerializer.Deserialize<DataPackage>(msg);

                    if (package != null)
                    {
                        Console.WriteLine($"Received: {package.Status} from {result.RemoteEndPoint} (MAC: {package.MAC})");

                        var client = _httpClientFactory.CreateClient();
                        var response = await client.PostAsJsonAsync(_serverUrl, package, stoppingToken);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Posted successfully to API!");
                        }
                        else
                        {
                            Console.WriteLine($"API POST failed: {response.StatusCode}");
                        }
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
