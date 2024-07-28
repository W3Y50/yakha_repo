using System;
using StrategyPattern;

public class Investment
{
    private double investmentMoney;
    private bool talkedToBankEmployee = false;
    private IInvestmentStrategy investmentStrategy;

    // Constructor initializes the investment with a specific amount of money
    public Investment(double investmentMoney)
    {
        this.investmentMoney = investmentMoney;
    }

    // Method to set the investment strategy
    public void SetInvestmentStrategy(IInvestmentStrategy strategy)
    {
        this.investmentStrategy = strategy;
        Console.WriteLine("The strategy has been changed"); // Translation of "Die Strategie wurde geändert"
    }

    // Method to execute the investment if conditions are met
    public void MakeInvestment()
    {
        if (investmentStrategy != null && talkedToBankEmployee)
        {
            investmentStrategy.Invest(investmentMoney);
        }
        else
        {
            Console.WriteLine("The criteria for an investment have not yet been met"); // Translation of "Die Kriterien für ein Investment wurden noch nicht erfüllt"
        }
    }

    // Method to simulate talking to a bank employee
    public void TalkToBankEmployee()
    {
        talkedToBankEmployee = true;
    }
}
