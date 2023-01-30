using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;

namespace ProiectDAW.Services.VideoGameService
{
    public interface IVideoGamesService
    {
        public Task CreateVideoGame(VideoGame videoGame);
        public Task<List<VideoGameGetDTO>> GetVideoGames();

        public Task<VideoGame> UpdateVideoGame(Guid id, VideoGameEditDTO videoGame);

        public Task<List<VideoGame>> DeleteVideoGame(Guid id);
    }
}
