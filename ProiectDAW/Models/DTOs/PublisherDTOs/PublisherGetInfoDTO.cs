using ProiectDAW.Models.DTOs.VideoGamesDTOs;

namespace ProiectDAW.Models.DTOs.PublisherDTOs
{
    public class PublisherGetInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<VideoGameGetDTO> VideoGames { get; set; }
    }
}
