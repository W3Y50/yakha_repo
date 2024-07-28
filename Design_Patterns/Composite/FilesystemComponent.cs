using System;
namespace Composite
{
    // Abstract base class for filesystem components
    public abstract class FilesystemComponent
    {
        // Property to get or set the name of the filesystem component
        public string Name { get; set; }

        // Abstract method to print details of the filesystem component
        public abstract void Print();
    }
}

