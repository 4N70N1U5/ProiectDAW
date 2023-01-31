using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.PublishersRepository
{
    public class PublishersRepository : GenericRepository<Publisher>, IPublishersRepository
    {
        public PublishersRepository(DataContext context) : base(context) { }

        public async Task<List<Publisher>> GetAllWithInfoAsync()
        {
            return await _table.Include(p => p.VideoGames).ToListAsync();
        }
    }
}
