using System;
using System.Collections.Generic;

namespace FlightDocs.Model;

public partial class Document
{
    public int DocumentId { get; set; }

    public string DocumentName { get; set; } = null!;

    public int TypeId { get; set; }

    public DateTime CreateDate { get; set; }

    public string Version { get; set; } = null!;

    public string? Note { get; set; }

    public string FlightId { get; set; } = null!;

    public int UserId { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual DocumentType Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
