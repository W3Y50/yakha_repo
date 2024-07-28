using System;
namespace TemplateMethod
{
    public class ManagerWorkday : WorkdayPlanner
    {
        // Implementation of the manager going to work
        public override void GoToWork()
        {
            Console.WriteLine("Manager drives to the office"); // Translation of "Manager fährt ins Büro"
        }

        // Implementation of the manager's work routine
        public override void Work()
        {
            Console.WriteLine("The manager manages his department"); // Translation of "Der Manager managed sein Abteil"
        }
    }
}

