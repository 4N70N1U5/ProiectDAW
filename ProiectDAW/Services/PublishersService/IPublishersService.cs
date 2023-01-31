using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PublisherDTOs;

namespace ProiectDAW.Services.PublishersService
{
    public interface IPublishersService
    {
        // Create
        Task CreatePublisher(Publisher request);

        // Read
        Task<List<PublisherGetDTO>> GetPublishers();
        Task<List<PublisherGetInfoDTO>> GetPublishersWithInfo();

        // Update
        Task<Publisher> UpdatePublisher(Guid id, PublisherCreateEditDTO request);

        // Delete
        Task<List<Publisher>> DeletePublisher(Guid id);
    }
}
