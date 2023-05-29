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
        private readonly IConfiguration? _configuration;
        private readonly DataContext _dataContext;

        public UserRepo(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        public async Task<object> CreateUser(UserCreate user)
        {   
            CreatePasswordHashing(user.Password, out byte[] passHash, out byte[] passSalt);
            var createUser = new User();

            // r is used to save the result
            var r = new UserResult();
            createUser.Name = user.Name;
            createUser.Email = user.Email;
            createUser.PasswordHashing = passHash;
            createUser.PasswordSalt = passSalt;
            createUser.Address = user.Address;
            createUser.Phone = user.Phone;
            createUser.VerifyToken = CreateNewToken();
            r.Success = SaveData(createUser);
            return r;
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

        public string CreateNewToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 64)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        //Save data into database
        public bool SaveData(User user)
        {
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
