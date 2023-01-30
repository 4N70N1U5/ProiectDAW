namespace ProiectDAW.Models.DTOs.VideoGamesDTOs
{
    public class VideoGameCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public int Price { get; set; }
        public Guid PublisherId { get; set; }
    }
}
