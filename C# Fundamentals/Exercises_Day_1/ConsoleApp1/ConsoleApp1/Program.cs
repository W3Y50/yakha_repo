using System.Numerics;

namespace syntax
{
    class myFirstCode
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(8+6);
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Your Name is: " + name); //Concatination --> join 2 Strings
            Console.Write("Write");  // Write things without a new line
            Console.WriteLine('H'); //Wirte a char only
            /*
             * 
             * This is a multiline comment
             * 
             */
            int i = 1;
            Console.WriteLine(i++); // add 1 to i = 2
            Console.WriteLine(++i); // adds one an gives 3
            i += 5; // equals i = i + 5
            string txt = "We are the so-called \"Vikings\" from the north...";

            Console.WriteLine("Enter a number: ");
            int myNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The entered number is: " + myNum + 3);
            Console.WriteLine(myNum + 3 + " The entered number was.");



        }

    }

}