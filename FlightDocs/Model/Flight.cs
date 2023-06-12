using System;
using System.Collections.Generic;

namespace FlightDocs.Model;

public partial class Flight
{
    public string FlightId { get; set; } = null!;

    public string FlightFrom { get; set; } = null!;

    public string FlightTo { get; set; } = null!;

    public DateTime DepartureDate { get; set; }
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
