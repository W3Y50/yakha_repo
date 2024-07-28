using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Models;

namespace ZooClassLibrary.Interfaces
{
    public interface ITasksRepo
    {
        Task<IEnumerable<Tasks>> GetAllTasks();
        Task<Tasks> GetTasksById(Guid id);
        Task<IEnumerable<Tasks>> GetTasksByLocation(Location location);
        Task<IEnumerable<Tasks>> SearchByStaffMemberName(string name);
        Task<Tasks> CreateTask(Tasks task);
        Task<Tasks> UpdateTask(Guid id);
    }
}
