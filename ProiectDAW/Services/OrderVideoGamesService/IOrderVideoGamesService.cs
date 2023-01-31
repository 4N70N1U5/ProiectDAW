using ProiectDAW.Models;

namespace ProiectDAW.Services.OrderVideoGamesService
{
    public interface IOrderVideoGamesService
    {
        // Create
        Task CreateOrderVideoGame(OrderVideoGame request);

        // Delete
        Task<List<OrderVideoGame>> DeleteOrderVideoGame(Guid orderId, Guid videoGameId);
    }
}
