using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context) { }

        //public Task<List<User>> GetAll()
        //{

        //}

        //public Task<User> GetById(int id)
        //{

        //}

        public async Task<List<User>> GetAllIncludeOrders()
        {
            return await _table.Include(u => u.Orders).ThenInclude(o => o.Payment).ToListAsync();
        }

        public async Task<User> GetByIdIncludeOrders(Guid id)
        {
            return await _table.Include(u => u.Orders).ThenInclude(o => o.Payment).FirstOrDefaultAsync(u => id == u.Id);
        }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username == username);
        }
    }
}
