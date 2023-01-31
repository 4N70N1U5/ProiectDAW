using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PublishersRepository
{
    public interface IPublishersRepository : IGenericRepository<Publisher>
    {
        Task<List<Publisher>> GetAllWithInfoAsync();
    }
}
