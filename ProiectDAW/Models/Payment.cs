using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class Payment : BaseEntity
    {
        public string CardIssuer { get; set; } = string.Empty; // Visa or Mastercard.
        public string CardNumber { get; set; } = string.Empty; // Last 4 digits of card number.
        public string CardType { get; set; } = string.Empty; // Debit or credit card.
    }
}
