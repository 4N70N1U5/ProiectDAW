using ProiectDAW.Models.DTOs.PublisherDTOs;

namespace ProiectDAW.Models.DTOs.VideoGamesDTOs
{
    public class VideoGameGetInfoDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public PublisherGetDTO Publisher { get; set; }
    }
}
