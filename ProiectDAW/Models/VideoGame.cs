using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class VideoGame : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public Publisher Publisher { get; set; }
        public Guid PublisherId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
