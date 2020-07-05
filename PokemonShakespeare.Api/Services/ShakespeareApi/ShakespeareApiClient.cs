using PokemonShakespeare.Api.Models.ShakespeareApi;
using System;
using System.Net;
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
			string urlSafeText = Uri.EscapeDataString(text.Replace("\n", " "));
			var requestUrl = new Uri(api + urlSafeText);
			var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
			var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

			if (response.StatusCode == HttpStatusCode.TooManyRequests)
			{
				throw new TooManyRequestsException();
			}
			using (var contentStream = await response.Content.ReadAsStreamAsync())
			{
				return await JsonSerializer.DeserializeAsync<ShakespeareApiResponse>(contentStream, new JsonSerializerOptions(), cancellationToken);
			}
		}
	}
}