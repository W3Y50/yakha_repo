using System;
using System.Xml.Linq;

namespace Composite
{
    public class File : FilesystemComponent
    {
        public string Owner { get; set; }  // Property to get or set the owner of the file.

        public File(string name, string owner)
        {
            this.Name = name;  // Assign the name of the file to the Name property.
            this.Owner = owner;  // Assign the owner of the file to the Owner property.
        }

        public override void Print()
        {
            // Output the details of the file including its name and owner.
            Console.WriteLine("Filename: {0} Owner: {1}", Name, Owner);
        }
    }
}

