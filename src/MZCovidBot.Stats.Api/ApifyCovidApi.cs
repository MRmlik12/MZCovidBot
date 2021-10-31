using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MZCovidBot.Stats.Api.Models;

namespace MZCovidBot.Stats.Api
{
    public static class ApifyCovidApi
    {
        private const string GetLatestUrl = "https://api.apify.com/v2/key-value-stores";

        public static async Task<LatestCovidStats> GetLatestCovidStats()
            => await GetLatestUrl
                .AppendPathSegment("/3Po6TV7wTht4vIEid/records/LATEST")
                .SetQueryParam("disableRedirect", "false")
                .GetAsync()
                .ReceiveJson<LatestCovidStats>();
    }
}