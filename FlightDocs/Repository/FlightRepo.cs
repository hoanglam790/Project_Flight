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

        public async Task<object> CreateFlight(FlightCreate flightCreate)
        {
            var r = new Result();
            var addFlight = new Flight();
            addFlight.FlightID = flightCreate.FlightID;
            addFlight.FlightFrom = flightCreate.FlightFrom;
            addFlight.FlightTo = flightCreate.FlightTo;
            addFlight.DepartureDate = flightCreate.DepartureDate;
            r.Success = SaveData(addFlight);
            return r;
        }

        public async Task UpdateFlight(FlightRead flight, string id)
        {
            if(flight.FlightID == id)
            {
                var updateFlight = new Flight();
                updateFlight.FlightFrom = flight.FlightFrom;
                updateFlight.FlightTo = flight.FlightTo;
                updateFlight.DepartureDate = flight.DepartureDate;
                _dataContext.Update(updateFlight);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteFlight(string id)
        {
            var deleteFlight = await _dataContext.Flights.FirstOrDefaultAsync(n => n.FlightID == id);
            if(deleteFlight != null)
            {
                _dataContext.Remove(deleteFlight);
                await _dataContext.SaveChangesAsync();
            }
        }

        public bool SaveData(Flight flight)
        {
            _dataContext.Add(flight);
            _dataContext.SaveChanges();
            return true;
        }     
    }
}
