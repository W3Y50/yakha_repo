namespace AbstractFactory;

class Program
{
    static void Main(string[] args)
    {
        QuadrocopterFactory flyFactory = new FlyFactory();
        ControllerBoard controller = new ControllerBoard(flyFactory);
        Console.ReadKey();
    }
}

