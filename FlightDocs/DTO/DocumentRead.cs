namespace FlightDocs.DTO
{
    public class DocumentRead
    {
        public int DocumentID { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentTypeName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Version { get; set; } = string.Empty;
        public string FlightID { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
    }
}
