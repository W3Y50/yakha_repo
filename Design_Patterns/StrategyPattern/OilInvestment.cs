using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    // Concrete implementation of an investment strategy for oil
    public class OilInvestment : IInvestmentStrategy
    {
        public void Invest(double investMoney)
        {
            Console.WriteLine($"You have invested {investMoney} euros in oil.");
        }
    }
}
