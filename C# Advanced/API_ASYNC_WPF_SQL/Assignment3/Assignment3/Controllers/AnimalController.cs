using Microsoft.AspNetCore.Mvc;
using ZooClassLibrary.Models;
using ZooClassLibrary.Interfaces;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _repository;

        public AnimalController(IAnimalRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateAnimal")] //Set animal
        public async Task<ActionResult<Animal>> CreateAnimal(Animal animal)
        {
            var createdAnimal = await _repository.CreateAnimal(animal);
            return CreatedAtAction(nameof(_repository.GetAnimalById), new { id = createdAnimal.Id }, createdAnimal);
        }

        [HttpGet("GetAllAnimals")] //Get all animals
        public async Task<ActionResult<IEnumerable<Animal>>> GetAllAnimals()
        {
            var animals = await _repository.GetAllAnimals();
            return Ok(animals);
        }

        [HttpGet("GetAnimalByLocation")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalByLocation(Location loc)
        {
            var animals = await _repository.GetAnimalsByLocation(loc);
            return Ok(animals);
        }
    }
}
