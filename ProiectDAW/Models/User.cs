using ProiectDAW.Models.Base;
using ProiectDAW.Models.Enum;
using System.Text.Json.Serialization;

namespace ProiectDAW.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
