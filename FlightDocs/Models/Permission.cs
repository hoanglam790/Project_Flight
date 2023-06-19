using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public string? PermissionName { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();
        
    }
}
