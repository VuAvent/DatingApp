using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Database.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        [Required]
        public string Username { get; set; }

        [StringLength(255)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }  

        public byte[] PasswordHash{get; set;}

        public byte[] PasswordSalt { get; set;} 

        [StringLength(32)]
        public DateTime DateOfBirth {get; set;}

        public string KnownAs {get; set;}
        [StringLength(6)]
        public string Gender {get; set;}
        [StringLength(256)]
        public string Introduction {get; set;}
        [StringLength(32)]
        public string City {get; set;}

        [StringLength(512)]
        public string Avatar {get; set;}

        public DateTime CreatedAt {get; set;}

        public DateTime UpdatedAt {get; set;}

        public int GetAge() 
        {
            var today = DateTime.Now;
            var age = today.Year - DateOfBirth.Year;
            if(DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}