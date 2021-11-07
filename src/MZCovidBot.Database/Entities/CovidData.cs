using System.ComponentModel.DataAnnotations;
using MZCovidBot.Stats.Api.Models;

namespace MZCovidBot.Database.Entities
{
    public class CovidData : LatestCovidStats
    {
        [Key] public ulong Id { get; set; }
    }
}