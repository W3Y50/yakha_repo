using System;

namespace BeispielFactoryMethod
{
    public class SeaStreetFlightLogistics : Logistics
    {
        protected override Transport TransportFactory(string transportType)
        {
            Transport transport = null;

            if (transportType == "street")
            {
                transport = new StreetTransport();
            }
            else if (transportType == "air")
            {
                transport = new FlightTransport();
            }
            else if (transportType == "sea")
            {
                transport = new SeaTransport();
            }
            else
            {
                Console.WriteLine("Invalid transport type");
            }

            return transport;
        }
    }
}
