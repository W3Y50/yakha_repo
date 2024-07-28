using Assignment3.Intertfaces;
using Assignment3.Models;

namespace Assignment3.Repos
{
    public class TasksRepo : IZooRepo.ITasksRepo
    {
        // Implementation of repository methods and logic - defined in the IZooRepo

        public Task<Tasks> CreateTask(Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tasks>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> GetTasksById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tasks>> GetTasksByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tasks>> SearchByStaffMemberName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> UpdateTask(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
