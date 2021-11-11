using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MZCovidBot.Database.Models
{
    public class CovidData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public long Infected { get; set; }
        public long Deceased { get; set; }
        public long Recovered { get; set; }
        public long DailyInfected { get; set; }
        public long DailyTested { get; set; }
        public long DailyPositiveTests { get; set; }
        public long DailyDeceased { get; set; }
        public long DailyRecovered { get; set; }
        public long DailyQuarantine { get; set; }
        public string TxtDate { get; set; }
        public DateTimeOffset LastUpdatedAtApify { get; set; }
        public DateTimeOffset LastUpdatedAtSource { get; set; }
        public string Country { get; set; }
        public Uri SourceUrl { get; set; }
        public Uri HistoryData { get; set; }
    }
}