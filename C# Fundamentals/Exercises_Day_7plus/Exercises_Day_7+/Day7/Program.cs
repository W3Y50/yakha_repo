using Exercises_Day_7plus.Day7.DoSomethingWithStrings;
using Exercises_Day_7plus.Day7.StructExample;
using System; // using System namespace

namespace Exercises_Day_7plus.Day7
{

    //namespace MyProgram //using namespace
    //{

    //    class MainClass()
    //    {

    //        public static void Main(string[] args)
    //        {
    //            Concat obj1 = new Concat();
    //            obj1.ConEtc();
    //            StringOps obj2 = new StringOps();
    //            obj2.strOps();
    //            Animal obj3 = new Animal();   //declare a new struct
    //            obj3.getAnimalName("Jolanda");

    //        }

    //    }
    //}

    namespace DoSomethingWithStrings //using namespace
    {
        class Concat()
        {
            public void ConEtc()
            {
                // First 
                string firstName1 = "Bernd ";
                string lastName1 = "Müller";
                string name1 = firstName1 + lastName1;
                Console.WriteLine(name1);

                // Second
                string firstName2 = "Tilo ";
                string lastName2 = "Schmidt";
                string name2 = string.Concat(firstName2, lastName2);
                Console.WriteLine(name2);

                //Interpolation

                string firstName3 = "Eberhardt";
                string lastName3 = "Friedrich";
                string name3 = $"My full name is: {firstName3} {lastName3} the 3.!";
                Console.WriteLine(name3);

            }


        }

        class StringOps()
        {
            public void strOps()
            {
                //Concat

                string firstName4 = "Max";
                string lastName4 = "Schreiner";
                string fullName4 = firstName4 + " " + lastName4;
                Console.WriteLine("Concat: " + fullName4);

                //Substring

                string str1 = "Hello World, what is going on?";
                string subString = str1.Substring(11, 1);
                Console.WriteLine("Substring: " + subString);

                //Length

                string str2 = "Hello, hello there!";
                int length = str2.Length;
                Console.WriteLine("Length: " + str2);

                //Split

                string str3 = "red-blue-yellow-purple-green";
                string[] colors = str3.Split(',');
                Console.WriteLine("Split: " + colors);

                //Join

                string str4 = string.Join("/", colors);
                Console.WriteLine("Join: " + str4);

                //Replace

                string str5 = "Hello Max!";
                string newStr = str5.Replace("Max", "Mister Universe");
                Console.WriteLine("Replace: " + str5);

                //Lower-/Uppercase

                string str6 = "Hello,HellouAuOPAssQ";
                string lowerCaseStr = str6.ToLower();    
                Console.WriteLine("Lowecase: " + lowerCaseStr);
                string upperCaseStr = str6.ToUpper();   
                Console.WriteLine("Uppercase: " + upperCaseStr);

                //Trim
                string str7 = " Hello     ";
                string trimmedStr = str7.Trim();
                Console.WriteLine("Trim: " + str7);

                //IndexOf
                string str8 = "Hello World, this is your time!";
                int index = str8.IndexOf("is");
                Console.WriteLine("IndexOf: " + index);

                //Format

                string name = "John John";
                int age = 27;
                string formattedString = string.Format("Name: {0}, Age: {1}", name, age);
                Console.WriteLine("formattedString: " + formattedString);

                // Result: "Name: John, Age: 30"

                // String interpolation
                string interpolatedString = $"Name: {name}, Age: {age}";
                Console.WriteLine("interpolatedString: " + interpolatedString);
            }
        }

    }

    namespace StructExample
    {

        // defining a struct
        struct Animal
        {
            public string animalName;

            public void getAnimalName(string name)
            {
                Console.WriteLine("The Animal Name is: " + name);
            }
        }

    }

}


