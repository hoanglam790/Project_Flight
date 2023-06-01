using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IUserRepo
    {
        Task<object> CreateUser(UserCreate user);
        Task<object> LoginUser(UserLogin user);
        Task<object> VerifyUser(string token);
    }
}
