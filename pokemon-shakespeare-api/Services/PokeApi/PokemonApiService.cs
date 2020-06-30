using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

public interface IPokemonApiService
{
	Task<string> GetPokemonDescription(string pokemonName, CancellationToken cancellationToken);
}
public class PokemonApiService : IPokemonApiService
{
	private const string LanguageCodeKey = "LanguageCode";
	private readonly IMemoryCache _memoryCache;
	private readonly PokemonApiClient _pokemonApiClient;
	private readonly IConfiguration _config;


	public PokemonApiService(PokemonApiClient pokemonApiClient, IMemoryCache memoryCache, IConfiguration config)
	{
		_pokemonApiClient = pokemonApiClient;
		_memoryCache = memoryCache;
		_config = config;
	}

	public async Task<string> GetPokemonDescription(string pokemonName, CancellationToken cancellationToken)
	{
		string languageCode = _config[LanguageCodeKey];
		string key = languageCode + pokemonName;
		if (_memoryCache.TryGetValue(key, out string description) && description != null)
		{
			return description;
		}
		var pokemon = await _pokemonApiClient.GetPokemonByName(pokemonName, cancellationToken);
		description = pokemon.FlavorTextEntries.FirstOrDefault(fte => fte.Language.Name == languageCode)?.FlavorText;
		_memoryCache.Set(key, description);
		return description;
	}
}

