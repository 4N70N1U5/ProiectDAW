using ProiectDAW.Models;
using ProiectDAW.Repositories.OrderVideoGamesRepository;
using ProiectDAW.Repositories.UnitOfWork;

namespace ProiectDAW.Services.OrderVideoGamesService
{
    public class OrderVideoGamesService : IOrderVideoGamesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderVideoGamesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrderVideoGame(OrderVideoGame request)
        {
            await _unitOfWork._orderVideoGamesRepository.CreateAsync(request);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<OrderVideoGame>> DeleteOrderVideoGame(Guid orderId, Guid videoGameId)
        {
            var orderVideoGameToDelete = await _unitOfWork._orderVideoGamesRepository.GetByIdsAsync(orderId, videoGameId);

            _unitOfWork._orderVideoGamesRepository.Delete(orderVideoGameToDelete);
            await _unitOfWork.SaveAsync();

            return await _unitOfWork._orderVideoGamesRepository.GetAllAsync();
        }
    }
}
