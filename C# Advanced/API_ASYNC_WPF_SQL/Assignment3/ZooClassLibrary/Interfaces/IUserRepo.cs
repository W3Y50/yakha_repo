using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Models;

namespace ZooClassLibrary.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUserByLocation(Location location);
        Task<IEnumerable<User>> SearchByUserName(string name);
        Task<User> CreateTask(User user);
        Task<User> UpdateTask(Guid id1);
    }
}
