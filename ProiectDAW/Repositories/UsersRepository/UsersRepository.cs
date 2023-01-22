using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context) { }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _table.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
