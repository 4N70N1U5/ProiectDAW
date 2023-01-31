using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.OrdersRepository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(DataContext context) : base(context) { }

        public async Task<List<Order>> GetAllWithInfoAsync()
        {
            return await _table.Include(o => o.Payment).Include(o => o.User).ToListAsync();
        }

        public async Task<List<Order>> GetByUserIdWithInfoAsync(Guid userId)
        {
            var result = from order in _table.Include(o => o.Payment)
                         where order.UserId == userId
                         select order;

            return await result.ToListAsync();
        }

        public async Task<List<Order>> GetByUsernameWithInfoAsync(string username)
        {
            var result = from order in _table.Include(o => o.Payment)
                         where order.User.Username == username
                         select order;

            return await result.ToListAsync();
        }
    }
}
