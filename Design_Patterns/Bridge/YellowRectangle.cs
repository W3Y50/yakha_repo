using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class YellowRectangle : IDrawAPI
    {
        public void Draw(int x, int y, int width, int height)
        {
            Console.WriteLine($"The yellow rectangle was drawn at position ({x},{y}), with width {width} and height {height}.");
        }
        public void Draw(int x, int y, int radius)
        {
            //null
        }
    }
}
