using System;
namespace Command
{
	public interface IBankTransactionCommand
	{
        void Execute();
        void Undo();
    }
}

