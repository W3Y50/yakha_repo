using System;
namespace TemplateMethod
{
    public class PoliceOfficerWorkday : WorkdayPlanner
    {
        // Implementation of the police officer going to work
        public override void GoToWork()
        {
            Console.WriteLine("Police officer goes to the station"); // Translation of "Polizist fährt zur Wache"
        }

        // Implementation of the police officer's work routine
        public override void Work()
        {
            Console.WriteLine("The police officer protects the citizens"); // Translation of "Polizist beschützt die Bürger"
        }
    }
}

