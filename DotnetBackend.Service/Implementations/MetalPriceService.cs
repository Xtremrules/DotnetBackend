using DotnetBackend.Core.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DotnetBackend.Service.Implementations
{
    public class MetalPriceService : IMetalPriceService
    {
        private readonly ILogger<MetalPriceService> logger;
        private readonly MetalData metalData;
        private readonly IHttpClientFactory clientFactory;

        public MetalPriceService(ILogger<MetalPriceService> logger, IOptions<MetalData> metalData, IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.metalData = metalData.Value;
            this.clientFactory = clientFactory;
        }

        public async Task<GoldSilverResponse> GetGoldSilverPrice()
        {
            var url = $"{metalData.BASE_URL}{metalData.METAL_PRICES}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-RapidAPI-Host", metalData.X_RapidAPI_Host);
            request.Headers.Add("X-RapidAPI-Key", metalData.X_RapidAPI_Key);

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var resContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GoldSilverResponse>(resContent);
        }
    }
}
