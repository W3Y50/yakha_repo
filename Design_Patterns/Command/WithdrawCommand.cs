using System;
namespace Command
{
    public class WithdrawCommand : IBankTransactionCommand
    {
        private BankAccount bankAccount;
        private double amount;

        public WithdrawCommand(BankAccount bankAccount, double amount)
        {
            this.bankAccount = bankAccount;
            this.amount = amount;
        }

        public void Execute()
        {
            bankAccount.Withdraw(amount);
        }

        public void Undo()
        {
            //bankAccount.Withdraw(-amount);
        }
    }
}

