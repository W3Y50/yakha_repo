using System;
namespace Facade
{
	public class Airplane
	{
        public void PutLuggageIn()
        {
            Console.WriteLine("The luggage was loaded onto the airplane.");
        }

        public void PutLuggageOut()
        {
            Console.WriteLine("The luggage was unloaded from the airplane.");
        }
    }
}

