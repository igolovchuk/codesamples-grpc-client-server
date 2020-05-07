using Grpc.Net.Client;
using GrpcDemo.Protos;
using System.Text.Json;
using System.Threading.Tasks;
using static GrpcDemo.Protos.GrpcDemoApiProvider;

namespace GrpcDemo.Console.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new GrpcDemoApiProviderClient(GrpcChannel.ForAddress("https://localhost:5001"));

            System.Console.WriteLine("Please enter GrpcDemo symbol...");
            var searchText = System.Console.ReadLine();

            var reply = await client.SearchAsync(new GrpcDemoSearchRequest { Text = searchText });

            System.Console.WriteLine(JsonSerializer.Serialize(reply));
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
