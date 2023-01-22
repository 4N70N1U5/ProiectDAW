namespace ProiectDAW.Models
{
    public class OrderVideoGame
    {
        public Order Order { get; set; }
        public Guid OrdersId { get; set; }
        public VideoGame VideoGame { get; set; }
        public Guid VideoGamesId { get; set; }
    }
}
