using ProiectDAW.Models.DTOs.PaymentDTOs;

namespace ProiectDAW.Models.DTOs.OrderDTOs
{
    public class OrderGetInfoPaymentDTO
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        public PaymentGetDTO Payment { get; set; }
        // public List<VideoGame> VideoGames { get; set; }
    }
}
