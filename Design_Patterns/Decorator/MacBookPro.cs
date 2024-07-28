using System;
namespace Decorator
{
    public class MacBookPro : IMacBook
    {
        // Returns the description of the MacBook Pro with standard equipment.
        public string GetDescription()
        {
            return "MacBook Pro with standard equipment"; 
        }

        // Returns the price of the MacBook Pro.
        public double GetPrice()
        {
            return 1199.99;
        }

        // Increases the volume and logs that the volume was increased.
        public void IncreaseVolume()
        {
            Console.WriteLine("The volume has been increased!"); 
        }
    }
}

