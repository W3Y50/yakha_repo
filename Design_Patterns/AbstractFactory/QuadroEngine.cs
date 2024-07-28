using System;

namespace AbstractFactory
{
    public class QuadroEngine : Engine
    {
        public QuadroEngine()
        {
            Console.WriteLine("The QuadroEngine has been created.");
        }

        public override void RevCounter()
        {
            Console.WriteLine("The RPM is 100 revolutions per minute.");
        }
    }
}
