using ProiectDAW.Repositories.OrdersRepository;
using ProiectDAW.Repositories.OrderVideoGamesRepository;
using ProiectDAW.Repositories.PaymentsRepository;
using ProiectDAW.Repositories.PublishersRepository;
using ProiectDAW.Repositories.UsersRepository;
using ProiectDAW.Repositories.VideoGamesRepository;

namespace ProiectDAW.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUsersRepository _usersRepository { get; }
        IOrdersRepository _ordersRepository { get; }
        IPaymentsRepository _paymentsRepository { get; }
        IPublishersRepository _publishersRepository { get; }
        IVideoGamesRepository _videoGamesRepository { get; }
        IOrderVideoGamesRepository _orderVideoGamesRepository { get; }
        Task<bool> SaveAsync();
    }
}
