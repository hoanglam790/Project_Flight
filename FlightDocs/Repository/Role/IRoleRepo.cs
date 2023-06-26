using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IRoleRepo
    {
        Task<List<RoleRead>> GetAllRole();
        Task<RoleRead> GetRoleById(int id);
        Task<bool> CreateRole(RoleCreate roleCreate);
        Task<bool> UpdateRole(RoleRead role, int id);
        Task<bool> DeleteRole(int id);
    }
}
