using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.OrderDTOs;
using ProiectDAW.Repositories.OrdersRepository;

namespace ProiectDAW.Services.OrdersService
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task CreateOrder(Order request)
        {
            await _ordersRepository.CreateAsync(request);
            await _ordersRepository.SaveAsync();
        }

        public async Task<List<OrderGetDTO>> GetOrders()
        {
            var orders = await _ordersRepository.GetAllAsync();
            List<OrderGetDTO> result = _mapper.Map<List<OrderGetDTO>>(orders);
            return result;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _ordersRepository.GetByIdAsync(id);
        }

        public async Task<List<OrderGetInfoDTO>> GetOrdersWithInfo()
        {
            var orders = await _ordersRepository.GetAllWithInfoAsync();
            List<OrderGetInfoDTO> result = _mapper.Map<List<OrderGetInfoDTO>>(orders);
            return result;
        }

        public async Task<List<OrderGetInfoPaymentDTO>> GetOrdersWithInfoByUserId(Guid userId)
        {
            var orders = await _ordersRepository.GetByUserIdWithInfoAsync(userId);
            List<OrderGetInfoPaymentDTO> result = _mapper.Map<List<OrderGetInfoPaymentDTO>>(orders);
            return result;
        }

        public async Task<List<OrderGetInfoPaymentDTO>> GetOrdersWithInfoByUsername(string username)
        {
            var orders = await _ordersRepository.GetByUsernameWithInfoAsync(username);
            List<OrderGetInfoPaymentDTO> result = _mapper.Map<List<OrderGetInfoPaymentDTO>>(orders);
            return result;
        }

        public async Task<Order> UpdateOrder(Guid id, OrderEditDTO request)
        {
            var orderToEdit = await _ordersRepository.GetByIdAsync(id);

            if (orderToEdit == null) return null;

            orderToEdit.PurchaseDate = request.PurchaseDate;
            orderToEdit.DateModified = DateTime.UtcNow;

            await _ordersRepository.SaveAsync();

            return orderToEdit;
        }

        public async Task UpdateOrderTotal(Order order, int total)
        {
            order.OrderTotal += total;
            order.DateModified = DateTime.UtcNow;

            await _ordersRepository.SaveAsync();
        }

        public async Task<List<Order>> DeleteOrder(Guid id)
        {
            var orderToDelete = await _ordersRepository.GetByIdAsync(id);

            if (orderToDelete == null) return null;

            _ordersRepository.Delete(orderToDelete);
            await _ordersRepository.SaveAsync();

            return (await _ordersRepository.GetAllAsync());
        }
    }
}
