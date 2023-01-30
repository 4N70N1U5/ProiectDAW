using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class VideoGame : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public Publisher Publisher { get; set; } // = new Publisher();
        public Guid PublisherId { get; set; }
        public List<OrderVideoGame> Orders { get; set; } // = new List<OrderVideoGame>();
    }
}
