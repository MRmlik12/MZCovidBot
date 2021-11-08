using System.Threading.Tasks;
using MZCovidBot.Database.Models;

namespace MZCovidBot.Database.Interfaces
{
    public interface ICovidDataRepository
    {
        Task Create(CovidData covidData);
    }
}