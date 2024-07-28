using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Administration.General
{
    public class Gehege
    {
        public int GehegeNr { get; set; }
        public int MaxAnzahl { get; set; }
        public int MinAnzahl { get; set; }
        public string Bezeichnung { get; set; }

        public Gehege(int gehegeNr, int maxAnzahl, int minAnzahl, string bezeichnung)
        {
            this.GehegeNr = gehegeNr;
            this.MaxAnzahl = maxAnzahl;
            this.MinAnzahl = minAnzahl;
            this.Bezeichnung = bezeichnung;
        }
		
		public int getGehegeNr() {
        return GehegeNr;
		}

		public void setGehegeNr(int gehegeNr) {
			this.GehegeNr = gehegeNr;
		}

		public int getMaxAnzahl() {
			return MaxAnzahl;
		}

		public void setMaxAnzahl(int maxAnzahl) {
			this.MaxAnzahl = maxAnzahl;
		}

		public int getMinAnzahl() {
			return MinAnzahl;
		}

		public void setMinAnzahl(int minAnzahl) {
			this.MinAnzahl = minAnzahl;
		}

		public String getBezeichnung() {
			return Bezeichnung;
		}

		public void setBezeichnung(String bezeichnung) {
			this.Bezeichnung = bezeichnung;
		}

        public override string ToString()
        {
            return $"Gehege{{Gehege Nummer={GehegeNr}, Max. Anzahl={MaxAnzahl}, Min. Anzahl={MinAnzahl}, Bezeichnung='{Bezeichnung}'}}";
        }
    }
}

