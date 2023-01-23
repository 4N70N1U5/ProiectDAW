using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;

namespace ProiectDAW.Services.PaymentsService
{
    public interface IPaymentsService
    {
        // Create
        Task CreatePayment(Payment payment);

        // Read
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(Guid id);
        Task<List<Payment>> GetPaymentsByCardIssuer(string cardIssuer);
        Task<List<Payment>> GetPaymentsByCardType(string cardType);
        Task<Payment> GetPaymentByOrderId(Guid orderId);
        Task<List<Payment>> GetPaymentsByUserId(Guid userId);

        // Update
        Task<Payment> UpdatePayment(Guid id, Payment payment);

        // Delete
        Task<List<Payment>> DeletePayment(Guid id);
    }
}
