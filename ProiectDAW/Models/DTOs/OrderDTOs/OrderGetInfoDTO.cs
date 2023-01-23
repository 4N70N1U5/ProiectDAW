namespace ProiectDAW.Models.DTOs.OrderDTOs
{
    public class OrderGetInfoDTO
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }
        // public List<VideoGame> VideoGames { get; set; }
    }
}
