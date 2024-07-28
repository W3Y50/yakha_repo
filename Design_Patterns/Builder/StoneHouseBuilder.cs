using System;
namespace Builder
{
    public class StoneHouseBuilder : HouseBuilder
    {
        private House house = new House();

        public override void BuildBasement()
        {
            house.Basement = "Stone cellar with electricity and water lines";
        }

        public override void BuildKitchen()
        {
            house.Kitchen = "Kitchen with fine wooden elements";
        }

        public override void BuildMaterial()
        {
            house.Material = "Stone";
        }

        public override void BuildRoof()
        {
            house.Roof = "Stone roof";
        }

        public override House GetHouse()
        {
            return house;
        }
    }
}

