using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetByUserNameAsync(string userName);
    }
}
