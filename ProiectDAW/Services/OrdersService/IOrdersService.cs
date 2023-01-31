using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.OrderDTOs;

namespace ProiectDAW.Services.OrdersService
{
    public interface IOrdersService
    {
        // Create
        Task CreateOrder(Order request);

        // Read
        Task<List<OrderGetDTO>> GetOrders();
        Task<List<OrderGetInfoDTO>> GetOrdersWithInfo();
        Task<List<OrderGetInfoPaymentDTO>> GetOrdersWithInfoByUserId(Guid userId);
        Task<List<OrderGetInfoPaymentDTO>> GetOrdersWithInfoByUsername(string username);

        // Update
        Task<Order> UpdateOrder(Guid id, OrderEditDTO request);

        // Delete
        Task<List<Order>> DeleteOrder(Guid id);
    }
}
