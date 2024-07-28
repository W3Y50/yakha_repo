using System;

namespace BeispielFactoryMethod
{
    public abstract class Transport
    {
        // Properties
        public string Customer { get; set; }
        public string Destination { get; set; }

        // Methods
        public void CollectProductFromCustomer()
        {
            Console.WriteLine("The products are being picked up!");
        }

        public abstract void TransportProducts();
    }
}


