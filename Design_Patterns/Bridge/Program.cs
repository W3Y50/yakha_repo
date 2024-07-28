namespace Bridge;

class Program
{
    static void Main(string[] args)
    {
        // Creating a rectangle object using a 'GreenRectangle' drawing method.
        Shape greenRectangle = new Rectangle(new GreenRectangle(), 100, 200, 32, 32);

        // Drawing the green rectangle.
        greenRectangle.Draw();


        Shape yellowRectangle = new Rectangle(new YellowRectangle(), 50, 250, 64, 64);

        // Drawing the yellow rectangle.
        yellowRectangle.Draw();

        Shape yellowCircle = new Circle(new YellowCircle(), 50, 250, 64);

        // Drawing the yellow rectangle.
        yellowCircle.Draw();


        // Prevents the console window from closing immediately.
        Console.ReadKey();
    }
}
