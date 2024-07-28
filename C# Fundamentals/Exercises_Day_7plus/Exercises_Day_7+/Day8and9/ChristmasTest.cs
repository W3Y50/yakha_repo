using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/*
 Santa is handing out gifts in the kindergarten. Many toddlers are around there and everyone should have the opportunity to have a seat on Santa's lap. But there's Peter, a 5 year old boy, who is a bit naughty. He tries to get two gifts. After he got the first one, he lines up again in the queue of children.

But fortunately Santa is not alone. His elves keep a list with the names of the children, which already were on Santa's lap. We know, that each child name is unique. If a child tries to get a second gift, the elves will tell Santa.

OK, let's help Santa and his elves with a simple function handOutGift() (hand_out_gift in Ruby/Python, HandOutGift in C# ) which takes the name of the next child. If this child already got a gift, it must throw an error in order to remind Santa.
 
 */


namespace Exercises_Day_7_.Day8
{
    internal class ChristmasTest
    {
        static List<string> names = new List<string>();

        public static void HandOutGift(string name)
        {

            if (names.Contains(name) == true)
            {
                Console.WriteLine("'" + name + "' must throw an error!");
                //throw new ArgumentException("!", "!");

            }
            Console.WriteLine("'" + name + "' must not throw an error!");
            names.Add(name);
        }

        public static string HighAndLow(string numbers) //find the highest and lowest number in a string
        {

            List<int> numberList = new List<int>();
            MatchCollection matches = Regex.Matches(numbers, @"-?\d+");


            foreach (Match match in matches)
            {
                numberList.Add(int.Parse(match.Value));
                //Console.WriteLine(match.Value);
            }

            numberList.Sort();

            int firstElement = numberList[0];
            int lastElement = numberList[numberList.Count - 1];

            return lastElement.ToString() + " " + firstElement.ToString(); ;

        }
    }

}

