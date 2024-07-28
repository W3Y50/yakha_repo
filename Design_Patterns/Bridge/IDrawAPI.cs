using System;
namespace Bridge
{
    // This interface defines a drawing API that abstracts the details of drawing operations.
    public interface IDrawAPI
    {
        // Method to draw an object on the screen.
        // x and y specify the starting coordinates, and width and height define the dimensions of the drawable object.
        void Draw(int x, int y, int width, int height);
        void Draw(int x, int y, int radius);
    }
}

