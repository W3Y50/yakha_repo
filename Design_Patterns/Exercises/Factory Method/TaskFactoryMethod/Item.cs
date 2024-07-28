using System;
namespace TaskFactoryMethod
{
    public abstract class Item
    {
        public string Name { get; set; }  // Property to get or set the name of the item.
        public int Id { get; set; }       // Property to get or set the ID of the item.

        public Item(string name, int id)
        {
            Name = name;  // Assign the provided name to the Name property.
            Id = id;      // Assign the provided ID to the Id property.
        }

        public abstract void UseItem();  // Abstract method, must be implemented by derived classes to specify how the item is used.
    }
}

