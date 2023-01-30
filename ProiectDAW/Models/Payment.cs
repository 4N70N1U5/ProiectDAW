using ProiectDAW.Models.Base;
using System.Text.Json.Serialization;

namespace ProiectDAW.Models
{
    public class Payment : BaseEntity
    {
        public string CardIssuer { get; set; } = string.Empty; // Visa or Mastercard.
        public string CardNumber { get; set; } = string.Empty; // Last 4 digits of card number.
        public string CardType { get; set; } = string.Empty; // Debit or credit card.
        public Order Order { get; set; } // = new Order();
        public Guid OrderId { get; set; }
    }
}
