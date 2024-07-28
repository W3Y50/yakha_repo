namespace WebApplication1.Models
{

    public interface IComplaintRepository
    {
        Task<IEnumerable<Complaint>> GetAllComplaints();
        Task<Complaint> GetComplaintById(int id);
        Task<IEnumerable<Complaint>> GetComplaintsByDate(DateTime date);
        Task<IEnumerable<Complaint>> SearchComplaintsByName(string name);
        Task<Complaint> CreateComplaint(Complaint complaint);
        Task<Complaint> UpdateComplaint(Complaint complaint);
        Task<Complaint> SetComplaintStatus(int id, ComplaintStatus status);
    }

    public class Complaint
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ComplaintCategory Category { get; set; }
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Person Complainant { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
    }

    public enum ComplaintCategory
    {
       Animals,
       Children,
       Maintenance,
       Parking
    }

    public enum ComplaintStatus
    {
       Pending,
       Active,
       Resolved,
       Cancelled
    }

}
