using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context) { }

        public async Task<List<User>> GetAllIncludeOrders()
        {
            return await _table.Include(u => u.Orders).ThenInclude(o => o.Payment).ToListAsync();
        }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username == username);
        }
    }
}
