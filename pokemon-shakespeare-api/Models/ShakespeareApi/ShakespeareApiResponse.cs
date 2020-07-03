using System.Text.Json.Serialization;

namespace PokemonShakespeare.Api.Services.ShakespeareApi
{
    public class ShakespeareApiResponse
    {
        [JsonPropertyName("contents")]
        public Contents Contents { get; set; }
    }
}