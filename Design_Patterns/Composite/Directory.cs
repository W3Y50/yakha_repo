using System;
using System.Xml.Linq;

namespace Composite
{
    /// <summary>
    /// Represents a directory in a file system which can contain other directories or files.
    /// </summary>
    public class Directory : FilesystemComponent
    {
        // Holds a list of file system components (files or other directories).
        private List<FilesystemComponent> includedFiles = new List<FilesystemComponent>();

        /// <summary>
        /// Constructor to create a directory with a specific name.
        /// </summary>
        /// <param //name="//name">The name of the directory.</param>
        public Directory(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Prints the details of the directory and recursively prints the contents.
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("Directory: " + Name);
            // Recursively print each component contained in the directory.
            foreach (FilesystemComponent component in includedFiles)
            {
                component.Print();
            }
        }

        /// <summary>
        /// Adds a new file system component (file or directory) to the directory.
        /// </summary>
        /// <param //name="component">The file system component to add.</param>
        public void Add(FilesystemComponent component)
        {
            includedFiles.Add(component);
        }

        /// <summary>
        /// Removes a file system component from the directory.
        /// </summary>
        /// <param //name="component">The component to remove.</param>
        public void Remove(FilesystemComponent component)
        {
            includedFiles.Remove(component);
        }

        /// <summary>
        /// Retrieves a specific file system component by its index in the list.
        /// </summary>
        /// <param //name="index">The index of the component to retrieve.</param>
        /// <returns>The requested file system component.</returns>
        public FilesystemComponent GetFilesystemComponent(int index)
        {
            return includedFiles[index];
        }
    }

}

