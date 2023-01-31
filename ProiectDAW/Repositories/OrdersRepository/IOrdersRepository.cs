using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.OrdersRepository
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        // Read
        Task<List<Order>> GetAllWithInfoAsync();
        Task<List<Order>> GetByUserIdWithInfoAsync(Guid userId);
    }
}
