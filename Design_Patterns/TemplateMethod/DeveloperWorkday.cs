using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class DeveloperWorkday : WorkdayPlanner
    {
        // Implementation of the developer going to work
        public override void GoToWork()
        {
            Console.WriteLine("Developer goes to the coffe maschine."); // Translation of "Manager fährt ins Büro"
        }

        // Implementation of the developers's work routine
        public override void Work()
        {
            Console.WriteLine("The developer create awesome software!"); // Translation of "Der Manager managed sein Abteil"
        }
    }
}
