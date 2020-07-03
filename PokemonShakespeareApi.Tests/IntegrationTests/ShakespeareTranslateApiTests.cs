using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using PokemonShakespeare.Api.Services.ShakespeareApi;

namespace PokemonShakespeare.Api.Tests.UnitTests
{
    public class ShakespeareTranslateApiTests
    {
        [Fact]
        public async Task EmptyString_ReturnsNull()
        {
            var service = new ShakespeareApiClient(new HttpClient());
            var result = await service.TranslateToShakespearean("", CancellationToken.None);
            Assert.Null(result);
        }

        [Fact]
        public async Task NullString_ReturnsNull()
        {
            var service = new ShakespeareApiClient(new HttpClient());
            var result = await service.TranslateToShakespearean(null, CancellationToken.None);
            Assert.Null(result);
        }

        [Fact]
        public async Task NonEmptyString_ReturnsAValue()
        {
            var service = new ShakespeareApiClient(new HttpClient());
            var result = await service.TranslateToShakespearean("the", CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task NonUrlSafe_ReturnsAValue()
        {
            var service = new ShakespeareApiClient(new HttpClient());
            var result = await service.TranslateToShakespearean("compare ya to a summers day? Or nah?", CancellationToken.None);
            Assert.NotNull(result);
        }


        //  For public API calls this is 60 API calls a day with distribution of 5 calls an hour.
        // this tests that the API 429 exceptions (too many requests) are bubbled up. Uncomment out the [Fact] attribute to run it, but be aware this will break the other integration tests.
      //  [Fact]
        public async Task TooManyApiCalls_ReturnsNull()
        {
            var service = new ShakespeareApiClient(new HttpClient());
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {

                for (int i = 0; i < 60; i++)
                {
                    var result = await service.TranslateToShakespearean("compare ya to a summers day? Or nah?", CancellationToken.None);
                    Assert.NotNull(result);
                }
            });
        }
    }
}
