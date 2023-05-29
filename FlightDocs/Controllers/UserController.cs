using FlightDocs.DTO;
using FlightDocs.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        //Create a new user
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateNewUser([FromBody] UserCreate user)
        {
            await _userRepo.CreateUser(user);
            return Ok("New user has been created successfully.");
        }
    }
}
