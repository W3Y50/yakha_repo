using System;
namespace Builder
{
    public class WoodHouseBuilder : HouseBuilder
    {
        private House house = new House();

        public override void BuildBasement()
        {
            house.Basement = "Stone basement with electrical and water installations";
        }

        public override void BuildKitchen()
        {
            house.Kitchen = "Kitchen with fine wooden elements";
        }

        public override void BuildMaterial()
        {
            house.Material = "Wood";
        }

        public override void BuildRoof()
        {
            house.Roof = "Wooden roof";
        }

        public override House GetHouse() //the house in line 6
        {
            return house;
        }
    }
}

