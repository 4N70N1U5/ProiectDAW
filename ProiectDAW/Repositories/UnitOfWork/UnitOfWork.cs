using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.Repositories.OrdersRepository;
using ProiectDAW.Repositories.OrderVideoGamesRepository;
using ProiectDAW.Repositories.PaymentsRepository;
using ProiectDAW.Repositories.PublishersRepository;
using ProiectDAW.Repositories.UsersRepository;
using ProiectDAW.Repositories.VideoGamesRepository;

namespace ProiectDAW.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext _context { get; set; }

        public IUsersRepository _usersRepository { get; set; }

        public IOrdersRepository _ordersRepository { get; set; }

        public IPaymentsRepository _paymentsRepository { get; set; }

        public IPublishersRepository _publishersRepository { get; set; }

        public IVideoGamesRepository _videoGamesRepository { get; set; }

        public IOrderVideoGamesRepository _orderVideoGamesRepository { get; set; }

        public UnitOfWork(DataContext context,
            IUsersRepository usersRepository,
            IOrdersRepository ordersRepository,
            IPaymentsRepository paymentsRepository,
            IPublishersRepository publishersRepository,
            IVideoGamesRepository videoGamesRepository,
            IOrderVideoGamesRepository orderVideoGamesRepository)
        {
            _context = context;
            _usersRepository = usersRepository;
            _ordersRepository = ordersRepository;
            _paymentsRepository = paymentsRepository;
            _publishersRepository = publishersRepository;
            _videoGamesRepository = videoGamesRepository;
            _orderVideoGamesRepository = orderVideoGamesRepository;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }

            return false;
        }
    }
}
