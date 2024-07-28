using System;
namespace StrategyPattern
{
    // Concrete implementation of an investment strategy for gold
    public class GoldInvestment : IInvestmentStrategy
    {
        public void Invest(double investMoney)
        {
            Console.WriteLine($"You have invested {investMoney} euros in gold."); 
        }
    }
}

