using FlightDocs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepo _flightRepo;

        public FlightController(IFlightRepo flightRepo)
        {
            _flightRepo = flightRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlight()
        {
            var getFlight = await _flightRepo.GetAllFlight();
            return Ok(getFlight);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFlightById(string id)
        {
            var getFlightByID = await _flightRepo.GetFlightById(id);
            return Ok(getFlightByID);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewFlight(FlightCreate flight)
        {
            await _flightRepo.CreateFlight(flight);
            return Ok("New flight has been created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlight(FlightRead flight, string id)
        {
            if(flight.FlightID != id)
            {
                return BadRequest("Not found flight id");
            }
            else
            {
                await _flightRepo.UpdateFlight(flight, id);
                return Ok("Flight has been updated successfully.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlight(string id)
        {
            var getFlightID = await _flightRepo.GetFlightById(id);
            if(getFlightID == null)
            {
                return BadRequest("Flight id is not exist.");
            }
            else
            {
                await _flightRepo.DeleteFlight(id);
                return Ok("Flight has been deleted successfully.");
            }
        }
    }
}
