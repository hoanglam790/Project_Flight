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
        public async Task<IActionResult> CreateNewUser(UserCreate user)
        {
            await _userRepo.CreateUser(user);
            return Ok("New user has been created successfully.");
        }

        //Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            var userLogin = await _userRepo.LoginUser(user);
            if(userLogin == null)
            {
                return BadRequest("Login failed.");
            }
            return Ok(userLogin);
        }

        //Verify user
        [HttpPost]
        [Route("Verify")]
        public async Task<IActionResult> VerifyUser(string token)
        {
            var verifyUser = await _userRepo.VerifyUser(token);
            if (verifyUser == null)
            {
                return BadRequest("Invalid token.");
            }
            return Ok(verifyUser);
        }
    }
}
