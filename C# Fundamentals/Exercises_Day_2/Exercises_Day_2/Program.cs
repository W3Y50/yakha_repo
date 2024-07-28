using System.Drawing;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;

class Car //definition of the class
{
    // int year; //--> declare a variable
    // int a = 1; // --> define a variable   
    //string color = "red"; //class members
    int manYear;
    string color;
    string brand;

    Car(int manYear, string color, string brand) // its a constructor --> no return type --> use for initialization --> name similiar to the class 
    {       // is fired as soon as a new object of type Car is created
            // year = manYear;
        this.manYear = manYear;
        this.color = color;
        this.brand = brand;

    }

    public void printCarType(Car a) //method without a returntype , method is also a class member
    {
        Console.WriteLine(a);
    }
    public static void Main(string[] args)  //every class must contain a Main method
    {
        Car BMW = new Car(1998, "red", "Volkswagen");
        Car AUDI = new Car(2000, "yellow", "Audi");
        Car SKODA = new Car(2003, "purple", "Skoda");

        Console.WriteLine("--------------Mein Bestand an Fahrzeugen: --------------------------");
        
        Console.WriteLine("Baujahr: " + BMW.manYear + " /Fabe: " + BMW.color + " / Marke: " + BMW.brand);
        Console.WriteLine("Baujahr: " + AUDI.manYear + " /Fabe: " + AUDI.color + " / Marke: " + AUDI.brand);
        Console.WriteLine("Baujahr: " + SKODA.manYear + " /Fabe: " + SKODA.color + " / Marke: " + SKODA.brand);

        Console.WriteLine("--------------------------------------------------------------------");

        Dog bulldog = new Dog(45.0, "brown", "English Bulldog", "m");
        Console.WriteLine(bulldog.outputDog(bulldog));
    }

    /*acess modifier public --> acess from everywear
     * private --> same class or structure
     * protected --> for class members --> only acess in the class und vererbte
     * internal --> for class members -->  onyly acess in the same assembly / part of code
     * protected internat and priovate interal combinations möglich     
     */

}

class Dog
{
    //public static int dlegs;
    protected int legs = 4;
    double widerrist;
    string dogbreed;
    string color;
    string gender;

    public int GetLegs() 
    {
        return legs;
    }
    public Dog(double widerrist, string color, string dogbreed, string gender)
    {
        this.widerrist = widerrist;
        this.color = color;
        this.dogbreed = dogbreed;
        this.gender = gender;
    }

  //  public Dog()
  //  {
  //
  //  }

    public string outputDog(Dog dog)
    {

       Console.WriteLine("My dog: ");
       Console.WriteLine(dog.GetLegs() + " legs.");
       Console.WriteLine(dog.widerrist + " withers height.");
       Console.WriteLine(dog.dogbreed + " is the dog breed.");
       Console.WriteLine(dog.color + " is the color.");
       Console.WriteLine(dog.gender + " is the gender.");

        return "";
    }

}