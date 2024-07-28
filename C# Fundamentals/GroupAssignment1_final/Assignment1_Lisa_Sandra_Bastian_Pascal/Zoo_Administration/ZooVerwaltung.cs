using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using verwaltungen;
using Zoo_Administration.General;
using Zoo_Administration.Verwaltung.tupeln;

public class ZooVerwaltung
{
    private static verwaltungen.GehegeVerwaltung gehegeVerwaltung;
    private static List<Mitarbeiter> mitarbeiterListe;
    private static List<Tier> tierListe;
    private static List<Gehege> gehegeListe;

    public static void Main(string[] args)
    {
        //Initialisieren der hardcodierten Zoo-Tiere, Mitarbeiter und Gehege
        Initialisieren();

        //Begrüße Nutzer
        Console.WriteLine("Willkommen bei der Zoo-Verwaltung!");
        Verifikation();

        //Bitte Nutzer um Eingabe
        NutzerEingabe();
    }

    /// <summary>
    /// Diese Methode kann für alle Eingaben des Nutzers genutzt werden
    /// </summary>
    /// <returns>Die Eingabe des Nutzers als String oder ein leerer String, wenn etwas schief gelaufen ist in dem IO System.</returns>

    public static string NutzerEingabe()
	{
		// Fehlererkennung, falls etwas bei der Eingabe schief geht, hierdran bitte nichts ändern
		string antwort = "";
		try
		{
			antwort = Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine("Da ist etwas schief gegangen. Starten Sie das Programm neu.");
		}

		return antwort;
	}

    /// <summary>
    /// Generiert die Nummer einer Eingabe
    /// </summary>
    /// <param name="antwort">Übergebene Nutzer-Eingabe</param>
    /// <returns>Nummer aus der Nutzer-Eingabe</returns>

    private static int NummerVonEingabe(string antwort)
    {
        try
        {
            return int.Parse(antwort);
        }
        catch (FormatException)
        {
            return -1;
        }
    }
    /// <summary>
    /// Hier haben wir eine einfache Verifikation am Anfang der Software
    /// </summary>
    public static void Verifikation()
    {
        Console.WriteLine("Geben Sie Ihre Mitarbeiternummer ein:");

        string antwort = NutzerEingabe();

        int mitarbeiterNr = -1;

        if (!string.IsNullOrEmpty(antwort))
        {
            mitarbeiterNr = NummerVonEingabe(antwort);
        }
        Mitarbeiter mitarbeiter = mitarbeiterListe.FirstOrDefault(m => m.getMitarbeiterNr() == mitarbeiterNr);

        if (mitarbeiter == null)
            Console.WriteLine("Die Mitarbeiternummer ist falsch. Bitte starten Sie das Programm neu.");
        else
        {
            Console.WriteLine("Geben Sie das Passwort ein:");
            string passwortEingabe = NutzerEingabe();

            if (passwortEingabe == mitarbeiter.getPasswort())
            {
                if (mitarbeiter.getName() == "Hildegard Grün")
                {
                    VerarbeiteNutzerEingabeOption1("1");
                    Console.WriteLine("Willkommen in der Zoo Verwaltungs Software!");
                }
                else
                    Console.WriteLine("Willkommen in der Zoo Verwaltungs Software!");
                if (mitarbeiter.getGehalt() >= 3000)
                    NutzerMenu1();
                else
                    NutzerMenuOhneVerwaltung();
            }
            else
            {
                Console.WriteLine("Das Passwort ist falsch. Bitte starten Sie das Programm neu.");
            }

        }

    }
    /// <summary>
    /// Nutzer Eingabe
    /// </summary>
    public static void NutzerMenu1()
    {
        //Mögliche Nutzer anfragen
        string[] nutzerFragen = new string[]
        {
            "1) Gib Teile der Zoo Verwaltung aus.",
            "2) Verwalte Tiere.",
            "3) Verwalte Mitarbeiter.",
            "4) Verwalte Gehege.",
            "5) Bearbeiten die Gehegeverwaltung.",
            "6) Beenden"
        };

        //Frage den Nutzer was er tun möchte:
        Console.WriteLine("Was wollen Sie tun? Geben Sie eine Zahl ein:");
        foreach (string frage in nutzerFragen)
        {
            Console.WriteLine(frage);
        }

        string antwort = NutzerEingabe();

        //Verarbeite die Antwort des Nutzers (Sollte eine Zahl von 1 bis 5 sein.)
        if (!string.IsNullOrEmpty(antwort))
        {
            VerarbeiteNutzerMenu1(antwort);
        }

    }

