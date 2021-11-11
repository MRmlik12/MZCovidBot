using System;
using MongoDB.Driver;
using MZCovidBot.Database.Models;

namespace MZCovidBot.Database
{
    public class MongoDbContext
    {
        public MongoDbContext()
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING"));
            var database = client.GetDatabase("MZCovidDB");
            CovidData = database.GetCollection<CovidData>("CovidData");
        }

        public IMongoCollection<CovidData> CovidData { get; }
    }
}