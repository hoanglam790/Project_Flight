using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public class PermissionRepo : IPermissionRepo
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PermissionRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<List<PermissionRead>> GetAllPermission()
        {
            var listPermission = await _dataContext.Permissions.ToListAsync();
            return _mapper.Map<List<PermissionRead>>(listPermission);
        }

        public async Task<PermissionRead> GetPermissionById(int id)
        {
            var listPermissionById = await _dataContext.Permissions.FindAsync(id);
            return _mapper.Map<PermissionRead>(listPermissionById);
        }

        public async Task<bool> CreatePermission(PermissionCreate permissionCreate)
        {
            var addPermission = new Permission();
            addPermission.PermissionName = permissionCreate.PermissionName;
            _dataContext.Add(addPermission);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePermission(PermissionRead permission, int id)
        {
            var updatePermission = await _dataContext.Permissions.FirstOrDefaultAsync(f => f.PermissionID == id);
            if (updatePermission != null)
            {
                updatePermission.PermissionName = permission.PermissionName;
                _dataContext.Update(updatePermission);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeletePermission(int id)
        {
            var deletePermission = await _dataContext.Permissions.FirstOrDefaultAsync(f => f.PermissionID == id);
            if (deletePermission != null)
            {
                _dataContext.Remove(deletePermission);
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
