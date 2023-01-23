namespace ProiectDAW.Models.DTOs.OrderDTOs
{
    public class OrderGetDTO
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        // public Guid UserId { get; set; }
    }
}
