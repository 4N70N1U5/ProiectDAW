using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;
using ProiectDAW.Repositories.VideoGamesRepository;

namespace ProiectDAW.Services.VideoGameService
{
    public class VideoGamesService : IVideoGamesService
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public VideoGamesService(IVideoGamesRepository videoGamesRepository, IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }

        public async Task CreateVideoGame(VideoGame request)
        {
            await _videoGamesRepository.CreateAsync(request);
            await _videoGamesRepository.SaveAsync();
        }

        public async Task<List<VideoGameGetDTO>> GetVideoGames()
        {
            var videoGames = await _videoGamesRepository.GetAllAsync();
            List<VideoGameGetDTO> result = _mapper.Map<List<VideoGameGetDTO>>(videoGames);
            return result;
        }

        public async Task<List<VideoGameGetInfoDTO>> GetVideoGamesWithInfo()
        {
            var videoGames = await _videoGamesRepository.GetAllWithInfoAsync();
            List<VideoGameGetInfoDTO> result = _mapper.Map<List<VideoGameGetInfoDTO>>(videoGames);
            return result;
        }

        public async Task<VideoGame> UpdateVideoGame(Guid id, VideoGameEditDTO request)
        {
            var gameToEdit = await _videoGamesRepository.GetByIdAsync(id);

            if (gameToEdit == null) return null;

            gameToEdit.Title = request.Title;
            gameToEdit.ReleaseDate = request.ReleaseDate.ToDateTime(TimeOnly.MinValue);
            gameToEdit.Price = request.Price;
            gameToEdit.DateModified = DateTime.UtcNow;

            await _videoGamesRepository.SaveAsync();

            return gameToEdit;
        }

        public async Task<List<VideoGame>> DeleteVideoGame(Guid id)
        {
            var gameToDelete = await _videoGamesRepository.GetByIdAsync(id);

            if (gameToDelete == null) return null;

            _videoGamesRepository.Delete(gameToDelete);

            await _videoGamesRepository.SaveAsync();

            return await _videoGamesRepository.GetAllAsync();
        }
    }
}
