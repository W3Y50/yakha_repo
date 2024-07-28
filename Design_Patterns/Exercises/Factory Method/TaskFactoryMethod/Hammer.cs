using System;
namespace TaskFactoryMethod
{
    public class Hammer : Item
    {
        public int AttackValue { get; set; }

        public Hammer(string name, int id, int attackValue) : base(name, id)
        {
            AttackValue = attackValue;
        }

        public override void UseItem()
        {
            Console.WriteLine("The hammer with the name " + this.Name + " has an attack value of " + this.AttackValue);
        }
    }
}

