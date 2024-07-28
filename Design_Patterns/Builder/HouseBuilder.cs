using System;
namespace Builder
{
    public abstract class HouseBuilder
    {
        public abstract void BuildMaterial();
        public abstract void BuildBasement();
        public abstract void BuildKitchen();
        public abstract void BuildRoof();
        public abstract House GetHouse();
    }
}

