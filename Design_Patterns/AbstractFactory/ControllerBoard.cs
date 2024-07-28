using System;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class ControllerBoard
    {
        // Properties
        public Regulator MyRegulator { get; set; }
        public Engine MyEngine { get; set; }
        public QuadrocopterFactory UsedFactory { get; set; }

        // Constructor
        public ControllerBoard(QuadrocopterFactory usedFactory)
        {
            UsedFactory = usedFactory;
            CreateParts();
        }

        // Method to create parts
        public void CreateParts()
        {
            MyRegulator = UsedFactory.CreateRegulator();
            MyEngine = UsedFactory.CreateEngine();
        }
    }
}
