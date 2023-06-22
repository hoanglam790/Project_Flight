namespace FlightDocs.DTO
{
    public class GroupPermissionRead
    {
        public int GroupID { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Note { get; set; }
        public int? PermissionID { get; set; }
        public int? DocumentID { get; set; }
    }
}
