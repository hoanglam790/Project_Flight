using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IFlightRepo
    {
        Task<List<FlightRead>> GetAllFlight();
        Task<FlightRead> GetFlightById(string id);
        Task<object> CreateFlight(FlightCreate flightCreate);
        Task UpdateFlight(FlightRead flight, string id);
        Task DeleteFlight(string id);
    }
}
