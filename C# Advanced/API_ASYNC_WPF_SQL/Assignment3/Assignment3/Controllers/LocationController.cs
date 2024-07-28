using ZooClassLibrary.Interfaces;
using ZooClassLibrary.Models;
using Assignment3.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepo _repository;
        
        public LocationController(ILocationRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateLocation")] //Set location
        public async Task<ActionResult<Location>> CreateLocation(Location location)
        {
            var createdLocation = await _repository.CreateLocation(location);
            return CreatedAtAction(nameof(_repository.GetLocationById), new { id = createdLocation.Id }, createdLocation);
        }

        [HttpGet("GetAllLocations")] //Get all locations
        public async Task<ActionResult<IEnumerable<Location>>> GetAllAnimals()
        {
            var locations = await _repository.GetAllLocations();
            return Ok(locations);
        }

    }
}
