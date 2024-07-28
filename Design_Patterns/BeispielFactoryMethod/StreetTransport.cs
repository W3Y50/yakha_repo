using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielFactoryMethod
{
    public class StreetTransport : Transport
    {
        public override void TransportProducts()
        {
            Console.WriteLine("The products are transported via the road.");
        }
    }
}
