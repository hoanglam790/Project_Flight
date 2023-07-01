using FlightDocs.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupPermissionRepo _groupPermissionRepo;

        public GroupPermissionController(IGroupPermissionRepo groupPermissionRepo)
        {
            _groupPermissionRepo = groupPermissionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroupPermission()
        {
            var getAllGroupPermission = await _groupPermissionRepo.GetAllGroupPermission();
            return Ok(getAllGroupPermission);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGroupPermissionById(int id)
        {
            var getGroupPermissionByID = await _groupPermissionRepo.GetGroupPermissionById(id);
            if (getGroupPermissionByID != null)
            {
                return Ok(getGroupPermissionByID);
            }
            else
            {
                return BadRequest("Not found group permission id.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGroupPermission(GroupPermissionCreate groupPermission)
        {
            await _groupPermissionRepo.CreateGroupPermission(groupPermission);
            return Ok("New group permission has been created successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGroupPermission(GroupPermissionRead groupPermission, int id)
        {
            var getGroupPermissionID = await _groupPermissionRepo.GetGroupPermissionById(id);
            if (getGroupPermissionID != null)
            {
                await _groupPermissionRepo.UpdateGroupPermission(groupPermission, id);
                return Ok("Group permission has been updated successfully.");
            }
            else
            {
                return BadRequest("Update fail. Not found group permission id.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGroupPermission(int id)
        {
            var getGroupPermissionID = await _groupPermissionRepo.GetGroupPermissionById(id);
            if (getGroupPermissionID != null)
            {
                await _groupPermissionRepo.DeleteGroupPermission(id);
                return Ok("Group permission has been deleted successfully.");
            }
            else
            {
                return BadRequest("Delete fail. Group permission id is not exist.");
            }
        }
    }
}
