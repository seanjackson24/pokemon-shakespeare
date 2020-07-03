using System.Text.Json.Serialization;

namespace PokemonShakespeare.Api.Services.PokeApi
{
    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        [JsonPropertyName("language")]
        public Language Language { get; set; }
    }
}