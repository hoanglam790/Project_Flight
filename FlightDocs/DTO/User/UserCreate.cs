using System.ComponentModel.DataAnnotations;

namespace FlightDocs.DTO
{
    public class UserCreate
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Please enter a password at least 8 characters.")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        public int Role { get; set; }
        public int Group { get; set; }
        public string? VerifyToken { get; set; }
    }
}
