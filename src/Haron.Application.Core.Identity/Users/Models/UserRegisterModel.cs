using System.ComponentModel.DataAnnotations;

namespace Haron.Application.Core.Identity.Users.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public string? ConfirmPassword { get; set; }

        public string? PhoneNumber { get; set; }
    }
}