using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;

namespace ProiectDAW.Services.PaymentsService
{
    public interface IPaymentsService
    {
        // Create
        Task CreatePayment(Payment request);

        // Read
        Task<List<PaymentGetDTO>> GetPayments();
        Task<List<PaymentGetInfoDTO>> GetPaymentsWithInfo();

        // Update
        Task<Payment> UpdatePayment(Guid id, PaymentEditDTO request);

        // Delete
        Task<List<Payment>> DeletePayment(Guid id);
    }
}
