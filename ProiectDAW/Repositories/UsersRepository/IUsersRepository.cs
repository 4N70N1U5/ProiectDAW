using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User GetByUserName(string userName);
    }
}
