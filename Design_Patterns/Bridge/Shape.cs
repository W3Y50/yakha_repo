using System;
namespace Bridge
{
    public abstract class Shape
    {
        // Protected member to hold the reference to the implementor interface.
        protected IDrawAPI drawAPI;

        // Constructor to initialize the Shape with a specific drawing API.
        // This allows the drawing behavior to be configured at runtime,
        // adhering to the Bridge pattern's intent to decouple abstraction from implementation.
        public Shape(IDrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }

        // Abstract method 'Draw' that must be implemented by concrete shapes.
        // This method will be used to draw the shape using the drawing API provided.
        public abstract void Draw();
    }
}

