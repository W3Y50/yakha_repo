using System;
namespace Observer
{
    // Interface for the Observer pattern, specifically for newsletter updates
    public interface INewsletterObserver
    {
        // Method to update the observer with a new newsletter
        void Update(Newsletter newsletter);
    }
}

