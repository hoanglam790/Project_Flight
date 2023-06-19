using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IPermissionRepo
    {
        Task<List<PermissionRead>> GetAllPermission();
        Task<PermissionRead> GetPermissionById(int id);
        Task<bool> CreatePermission(PermissionCreate permissionCreate);
        Task<bool> UpdatePermission(PermissionRead permission, int id);
        Task<bool> DeletePermission(int id);
    }
}
