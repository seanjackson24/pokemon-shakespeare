using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonShakespeare.Api.Models;

namespace PokemonShakespeare.Api.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IPokemonFetchService _fetchService;
		public HomeController(ILogger<HomeController> logger, IPokemonFetchService fetchService)
		{
			_logger = logger;
			_fetchService = fetchService;
		}

		public async Task<IActionResult> Index()
		{
			var pokemon = await _fetchService.GetPokemon("bulbasaur", CancellationToken.None);

			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
