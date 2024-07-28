using System;
namespace TaskFactoryMethod
{
    public class ConcreteItemFactory : ItemFactory
    {
        public override Item CreateItem(int id)
        {
            Item item = null;

            switch (id)
            {
                case 1:
                    item = new Shield("Fire Shield", 1, 30);
                    break;
                case 2:
                    item = new Hammer("Warhammer", 2, 23);
                    break;
                default:
                    Console.WriteLine("Error creating the item");
                    break;
            }

            return item;
        }
    }
}

