using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.VideoGamesRepository
{
    public class VideoGamesRepository : GenericRepository<VideoGame>, IVideoGamesRepository
    {
        public VideoGamesRepository(DataContext context) : base(context) { }

        public async Task<List<VideoGame>> GetAllWithInfoAsync()
        {
            return await _table.Include(vg => vg.Publisher).ToListAsync();
        }
    }
}
