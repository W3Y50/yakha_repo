using System;
namespace Decorator
{
    public class MacBookAir : IMacBook
    {
        // Returns the description of the MacBook Air with standard equipment.
        public string GetDescription()
        {
            return "MacBook Air with standard equipment"; // ""
        }

        // Returns the price of the MacBook Air.
        public double GetPrice()
        {
            return 799.99;
        }

        // Increases the volume and logs that the volume was increased.
        public void IncreaseVolume()
        {
            Console.WriteLine("The volume has been increased!"); // ""
        }
    }
}

