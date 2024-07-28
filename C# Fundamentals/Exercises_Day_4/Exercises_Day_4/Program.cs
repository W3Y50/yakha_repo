using System.Collections;
using System.Threading;

class IfElse 
{
    public bool checkStatus1020(int number) //check if is the number between 10 and 20
    { 
        if (number == 1)
        {
            Console.WriteLine("The Status is 1!");
        }
        else if (number > 1 && number <=10)
        {
            Console.WriteLine("The Status is > 2 and <= 10!");
        }
        else if (number > 10 && number <= 20)
        {
            Console.WriteLine("The Status is > 10 and <= 20!");
            return true;
        }
        else 
        {
            //nested if - you can skip the {} when you have only one line
            if (number == 77)
                Console.WriteLine("The Status is 77!");
            else
                Console.WriteLine("The Status is < 1 or > 20 and not 77!");
        }

        return false;
    }


}

class switchCase
{
    public string daysofWeek(int day)
    {
        string theDay = "";

        switch (day) // as string its type sensitiv !
        {
            
            case 1:
                theDay = "Monday";
                goto case 99;
            case 2:
                theDay = "Tuesday";
                goto case 99;
            case 3:
                theDay = "Wednesday";
                goto case 99;
            case 4:
                theDay = "Thursday";
                goto case 99;
            case 5:
                theDay = "Friday";
                goto case 99;
            case 6:
                theDay = "Saturday";
                goto case 98;
            case 7:
                theDay = "Sunday";
                goto case 98;
            case 98:
                return "The day is: " + theDay + ".Its a not a day!";
            case 99:
                return "The day is: " + theDay + ".Its a working day!";
            default:
                return "Invalid day of the week";
        }
    }
}
class DoSomethingWithArrays
    {
        public string[,] DoSomething(string[,] Array)
        {
            foreach (var arrElement in Array)
            {
                // Printing each to the console
                Console.WriteLine(arrElement);
            }

        return Array;
        }
    }

class TheProgram
{
    public static void Main(string[] args)
    {
        IfElse obj = new IfElse();

        string result = (obj.checkStatus1020(17) == true) ? "Number is between 10-20." : "Number is NOT between 10-20.";
        Console.WriteLine (result);

        obj.checkStatus1020(77);
        obj.checkStatus1020(80);
     
        switchCase obj1 = new switchCase();
        Console.WriteLine(obj1.daysofWeek(4));
        Console.WriteLine(obj1.daysofWeek(3));
        Console.WriteLine(obj1.daysofWeek(6));
        Console.WriteLine(obj1.daysofWeek(7));
        Console.WriteLine(obj1.daysofWeek(10));

        DoSomethingWithArrays obj2 = new DoSomethingWithArrays();
        string[,] fruits = { { "Apple", "Banana", "Orange", "Grapes" },{ "Melone", "Citrone", "Coconut", "Grapefruit" } };
        obj2.DoSomething(fruits);
        
        MyCollection collection = new MyCollection();

        // Using foreach (IEnumerable)
        Console.WriteLine("Using foreach (IEnumerable):");
       
        foreach (int item in collection)
        {
            Console.WriteLine(item);
        }
 
        //CamleCase --> only variables
        //PascalCase classes, methods, events, interfaces, enums

    }
    public class MyCollection : IEnumerable<int>
    {
        private int[] items = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(items);
        }
    }

    public class MyEnumerator : IEnumerator<int>
    {
        private int[] titems;
        private int currentIndex = -1;

        public MyEnumerator(int[] items)
        {
            titems = items;
        }

        public int Current
        {
            get { return titems[currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return titems[currentIndex]; }
        }

        public bool MoveNext()
        {
            currentIndex++;
            return (currentIndex < titems.Length);
        }

        public void Reset()
        {
            currentIndex = -1;
        }
        public void Dispose()
        {
            // No resources to dispose
        }
    }
}
