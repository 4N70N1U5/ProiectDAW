namespace ProiectDAW.Models.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public DateTime PurchaseDate { get; set; }
        public Guid UserId { get; set; }
    }
}
