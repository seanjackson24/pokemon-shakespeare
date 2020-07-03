using System.Text.Json.Serialization;

namespace PokemonShakespeare.Api.Services.ShakespeareApi
{
    public class Contents
    {
        [JsonPropertyName("translated")]
        public string Translated { get; set; }
    }
}