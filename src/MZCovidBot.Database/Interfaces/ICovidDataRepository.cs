using System.Threading.Tasks;
using MZCovidBot.Database.Entities;

namespace MZCovidBot.Database.Interfaces
{
    public interface ICovidDataRepository
    {
        Task Create(CovidData entity);
    }
}