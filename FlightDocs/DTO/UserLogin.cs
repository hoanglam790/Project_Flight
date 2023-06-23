using System.ComponentModel.DataAnnotations;

namespace FlightDocs.DTO
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
