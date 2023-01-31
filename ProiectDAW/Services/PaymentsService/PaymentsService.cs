using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Repositories.PaymentsRepository;

namespace ProiectDAW.Services.PaymentsService
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IMapper _mapper;

        public PaymentsService(IPaymentsRepository paymentsRepository, IMapper mapper)
        {
            _paymentsRepository = paymentsRepository;
            _mapper = mapper;
        }

        public async Task CreatePayment(Payment request)
        {
            await _paymentsRepository.CreateAsync(request);
            await _paymentsRepository.SaveAsync();
        }

        public async Task<List<PaymentGetDTO>> GetPayments()
        {
            var payments = await _paymentsRepository.GetAllAsync();
            List<PaymentGetDTO> result = _mapper.Map<List<PaymentGetDTO>>(payments);
            return result;
        }

        public async Task<List<PaymentGetInfoDTO>> GetPaymentsWithInfo()
        {
            var payments = await _paymentsRepository.GetAllWithInfoAsync();
            List<PaymentGetInfoDTO> result = _mapper.Map<List<PaymentGetInfoDTO>>(payments);
            return result;
        }

        public async Task<Payment> UpdatePayment(Guid id, PaymentEditDTO request)
        {
            var paymentToEdit = await _paymentsRepository.GetByIdAsync(id);

            if (paymentToEdit == null) return null;

            paymentToEdit.CardIssuer = request.CardIssuer;
            paymentToEdit.CardNumber = request.CardNumber;
            paymentToEdit.CardType = request.CardType;
            paymentToEdit.DateModified = DateTime.UtcNow;

            await _paymentsRepository.SaveAsync();

            return paymentToEdit;
        }

        public async Task<List<Payment>> DeletePayment(Guid id)
        {
            var paymentToDelete = await _paymentsRepository.GetByIdAsync(id);

            if (paymentToDelete == null) return null;

            _paymentsRepository.Delete(paymentToDelete);
            await _paymentsRepository.SaveAsync();

            return await _paymentsRepository.GetAllAsync();
        }
    }
}
