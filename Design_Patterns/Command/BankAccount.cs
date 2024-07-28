using System;
namespace Command
{
    public class BankAccount
    {
        public double Balance { get; set; } = 0;
        public double OverdraftLimit { get; set; } = 1000;

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount} Euros have been deposited into the account.");
            Console.WriteLine($"The new balance is {Balance} Euros.");
        }

        public void Undo(double amount)
        {
            Balance -= amount;
            Console.WriteLine($"{amount} Euros have been undo deposited in the account.");
            Console.WriteLine($"The new balance is {Balance} Euros.");
        }

        public void Withdraw(double amount)
        {
            Console.WriteLine("Your actual balance is: " + Balance);

            if (Balance < amount) 
            {
                Console.WriteLine($"You have not enough money to withdrawn: {amount}");
            }
            else { 
                Balance -= amount;
                Console.WriteLine($"{amount} Euros have been withdrawn from the account. The new balance is {Balance} Euros.");
            }
        }

        public override string ToString()
        {
            return $"Account balance: {Balance} Euros, Overdraft limit: {OverdraftLimit} Euros";
        }
    }
}

