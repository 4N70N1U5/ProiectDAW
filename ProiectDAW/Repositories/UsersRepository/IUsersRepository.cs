using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User GetByUsername(string username);
    }
}
