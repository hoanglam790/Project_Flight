using FlightDocs.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FlightDocs.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;

        public UserRepo(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        public async Task<bool> CreateUser(UserCreate user)
        {   
            CreatePasswordHashing(user.Password, out byte[] passHash, out byte[] passSalt);
            var createUser = new User();
            createUser.Name = user.Name;
            createUser.Email = user.Email;
            createUser.PasswordHashing = passHash;
            createUser.PasswordSalt = passSalt;
            createUser.Address = user.Address;
            createUser.Phone = user.Phone;
            createUser.RoleID = user.Role;
            createUser.GroupPermissionID = user.Group;
            createUser.VerifyToken = CreateNewToken(user);
            _dataContext.Add(createUser);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginUser(UserLogin user)
        {
            User account = new User();
            var verifyUser = VerifyPasswordHashing(user.Password, account.PasswordHashing, account.PasswordSalt);
            if (!verifyUser)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> VerifyUser(string token)
        {
            //var userResult = new UserLoginResult();
            var verify = _dataContext.Users.FirstOrDefault(n => n.VerifyToken == token);
            if (verify == null)
            {
                return false;
            }
            verify.VeryfiedAt = DateTime.Now;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        private void CreatePasswordHashing(string passWord, out byte[] passHash, out byte[] passSalt)
        {
            using (var ph = new HMACSHA512())
            {
                passSalt = ph.Key;
                passHash = ph.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passWord));
            }
        }

        public bool VerifyPasswordHashing(string password, byte[] passHash, byte[] passSalt)
        {
            using (var ph = new HMACSHA512(passSalt))
            {
                var computhHash = ph.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computhHash.SequenceEqual(passHash);
            }
        }

        public string CreateNewToken(UserCreate user)
        {
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //Random random = new Random();
            //return new string(Enumerable.Repeat(chars, 64)
            //    .Select(s => s[random.Next(s.Length)]).ToArray());
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:SecretKey").Value!));
            var creden = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                    claims : claims,
                    expires: DateTime.Now.AddMonths(1),
                    signingCredentials: creden
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
