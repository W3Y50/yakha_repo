using System;
namespace StrategyPattern
{
    // Concrete implementation of an investment strategy for the stock market
    public class StockMarketInvestment : IInvestmentStrategy
    {
        public void Invest(double investMoney)
        {
            Console.WriteLine($"You have invested {investMoney} euros in the stock market."); 
        }
    }
}
