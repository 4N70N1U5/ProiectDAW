namespace ProiectDAW.Models.DTOs.UserDTOs
{
    public class UserResponseDTO
    {
        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Token { get; set; }
    }
}
