namespace Decorator;

class Program
{
    static void Main(string[] args)
    {
        // Create a new MacBookPro instance
        MacBookPro pc1 = new MacBookPro();

        // Decorate the MacBookPro with a Touchbar
        MacBookTouchbar macBookWithTouchbar = new MacBookTouchbar(pc1);

        // Further decorate the MacBookPro with Touchbar by adding an i5 Processor
        MacBookI5Processor macBookWithTouchAndI5 = new MacBookI5Processor(macBookWithTouchbar);

        // Further decorate the MacBookPro with Touchbar by adding an i4 Processor
        MacBookI4Processor macBookWithTouchAndI4 = new MacBookI4Processor(macBookWithTouchbar);

        // Output the description and price of the MacBook with Touchbar and i5 processor
        Console.WriteLine(macBookWithTouchAndI5.GetDescription());
        Console.WriteLine(macBookWithTouchAndI5.GetPrice());

        // Output the description and price of the MacBook with Touchbar and i4 processor
        Console.WriteLine(macBookWithTouchAndI4.GetDescription());
        Console.WriteLine(macBookWithTouchAndI4.GetPrice());

        // Wait for a key press to close the console window
        Console.ReadKey();


        //MacBookPro pc1 = new MacBookPro();
        //Console.WriteLine(pc1.GetDescription());
        //Console.WriteLine(pc1.GetPrice());
        //Console.ReadKey();
    }
}

//IMacBook
//Air
//Pro
//Addon
//touchbar
//Aufgabe
//processor