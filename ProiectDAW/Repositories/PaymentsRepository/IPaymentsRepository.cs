using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PaymentsRepository
{
    public interface IPaymentsRepository : IGenericRepository<Payment>
    {
        Task<List<Payment>> GetAllWithInfoAsync();
    }
}
