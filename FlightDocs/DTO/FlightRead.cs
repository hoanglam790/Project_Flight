﻿namespace FlightDocs.DTO
{
    public class FlightRead
    {
        public string FlightID { get; set; }
        public string FlightFrom { get; set; } = string.Empty;
        public string FlightTo { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
    }
}
