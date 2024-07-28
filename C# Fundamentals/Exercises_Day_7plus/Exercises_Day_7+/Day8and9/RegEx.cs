using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Exercises_Day_7_.Day8
{
    internal class RegExThings
    {

        public bool RegExIsMatched(string regstring) 
        {
            string pattern = @"^\d{2}-[A-Z]{3}-\d{4}$";
            Regex rg = new Regex(pattern);
            Console.WriteLine(rg.IsMatch(regstring) + " / " + regstring);
            return rg.IsMatch(regstring);
        
        }
    }
}
