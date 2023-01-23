using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<VideoGame> VideoGames { get; set; } = new List<VideoGame>();
    }
}
