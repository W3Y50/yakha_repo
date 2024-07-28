using System;
using System.Collections;
using System.Globalization;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class TypeCasting 
{

    public void ImplicitCasting() // converting a smaller type --> larger type size
    {
        int num1 = 9;
        double num2 = num1;

        if (num1 == num2) 
        {
            Console.WriteLine("In the If of ImplicitCasting");
        }
        Console.WriteLine(num1);
        Console.WriteLine(num2);
    }

    public void ExplicitCasting() // converting a larger type --> smaller size type
    {
        double num1 = 9.75; //Attention: rounded up or rounded down
        int num2 = (int)num1;

        if (num1 == num2)
        {
            Console.WriteLine("In the If of ExlicitCasting);");
        }

        Console.WriteLine(num1);
        Console.WriteLine(num2);
    }

    public void Parsing() // parse NON convertable types like int / string
    {

        //parse
        string test = "9";
        int numI = int.Parse(test);
        double numD = double.Parse(test);
        Console.WriteLine(numI);
        Console.WriteLine(numD);

        //tryparse

        bool sucess = int.TryParse(test, out int numnum);
        Console.WriteLine("TryPars result is: " + sucess);
        Console.WriteLine("--------------------------------");

        string value = "107";
        string strListStr = "";
        int intListRes = 0;
        int i = 0;
        int j = 0;
        int k = 0;
        int res = 0;
        int res1 = 0;
        double res2 = 0;
        decimal number;

        if (int.TryParse(value, out res))
        {
            Console.WriteLine($"Measurement: {res}");
        }
        else
        {
            Console.WriteLine("Unable to report the measurement.");
        }
        //------------------

        string[] arrval = { "12.3", "45", "ABC", "11", "DEF" };
        List<string> strList = new List<string>();
        List<double> doubleList = new List<double>();

        while (i < arrval.Length)
        {
            if (decimal.TryParse(arrval[i], out number))
            {
                double doubleValue = double.Parse(arrval[i]); // Parsing is false 123 --> expected 12.3
                Console.WriteLine(doubleValue);
                doubleList.Add(doubleValue);
                Console.WriteLine("Not a string " + arrval[i]);
            }
            else
            {
                strList.Add(arrval[i]);
                Console.WriteLine("Its a string " + arrval[i]);
            }

            i ++;
        }
        while (j < strList.Count)
        {
            Console.WriteLine("New List: " + strList[j]);
            strListStr += strList[j];
            j++;
        }

        Console.WriteLine("Message: " + strListStr);
        Console.WriteLine("Total: " + doubleList.Sum());
        Console.WriteLine("-----------------------------------");
        int value1 = 11;
        decimal value2 = 6.2m;
        float value3 = 4.3f;

        int result1 = Convert.ToInt32(value1 / value2);
        Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

        decimal result2 = value2 / (decimal)value3;
        Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

        float result3 = value3 / value1;
        Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");

    }
    public void ConvertClass() // convert data types explicitly by using built-in methods, such as Convert.ToBoolean, Convert.ToDouble, Convert.ToString, Convert.ToInt32 (int) and Convert.ToInt64 (long)
    {
        int myInt = 27;
        double myDouble = 9.75;
        bool myBool = false;

        Console.WriteLine(Convert.ToString(myInt));    // convert int to string
        Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
        Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
        Console.WriteLine(Convert.ToString(myBool));   // convert bool to string


    }

    public void ArrayOps() // The Array class contains methods that you can use to manipulate the content, arrangement, and size of an array.
    {
        //CopyTo(Array, int)
        int[] sourceArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] destinationArray = new int[10];
        sourceArray.CopyTo(destinationArray, 0);

        foreach (int i in destinationArray)
        {
            Console.WriteLine("copyto destination arr: " +i);
        }

        //IndexOf(Object):

        int[] numbers1 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        int index = Array.IndexOf(numbers1, 30);
        Console.WriteLine("IndexOf(Object): " + index);


        //Reverse(Array)

        int[] numbers2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Array.Reverse(numbers2);
        
        foreach (int i in numbers2)
        {
            Console.WriteLine("Reverse(Array): " + i);
        }


        // Sort(Array)
        int[] numbers3 = { 5, 3, 1, 4, 2, 9, 7, 10, 8 };
        Array.Sort(numbers3);

        foreach (int i in numbers3)
        {
            Console.WriteLine("Sort(Array): " + i);
        }


        //Clear(Array)
        int[] numbers4 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Array.Clear(numbers4, 0, numbers4.Length);

        foreach (int i in numbers4)
        {
            Console.WriteLine("Clear(Array): " + i);
        }


        //split and reverse
        string value = "abc123";
        char[] valueArray = value.ToCharArray();
        Array.Reverse(valueArray);
        //string result = new string(valueArray);
        //join the string with , separated value
        string result = string.Join(",", valueArray);
        Console.WriteLine(result);
        string[] resitems = result.Split(',');
        foreach (string a in resitems)
        {
            Console.WriteLine(a);
        }
        //reverse
        string pangram = "The quick brown fox jumps over the lazy dog";
        string resPangram;
        string[] pan1 = pangram.Split(' ');
        string[] pan2 = new string[pan1.Length];

        for (int i = 0; i < pan1.Length; i++)
        {
            char[] letters = pan1[i].ToCharArray();
            Array.Reverse(letters);
            pan2[i] = new string(letters);
        }

        string resPangra = string.Join(" ", pan2);
        Console.WriteLine(resPangra);

        //composite formatting
        string first = "Hello";
        string second = "World";
        string re = string.Format("{0} {1} {1} {1}!", first, second);
        Console.WriteLine(re);
        //string interpolation
        string fi= "Hello";
        string se = "World";
        Console.WriteLine($"{first} {second}!");
        Console.WriteLine($"{second} {first}!");
        Console.WriteLine($"{first} {first} {first}!");
        Console.WriteLine(first.PadLeft(2));

    }

    static int OverlodingExampleInt(int x, int y)
    {
        return x + y;
    }

    static double OverlodingExampleDouble(double x, double y)
    {
        return x + y;
    }
    static double OverlodingExampleDouble(double x, double y,  double z)
    {
        return x + y + z;
    }

    class Recursion 
    { 
       public int factorial(int i) 
       {
            // 14 = 4*3*2*1
            if (i > 0)
            {
                return i * factorial(i - 1);
            }
            else 
            {
                return 1;
            }          
       }
    
    }

    public static void Main(string[] args)
    {
        TypeCasting obj1 = new TypeCasting();
        obj1.ImplicitCasting();
        obj1.ExplicitCasting();
        obj1.Parsing();
        obj1.ConvertClass();
        obj1.ArrayOps();
        Recursion obj2 = new Recursion();
        Console.WriteLine(obj2.factorial(4));

        //make overloding + default parameter
        //sort and reverse maually
    }


}

