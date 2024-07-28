using System;

namespace AbstractFactory
{
    public abstract class Engine
    {
        public double EngineSpeed { get; set; } // RPM

        public abstract void RevCounter();
    }
}
