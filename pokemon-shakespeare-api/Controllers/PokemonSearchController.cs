using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PokemonShakespeare.Api.Controllers
{
	[ApiController]
	[Route("/search-pokemon")]
	public class PokemonSearchController : Controller
	{
		private readonly IPokemonFetchService _fetchService;

		private readonly ILogger<PokemonSearchController> _logger;

		public PokemonSearchController(ILogger<PokemonSearchController> logger, IPokemonFetchService fetchService)
		{
			_logger = logger;
			_fetchService = fetchService;
		}

		public async Task<ActionResult<Pokemon>> Index(CancellationToken cancellationToken)
		{
			var pokemon = await _fetchService.GetPokemon("bulbasaur", cancellationToken);
			return pokemon;
		}
	}
}
