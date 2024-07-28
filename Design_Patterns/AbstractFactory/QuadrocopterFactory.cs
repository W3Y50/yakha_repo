using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class QuadrocopterFactory
    {
        // Abstract methods to be implemented by concrete factories
        public abstract Engine CreateEngine();
        public abstract Regulator CreateRegulator();
    }
}
