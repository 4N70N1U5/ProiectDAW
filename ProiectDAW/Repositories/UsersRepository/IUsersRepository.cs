using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.UsersRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        //Task<List<User>> GetAll();
        //Task<User> GetById(int id);
        Task<List<User>> GetAllIncludeOrders();
        Task<User> GetByIdIncludeOrders(Guid id);
        User GetByUsername(string username);
    }
}
