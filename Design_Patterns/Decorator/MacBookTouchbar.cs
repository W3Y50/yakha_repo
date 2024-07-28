using System;
namespace Decorator
{
    public class MacBookTouchbar : MacBookAddon
    {
        private IMacBook macBook;

        public MacBookTouchbar(IMacBook macBook) : base(macBook)
        {
            this.macBook = macBook;
        }

        // Returns the description of the MacBook along with the added touch bar information.
        public override string GetDescription()
        {
            return macBook.GetDescription() + " Additionally, a touch bar was installed!"; // German: "Zusätzlich wurde eine Touchbar verbaut!"
        }

        // Returns the price of the MacBook plus the additional cost for the touch bar.
        public override double GetPrice()
        {
            return macBook.GetPrice() + 400.00;
        }

        // Outputs a message about the volume increase, noting the use of the touch bar.
        public override void IncreaseVolume()
        {
            macBook.IncreaseVolume();
            Console.WriteLine("The volume was increased with the help of the touch bar!"); // German: "Die Lautstärke wurde mithilfe der Touchbar erhöht!"
        }
    }
}

