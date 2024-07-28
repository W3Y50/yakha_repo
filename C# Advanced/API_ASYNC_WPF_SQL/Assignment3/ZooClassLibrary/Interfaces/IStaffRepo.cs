using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Models;

namespace ZooClassLibrary.Interfaces
{
    public interface IStaffRepo
    {
        Task<IEnumerable<Staff>> GetAllStaffMembers();
        Task<Staff> GetStaffMemberById(Guid id);
        Task<IEnumerable<Staff>> GetStaffMemberByLocation(Location location);
        Task<IEnumerable<Staff>> SearchStaffMemberByName(string name);
        Task<Staff> CreateStaffMember(Staff staff);
        Task<Staff> UpdateStaffMember(Guid id);
    }
}
