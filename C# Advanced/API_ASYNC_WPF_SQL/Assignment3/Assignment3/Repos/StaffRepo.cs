using Assignment3.Intertfaces;
using Assignment3.Models;

namespace Assignment3.Repos
{
    public class StaffRepo : IZooRepo.IStaffRepo
    {
        // Implementation of repository methods and logic - defined in the IZooRepo

        public Task<Staff> CreateStaffMember(Staff staff)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllStaffMembers()
        {
            throw new NotImplementedException();
        }

        public Task<Staff> GetStaffMemberById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetStaffMemberByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> SearchStaffMemberByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> UpdateStaffMember(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
