using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public class GroupPermissionRepo : IGroupPermissionRepo
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public GroupPermissionRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<GroupPermissionRead>> GetAllGroupPermission()
        {
            var listGroupPermission = await _dataContext.GroupPermissions.ToListAsync();
            return _mapper.Map<List<GroupPermissionRead>>(listGroupPermission);
        }

        public async Task<GroupPermissionRead> GetGroupPermissionById(int id)
        {
            var listGroupPermissionById = await _dataContext.GroupPermissions.FindAsync(id);
            return _mapper.Map<GroupPermissionRead>(listGroupPermissionById);
        }

        public async Task<bool> CreateGroupPermission(GroupPermissionCreate permissionCreate)
        {
            var addGroupPermission = new GroupPermission();
            addGroupPermission.GroupName = permissionCreate.GroupName;
            addGroupPermission.CreateDate = DateTime.Now;
            addGroupPermission.Note = permissionCreate.Note;
            addGroupPermission.PermissionID = permissionCreate.PermissionID;
            addGroupPermission.DocumentID = permissionCreate.DocumentID;
            _dataContext.Add(addGroupPermission);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> UpdateGroupPermission(GroupPermissionRead permission, int id)
        {
            var updateGroupPermission = await _dataContext.GroupPermissions.FirstOrDefaultAsync(f => f.GroupID == id);
            if (updateGroupPermission != null)
            {
                updateGroupPermission.GroupName = permission.GroupName;
                updateGroupPermission.CreateDate = DateTime.Now;
                updateGroupPermission.Note = permission.Note;
                updateGroupPermission.PermissionID = permission.PermissionID;
                updateGroupPermission.DocumentID = permission.DocumentID;
                _dataContext.Update(updateGroupPermission);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteGroupPermission(int id)
        {
            var deleteGroupPermission = await _dataContext.GroupPermissions.FirstOrDefaultAsync(f => f.GroupID == id);
            if (deleteGroupPermission != null)
            {
                _dataContext.Remove(deleteGroupPermission);
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
