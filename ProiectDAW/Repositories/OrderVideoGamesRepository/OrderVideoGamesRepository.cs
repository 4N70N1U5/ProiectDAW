using Microsoft.Data.SqlClient;
using ProiectDAW.Models;

namespace ProiectDAW.Repositories.OrderVideoGamesRepository
{
    public class OrderVideoGamesRepository : IOrderVideoGamesRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<OrderVideoGame> _table;

        public OrderVideoGamesRepository(DataContext context)
        {
            _context = context;
            _table = _context.OrderVideoGames;
        }

        public async Task CreateAsync(OrderVideoGame request)
        {
            await _table.AddAsync(request);
        }

        public async Task<List<OrderVideoGame>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<OrderVideoGame> GetByIdsAsync(Guid orderId, Guid videoGameId)
        {
            return await _table.FirstOrDefaultAsync(ovg => ovg.OrderId == orderId && ovg.VideoGameId == videoGameId);
        }

        public void Delete(OrderVideoGame request)
        {
            _table.Remove(request);
        }
    }
}
