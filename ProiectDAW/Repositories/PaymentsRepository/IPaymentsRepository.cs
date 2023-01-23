using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PaymentsRepository
{
    public interface IPaymentsRepository : IGenericRepository<Payment>
    {
        List<Payment> GetByCardIssuer(string cardIssuer);
        List<Payment> GetByCardType(string cardType);
        Payment GetByOrderId(Guid orderId);
        List<Payment> GetByUserId(Guid userId);
    }
}
