using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MacBookI4Processor : MacBookAddon
    {
        private IMacBook macBook;

        public MacBookI4Processor(IMacBook macBook) : base(macBook)
        {
            this.macBook = macBook;
        }

        // Enhances the description with an additional note about the i5 processor.
        public override string GetDescription()
        {
            return macBook.GetDescription() + " Additionally, an i4 processor was installed!!"; // ""
        }

        // Adds the cost of the i5 processor to the base price.
        public override double GetPrice()
        {
            return macBook.GetPrice() + 410.00;
        }

        // Delegates the increase volume functionality to the base MacBook.
        public override void IncreaseVolume()
        {
            macBook.IncreaseVolume();
            Console.WriteLine("The volume was increased!");
        }
    }
}
