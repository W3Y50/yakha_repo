using System.Threading.Channels;

namespace Iterator;

class Program
{
    static void Main(string[] args)
    {
        IChannelCollection radio = new CarRadio();
        radio.AddChannel(new Channel("FlyloFM", 106.4));
        radio.AddChannel(new Channel("Channel X", 103.1));
        radio.AddChannel(new Channel("The lab", 101.1));
        radio.AddChannel(new Channel("Jump Radio", 105.1));
        radio.AddChannel(new Channel("Radio Energy", 101.1));

        IChannelIterator iterator = radio.CreateIterator(); //here we iterate through the car radio list without even to know how they are programmed or saved are 

        while (iterator.HasNext())
        {
            Channel c = iterator.Next();
            Console.WriteLine(c);
        }

        Console.WriteLine("-------------------------");
        Channel crand = iterator.RandomShuffel();
        Console.WriteLine("Randomshuffle is: " + crand);


        Console.ReadKey();
    }
}

//IChannelIterator->IChannelCollection->Channel->

