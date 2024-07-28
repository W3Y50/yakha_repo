namespace Observer;

class Program
{
    static void Main(string[] args)
    {
        // Creating a new newsletter with training tips
        SportNewsletter sn = new SportNewsletter(new Newsletter("Tips for your training", "Content..."));
        Person person1 = new Person("Timo");
        Person person2 = new Person("Max");
        Person person3 = new Person("Leo");

        // Subscribing persons to the sport newsletter
        sn.Subscribe(person1);
        sn.Subscribe(person2);

        // Sending the first newsletter
        sn.SetNewsletter(new Newsletter("Olympic Games", "Content about the Olympic Games."));
        // Unsubscribing Person1 and subscribing Person3
        sn.Unsubscribe(person1);
        sn.Subscribe(person3);

        // Sending another newsletter
        sn.SetNewsletter(new Newsletter("World Cup 2022", "Content about the 2022 Soccer World Cup."));

        Console.ReadKey();
    }
}

//NewsLetterSubject ->INewsLetterObserver ->