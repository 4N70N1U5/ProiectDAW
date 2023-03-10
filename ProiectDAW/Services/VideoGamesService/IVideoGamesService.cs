using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;

namespace ProiectDAW.Services.VideoGameService
{
    public interface IVideoGamesService
    {
        // Create
        Task CreateVideoGame(VideoGame request);

        // Read
        Task<List<VideoGameGetDTO>> GetVideoGames();
        Task<VideoGame> GetVideoGameById(Guid id);
        Task<List<VideoGameGetInfoDTO>> GetVideoGamesWithInfo();
        Task<List<VideoGameCopiesDTO>> GetVideoGamesWithCopiesSold();

        // Update
        Task<VideoGame> UpdateVideoGame(Guid id, VideoGameEditDTO request);

        // Delete
        Task<List<VideoGame>> DeleteVideoGame(Guid id);
    }
}
