using ZooClassLibrary.Interfaces;
using ZooClassLibrary.Models;
using Assignment3.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepo _repository;

        public TasksController(ITasksRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateTask")] //Set tasks
        public async Task<ActionResult<Tasks>> CreateTasks(Tasks tasks)
        {
            var createdTask= await _repository.CreateTask(tasks);
            return CreatedAtAction(nameof(_repository.GetTasksById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet("GetAllTasks")] //Get all tasks
        public async Task<ActionResult<IEnumerable<Tasks>>> GetAllTasks()
        {
            var tasks= await _repository.GetAllTasks();
            return Ok(tasks);
        }

    }
}
