using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllIncludeOrders();
        User GetByUsername(string username);
    }
}
