using System;
namespace Decorator
{
    public class MacBookI5Processor : MacBookAddon
    {
        private IMacBook macBook;

        public MacBookI5Processor(IMacBook macBook) : base(macBook)
        {
            this.macBook = macBook;
        }

        // Enhances the description with an additional note about the i5 processor.
        public override string GetDescription()
        {
            return macBook.GetDescription() + " Additionally, an i5 processor was installed!!"; // ""
        }

        // Adds the cost of the i5 processor to the base price.
        public override double GetPrice()
        {
            return macBook.GetPrice() + 500.00;
        }

        // Delegates the increase volume functionality to the base MacBook.
        public override void IncreaseVolume()
        {
            macBook.IncreaseVolume();
            Console.WriteLine("The volume was increased!");
        }
    }
}

