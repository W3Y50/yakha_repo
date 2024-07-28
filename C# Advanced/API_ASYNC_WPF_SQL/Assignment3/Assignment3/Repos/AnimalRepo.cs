using Assignment3.Intertfaces;
using Assignment3.Models;

namespace Assignment3.Repos
{
    public class AnimalRepo : IZooRepo.IAnimalRepo
    {
        private static List<Animal> _animals = new List<Animal>();
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Compliants;Integrated Security=True";

        // Implementation of repository methods and logic - defined in the IZooRepo
        public Task<IEnumerable<Animal>> GetAllAnimals()
        {

            IEnumerable<Animal> resenum = _animals;
            return Task.FromResult(resenum);
        }
        public Task<Animal> GetAnimalById(Guid id)
        {
            int i = 0;

            foreach (Animal anm in _animals)
            {
                if (anm.Id == _animals[i].Id)
                {
                    return Task.FromResult(_animals[i]);
                }

                i++;
            }

            return null;
        }

        public Task<IEnumerable<Animal>> GetAnimalsByLocation(Location location)
        {
            return null;
        }

        public Task<IEnumerable<Animal>> SearchAnimalsByName(string name)
        {
            List<Animal>anmList = new List<Animal>();
            int i = 0;

            foreach (Animal a in _animals)
            {
                if (a.name == name)
                {
                    anmList.Add(a);
                    IEnumerable<Animal> resenum = anmList;
                    return Task.FromResult(resenum);
                }

                i++;
            }

            return null;
        }

        public Task<IEnumerable<Animal>> SearchAnimalsByArea(string name)
        {
            return null;
        }
        public Task<IEnumerable<Animal>> SearchAnimalsBySpecies(string name)
        {
            return null;
        }

        public Task<Animal> CreateAnimal(Animal animal)
        {
            return null;
        }

        public Task<Animal> UpdateAnimal(Animal animal)
        {
            return null;
        }

        public Task<Animal> SetAnimalHealth(Guid id, HealthEnum health)
        {
            return null;
        }

    }
}
