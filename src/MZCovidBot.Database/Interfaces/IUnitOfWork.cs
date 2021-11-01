using System.Threading.Tasks;

namespace MZCovidBot.Database.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}