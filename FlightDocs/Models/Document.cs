using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Version { get; set; } = string.Empty;
        public string FlightID { get; set; } = string.Empty;
        public int UserID { get; set; }
    }
}
