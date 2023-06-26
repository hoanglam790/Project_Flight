namespace FlightDocs.DTO
{
    public class GroupPermissionCreate
    {
        public string? GroupName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Note { get; set; }
        public int? PermissionID { get; set; }
        public int? DocumentID { get; set; }
    }
}
