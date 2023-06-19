using FlightDocs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepo _roleRepo;

        public RoleController(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var getAllRole = await _roleRepo.GetAllRole();
            return Ok(getAllRole);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var getRoleByID = await _roleRepo.GetRoleById(id);
            if (getRoleByID != null)
            {
                return Ok(getRoleByID);
            }
            else
            {
                return BadRequest("Not found role id.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewFlight(RoleCreate role)
        {
            await _roleRepo.CreateRole(role);
            return Ok("New role has been created successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRole(RoleRead role, int id)
        {
            var getRoleID = await _roleRepo.GetRoleById(id);
            if (getRoleID != null)
            {
                await _roleRepo.UpdateRole(role, id);
                return Ok("Role has been updated successfully.");
            }
            else
            {
                return BadRequest("Update fail. Not found role id.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var getRoleID = await _roleRepo.GetRoleById(id);
            if (getRoleID != null)
            {
                await _roleRepo.DeleteRole(id);
                return Ok("Role has been deleted successfully.");
            }
            else
            {
                return BadRequest("Delete fail. Role id is not exist.");
            }
        }
    }
}
