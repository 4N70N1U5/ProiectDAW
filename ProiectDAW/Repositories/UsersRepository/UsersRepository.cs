using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context) { }

        public User GetByUserName(string userName)
        {
            return _table.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
