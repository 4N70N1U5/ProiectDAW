namespace ProiectDAW.Models.DTOs.PaymentDTOs
{
    public class PaymentDTO
    {
        public string CardIssuer { get; set; } = string.Empty; // Visa or Mastercard.
        public string CardNumber { get; set; } = string.Empty; // Last 4 digits of card number.
        public string CardType { get; set; } = string.Empty; // Debit or credit card.
    }
}
