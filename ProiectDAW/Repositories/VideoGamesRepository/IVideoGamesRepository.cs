using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.VideoGamesRepository
{
    public interface IVideoGamesRepository : IGenericRepository<VideoGame>
    {
        Task<List<VideoGame>> GetAllWithInfoAsync();
        Task<List<VideoGameCopiesDTO>> GetAllWithCopiesSoldAsync();
    }
}
