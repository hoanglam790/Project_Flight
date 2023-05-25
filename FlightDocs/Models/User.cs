using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHashing { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? VerifyToken { get; set; }
        public DateTime? VeryfiedAt { get; set; }
        public string? ResetPassword { get; set; }
        public DateTime? TokenExpire { get; set; }
    }
}
