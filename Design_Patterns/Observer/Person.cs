using System;
namespace Observer
{
    // Class Person acts as an observer for the newsletter
    public class Person : INewsletterObserver
    {
        private string name;
        private Newsletter currentNewsletter;

        // Constructor to initialize a person with a name
        public Person(string name)
        {
            this.name = name;
        }

        // Method that updates the observer with the new newsletter
        public void Update(Newsletter newsletter)
        {
            currentNewsletter = newsletter;
            Console.WriteLine(name + " has received the new newsletter on the topic '" + currentNewsletter.Topic);
        }
    }
}

