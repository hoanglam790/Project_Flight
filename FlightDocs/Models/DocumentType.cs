using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class DocumentType
    {
        [Key]
        public int TypeID { get; set; }
        public string TyleName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
    }
}
