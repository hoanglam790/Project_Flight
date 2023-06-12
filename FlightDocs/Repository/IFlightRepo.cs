using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IFlightRepo
    {
        Task<List<FlightRead>> GetAllFlight();
        Task<FlightRead> GetFlightById(string id);
        Task<bool> CreateFlight(FlightCreate flightCreate);
        Task<bool> UpdateFlight(FlightRead flight, string id);
        Task<bool> DeleteFlight(string id);
    }
}
