using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PaymentsRepository
{
    public class PaymentsRepository : GenericRepository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(DataContext context) : base(context) { }

        public List<Payment> GetByCardIssuer(string cardIssuer)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetByCardType(string cardType)
        {
            throw new NotImplementedException();
        }

        public Payment GetByOrderId(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
