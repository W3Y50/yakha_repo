using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Circle : Shape
    {
        // Private member variables for the dimensions of the circle
        private int x;
        private int y;
        private int radius;
        
        // Constructor: Initializes a new circle specifying an API for drawing and dimensions
        public Circle(IDrawAPI drawAPI, int x, int y, int radius)
            : base(drawAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;            


            // Create a Graphics object to draw on the form
            //Graphics g = this.CreateGraphics();


            // Draw the circle
            //g.DrawEllipse(Pens.Blue, x - radius, y - radius, radius * 2, radius * 2);
        }

        // Overridden method from abstract class Shape; it calls the Draw method of the drawing API
        public override void Draw()
        {
            drawAPI.Draw(x, y, radius);
        }
    }
}
