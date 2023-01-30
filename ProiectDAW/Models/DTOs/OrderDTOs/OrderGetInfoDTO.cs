using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Models.DTOs.UserDTOs;

namespace ProiectDAW.Models.DTOs.OrderDTOs
{
    public class OrderGetInfoDTO
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        public UserGetDTO User { get; set; }
        public PaymentGetDTO Payment { get; set; }
        // public List<VideoGame> VideoGames { get; set; }
    }
}
