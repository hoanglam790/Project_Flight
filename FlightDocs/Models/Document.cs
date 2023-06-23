using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }
        public string? DocumentName { get; set; }
        public int? DocumentTypeID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Version { get; set; }
        public string? FlightID { get; set; }
        public int? UserID { get; set; }
        public virtual User? User { get; set; }
        public virtual DocumentType? DocumentType { get; set; }
        public virtual Flight? Flight { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();
    }
}
