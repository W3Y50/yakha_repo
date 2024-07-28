using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class QuadroFactory : QuadrocopterFactory
    {
        public override Engine CreateEngine()
        {
            return new QuadroEngine();
        }

        public override Regulator CreateRegulator()
        {
            return new QuadroRegulator();
        }
    }
}
