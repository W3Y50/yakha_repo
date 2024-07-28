namespace BeispielFactoryMethod;

class Program
{
    static void Main(string[] args)
    {
        Logistics logisticsSoftware = new SeaStreetFlightLogistics();
        Transport kundenTransport = logisticsSoftware.ManageTransportForCustomer("air"); // Add a transport type as an argument
        Console.ReadKey();
    }
}

