using System;
using System.Collections.Generic;

namespace FlightDocs.Model;

public partial class Permission
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public int Member { get; set; }

    public DateTime CreateDate { get; set; }

    public string Note { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
