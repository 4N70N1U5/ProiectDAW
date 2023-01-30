using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.VideoGamesRepository
{
    public class VideoGamesRepository : GenericRepository<VideoGame>, IVideoGamesRepository
    {
        public VideoGamesRepository(DataContext context) : base(context) { }
    }
}
