using ProiectDAW.Models;

namespace ProiectDAW.Services.OrdersService
{
    public interface IOrdersService
    {
        Task CreateOrder(Order order);

        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(Guid id);

        Task<List<Order>> EditOrder(Guid id, Order order);

        Task<List<Order>> DeleteOrder(Guid id);
    }
}
