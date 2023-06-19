using AutoMapper;
using FlightDocs.DTO;
using FlightDocs.Results;

namespace FlightDocs.Repository
{
    public class FlightRepo : IFlightRepo
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public FlightRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<FlightRead>> GetAllFlight()
        {
            var listFlight = await _dataContext.Flights.ToListAsync();
            return _mapper.Map<List<FlightRead>>(listFlight);
        }

        public async Task<FlightRead> GetFlightById(string id)
        {
            var listFlightByID = await _dataContext.Flights.FindAsync(id);
            return _mapper.Map<FlightRead>(listFlightByID);
        }

        public async Task<bool> CreateFlight(FlightCreate flightCreate)
        {
            var addFlight = new Flight();
            addFlight.FlightID = flightCreate.FlightID;
            addFlight.FlightFrom = flightCreate.FlightFrom;
            addFlight.FlightTo = flightCreate.FlightTo;
            addFlight.DepartureDate = flightCreate.DepartureDate;
            _dataContext.Add(addFlight);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateFlight(FlightRead flight, string id)
        {
            var updateFlight = await _dataContext.Flights.FirstOrDefaultAsync(f => f.FlightID == id);
            if (updateFlight != null)
            {
                updateFlight.FlightFrom = flight.FlightFrom;
                updateFlight.FlightTo = flight.FlightTo;
                updateFlight.DepartureDate = flight.DepartureDate;
                _dataContext.Update(updateFlight);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteFlight(string id)
        {
            var deleteFlight = await _dataContext.Flights.FirstOrDefaultAsync(n => n.FlightID == id);
            if (deleteFlight != null)
            {
                _dataContext.Remove(deleteFlight);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
