﻿namespace ProiectDAW.Models.DTOs.OrderDTOs
{
    public class OrderGetInfoUserDTO
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int OrderTotal { get; set; }
        public User User { get; set; }
        // public List<VideoGame> VideoGames { get; set; }
    }
}
