
using System.Text.Json.Serialization;

public class ShakespeareApiResponse
{
	[JsonPropertyName("contents")]
	public Contents Contents { get; set; }
}