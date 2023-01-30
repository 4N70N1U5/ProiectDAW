using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PublishersRepository
{
    public class PublishersRepository : GenericRepository<Publisher>, IPublishersRepository
    {
        public PublishersRepository(DataContext context) : base(context) { }
    }
}
