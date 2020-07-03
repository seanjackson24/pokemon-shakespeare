using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonShakespeare.Api.Services.PokeApi
{
    public class PokemonApiResponse
    {
        [JsonPropertyName("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }

    }
}