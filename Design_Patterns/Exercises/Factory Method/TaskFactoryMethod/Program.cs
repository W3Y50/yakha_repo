namespace TaskFactoryMethod;

class Program
{
    static void Main(string[] args)
    {
        // Create a new factory instance for creating items
        ConcreteItemFactory factory = new ConcreteItemFactory();

        // Use the factory to create a random item
        Item item = factory.CreateRandomItem();

        // Use the created item
        item.UseItem();

        // Wait for a key press before closing the console window
        Console.ReadKey();
    }
}

