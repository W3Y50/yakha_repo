using System;
namespace TaskFactoryMethod
{
    public class Shield : Item
    {
        public int DefenseValue { get; set; }  // Property to hold the defense value of the shield

        // Constructor to initialize the Shield with name, id, and defense value
        public Shield(string name, int id, int defenseValue) : base(name, id)
        {
            DefenseValue = defenseValue;
        }

        // Method to use the shield which prints its name and defense value
        public override void UseItem()
        {
            Console.WriteLine("The shield with the name " + Name + " has a defense value of " + DefenseValue + " points.");
        }
    }
}

