using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonShakespeare.Api.Services.ShakespeareApi
{
    public class ShakespeareApiClient
    {
        const string api = "https://api.funtranslations.com/translate/shakespeare.json?text=";
        private readonly HttpClient _httpClient;

        public ShakespeareApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShakespeareApiResponse> TranslateToShakespearean(string text, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            string urlSafeText = Uri.EscapeDataString(text.Replace("\n", ""));
            var requestUrl = new Uri(api + urlSafeText);
            var response = await _httpClient.GetStreamAsync(requestUrl);
            return await JsonSerializer.DeserializeAsync<ShakespeareApiResponse>(response, new JsonSerializerOptions(), cancellationToken);
        }
    }
}