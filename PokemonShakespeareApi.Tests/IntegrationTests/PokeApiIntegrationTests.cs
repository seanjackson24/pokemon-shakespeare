using PokemonShakespeare.Api.Services.PokeApi;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PokemonShakespeare.Api.Tests.IntegrationTests
{
    public class PokeApiIntegrationTests
    {
        [Fact]
        public async Task EmptyString_ReturnsNull()
        {
            var service = new PokemonApiClient(new HttpClient());
            var result = await service.GetPokemonByName("", CancellationToken.None);
            Assert.Null(result);
        }

        [Fact]
        public async Task NullString_ReturnsNull()
        {
            var service = new PokemonApiClient(new HttpClient());
            var result = await service.GetPokemonByName(null, CancellationToken.None);
            Assert.Null(result);
        }

        [Fact]
        public async Task GarbagePokemon_ReturnsNull()
        {
            var service = new PokemonApiClient(new HttpClient());
            var result = await service.GetPokemonByName("sdfysiughlskgdlk", CancellationToken.None);
            Assert.Null(result);
        }

        [Fact]
        public async Task KnownPokemon_ReturnsData()
        {
            var service = new PokemonApiClient(new HttpClient());
            var result = await service.GetPokemonByName("charmander", CancellationToken.None);
            AssertValidPokemon(result);
        }

        private static void AssertValidPokemon(PokemonApiResponse result)
        {
            Assert.NotNull(result.FlavorTextEntries);
            foreach (var item in result.FlavorTextEntries)
            {
                Assert.NotNull(item.Language);
                Assert.False(string.IsNullOrEmpty(item.Language.Name));
                Assert.False(string.IsNullOrEmpty(item.FlavorText));
            }
        }

        [Fact]
        public async Task KnownPokemon_StrangeCase_ReturnsData()
        {
            var service = new PokemonApiClient(new HttpClient());
            var result = await service.GetPokemonByName("chaRMander", CancellationToken.None);
            AssertValidPokemon(result);
        }
    }
}
