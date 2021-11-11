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
            var filter = Builders<CovidData>.Filter.Lte(x => x.LastUpdatedAtSource, date);

            return await CovidData.Find(filter)
                .Limit(7)
                .ToListAsync();
        }

        public async Task<CovidData> GetLatest()
            => await CovidData.AsQueryable()
                .OrderByDescending(x => x.LastUpdatedAtSource)
                .FirstOrDefaultAsync();
    }
}