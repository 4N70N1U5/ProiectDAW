using ProiectDAW.Models;
using ProiectDAW.Repositories.OrdersRepository;

namespace ProiectDAW.Services.OrdersService
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task CreateOrder(Order order)
        {
            await _ordersRepository.CreateAsync(order);
            await _ordersRepository.SaveAsync();
        }

        public async Task<List<Order>> DeleteOrder(Guid id)
        {
            var orderToDelete = await _ordersRepository.GetByIdAsync(id);

            if (orderToDelete == null) return null;

            _ordersRepository.Delete(orderToDelete);
            await _ordersRepository.SaveAsync();

            return (await _ordersRepository.GetAllAsync()).ToList();
        }

        public Task<List<Order>> EditOrder(Guid id, Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _ordersRepository.GetByIdAsync(id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _ordersRepository.GetAllIncludePayment();
            // return await _ordersRepository.GetAllAsync();
        }
    }
}
