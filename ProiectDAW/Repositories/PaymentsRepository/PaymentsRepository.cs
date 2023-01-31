using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PaymentsRepository
{
    public class PaymentsRepository : GenericRepository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(DataContext context) : base(context) { }

        public async Task<List<Payment>> GetAllWithInfoAsync()
        {
            return await _table.Include(p => p.Order).ThenInclude(o => o.User).ToListAsync();
        }
    }
}
