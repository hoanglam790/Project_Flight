using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class DocumentType
    {
        [Key]
        public int TypeID { get; set; }
        public string? TyleName { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
