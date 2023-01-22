using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public List<Order> Orders { get; set; }
    }
}
