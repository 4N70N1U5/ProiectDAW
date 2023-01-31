using ProiectDAW.Models;
using ProiectDAW.Repositories.OrderVideoGamesRepository;

namespace ProiectDAW.Services.OrderVideoGamesService
{
    public class OrderVideoGamesService : IOrderVideoGamesService
    {
        private readonly IOrderVideoGamesRepository _orderVideoGamesRepository;

        public OrderVideoGamesService(IOrderVideoGamesRepository orderVideoGamesRepository)
        {
            _orderVideoGamesRepository = orderVideoGamesRepository;
        }

        public async Task CreateOrderVideoGame(OrderVideoGame request)
        {
            await _orderVideoGamesRepository.CreateAsync(request);
            await _orderVideoGamesRepository.SaveAsync();
        }

        public async Task<List<OrderVideoGame>> DeleteOrderVideoGame(Guid orderId, Guid videoGameId)
        {
            var orderVideoGameToDelete = await _orderVideoGamesRepository.GetByIdsAsync(orderId, videoGameId);

            _orderVideoGamesRepository.Delete(orderVideoGameToDelete);
            await _orderVideoGamesRepository.SaveAsync();

            return await _orderVideoGamesRepository.GetAllAsync();
        }
    }
}
