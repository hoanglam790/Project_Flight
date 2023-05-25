using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Permission
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int Member { get; set; }
        public DateTime CreateDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public int UserID { get; set; }
    }
}
