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

        public async Task<bool> CreateUser(UserCreate user)
        {   
            CreatePasswordHashing(user.Password, out byte[] passHash, out byte[] passSalt);
            var createUser = new User();

            // r is used to save the result
            //var r = new UserResult();
            createUser.Name = user.Name;
            createUser.Email = user.Email;
            createUser.PasswordHashing = passHash;
            createUser.PasswordSalt = passSalt;
            createUser.Address = user.Address;
            createUser.Phone = user.Phone;
            createUser.RoleID = user.Role;
            createUser.GroupPermissionID = user.Group;
            createUser.VerifyToken = CreateNewToken();
            _dataContext.Add(createUser);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginUser(UserLogin user)
        {
            //var userResult = new UserLoginResult();
            //var userLogin = FindUser(user.Email);
            //if(userLogin != user.Email)
            //{
            //    //userResult.Success = false;
            //    //userResult.MessageResponse = "Invalid email.";
            //    return false;
            //}
            //else
            //{

            //}
            User account = new User();
            var verifyUser = VerifyPasswordHashing(user.Password, account.PasswordHashing, account.PasswordSalt);
            if (!verifyUser)
            {
                //userResult.Success = false;
                //userResult.MessageResponse = "Password is invalid. Please check again !!!";
                return false;
            }
            //if(account.VeryfiedAt == null)
            //{
            //    //userResult.Success = false;
            //    //userResult.MessageResponse = "Unauthenticated user.";
            //    return false;
            //}
            return true;
        }

        public async Task<bool> VerifyUser(string token)
        {
            //var userResult = new UserLoginResult();
            var verify = _dataContext.Users.FirstOrDefault(n => n.VerifyToken == token);
            if (verify == null)
            {
                //userResult.Success = false;
                //userResult.MessageResponse = "Invalid token";
                return false;
            }
            verify.VeryfiedAt = DateTime.Now;
            await _dataContext.SaveChangesAsync();
            //userResult.Success = true;
            //userResult.MessageResponse = "User has been verified successful.";
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

        public string CreateNewToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 64)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public object FindUser(string email)
        {
            var userResult = new UserLoginResult();
            var userLogin = _dataContext.Users.FirstOrDefault(n => n.Email == email);
            if (userLogin == null)
            {
                userResult.Success = false;
                userResult.MessageResponse = "User is not found.";
                return userResult;
            }
            else
            {
                userResult.Success = true;
                userResult.MessageResponse = "User was found.";
                return userResult;
            }           
        }

        //public object VerifyUser(string token)
        //{
        //    var userResult = new UserLoginResult();
        //    var verify = _dataContext.Users.FirstOrDefault(n => n.VerifyToken == token);
        //    if(verify == null)
        //    {
        //        userResult.Success = false;
        //        userResult.MessageResponse = "Invalid token";
        //        return userResult;
        //    }
        //    verify.VeryfiedAt = DateTime.Now;
        //    _dataContext.SaveChanges();
        //    userResult.MessageResponse = "User has been verified successful.";
        //    return userResult;
        //}

        //Save data into database
        public bool SaveData(User user)
        {
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
