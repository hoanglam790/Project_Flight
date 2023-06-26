using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IGroupPermissionRepo
    {
        Task<List<GroupPermissionRead>> GetAllGroupPermission();
        Task<GroupPermissionRead> GetGroupPermissionById(int id);
        Task<bool> CreateGroupPermission(GroupPermissionCreate permissionCreate);
        Task<bool> UpdateGroupPermission(GroupPermissionRead permission, int id);
        Task<bool> DeleteGroupPermission(int id);
    }
}
