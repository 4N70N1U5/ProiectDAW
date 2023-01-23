namespace ProiectDAW.Models
{
    public class OrderVideoGame
    {
        public Order Order { get; set; } = new Order();
        public Guid OrderId { get; set; }
        public VideoGame VideoGame { get; set; } = new VideoGame();
        public Guid VideoGameId { get; set; }
    }
}
