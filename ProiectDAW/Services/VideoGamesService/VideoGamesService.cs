using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;
using ProiectDAW.Repositories.UnitOfWork;
using ProiectDAW.Repositories.VideoGamesRepository;

namespace ProiectDAW.Services.VideoGameService
{
    public class VideoGamesService : IVideoGamesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideoGamesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateVideoGame(VideoGame request)
        {
            await _unitOfWork._videoGamesRepository.CreateAsync(request);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<VideoGameGetDTO>> GetVideoGames()
        {
            var videoGames = await _unitOfWork._videoGamesRepository.GetAllAsync();
            List<VideoGameGetDTO> result = _mapper.Map<List<VideoGameGetDTO>>(videoGames);
            return result;
        }

        public async Task<VideoGame> GetVideoGameById(Guid id)
        {
            return await _unitOfWork._videoGamesRepository.GetByIdAsync(id);
        }

        public async Task<List<VideoGameGetInfoDTO>> GetVideoGamesWithInfo()
        {
            var videoGames = await _unitOfWork._videoGamesRepository.GetAllWithInfoAsync();
            List<VideoGameGetInfoDTO> result = _mapper.Map<List<VideoGameGetInfoDTO>>(videoGames);
            return result;
        }

        public async Task<List<VideoGameCopiesDTO>> GetVideoGamesWithCopiesSold()
        {
            return await _unitOfWork._videoGamesRepository.GetAllWithCopiesSoldAsync();
        }

        public async Task<VideoGame> UpdateVideoGame(Guid id, VideoGameEditDTO request)
        {
            var gameToEdit = await _unitOfWork._videoGamesRepository.GetByIdAsync(id);

            if (gameToEdit == null) return null;

            gameToEdit.Title = request.Title;
            gameToEdit.ReleaseDate = request.ReleaseDate.ToDateTime(TimeOnly.MinValue);
            gameToEdit.Price = request.Price;
            gameToEdit.DateModified = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return gameToEdit;
        }

        public async Task<List<VideoGame>> DeleteVideoGame(Guid id)
        {
            var gameToDelete = await _unitOfWork._videoGamesRepository.GetByIdAsync(id);

            if (gameToDelete == null) return null;

            _unitOfWork._videoGamesRepository.Delete(gameToDelete);

            await _unitOfWork.SaveAsync();

            return await _unitOfWork._videoGamesRepository.GetAllAsync();
        }
    }
}
