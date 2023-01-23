using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Repositories.PaymentsRepository;

namespace ProiectDAW.Services.PaymentsService
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public async Task CreatePayment(Payment payment)
        {
            await _paymentsRepository.CreateAsync(payment);
            await _paymentsRepository.SaveAsync();
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _paymentsRepository.GetAllAsync();
        }

        public async Task<Payment> GetPaymentById(Guid id)
        {
            return await _paymentsRepository.GetByIdAsync(id);
        }

        public Task<List<Payment>> GetPaymentsByCardIssuer(string cardIssuer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsByCardType(string cardType)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentByOrderId(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> UpdatePayment(Guid id, Payment payment)
        {
            var paymentToEdit = await GetPaymentById(id);

            if (paymentToEdit == null) return null;

            paymentToEdit.CardIssuer = payment.CardIssuer;
            paymentToEdit.CardNumber = payment.CardNumber;
            paymentToEdit.CardType = payment.CardType;
            paymentToEdit.DateModified = DateTime.UtcNow;

            await _paymentsRepository.SaveAsync();

            return paymentToEdit;
        }

        public async Task<List<Payment>> DeletePayment(Guid id)
        {
            var paymentToDelete = await GetPaymentById(id);

            if (paymentToDelete == null) return null;

            _paymentsRepository.Delete(paymentToDelete);
            await _paymentsRepository.SaveAsync();

            return await GetAllPayments();
        }
    }
}
