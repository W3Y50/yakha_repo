using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Day_7_.Day10
{
    internal class PlayAround
    {

        /*
        In a small town the population is p0 = 1000 at the beginning of a year. The population regularly increases by 2 percent per year and moreover 50 new inhabitants per year come to live in the town. How many years does the town need to see its population greater than or equal to p = 1200 inhabitants?

        At the end of the first year there will be: 
        1000 + 1000 * 0.02 + 50 => 1070 inhabitants

        At the end of the 2nd year there will be: 
        1070 + 1070 * 0.02 + 50 => 1141 inhabitants (** number of inhabitants is an integer **)

        At the end of the 3rd year there will be:
        1141 + 1141 * 0.02 + 50 => 1213

        It will need 3 entire years.
        */
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int n = 0;
            double p1 = (double)p0;
            Console.WriteLine(p);

            while (p1 < p)
            {
                p1 = Math.Floor(p1 + (p1 * (percent / 100)) + aug);
                Console.WriteLine(p1);
                n++;
            }

            Console.WriteLine(n);
            return n;
        }


    }
}


/*
 
 
 
[Test]
    public static void test1() {
        Console.WriteLine("Testing NbYear");
        testing(Arge.NbYear(1500, 5, 100, 5000),15);
        testing(Arge.NbYear(1500000, 2.5, 10000, 2000000), 10);
        testing(Arge.NbYear(1500000, 0.25, 1000, 2000000), 94);
    }

 
 */