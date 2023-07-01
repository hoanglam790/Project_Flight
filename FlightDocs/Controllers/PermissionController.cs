using FlightDocs.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepo _permissionRepo;

        public PermissionController(IPermissionRepo permissionRepo)
        {
            _permissionRepo = permissionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermission()
        {
            var getAllPermission = await _permissionRepo.GetAllPermission();
            return Ok(getAllPermission);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            var getPermissionByID = await _permissionRepo.GetPermissionById(id);
            if (getPermissionByID != null)
            {
                return Ok(getPermissionByID);
            }
            else
            {
                return BadRequest("Not found permission id.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPermission(PermissionCreate permission)
        {
            await _permissionRepo.CreatePermission(permission);
            return Ok("New permission has been created successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePermission(PermissionRead permission, int id)
        {
            var getPermissionID = await _permissionRepo.GetPermissionById(id);
            if (getPermissionID != null)
            {
                await _permissionRepo.UpdatePermission(permission, id);
                return Ok("Permission has been updated successfully.");
            }
            else
            {
                return BadRequest("Update fail. Not found permission id.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var getPermissionID = await _permissionRepo.GetPermissionById(id);
            if (getPermissionID != null)
            {
                await _permissionRepo.DeletePermission(id);
                return Ok("Permission has been deleted successfully.");
            }
            else
            {
                return BadRequest("Delete fail. Permission id is not exist.");
            }
        }
    }
}
