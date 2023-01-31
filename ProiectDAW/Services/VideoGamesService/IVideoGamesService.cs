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
        Task<List<VideoGameGetInfoDTO>> GetVideoGamesWithInfo();

        // Update
        Task<VideoGame> UpdateVideoGame(Guid id, VideoGameEditDTO request);

        // Delete
        Task<List<VideoGame>> DeleteVideoGame(Guid id);
    }
}
