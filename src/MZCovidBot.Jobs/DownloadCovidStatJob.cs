using System.Threading.Tasks;
using MZCovidBot.Stats.Api;
using Quartz;

namespace MZCovidBot.Jobs
{
    public class DownloadCovidStatJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var covidData = await ApifyCovidApi.GetLatestCovidStats();
        }
    }
}