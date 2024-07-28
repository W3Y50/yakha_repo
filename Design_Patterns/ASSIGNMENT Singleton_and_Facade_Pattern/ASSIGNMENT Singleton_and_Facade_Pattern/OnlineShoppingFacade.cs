using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGNMENT_Singleton_and_Facade_Pattern
{
    // The Facade class
    public class OnlineShoppingFacade
    {
        private IInventory inventory;
        private IOrderVerify orderVerify;
        private IPaymentProcessor paymentProcessor;
        private ILogistics logistics;

        public OnlineShoppingFacade()
        {
            inventory = new InventoryManager();
            orderVerify = new OrderVerificationManager();
            paymentProcessor = new PaymentManager();
            logistics = new LogisticsManager();

        }

        public void FinalizeOrder(OrderDetails orderDetails)
        {
            if (orderVerify.Verify(orderDetails))
            {
                inventory.Update(orderDetails.ProductId);
                if (paymentProcessor.ProcessPayment(orderDetails.CardNumber, orderDetails.Cost))
                {
                    logistics.ShipProduct(orderDetails.ProductName, $"{orderDetails.AddressLine1}, {orderDetails.AddressLine2} - {orderDetails.PinCode}");
                }
            } //--> übertrag in den singleton?
            // Usage
            //Singleton singleton = Singleton.Instance;
            //singleton.DoSomething();
        }
    }
}


/*
 
Das Facade-Muster bietet eine vereinfachte Schnittstelle zu einem komplexen Subsystem. 
Es fungiert als Wrapper um eine Reihe von Klassen und verbirgt die Komplexität des zugrunde liegenden Systems vor dem Client. 
Betrachten wir ein Beispiel für ein Online-Einkaufssystem. Das System hat mehrere Subsysteme,
wie z. B. Bestandsverwaltung, Bestellungsprüfung, Zahlungsabwicklung und Versandlogistik. 
Anstatt all diese Subsysteme direkt dem Client zugänglich zu machen, können wir eine Fassadenklasse erstellen, 
die eine vereinfachte Schnittstelle zur Interaktion mit dem System bietet.
--------
In diesem Beispiel bietet die Klasse OnlineShoppingFacade dem Kunden eine vereinfachte Schnittstelle 
für den Abschluss einer Bestellung. Der Kunde muss nicht direkt mit den einzelnen Subsystemen 
(Bestand, Auftragsprüfung, Zahlungsabwicklung und Versandlogistik) interagieren. 
Stattdessen ruft der Kunde die Methode FinalizeOrder auf dem OnlineShoppingFacade-Objekt auf, 
und die Fassade übernimmt die Koordination und den Aufruf der zugrunde liegenden Subsysteme. 

Das Facade-Muster hilft dabei:

- Vereinfachung der Interaktion des Clients mit den komplexen Subsystemen.
- die lose Kopplung zwischen dem Client und den Subsystemen zu fördern.
- Verbesserung der Wartbarkeit des Systems durch Kapselung der Komplexität innerhalb der Fassade.
--------
 
 */






/*
  
In diesem Beispiel hat die Singleton-Klasse einen privaten Konstruktor, 
um eine direkte Instanziierung zu verhindern. 
Die Klasse verfügt außerdem über eine statische Instance-Eigenschaft, 
die die einzelne Instanz der Klasse zurückgibt, die beim ersten Laden der Klasse erstellt wird. 
Die wichtigsten Aspekte dieser Singleton-Implementierung sind:

    - Die Singleton-Klasse ist als versiegelt gekennzeichnet, um Vererbung zu verhindern.
    - Der Konstruktor ist privat, um eine direkte Instanziierung zu verhindern.
    - Die Instance-Eigenschaft ist statisch und gibt bei jedem Aufruf die gleiche Instanz der Singleton-Klasse zurück.
    - Das Instanzfeld ist statisch und schreibgeschützt, um sicherzustellen, dass nur eine Instanz der Singleton-Klasse erzeugt wird.

Diese Implementierung ist als „eager initialization“-Ansatz bekannt, 
bei dem die einzelne Instanz beim ersten Laden der Klasse erstellt wird. 
Es gibt noch weitere Varianten des Singleton-Musters, wie z. B. die „träge Initialisierung“ und die „thread-sichere Initialisierung“, 
die unterschiedliche Anliegen und Kompromisse berücksichtigen. Das Singleton-Muster ist nützlich, 
wenn Sie sicherstellen müssen, dass eine Klasse nur eine Instanz hat, 
und einen globalen Zugriffspunkt für diese Klasse bereitstellen wollen. 
Es ist jedoch wichtig, das Singleton-Muster mit Bedacht einzusetzen, 
da es zu einer engen Kopplung führen und Unit-Tests erschweren kann. 
Alternative Muster, wie z. B. das Dependency Injection-Muster, 
werden im modernen Softwaredesign oft bevorzugt.
 
 
 */



//stop watch mal testen...