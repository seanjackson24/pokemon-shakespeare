using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

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
		var requestUrl = api + text;
		// try
		// {
		var response = await _httpClient.GetStreamAsync(requestUrl);
		return await JsonSerializer.DeserializeAsync<ShakespeareApiResponse>(response, new JsonSerializerOptions(), cancellationToken);
		// }
		// catch (Exception ex)
		// {
		// 	return Task.FromResult(null);
		// }
		// todo: using??
	}
}

public interface IShakespeareTranslateService
{
	Task<string> TranslateToShakespearean(string text, CancellationToken cancellationToken);
}
public class ShakespeareTranslateService : IShakespeareTranslateService
{
	private readonly ShakespeareApiClient _apiClient;
	private readonly IMemoryCache _memoryCache;

	public ShakespeareTranslateService(ShakespeareApiClient apiClient, IMemoryCache memoryCache)
	{
		_apiClient = apiClient;
		_memoryCache = memoryCache;
	}

	public async Task<string> TranslateToShakespearean(string text, CancellationToken cancellationToken)
	{
		if (_memoryCache.TryGetValue(text, out string translated))
		{
			return translated;
		}

		string urlSafeText = Uri.EscapeDataString(text.Replace("\n", ""));
		var apiResponse = await _apiClient.TranslateToShakespearean(urlSafeText, cancellationToken);
		translated = apiResponse.Contents.Translated;
		_memoryCache.Set(text, translated);
		return translated;
	}
}