using ProiectDAW.Models.DTOs.OrderDTOs;

namespace ProiectDAW.Models.DTOs.PaymentDTOs
{
    public class PaymentGetInfoDTO
    {
        public Guid Id { get; set; }
        public string CardIssuer { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public OrderGetInfoUserDTO Order { get; set; }
    }
}
