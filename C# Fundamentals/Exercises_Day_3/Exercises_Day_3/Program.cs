//Inheritance
//Polymorphism with overriding

using System.Reflection.Emit;

interface IAnimal //By default, members of an interface are abstract and public.
{
    void animalSound3(); // interface method (does not have a body)
}

enum starvationLevel
{
    Low = 1000, //kcal
    Medium = 3500, //kcal
    High = 7000, //kcal
}
abstract class Animal  // Base class (parent) 
{
    public abstract void animalSound2();
    public abstract void animalSound();

    public virtual void aSound()
    {
        Console.WriteLine("The special a sound.");
    }

}

class Pig : Animal  // Derived class (child) 
{
    starvationLevel myStrL = starvationLevel.High;

    public override void animalSound()
    {
        Console.WriteLine("The pig says: wee wee" + " and the pig needs " + (int)myStrL + " kcal per day. This is very: " + myStrL);
    }

    public override void animalSound2()
    {
        Console.WriteLine("The pig says: rrrr rrrr" + " and the pig needs " + (int)myStrL + " kcal per day. This is very: " + myStrL);
    }

    public override void aSound()
    {
        // Override virtual method

        // Call parent implementation
        base.aSound();
    }
}

class Dog : Animal  // Derived class (child) 
{
    starvationLevel myStrL = starvationLevel.Medium;
    public override void animalSound()
    {
        Console.WriteLine("The dog says: wow wow" + " and the dog needs " + (int)myStrL + " kcal per day. This is very: " + myStrL);
    }

    public override void animalSound2()
    {
        Console.WriteLine("The dog says: uuuuw uuuuw" + " and the dog needs " + (int)myStrL + " kcal per day. This is very: " + myStrL);
    }
}

// GuineaPig "implements" the IAnimal interface
class GuineaPig : IAnimal // Its good practice to start with the letter "I" at the beginning of an interface
{
    starvationLevel myStrL = starvationLevel.Low;
    public void animalSound3()
    {
        // The body of animalSound3() is provided here
        Console.WriteLine("The GuineaPig says: peeep peeeep" + " and the GuineaPig needs " + (int)myStrL + " kcal per day. This is very: " + myStrL);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Animal myAnimal = new Animal();  // Create a Animal object
        Animal myPig = new Pig();  // Create a Pig object
        Animal myDog = new Dog();  // Create a Dog object
        GuineaPig gPig = new GuineaPig();  // Create a Pig object
        
        //myAnimal.animalSound();
        myPig.animalSound(); //regular method
        myPig.animalSound2(); //abstract method
        myPig.aSound(); // Pig inheritate Animal - Animal is abstract and contains a method aSound (with body), the call is in myPig
        myDog.animalSound(); //regular method
        myDog.animalSound2(); //abstract method
        gPig.animalSound3(); //implemented with Interface

    }
}
