using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MZCovidBot.Stats.Api.Models;

namespace MZCovidBot.Database.Models
{
    public class CovidData : LatestCovidStats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}