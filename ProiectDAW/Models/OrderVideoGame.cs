namespace ProiectDAW.Models
{
    public class OrderVideoGame
    {
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public VideoGame VideoGame { get; set; }
        public Guid VideoGameId { get; set; }
    }
}
