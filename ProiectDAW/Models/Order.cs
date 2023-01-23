using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class Order : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Payment Payment { get; set; }
        public List<OrderVideoGame> VideoGames { get; set; }
    }
}
