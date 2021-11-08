using System.Threading.Tasks;
using MongoDB.Driver;
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
    }
}