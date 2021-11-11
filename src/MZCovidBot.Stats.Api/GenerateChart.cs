using System.Collections.Generic;
using System.Linq;
using MZCovidBot.Database.Models;
using MZCovidBot.Stats.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuickChart;

namespace MZCovidBot.Stats.Api
{
    public static class GenerateChart
    {
        public static string GetGeneratedChartUrl(List<CovidData> stats)
        {
            if (stats.Count == 1) return null;

            var config = JsonConvert.SerializeObject(new ChartConfig
            {
                Type = "line",
                Data = new ChartConfig.ChartData
                {
                    Labels = stats.Select(x => x.TxtDate).ToList(),
                    DataSets = new List<ChartConfig.ChartData.DataSet>
                    {
                        new()
                        {
                            Label = "Infected",
                            Data = stats.Select(x => x.DailyInfected).ToList()
                        }
                    }
                }
            }, GetNewtonsoftJsonConfiguration());

            return new Chart
            {
                Height = 400,
                Width = 800,
                Config = config
            }.GetUrl();
        }

        private static JsonSerializerSettings GetNewtonsoftJsonConfiguration()
        {
            return new()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
        }
    }
}