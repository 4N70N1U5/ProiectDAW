using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.OrderVideoGamesRepository
{
    public interface IOrderVideoGamesRepository
    {
        Task CreateAsync(OrderVideoGame request);
        Task<List<OrderVideoGame>> GetAllAsync();
        Task<OrderVideoGame> GetByIdsAsync(Guid orderId, Guid videoGameId);
        void Delete(OrderVideoGame request);
        Task<bool> SaveAsync();
    }
}
