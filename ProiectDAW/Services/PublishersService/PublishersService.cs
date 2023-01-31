using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PublisherDTOs;
using ProiectDAW.Repositories.PublishersRepository;

namespace ProiectDAW.Services.PublishersService
{
    public class PublishersService : IPublishersService
    {
        private readonly IPublishersRepository _publishersRepository;
        private readonly IMapper _mapper;

        public PublishersService(IPublishersRepository publishersRepository, IMapper mapper)
        {
            _publishersRepository = publishersRepository;
            _mapper = mapper;
        }

        public async Task CreatePublisher(Publisher request)
        {
            await _publishersRepository.CreateAsync(request);
            await _publishersRepository.SaveAsync();
        }

        public async Task<List<PublisherGetDTO>> GetPublishers()
        {
            var publishers = await _publishersRepository.GetAllAsync();
            List<PublisherGetDTO> result = _mapper.Map<List<PublisherGetDTO>>(publishers);
            return result;
        }

        public async Task<List<PublisherGetInfoDTO>> GetPublishersWithInfo()
        {
            var publishers = await _publishersRepository.GetAllWithInfoAsync();
            List<PublisherGetInfoDTO> result = _mapper.Map<List<PublisherGetInfoDTO>>(publishers);
            return result;
        }

        public async Task<Publisher> UpdatePublisher(Guid id, PublisherCreateEditDTO request)
        {
            var publisherToEdit = await _publishersRepository.GetByIdAsync(id);

            if (publisherToEdit == null) { return null; }

            publisherToEdit.Name = request.Name;
            publisherToEdit.DateModified = DateTime.UtcNow;

            await _publishersRepository.SaveAsync();

            return publisherToEdit;
        }

        public async Task<List<Publisher>> DeletePublisher(Guid id)
        {
            var publisherToDelete = await _publishersRepository.GetByIdAsync(id);

            if (publisherToDelete == null) { return null; }

            _publishersRepository.Delete(publisherToDelete);

            await _publishersRepository.SaveAsync();

            return await _publishersRepository.GetAllAsync();
        }
    }
}
