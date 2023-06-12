namespace FlightDocs.DTO
{
    public class DocumentTypeRead
    {
        public int DocumentTypeID { get; set; }
        public string DocumentTypeName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
    }
}
