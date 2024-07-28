using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Day_7_.Day8
{
    public delegate void DoSomething();  // delegate

    public class ProceedtheLogic
    {
        public event DoSomething ProcessCompleted; // event

        public void StartProceeding()
        {
            Console.WriteLine("Process Started!");
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine("please wait. " + i + " second...");
                i++;
            }
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke();
        }
    }

    public static class Button
    {
        // Define a delegate type for the event
        public delegate void ClickEventHandler();

        // Define the event using the delegate type
        public static event ClickEventHandler Click;

        // Method to simulate a button click
        public static void SimulateClick()
        {
            Console.WriteLine("Button clicked");
            OnClick();
        }

        // Method to raise the event
        private static void OnClick()
        {
            // Check if there are any subscribers to the event
            Click?.Invoke();
        }
    }

    public static class EventHandlerExample
    {
        // Event handler method
        public static void ButtonClickHandler()
        {
            Console.WriteLine("Button click event handled");
        }
    }

}
