using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.OrderDTOs;

namespace ProiectDAW.Services.OrdersService
{
    public interface IOrdersService
    {
        Task CreateOrder(Order order);

        Task<List<OrderGetDTO>> GetOrders();
        Task<List<OrderGetInfoDTO>> GetOrdersInfo();
        Task<Order> GetOrderById(Guid id);

        Task<Order> EditOrder(Guid id, OrderEditDTO request);

        Task<List<Order>> DeleteOrder(Guid id);
    }
}
