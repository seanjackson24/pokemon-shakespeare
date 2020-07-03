using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PokemonShakespeare.Api.Models;
using PokemonShakespeare.Api.Services.PokeApi;
using PokemonShakespeare.Api.Services.ShakespeareApi;

namespace PokemonShakespeare.Api.Services
{
    public interface IPokemonFetchService
    {
        Task<Pokemon> GetPokemon(string name, CancellationToken cancellationToken);
    }
    public class PokemonFetchService : IPokemonFetchService
    {
        private readonly IPokemonApiService _apiClient;
        private readonly IShakespeareTranslateService _shakespeare;
        private readonly IMemoryCache _cache;

        public PokemonFetchService(IPokemonApiService apiClient, IMemoryCache cache, IShakespeareTranslateService shakespeare)
        {
            _apiClient = apiClient;
            _cache = cache;
            _shakespeare = shakespeare;
        }

        public async Task<Pokemon> GetPokemon(string name, CancellationToken cancellationToken)
        {
            if (_cache.TryGetValue<Pokemon>(name, out var pokemon) && pokemon != null)
            {
                return pokemon;
            }
            // todo: cache expiration
            var localFlavorText = await _apiClient.GetPokemonDescription(name, cancellationToken);

            string translated = await _shakespeare.TranslateToShakespearean(localFlavorText, cancellationToken);
            pokemon = new Pokemon() { Name = name, Description = translated };
            _cache.Set(name, pokemon);
            return pokemon;
        }
    }
}