using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MZCovidBot.Database.Interfaces;
using MZCovidBot.Database.Models;

namespace MZCovidBot.Database.Repository
{
    public class CovidDataRepository : ICovidDataRepository
    {
        public CovidDataRepository(MongoDbContext context)
        {
            CovidData = context.CovidData;
        }

        private IMongoCollection<CovidData> CovidData { get; }

        public async Task Create(CovidData covidData)
        {
            await CovidData.InsertOneAsync(covidData);
        }

        public async Task<List<CovidData>> GetWeekData(DateTimeOffset date)
        {
            return await CovidData.Aggregate()
                .Match(x => x.LastUpdatedAtSource >= date.AddDays(-7) && x.LastUpdatedAtSource < date)
                .ToListAsync();
        }

        public async Task<CovidData> GetLatest()
            => await CovidData.AsQueryable()
                .OrderByDescending(x => x.LastUpdatedAtSource)
                .FirstOrDefaultAsync();
    }
}