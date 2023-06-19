using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class GroupPermission
    {
        [Key]
        public int GroupID { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Note { get; set; }
        public int? PermissionID { get; set; }
        public int? DocumentID { get; set; }
        public virtual Permission? Permission { get; set; }
        public virtual Document? Document { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
