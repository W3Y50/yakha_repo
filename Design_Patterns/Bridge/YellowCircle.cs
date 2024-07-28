using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class YellowCircle : IDrawAPI
    {
        public void Draw(int x, int y, int width, int height)
        {
            //null
        }
        public void Draw(int x, int y, int radius)
        {
            Console.WriteLine($"The yellow cirlce was drawn at position ({x},{y}), with the radius {radius}.");
        }
    }
}
