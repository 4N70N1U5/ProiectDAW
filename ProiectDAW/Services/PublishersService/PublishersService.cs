using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PublisherDTOs;
using ProiectDAW.Repositories.PublishersRepository;
using ProiectDAW.Repositories.UnitOfWork;

namespace ProiectDAW.Services.PublishersService
{
    public class PublishersService : IPublishersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PublishersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreatePublisher(Publisher request)
        {
            await _unitOfWork._publishersRepository.CreateAsync(request);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<PublisherGetDTO>> GetPublishers()
        {
            var publishers = await _unitOfWork._publishersRepository.GetAllAsync();
            List<PublisherGetDTO> result = _mapper.Map<List<PublisherGetDTO>>(publishers);
            return result;
        }

        public async Task<List<PublisherGetInfoDTO>> GetPublishersWithInfo()
        {
            var publishers = await _unitOfWork._publishersRepository.GetAllWithInfoAsync();
            List<PublisherGetInfoDTO> result = _mapper.Map<List<PublisherGetInfoDTO>>(publishers);
            return result;
        }

        public async Task<Publisher> UpdatePublisher(Guid id, PublisherCreateEditDTO request)
        {
            var publisherToEdit = await _unitOfWork._publishersRepository.GetByIdAsync(id);

            if (publisherToEdit == null) { return null; }

            publisherToEdit.Name = request.Name;
            publisherToEdit.DateModified = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return publisherToEdit;
        }

        public async Task<List<Publisher>> DeletePublisher(Guid id)
        {
            var publisherToDelete = await _unitOfWork._publishersRepository.GetByIdAsync(id);

            if (publisherToDelete == null) { return null; }

            _unitOfWork._publishersRepository.Delete(publisherToDelete);

            await _unitOfWork.SaveAsync();

            return await _unitOfWork._publishersRepository.GetAllAsync();
        }
    }
}
