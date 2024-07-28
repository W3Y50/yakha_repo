using System;

namespace AbstractFactory
{
    public class FlyRegulator : Regulator
    {
        public FlyRegulator()
        {
            Console.WriteLine("The FlyRegulator has been created.");
        }

        public override void IncreaseVoltage()
        {
            Console.WriteLine("The voltage has been increased by 10V.");
        }
    }
}
