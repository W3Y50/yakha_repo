namespace Adapter;

class Program
{
    static void Main(string[] args)
    {
        IEnemyObject goblin = new Goblin();
        //goblin.Attack();
        //goblin.SayHello();
        //goblin.Sleep();
        //Console.ReadKey();

        Wizard wizard = new Wizard();
        IEnemyObject adapterWizard = new AdapterWizard(wizard);

        adapterWizard.Attack();
        adapterWizard.Sleep();
        adapterWizard.SayHello();

        Console.ReadKey();
    }
}

