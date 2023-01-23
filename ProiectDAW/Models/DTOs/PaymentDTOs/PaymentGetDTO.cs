namespace ProiectDAW.Models.DTOs.PaymentDTOs
{
    public class PaymentGetDTO
    {
        public Guid Id { get; set; }
        public string CardIssuer { get; set; } = string.Empty; 
        public string CardNumber { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        // public Guid OrderId { get; set; }
    }
}
