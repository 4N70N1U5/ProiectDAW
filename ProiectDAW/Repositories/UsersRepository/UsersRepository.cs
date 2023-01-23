using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context) { }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username == username);
        }
    }
}
