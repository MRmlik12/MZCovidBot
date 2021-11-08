using Flurl.Http.Testing;
using MZCovidBot.Stats.Api.Models;
using Xunit;

namespace MZCovidBot.Stats.Api.Test
{
    public class TestApifyCovidApi
    {
        [Fact]
        public async void TestGetLatestCovidStats_CheckResponseBodyAndStatus()
        {
            using var httpTest = new HttpTest();
            httpTest.RespondWithJson(new LatestCovidStats
            {
                Country = "Poland"
            });

            var result = await ApifyCovidApi.GetLatestCovidStats();

            Assert.NotNull(result.Country);
        }
    }
}