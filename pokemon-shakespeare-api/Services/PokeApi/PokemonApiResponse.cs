using System.Collections.Generic;
using System.Text.Json.Serialization;

public class PokemonApiResponse
{
	[JsonPropertyName("flavor_text_entries")]
	public List<FlavorTextEntry> FlavorTextEntries { get; set; }

}