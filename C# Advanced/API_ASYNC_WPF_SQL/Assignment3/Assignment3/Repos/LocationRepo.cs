using Assignment3.Intertfaces;
using Assignment3.Models;

namespace Assignment3.Repos
{
    public class LocationRepoIZooRepo : IZooRepo.ILocationRepo
    {
        // Implementation of repository methods and logic - defined in the IZooRepo

        public Task<Location> CreateLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Location>> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetAnimalById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Location>> GetLocationById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Location>> SearchLocationByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Location> UpdateLocation(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