    public static void NutzerMenuOhneVerwaltung()
    {
        //Mögliche Nutzer anfragen
        string[] nutzerFragen = new string[]
        {
            "1) Gib Teile der Zoo Verwaltung aus.",
            "2) Beenden"
        };

        //Frage den Nutzer was er tun möchte:
        Console.WriteLine("Was wollen Sie tun? Geben Sie eine Zahl ein:");
        foreach (string frage in nutzerFragen)
        {
            Console.WriteLine(frage);
        }

        string antwort = NutzerEingabe();

        //Verarbeite die Antwort des Nutzers
        if (!string.IsNullOrEmpty(antwort))
        {
            if (antwort == "1")
                NutzerOption1();
            else
                Beenden();
        }

    }


    /// <summary>
    /// Soll die Nutzerantwort verarbeiten, je nach dem was gewollt ist, neue Sequenz an Fragen und Antworten einleiten
    /// </summary>
    /// <param name="antwort">Eingabe eines Nutzers</param>

    public static void VerarbeiteNutzerMenu1(string antwort)
	{
		int nummer = NummerVonEingabe(antwort);
		//Unterscheidung der eingegebenen Nummer
		switch (nummer)
		{
			case -1:
				Console.WriteLine("Das war keine der angegebenen Nummern.");
				break;
			case 1:
				//Methodenaufruf für Ausgabe
				NutzerOption1();
				break;
			case 2:
                TierVerwaltung();
                break;
			case 3:
                MitarbeiterVerwaltung();
				break;
			case 4:
                GehegeVerwalten();
				break;
			case 5:
                GehegeVerlwatungVerwalten();
                break;
			case 6:
				//Methodenaufruf für Ende
				Beenden();
				break;
			default:
				Console.WriteLine("Das war keine der angegebenen Nummern.");
				break;
		}
	}

	/// <summary>
	/// Nutzer Eingabe für die Option 1 - Ausgabe
	/// </summary>
    ///
    
    public static void TierVerwaltung()
    {
        string[] verwaltungsOptions = new string[]
        {
            "1) Tier hinzufügen.",
            "2) Tier löschen.",
            "3) Hauptmenü"
        };

        //Frage den Nutzer was er ausgeben möchte:
        Console.Clear();
        Console.WriteLine("Was wollen Sie machen? Geben Sie eine Zahl ein: \n");
        foreach (string option in verwaltungsOptions)
        {
            Console.WriteLine(option);
        }

        string antwort = NutzerEingabe();
        Console.Clear();
        if (!string.IsNullOrEmpty(antwort))
        {
            //Verarbeite die Nutzerantwort für die Ausgabe
            switch(antwort)
            {
                case "1":
                    int newTierID=tierListe.Count;
                    Console.WriteLine("Gib das Alter des Tieres an");
                    string tierAlter = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib die Gehegenummer ein, in die das Tier soll.\n");
                    //alle gehege ausgeben damit der Nutzer eins wählen kann
                    VerarbeiteNutzerEingabeOption1("3");
                    string chooseGehege = NutzerEingabe();
                    if(Convert.ToInt32(chooseGehege) > gehegeListe.Count || Convert.ToInt32(chooseGehege) < 1)
                    {
                        Console.WriteLine("Bitte gib ein Gültiges Gehege ein.");
                        Console.ReadKey();
                        Console.Clear();
                        TierVerwaltung();
                    }
                    Console.Clear();
                    Console.WriteLine("Gib den Namen des Tieres an");
                    string tierName = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib die Art des Tieres an");
                    string tierArt = NutzerEingabe();
                    tierListe.Add(new Tier(newTierID, Convert.ToInt32(tierAlter), Convert.ToInt32(chooseGehege), tierName, tierArt));
                    Console.WriteLine("Tier erstellt: ");
                    Console.WriteLine(tierListe[newTierID]);
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "2":
                    VerarbeiteNutzerEingabeOption1("1");
                    Console.WriteLine("\nWelches Tier soll gelöscht werden? Bitte gib eine Tiernummer ein");
                    string deleteAt = NutzerEingabe();
                    foreach (Tier tier in tierListe)
                    {
                        if (tier.getTierNr() == Convert.ToInt32(deleteAt))
                        {
                            tierListe.Remove(tier);
                            break;
                        }
                    }
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "3":
                    NutzerMenu1();
                    break;
                default:
                    Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
                    TierVerwaltung();
                    break;
            }
        }
        else 
        {
            Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
            TierVerwaltung();
        }
    }

