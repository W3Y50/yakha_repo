using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Models;

namespace ZooClassLibrary.Interfaces
{
    public interface ILocationRepo
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> GetAnimalById(Guid id);
        Task<IEnumerable<Location>> GetLocationById(Guid id);
        Task<IEnumerable<Location>> SearchLocationByName(string name);

        Task<Location> CreateLocation(Location location);
        Task<Location> UpdateLocation(Guid id);

    }
}
