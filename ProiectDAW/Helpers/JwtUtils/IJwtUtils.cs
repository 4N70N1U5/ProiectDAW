using ProiectDAW.Models;

namespace ProiectDAW.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken (string token);
    }
}
