using System;
namespace Observer
{
    public class SportNewsletter : NewsletterSubject
    {
        private Newsletter currentNewsletter;

        public SportNewsletter(Newsletter newsletter) //constructor so the sportnewsletter can be created in main
        {
            this.currentNewsletter = newsletter;
        }
        // Method to retrieve the current newsletter
        public Newsletter GetNewsletter()
        {
            return currentNewsletter;
        }

        // Method to set a new newsletter and notify all observers (when it changes)
        public void SetNewsletter(Newsletter newNewsletter)
        {
            currentNewsletter = newNewsletter;
            Console.WriteLine("A Newsletter has been published: " + currentNewsletter.Topic);
            SendNewsletter(currentNewsletter);
        }
    }
}

