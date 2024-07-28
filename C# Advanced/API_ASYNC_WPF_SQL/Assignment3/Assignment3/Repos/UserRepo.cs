using Assignment3.Intertfaces;
using Assignment3.Models;

namespace Assignment3.Repos
{
    public class UserRepo : IZooRepo.IUserRepo
    {
        // Implementation of repository methods and logic - defined in the IZooRepo

        public Task<User> CreateTask(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUserByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchByUserName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateTask(Guid id1)
        {
            throw new NotImplementedException();
        }
    }
}
