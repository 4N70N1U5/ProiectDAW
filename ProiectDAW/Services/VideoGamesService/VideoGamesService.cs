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

        public async Task CreateVideoGame(VideoGame videoGame)
        {
            await _videoGamesRepository.CreateAsync(videoGame);
            await _videoGamesRepository.SaveAsync();
        }

        public async Task<List<VideoGameGetDTO>> GetVideoGames()
        {
            var videoGames = await _videoGamesRepository.GetAllAsync();
            List<VideoGameGetDTO> result = _mapper.Map<List<VideoGameGetDTO>>(videoGames);
            return result;
        }
    }
}
