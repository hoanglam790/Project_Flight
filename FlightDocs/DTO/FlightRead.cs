namespace FlightDocs.DTO
{
    public class FlightRead
    {
        public string? FlightID { get; set; }
        public string? FlightFrom { get; set; }
        public string? FlightTo { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
