﻿using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.Models.DTOs.UserDTOs
{
    public class UserRequestDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Email { get; set;}
        [Required] public string Password { get; set; }
    }
}
