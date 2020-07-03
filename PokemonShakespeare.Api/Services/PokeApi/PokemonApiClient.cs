using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonShakespeare.Api.Services.PokeApi
{
    public class PokemonApiClient
    {
        const string url = "https://pokeapi.co/api/v2/pokemon-species/";
        private readonly HttpClient _httpClient;

        public PokemonApiClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<PokemonApiResponse> GetPokemonByName(string pokemonName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(pokemonName))
            {
                return null;
            }
            var requestUrl = new Uri(url + pokemonName.ToLowerInvariant());
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            using (var contentStream = await response.Content.ReadAsStreamAsync())
            {
                try
                {
                    // return await as opposed to just return as we are inside a using statement
                    return await JsonSerializer.DeserializeAsync<PokemonApiResponse>(contentStream, new JsonSerializerOptions(), cancellationToken);
                } catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}