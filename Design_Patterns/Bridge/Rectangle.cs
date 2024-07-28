using System;
namespace Bridge
{
    public class Rectangle : Shape
    {
        // Private member variables for the dimensions of the rectangle
        private int x;
        private int y;
        private int width;
        private int height;

        // Constructor: Initializes a new rectangle specifying an API for drawing and dimensions
        public Rectangle(IDrawAPI drawAPI, int x, int y, int width, int height)
            : base(drawAPI)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        // Overridden method from abstract class Shape; it calls the Draw method of the drawing API
        public override void Draw()
        {
            drawAPI.Draw(x, y, width, height);
        }
    }
}

