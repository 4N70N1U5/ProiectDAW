using ProiectDAW.Models.DTOs.OrderDTOs;
using ProiectDAW.Models.Enum;

namespace ProiectDAW.Models.DTOs.UserDTOs
{
    public class UserGetInfoDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }
        public List<OrderGetInfoPaymentDTO> Orders { get; set; } = new List<OrderGetInfoPaymentDTO>();
    }
}
