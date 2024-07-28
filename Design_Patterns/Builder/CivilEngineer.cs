using System;
namespace Builder
{
    public class CivilEngineer
    {
        // Private Variable
        private HouseBuilder builder;

        // Konstruktor (Constructor)
        public CivilEngineer(HouseBuilder builder)
        {
            this.builder = builder; // Assigns the builder object passed to the constructor
        }

        // Methode (Method) to construct the entire house
        public void ConstructHouse()
        {
            builder.BuildBasement(); // Constructs the basement
            builder.BuildMaterial(); // Selects and uses the building materials
            builder.BuildKitchen(); // Constructs the kitchen
            builder.BuildRoof(); // Adds the roof
        }

        // Methode (Method) to retrieve the finished house
        public House GetHouse()
        {
            return builder.GetHouse(); // Returns the finished house
        }
    }
}