    public static void MitarbeiterVerwaltung()
    {
        //mitarbeiterListe.Add(new Mitarbeiter(1, "Herbert Grün", 88, 6200, "ZoodirektorIn"));

        string[] verwaltungsOptions = new string[]
        {
            "1) Mitarbeiter hinzufügen.",
            "2) Mitarbeiter löschen.",
            "3) Hauptmenü"
        };

        //Frage den Nutzer was er ausgeben möchte:
        Console.Clear();
        Console.WriteLine("Was wollen Sie machen? Geben Sie eine Zahl ein: \n");
        foreach (string option in verwaltungsOptions)
        {
            Console.WriteLine(option);
        }

        string antwort = NutzerEingabe();
        Console.Clear();
        if (!string.IsNullOrEmpty(antwort))
        {
            //Verarbeite die Nutzerantwort für die Ausgabe
            switch (antwort)
            {
                case "1":
                    int mitarbeiterID = mitarbeiterListe.Count;
                    Console.WriteLine("Gib den Namen des Mitarbeiters an.");
                    string mitarbeiterName = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib das Alter des Mitarbeiters an.");
                    string mitarbeiterAlter = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib das Gehalt des Mitarbeiters an");
                    string mitarbeiterGehalt = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib die Job Bezeichnung des Mitarbeiters an");
                    string mitarbeiterJobBezeichnung = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib das Passwort an");
                    string mitarbeiterPasswort = NutzerEingabe();

                    mitarbeiterListe.Add(new Mitarbeiter(mitarbeiterID, mitarbeiterName, Convert.ToInt32(mitarbeiterAlter), Convert.ToInt32(mitarbeiterGehalt), mitarbeiterJobBezeichnung, mitarbeiterPasswort));
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "2":
                    VerarbeiteNutzerEingabeOption1("2");

                    Console.WriteLine("\nWelcher Mitarbeiter soll gelöscht werden? Bitte gib eine Tiernummer ein");
                    string deleteAt = NutzerEingabe();
                    foreach (Mitarbeiter arbeiter in mitarbeiterListe)
                    {
                        if (arbeiter.getMitarbeiterNr() == Convert.ToInt32(deleteAt))
                        {
                            mitarbeiterListe.Remove(arbeiter);
                            break;
                        }
                    }
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "3":
                    NutzerMenu1();
                    break;
                default:
                    Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
                    MitarbeiterVerwaltung();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
            MitarbeiterVerwaltung();
        }
    }

    public static void GehegeVerwalten()
    {

        string[] verwaltungsOptions = new string[]
        {
            "1) Gehege hinzufügen.",
            "2) Gehege löschen.",
            "3) Hauptmenü"
        };

        //Frage den Nutzer was er ausgeben möchte:
        Console.Clear();
        Console.WriteLine("Was wollen Sie machen? Geben Sie eine Zahl ein: \n");
        foreach (string option in verwaltungsOptions)
        {
            Console.WriteLine(option);
        }

        string antwort = NutzerEingabe();
        Console.Clear();

        if (!string.IsNullOrEmpty(antwort))
        {
            //Verarbeite die Nutzerantwort für die Ausgabe
            switch (antwort)
            {
                case "1":
                    int GehegeID = gehegeListe.Count+1;
                    Console.WriteLine("Gib die kleinste Anzahl von Tieren für das Gehege an.");
                    string GehegeMin = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib die gößte Anzahl von Tieren für das Gehege an.");
                    string GehegeMax = NutzerEingabe();
                    Console.Clear();
                    Console.WriteLine("Gib den Namen des Geheges an.");
                    string GehegeName = NutzerEingabe();

                    gehegeListe.Add(new Gehege(GehegeID, Convert.ToInt32(GehegeMax), Convert.ToInt32(GehegeMin), GehegeName));
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "2":
                    VerarbeiteNutzerEingabeOption1("3");
                    Console.WriteLine("\nWelches Gehege soll gelöscht werden? Bitte gib eine Gehegenummer ein");
                    string deleteAt = NutzerEingabe();
                    foreach (Gehege DeleteGehege in gehegeListe)
                    {
                        if (DeleteGehege.getGehegeNr() == Convert.ToInt32(deleteAt))
                        {
                            gehegeListe.Remove(DeleteGehege);
                            break;
                        }
                    }
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "3":
                    NutzerMenu1();
                    break;
                default:
                    Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
                    GehegeVerwalten();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
            GehegeVerwalten();
        }

    }

    public static void NutzerOption1()
    {
        //Mögliche Nutzer anfragen
        string[] nutzerFragen = new string[]
        {
            "1) Gib alle Tiere aus.",
            "2) Gib alle Mitarbeiter aus.",
            "3) Gib alle Gehege aus.",
            "4) Gib die Gehegeverwaltung aus."
        };

        //Frage den Nutzer was er ausgeben möchte:
        Console.WriteLine("Was wollen Sie ausgeben? Geben Sie eine Zahl ein:");
        foreach (string frage in nutzerFragen)
        {
            Console.WriteLine(frage);
        }

        string antwort = NutzerEingabe();

        //Verarbeite die Antwort des Nutzers (Sollte eine Zahl von 1 bis 5 sein.)
        if (!string.IsNullOrEmpty(antwort))
        {
            //Verarbeite die Nutzerantwort für die Ausgabe
            VerarbeiteNutzerEingabeOption1(antwort);
        }

        ZurueckzuMenue1();
    }

    //Methode zum Zurückk
    public static void ZurueckzuMenue1()
    {
        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren.");
        Console.ReadKey();
        Console.Clear();
        NutzerMenu1();
    }

    // Loop zum Auslesen der einzelnen Listen
    public static void ZeigeListe<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

    }

    public static void GehegeVerlwatungVerwalten()
    {
        string[] verwaltungsOptions = new string[]
        {
            "1) Gehegeverwaltung hinzufügen.",
            "2) Gehegeverwaltung löschen.",
            "3) Hauptmenü"
        };

        //Frage den Nutzer was er ausgeben möchte:
        Console.Clear();
        Console.WriteLine("Was wollen Sie machen? Geben Sie eine Zahl ein: \n");
        foreach (string option in verwaltungsOptions)
        {
            Console.WriteLine(option);
        }

        string antwort = NutzerEingabe();
        Console.Clear();

        if (!string.IsNullOrEmpty(antwort))
        {
            //Verarbeite die Nutzerantwort für die Ausgabe
            switch (antwort)
            {
                case "1":
                    List<Gehege> availableGehege = new List<Gehege>();
                    foreach(Gehege G in gehegeListe) { availableGehege.Add(G); }
                    List<GMTupel> VerwalungsListe = gehegeVerwaltung.AlleAusgeben();
                    List<Mitarbeiter> Arbeiter = new List<Mitarbeiter>();
                    List<Mitarbeiter> Verwaltungskraft = new List<Mitarbeiter>();
                    
                    foreach(Gehege testGehege in gehegeListe)
                    {
                        foreach(GMTupel tupel in VerwalungsListe)
                        {
                            if(testGehege.getGehegeNr() == tupel.GehegeNummer)
                            {
                                availableGehege.Remove(testGehege);
                            }
                        }
                    }
                    
                    if(availableGehege.Count < 1)
                    {
                        Console.WriteLine("Es gibt keine uverwalteten Gehege");
                        Console.ReadKey();
                        Console.Clear();
                        NutzerMenu1();
                        break;
                    }
                    //called if a gehege is not managed by staff yet, returns current number of unmanaged cages
                    else
                    {
                        foreach (Gehege gehege in availableGehege)
                        {
                            Console.WriteLine(gehege);
                        }
                        string chosenGehege = NutzerEingabe();
                        Console.Clear();
                        foreach(Mitarbeiter arbeiter in mitarbeiterListe)
                        {
                            if(arbeiter.getJobBezeichnung() == "TierpflegerIn")
                            {
                                Console.WriteLine(arbeiter);
                                Arbeiter.Add(arbeiter);
                            }
                        }
                        Console.WriteLine("Wähle einen Tierpfleger für das Gehege");
                        string chosenArbeiter = NutzerEingabe();
                        Console.Clear();
                        foreach (Mitarbeiter verwalter in mitarbeiterListe)
                        {
                            if (verwalter.getJobBezeichnung() == "Verwaltungskraft")
                            {
                                Console.WriteLine(verwalter);
                                Verwaltungskraft.Add(verwalter);
                            }
                        }
                        Console.WriteLine("Wähle einen Verwaltungskraft für das Gehege");
                        string chosenVerwaltungskraft = NutzerEingabe();

                        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[Convert.ToInt32(chosenGehege)-1], (Mitarbeiter)mitarbeiterListe[Convert.ToInt32(chosenArbeiter) - 1], (Mitarbeiter)mitarbeiterListe[Convert.ToInt32(chosenVerwaltungskraft) - 1]);
                        Console.Clear();
                        NutzerMenu1();
                        break;


                    }
                case "2":
                    VerarbeiteNutzerEingabeOption1("4");
                    Console.WriteLine("\n Gib die Nummer der zu Löschenden Gehegeverwaltung ein");
                    string verwaltungToDelete = NutzerEingabe();
                    gehegeVerwaltung.Loeschen((gehegeVerwaltung.AlleAusgeben())[Convert.ToInt32(verwaltungToDelete)]);
                    Console.Clear();
                    NutzerMenu1();
                    break;
                case "3":
                    NutzerMenu1();
                    break;
                default:
                    Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
                    GehegeVerwalten();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Bitte gib eine Auswahlmöglichkeit an");
            GehegeVerwalten();
        }
    }

    /// <summary>
    /// Bearbeitet die Antwort des Nutzers auf Option 1
    /// </summary>
    /// <param name="antwort">Die Antwort des Nutzers auf Option 1</param>
    public static void VerarbeiteNutzerEingabeOption1(string antwort)
    {
        int nummer = NummerVonEingabe(antwort);
        switch (nummer)
        {
            case 1:

                var tiereSortiert = tierListe.OrderBy(obj => obj.Art).ToList();
                ZeigeListe(tiereSortiert);
                break;
            case 2:
                var mitarbeiterSortiert = mitarbeiterListe.OrderBy(obj => obj.JobBezeichnung).ToList();
                ZeigeListe(mitarbeiterSortiert);
                break;
            case 3:
                var gehegeSortiert = gehegeListe.OrderBy(obj => obj.GehegeNr).ToList();
                ZeigeListe(gehegeSortiert);
                break;
            case 4:
                List<GMTupel> GehegeVerwaltungsListe = gehegeVerwaltung.AlleAusgeben();
                int indexOfOBJ = 0;
                foreach (GMTupel TupleToPrint in GehegeVerwaltungsListe)
                {
                    Console.WriteLine("" + indexOfOBJ + ", " + TupleToPrint.Gehege.getBezeichnung() + ", " + TupleToPrint.Mitarbeiter1.Name + ", " + TupleToPrint.Mitarbeiter2.Name);
                    indexOfOBJ++;
                }
                break;
            default:
                Console.WriteLine("Das war keine gültige Eingabe.");
                NutzerMenu1();
                break;
        }
    }


    /// <summary>
    /// Initialisiert die Zoo Verwaltung mit hardcodierten Daten
    /// </summary>
    public static void Initialisieren()
    {
        // Initialisiere Listen
        gehegeListe = new List<Gehege>();
        mitarbeiterListe = new List<Mitarbeiter>();
        tierListe = new List<Tier>();

        // Erschaffe Gehege
        Gehege gehege1 = new Gehege(1, 10, 3, "Löwengehege");
        gehegeListe.Add(gehege1);
        Gehege gehege2 = new Gehege(2, 20, 5, "Streichelzoo");
        gehegeListe.Add(gehege2);
        Gehege gehege3 = new Gehege(3, 5, 2, "Menschenaffengehege");
        gehegeListe.Add(gehege3);

        // Erschaffe Mitarbeiter
        mitarbeiterListe.Add(new Mitarbeiter(1, "Herbert Grün", 88, 6200, "ZoodirektorIn", "12345"));
        mitarbeiterListe.Add(new Mitarbeiter(2, "Hildegard Grün", 88, 6200, "ZoodirektorIn", "12346"));
        mitarbeiterListe.Add(new Mitarbeiter(3, "Hannelore Specht", 34, 2300, "TierpflegerIn", "98765"));
        mitarbeiterListe.Add(new Mitarbeiter(4, "Friedrich Müller", 45, 3200, "TierpflegerIn", "56789"));
        mitarbeiterListe.Add(new Mitarbeiter(5, "Elisa Grün", 23, 450, "KassiererIn", "13579"));
        mitarbeiterListe.Add(new Mitarbeiter(6, "Ali Mohammed", 19, 450, "KassiererIn", "24680"));
        mitarbeiterListe.Add(new Mitarbeiter(7, "Marianne Jakobs", 23, 3100, "Verwaltungskraft", "25912"));
        mitarbeiterListe.Add(new Mitarbeiter(8, "Niko Bart", 21, 3000, "Verwaltungskraft", "25911"));
        mitarbeiterListe.Add(new Mitarbeiter(9, "Franz Hubert", 35, 3300, "Verwaltungskraft", "25913"));


        // Erschaffe Tiere
        string[] loewen = { "Anton", "Bernd", "Claudia", "Ditrich" };
        string[] ziegen = { "Ella", "Franzi", "Gertrud", "Hilda", "Inge", "Jakob", "Karl" };
        string[] affen = { "Leopold", "Malte", "Ni", "Oppi", "Paulus" };

        Random random = new Random();
        for (int i = 0; i < loewen.Length; i++)
        {
            int zufallsAlter = random.Next(1, 7);
            int eindeutigeTierNummer = i;
            tierListe.Add(new Tier(eindeutigeTierNummer, zufallsAlter, 1, loewen[i], "Löwe"));
        }
        for (int i = 0; i < ziegen.Length; i++)
        {
            int zufallsAlter = random.Next(1, 7);
            int eindeutigeTierNummer = i + loewen.Length;
            tierListe.Add(new Tier(eindeutigeTierNummer, zufallsAlter, 2, ziegen[i], "Ziege"));
        }
        for (int i = 0; i < affen.Length; i++)
        {
            int zufallsAlter = random.Next(1, 7);
            int eindeutigeTierNummer = i + ziegen.Length + loewen.Length;
            tierListe.Add(new Tier(eindeutigeTierNummer, zufallsAlter, 3, affen[i], "Menschenaffe"));
        }

        // Erschaffe GehegeVerwaltung
        // Hier haben wir das so geregelt, dass ein Gehege je eine Verwaltungskraft und einen Tierpfleger hat
        // Dieser Tierpfleger ist dann auch für alle Tiere im Gehege verantwortlich
        gehegeVerwaltung = new GehegeVerwaltung();
        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[0], (Mitarbeiter)mitarbeiterListe[6], (Mitarbeiter)mitarbeiterListe[2]);
        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[1], (Mitarbeiter)mitarbeiterListe[7], (Mitarbeiter)mitarbeiterListe[3]);
        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[2], (Mitarbeiter)mitarbeiterListe[8], (Mitarbeiter)mitarbeiterListe[3]);
    }
    /// <summary>
    /// Endes
    /// </summary>
    /// 
    public static void Beenden()
    {
        Console.WriteLine("Auf Wiedersehen!");
    }
}



