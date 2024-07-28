namespace Facade;

class Program
{
    static void Main(string[] args)
    {
        //// Creating an instance of the airport system and performing operations
        //AirportSystem airport = new AirportSystem();
        //airport.CheckLuggage();
        //airport.TransportLuggageToAirplane();

        //// Creating an instance of the airplane and loading and unloading luggage
        //Airplane plane = new Airplane();
        //plane.PutLuggageIn();
        //plane.PutLuggageOut();

        //// Creating an instance of the local transport company and transporting luggage
        //LocalTransportCompany company = new LocalTransportCompany();
        //company.PutLuggageIntoTruck();
        //company.TransportLuggageToHotel();

        //// Creating an instance of the hotel and transporting luggage to the room
        //Hotel hotel = new Hotel();
        //hotel.TransportLuggageToRoom();

        //// Wait for a key press to close the console window
        //Console.ReadKey();


        FacadeLuggageManagement bookingSystem = new FacadeLuggageManagement();
        bookingSystem.SendLuggage();
        Console.ReadKey();
    }
}

