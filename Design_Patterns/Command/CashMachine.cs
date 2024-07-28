using System;
namespace Command
{
	public class CashMachine
	{
        public void ExecuteBankTransaction(IBankTransactionCommand command)
        {
            command.Execute();
        }
        public void UndoBankTransaction(IBankTransactionCommand command)
        {
            command.Undo();
        }
    }
}

