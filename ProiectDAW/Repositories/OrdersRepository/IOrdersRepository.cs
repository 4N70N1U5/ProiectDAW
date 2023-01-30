using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.OrdersRepository
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetAllIncludeInfo();
        Task<List<Order>> GetByPurchaseDate(DateOnly date);
        Task<List<Order>> GetByUserId(Guid userId);
    }
}
