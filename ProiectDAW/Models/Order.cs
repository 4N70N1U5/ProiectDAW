using ProiectDAW.Models.Base;
using System.Text.Json.Serialization;

namespace ProiectDAW.Models
{
    public class Order : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        public User User { get; set; } = new User();
        public Guid UserId { get; set; }
        public Payment Payment { get; set; } = new Payment();
        public List<OrderVideoGame> VideoGames { get; set; } = new List<OrderVideoGame> { };
    }
}
