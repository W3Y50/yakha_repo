using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintsController : Controller
    {
        private readonly IComplaintRepository _repository;

        public ComplaintsController(IComplaintRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Complaint>> CreateComplaint(Complaint complaint)
        {
            var createdComplaint = await _repository.CreateComplaint(complaint);
            return CreatedAtAction(nameof(GetComplaintById), new { id = createdComplaint.Id }, createdComplaint);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Complaint>> UpdateComplaint(int id, Complaint complaint)
        {
            if (id != complaint.Id)
                return BadRequest();

            var updatedComplaint = await _repository.UpdateComplaint(complaint);
            return Ok(updatedComplaint);
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<Complaint>> SetComplaintStatus(int id, ComplaintStatus status)
        {
            var updatedComplaint = await _repository.SetComplaintStatus(id, status);
            return Ok(updatedComplaint);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetAllComplaints()
        {
            var complaints = await _repository.GetAllComplaints();
            return Ok(complaints);
        }

        [HttpGet("getbydate/{date}")]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetComplaintsByDate(DateTime date)
        {
            var complaints = await _repository.GetComplaintsByDate(date);
            return Ok(complaints);
        }

        [HttpGet("searchbyname/{name}")]
        public async Task<ActionResult<IEnumerable<Complaint>>> SearchComplaintsByName(string name)
        {
            var complaints = await _repository.SearchComplaintsByName(name);
            return Ok(complaints);
        }

        [HttpGet("getid/{id}")]
        public async Task<ActionResult<Complaint>> GetComplaintById(int id)
        {
            var complaint = await _repository.GetComplaintById(id);
            if (complaint == null)
                return NotFound();

            return Ok(complaint);
        }

        [HttpPost("CreateFakeCompliant")]
        public async Task<string> CreateFakeCompliant()
        {

            Person pers = new Person();
            pers.Name = "Müller";
            pers.Building = "7";
            pers.Apartment = "3";

            var complaintData = new Complaint();
            
            complaintData.Id = 1;
            complaintData.Description ="aaa";
            complaintData.Location = "bbb";
            complaintData.Category = ComplaintCategory.Parking;
            complaintData.Status = ComplaintStatus.Active;
            complaintData.CreatedAt = DateTime.Now;
            complaintData.UpdatedAt = DateTime.Now;
            complaintData.Complainant = pers;


            var response = await _repository.CreateComplaint(complaintData);

            if (response.Id != null)
            {
                return $"Complaint with ID: {response.Id} was created successfully.";
            }
            else
            {
                return $"Error creating complaint ID: {response.Id}";
            }

        }
        
    }
}
