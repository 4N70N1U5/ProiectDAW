namespace ProiectDAW.Models.DTOs.VideoGamesDTOs
{
    public class VideoGameGetDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public Guid PublisherId { get; set; }
    }
}
