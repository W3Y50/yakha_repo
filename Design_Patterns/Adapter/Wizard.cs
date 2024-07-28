using System;
namespace Adapter
{
    public class Wizard 
    {
        public void AttackPlayer()
        {
            Console.WriteLine("The Wizard is attacking");
        }

        public void Rest()
        {
            Console.WriteLine("The Wizard is resting");
        }

        public void Communicate()
        {
            Console.WriteLine("The Wizard is communicating");
        }
    }

}

