using System.Text;

namespace AbstractFactory
{
    public class FlyFactory : QuadrocopterFactory
    {
        public override Engine CreateEngine()
        {
            return new FlyEngine();
        }

        public override Regulator CreateRegulator()
        {
            return new FlyRegulator();
        }
    }
}
