using System;
namespace Observer
{
    // Abstract class for managing newsletter subscribers and notifications
    public abstract class NewsletterSubject
    {
        // List to hold all the observers subscribing to the newsletter
        private List<INewsletterObserver> observers = new List<INewsletterObserver>();

        // Method to add an observer to the subscription list
        public void Subscribe(INewsletterObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        // Method to remove an observer from the subscription list
        public void Unsubscribe(INewsletterObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        // Method to notify all subscribers about a new newsletter
        public void SendNewsletter(Newsletter newNewsletter)
        {
            foreach (INewsletterObserver o in observers)
            {
                o.Update(newNewsletter);
            }
        }
    }
}

