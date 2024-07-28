using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Regulator
    {
        public double CurrentVoltage { get; set; } // Voltage
        public double CurrentCurrent { get; set; } // Current

        public abstract void IncreaseVoltage();
    }
}
