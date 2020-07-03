using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonShakespeare.Api.Models;
using PokemonShakespeare.Api.Services;

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

		public async Task<ActionResult<Pokemon>> Index(string name, CancellationToken cancellationToken)
		{
			try
			{
				var pokemon = await _fetchService.GetPokemon(name, cancellationToken);
				return pokemon;
			} catch (HttpRequestException ex)
            {
				_logger.LogError("Too many requests recorded from API", ex.Message);
				return StatusCode(StatusCodes.Status429TooManyRequests);
            }
		}
	}
}
