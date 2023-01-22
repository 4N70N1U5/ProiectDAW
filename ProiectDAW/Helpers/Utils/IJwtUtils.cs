using ProiectDAW.Models;

namespace ProiectDAW.Helpers.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken (string token);
    }
}
