using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IUserRepo
    {
        Task<object> CreateUser(UserCreate user);
    }
}
