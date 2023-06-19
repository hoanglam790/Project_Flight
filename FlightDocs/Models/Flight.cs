namespace FlightDocs.Models
{
    public class Flight
    {
        public string? FlightID { get; set; }
        public string? FlightFrom { get; set; }
        public string? FlightTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
