using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MZCovidBot.Database.Entities;
using MZCovidBot.Database.Interfaces;

namespace MZCovidBot.Database.Repositories
{
    public class CovidDataRepository : ICovidDataRepository
    {
        public CovidDataRepository(AppDbContext context)
        {
            CovidData = context.CovidData;
        }

        private DbSet<CovidData> CovidData { get; }

        public async Task Create(CovidData entity)
        {
            await CovidData.AddAsync(entity);
        }
    }
}