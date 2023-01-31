using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;
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

        public async Task<List<VideoGameCopiesDTO>> GetAllWithCopiesSoldAsync()
        {
            var result = from ovg in _context.OrderVideoGames
                         join vg in _table on ovg.VideoGameId equals vg.Id
                         select new { ovg, vg } into t
                         group t by t.vg.Id into g
                         select new VideoGameCopiesDTO
                         {
                             Id = g.FirstOrDefault().vg.Id,
                             Title = g.FirstOrDefault().vg.Title,
                             ReleaseDate = g.FirstOrDefault().vg.ReleaseDate,
                             Price = g.FirstOrDefault().vg.Price,
                             PublisherId = g.FirstOrDefault().vg.PublisherId,
                             CopiesSold = g.Sum(n => 1)
                         };

            return await result.ToListAsync();
        }
    }
}
