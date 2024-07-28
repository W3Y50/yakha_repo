using System;

namespace AbstractFactory
{
    public class FlyEngine : Engine
    {
        public FlyEngine()
        {
            Console.WriteLine("The FlyEngine has been created.");
        }

        public override void RevCounter()
        {
            Console.WriteLine("The RPM is 300 revolutions per minute.");
        }
    }
}
