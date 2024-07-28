using System;
using System.Collections.Generic;
using System.Linq;
using Zoo_Administration.Verwaltung.tupeln;
using Zoo_Administration.General;

namespace verwaltungen
{
    public class GehegeVerwaltung
    {
        private List<GMTupel> verwaltungsListe;

        // Zugriff auf verwaltungsListe in anderen Klassen

        public List<GMTupel> AlleAusgeben()
        {
            return verwaltungsListe; 
        }
        /**
         * In dieser Gehegeverwaltung gibt es je eine Liste für Mitarbeiter und Gehege,
         * diese müssen noch befüllt werden.
         */
        public GehegeVerwaltung()
        {
            verwaltungsListe = new List<GMTupel>();
        }

        /**
         * Fügt eine neue Verwaltungstupel hinzu, diese wird aus einem Gehege und zwei Mitarbeitern gebaut
         * @param gehege ..
         * @param mitarbeiter1 ..
         * @param mitarbeiter2 ..
         */
        public void HinzufÜgen(Gehege gehege, Mitarbeiter mitarbeiter1, Mitarbeiter mitarbeiter2)
        {
            GMTupel gmTupel = new GMTupel(gehege, mitarbeiter1, mitarbeiter2);
            verwaltungsListe.Add(gmTupel);
        }

        //ausgeben alle einträge
        //public List<GMTupel> AlleAusgeben()
        //{
        //    return verwaltungsListe;
        //}

        /**
         * Löscht für eine MitarbeiterNummer alle Einträge, dies könnte bedeuten, dass ein Gehege keine Verwaltung mehr hat
         * @param mitarbeiterNr Zu löschen.
         */
        public void LoescheMitarbeiter(int mitarbeiterNr)
        {
            verwaltungsListe.RemoveAll(t => t.Mitarbeiter1Nummer == mitarbeiterNr || t.Mitarbeiter2Nummer == mitarbeiterNr);
        }

        /**
         * Löscht für eine Gehegenummer alle Einträge.
         * @param gehegeNr Zu löschen.
         */
        public void LoescheGehege(int gehegeNr)
        {
            verwaltungsListe.RemoveAll(t => t.GehegeNummer == gehegeNr);
        }

        /**
         * Loescht eine GMTupel aus der Verwaltung
         * @param zuLoeschen die zu löschende GMTupel
         */
        public void Loeschen(GMTupel zuLoeschen)
        {
            verwaltungsListe.RemoveAll(t => t.IstGleich(zuLoeschen));
        }

        public override string ToString()
        {
            return $"GehegeVerwaltung{{ verwaltungsListe={string.Join(", ", verwaltungsListe)} }}";
        }
    }
}

