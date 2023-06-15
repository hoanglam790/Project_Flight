namespace FlightDocs.DTO
{
    public class DocumentCreate
    {
        public string DocumentName { get; set; } = string.Empty;
        public int DocumentTypeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Version { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string FlightID { get; set; } = string.Empty;
        public int UserID { get; set; }
    }
}
