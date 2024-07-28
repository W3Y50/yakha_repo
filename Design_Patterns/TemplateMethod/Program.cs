namespace TemplateMethod;

class Program
{
    static void Main(string[] args)
    {
        DeveloperWorkday dev = new DeveloperWorkday();
        dev.CreateWorkday(); // Executes the template method
        Console.ReadKey();
    }
}

//WorkdayPlanner
//ManagerWorkday
//PoliceOfficerWorkday