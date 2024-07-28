using System.Collections.Specialized;
using ClassLibrary;

namespace DigitalTwin_Api
{
    public class SeismicEventHandling
    {
        //Implement the event handler
        public void SeismicEvents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Item added: " + e.NewItems[0]);
                    //add to frontend and database from this point
                    // use the sender..
                    // --> input to list / database
                    
                    
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Item removed: " + e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Item replaced: " + e.OldItems[0] + " with " + e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine("Item moved: " + e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("Collection reset");
                    break;
            }
        }
    }
}
