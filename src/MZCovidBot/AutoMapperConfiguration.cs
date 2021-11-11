using AutoMapper;
using MZCovidBot.Database.Models;
using MZCovidBot.Stats.Api.Models;

namespace MZCovidBot
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg => { cfg.CreateMap<LatestCovidStats, CovidData>(); });
        }
    }
}