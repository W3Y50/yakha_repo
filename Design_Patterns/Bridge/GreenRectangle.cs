using System;
namespace Bridge
{
    public class GreenRectangle : IDrawAPI
    {
        public void Draw(int x, int y, int width, int height)
        {
            Console.WriteLine($"The green rectangle was drawn at position ({x},{y}), with width {width} and height {height}.");
        }
        public void Draw(int x, int y, int radius)
        {
            //null
        }
    }

}

