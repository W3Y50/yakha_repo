using System;
namespace StrategyPattern
{
    public class CryptoInvestment : IInvestmentStrategy
    {
        public void Invest(double investMoney)
        {
            Console.WriteLine($"You have invested {investMoney} euros in cryptocurrencies."); 
        }
    }
}

