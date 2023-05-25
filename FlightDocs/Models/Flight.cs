namespace FlightDocs.Models
{
    public class Flight
    {
        public string FlightID { get; set; } = string.Empty;
        public string FlightFrom { get; set; } = string.Empty;
        public string FlightTo { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
    }
}
