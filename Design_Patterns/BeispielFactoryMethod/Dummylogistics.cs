//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BeispielFactoryMethod
//{
//    public class Logistics
//    {
//        public Transport ManageTransportForCustomer(string transportType)
//        {
//            Transport transport = null;

//            if (transportType == "street")
//            {
//                transport = new StreetTransport();
//            }
//            else if (transportType == "air")
//            {
//                transport = new FlightTransport();
//            }
//            else if (transportType == "sea")
//            {
//                transport = new SeaTransport()

//            }
//            else
//            {
//                Console.WriteLine("Invalid transport type");
//            }

//            transport?.CollectProductFromCustomer();
//            transport?.TransportProducts();

//            return transport;
//        }
//    }
//}