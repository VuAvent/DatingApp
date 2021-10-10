using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class LoginDto
    {
        [StringLength(32)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password{get; set;}
    }
}