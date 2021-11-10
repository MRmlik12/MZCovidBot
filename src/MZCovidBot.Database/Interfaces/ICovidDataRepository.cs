using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MZCovidBot.Database.Models;

namespace MZCovidBot.Database.Interfaces
{
    public interface ICovidDataRepository
    {
        Task Create(CovidData covidData);
        Task<List<CovidData>> GetWeekData(DateTimeOffset date);
        Task<CovidData> GetLatest();
    }
}