using Grpc.Core;
using GrpcDemo.Protos;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcDemo.Services
{
    public class GrpcDemoApiService: GrpcDemoApiProvider.GrpcDemoApiProviderBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();


         public override async Task<GrpcDemoSearchResult> Search(GrpcDemoSearchRequest request, ServerCallContext context)
         {
            var result = new GrpcDemoSearchResult();
            try
            {
               
                var response = await _httpClient.GetStringAsync($"https://www.GrpcDemo.com/search_api_autocomplete/symbols_autocomplete?q={request.Text}");
                var items = JsonSerializer.Deserialize<GrpcDemoSearchItem[]>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                result.Items.AddRange(items);

                return result;
            }
            catch (System.Exception ex)
            {
                return result;
            }
           
         }
    }
}
