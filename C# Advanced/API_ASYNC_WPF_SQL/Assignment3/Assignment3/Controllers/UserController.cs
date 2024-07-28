using ZooClassLibrary.Interfaces;
using ZooClassLibrary.Models;
using Assignment3.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateUser")] //Set User
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var createdUser = await _repository.CreateTask(user);
            return CreatedAtAction(nameof(_repository.GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("GetAllUsers")] //Get all User
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();
            return Ok(users);
        }

    }
}
