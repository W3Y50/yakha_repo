using System;
namespace Singelton
{
    public class BasicSingleton
    {
        // Static variable that holds a single instance of the class
        private static readonly BasicSingleton instance = new BasicSingleton();

        // Private constructor prevents any other class from instantiating
        private BasicSingleton()
        {
            Console.WriteLine("The Singleton has been created!");
        }

        // Public static means of getting the instance of the Singleton
        public static BasicSingleton GetInstance()
        {
            return instance;
        }
    }
}

