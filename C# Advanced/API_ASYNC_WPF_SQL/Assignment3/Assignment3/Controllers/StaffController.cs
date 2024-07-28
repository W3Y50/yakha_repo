using ZooClassLibrary.Interfaces;
using ZooClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepo _repository;

        public StaffController(IStaffRepo repository)
        {
            _repository = repository;
         }

        [HttpPost("CreateStaffMember")] //Set staffmember
        public async Task<ActionResult<Staff>> CreateStaffMember(Staff staff)
        {
            var createdStaffMember = await _repository.CreateStaffMember(staff);
            return CreatedAtAction(nameof(_repository.GetStaffMemberById), new { id = createdStaffMember.Id }, createdStaffMember);
        }

        [HttpGet("GetAllStaffmembers")] //Get all staffmembers
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaffMembers()
        {
            var staffMembers = await _repository.GetAllStaffMembers();
            return Ok(staffMembers);
        }

    }
}
