namespace FlightDocs.DTO
{
    public class DocumentRead
    {
        public int DocumentID { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Version { get; set; }
        public string? FlightID { get; set; }
        public string? User { get; set; }
    }
}
