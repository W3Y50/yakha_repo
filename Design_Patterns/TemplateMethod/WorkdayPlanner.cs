using System;
namespace TemplateMethod
{
    // Abstract class to define the structure of a typical workday
    public abstract class WorkdayPlanner
    {
        // Template method that outlines the sequence of daily activities
        public void CreateWorkday()
        {
            WakeUp();
            TakeShower();
            Breakfast();
            GoToWork();
            Work();
            Sleep();
        }

        // Abstract method to define going to work
        public abstract void GoToWork();

        // Abstract method to define work activities
        public abstract void Work();


        // Implementations of specific activities, can be customized or expanded upon in child classes
        public void WakeUp()
        {
            Console.WriteLine("Waking up..."); // Translation of "Aufwachen..."
        }

        public void TakeShower()
        {
            Console.WriteLine("Showering..."); // Translation of "Duschen..."
        }

        public void Breakfast()
        {
            Console.WriteLine("Having breakfast..."); // Translation of "Frühstücken..."
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping..."); // Translation of "Schlafen..."
        }

    }

}