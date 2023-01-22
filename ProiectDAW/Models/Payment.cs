using ProiectDAW.Models.Base;

namespace ProiectDAW.Models
{
    public class Payment : BaseEntity
    {
        public string CardIssuer { get; set; } = string.Empty;
    }
}
