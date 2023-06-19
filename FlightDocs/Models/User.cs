using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordHashing { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? RoleID { get; set; }
        public int? GroupID { get; set; }
        public string? VerifyToken { get; set; }
        public DateTime? VeryfiedAt { get; set; }
        public string? ResetPassword { get; set; }
        public DateTime? TokenExpire { get; set; }
        public virtual Role? Role { get; set; }
        public virtual GroupPermission? GroupPermission { get; set; }
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
