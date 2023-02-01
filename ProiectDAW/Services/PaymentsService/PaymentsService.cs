using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Repositories.PaymentsRepository;
using ProiectDAW.Repositories.UnitOfWork;

namespace ProiectDAW.Services.PaymentsService
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreatePayment(Payment request)
        {
            await _unitOfWork._paymentsRepository.CreateAsync(request);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<PaymentGetDTO>> GetPayments()
        {
            var payments = await _unitOfWork._paymentsRepository.GetAllAsync();
            List<PaymentGetDTO> result = _mapper.Map<List<PaymentGetDTO>>(payments);
            return result;
        }

        public async Task<List<PaymentGetInfoDTO>> GetPaymentsWithInfo()
        {
            var payments = await _unitOfWork._paymentsRepository.GetAllWithInfoAsync();
            List<PaymentGetInfoDTO> result = _mapper.Map<List<PaymentGetInfoDTO>>(payments);
            return result;
        }

        public async Task<Payment> UpdatePayment(Guid id, PaymentEditDTO request)
        {
            var paymentToEdit = await _unitOfWork._paymentsRepository.GetByIdAsync(id);

            if (paymentToEdit == null) return null;

            paymentToEdit.CardIssuer = request.CardIssuer;
            paymentToEdit.CardNumber = request.CardNumber;
            paymentToEdit.CardType = request.CardType;
            paymentToEdit.DateModified = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return paymentToEdit;
        }

        public async Task<List<Payment>> DeletePayment(Guid id)
        {
            var paymentToDelete = await _unitOfWork._paymentsRepository.GetByIdAsync(id);

            if (paymentToDelete == null) return null;

            _unitOfWork._paymentsRepository.Delete(paymentToDelete);
            await _unitOfWork.SaveAsync();

            return await _unitOfWork._paymentsRepository.GetAllAsync();
        }
    }
}
