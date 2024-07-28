namespace StrategyPattern;

class Program
{
    static void Main(string[] args)
    {
        // Create a new investment with an initial amount of 300.00
        Investment inv = new Investment(300.00);

        // Set the investment strategy to GoldInvestment
        inv.SetInvestmentStrategy(new GoldInvestment());

        // Simulate talking to a bank employee
        inv.TalkToBankEmployee();

        // Make the investment
        inv.MakeInvestment();

        /******/

        // Create a new investment with an initial amount of 150.00
        Investment inv2 = new Investment(150.00);

        // Set the investment strategy to GoldInvestment
        inv2.SetInvestmentStrategy(new OilInvestment());

        // Simulate talking to a bank employee
        inv2.TalkToBankEmployee();

        // Make the investment
        inv2.MakeInvestment();

        /******/

        // Wait for the user to acknowledge the output before closing
        Console.ReadKey();
    }
}

