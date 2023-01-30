using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PublisherDTOs;

namespace ProiectDAW.Services.PublishersService
{
    public interface IPublishersService
    {
        public Task CreatePublisher(Publisher publisher);

        public Task<List<PublisherGetDTO>> GetPublishers();

        public Task<Publisher> UpdatePublisher(Guid id, PublisherCreateEditDTO publisher);

        public Task<List<Publisher>> DeletePublisher(Guid id);
    }
}
