using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IUserRepo
    {
        Task<bool> CreateUser(UserCreate user);
        Task<bool> LoginUser(UserLogin user);
        Task<bool> VerifyUser(string token);
    }
}
