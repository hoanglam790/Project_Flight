using System;
using System.Collections.Generic;

namespace FlightDocs.Model;

public partial class DocumentType
{
    public int TypeId { get; set; }

    public string TyleName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
