using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace PokemonShakespeare.Api.Services.ShakespeareApi
{

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

            var apiResponse = await _apiClient.TranslateToShakespearean(text, cancellationToken);
            translated = apiResponse.Contents.Translated;
            _memoryCache.Set(text, translated);
            return translated;
        }
    }
}