using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Models;
using ZooClassLibrary.Enums;

namespace ZooClassLibrary.Interfaces
{
    public interface IAnimalRepo
    {
        Task<IEnumerable<Animal>> GetAllAnimals();
        Task<Animal> GetAnimalById(Guid id);
        Task<IEnumerable<Animal>> GetAnimalsByLocation(Location location);
        Task<IEnumerable<Animal>> SearchAnimalsByName(string name);
        Task<IEnumerable<Animal>> SearchAnimalsBySpecies(string name);
        Task<Animal> CreateAnimal(Animal animal);
        Task<Animal> UpdateAnimal(Animal animal);
        Task<Animal> SetAnimalHealth(Guid id, HealthEnum health);

    }
}
