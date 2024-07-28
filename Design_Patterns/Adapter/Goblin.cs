using System;
namespace Adapter
{
    public class Goblin : IEnemyObject
    {
        public void Attack()
        {
            Console.WriteLine("The Goblin is attacking");
        }

        public void SayHello()
        {
            Console.WriteLine("The Goblin greets you");
        }

        public void Sleep()
        {
            Console.WriteLine("The Goblin is sleeping");
        }
    }

}

