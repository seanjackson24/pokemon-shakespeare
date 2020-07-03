using System.Text.Json.Serialization;

namespace PokemonShakespeare.Api.Services.PokeApi
{
    public class Language
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}