using System;
using System.Collections.Generic;

namespace FlightDocs.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] PasswordHashing { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? VerifyToken { get; set; }

    public DateTime? VeryfiedAt { get; set; }

    public string? ResetPassword { get; set; }

    public DateTime? TokenExpire { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
