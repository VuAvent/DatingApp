using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class RegisterDto
    {
        [StringLength(32)]
        [Required]
        public string Username { get; set; }

        [StringLength(255)]
        [Required]
        public string Email { get; set; }  

        [Required]
        public string Password{get; set;}

        
    }
}