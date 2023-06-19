using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public RoleRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<RoleRead>> GetAllRole()
        {
            var listRole = await _dataContext.Roles.ToListAsync();
            return _mapper.Map<List<RoleRead>>(listRole);
        }

        public async Task<RoleRead> GetRoleById(int id)
        {
            var listRoleByID = await _dataContext.Roles.FindAsync(id);
            return _mapper.Map<RoleRead>(listRoleByID);
        }

        public async Task<bool> CreateRole(RoleCreate roleCreate)
        {
            var addRole = new Role();
            addRole.RoleName = roleCreate.RoleName;
            _dataContext.Add(addRole);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRole(RoleRead role, int id)
        {
            var updateRole = await _dataContext.Roles.FirstOrDefaultAsync(f => f.RoleID == id);
            if (updateRole != null)
            {
                updateRole.RoleName = role.RoleName;
                _dataContext.Update(updateRole);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(int id)
        {
            var deleteRole = await _dataContext.Roles.FirstOrDefaultAsync(n => n.RoleID == id);
            if (deleteRole != null)
            {
                _dataContext.Remove(deleteRole);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
