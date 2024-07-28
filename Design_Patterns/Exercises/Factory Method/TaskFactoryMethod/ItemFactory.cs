using System;
namespace TaskFactoryMethod
{
    public abstract class ItemFactory
    {
        // Abstract method that must be implemented by derived classes to create items
        public abstract Item CreateItem(int id);

        // Method to create a random item using an ID between 1 and 3
        public Item CreateRandomItem()
        {
            // Initialize a new Random object
            Random rnd = new Random();

            // Generate a random integer between 1 and 3
            int randomId = rnd.Next(1, 3);

            // Return a new item by calling the CreateItem method with the generated random ID
            return CreateItem(randomId);
        }
    }
}

