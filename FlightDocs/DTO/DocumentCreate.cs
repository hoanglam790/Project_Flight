namespace FlightDocs.DTO
{
    public class DocumentCreate
    {
        public string? DocumentName { get; set; }
        public int DocumentTypeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Version { get; set; }
        //public string? Note { get; set; }
        public string? FlightID { get; set; }
        public int UserID { get; set; }
    }
}
