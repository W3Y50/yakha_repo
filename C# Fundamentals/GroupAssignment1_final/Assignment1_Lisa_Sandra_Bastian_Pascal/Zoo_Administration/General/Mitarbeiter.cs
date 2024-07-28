using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Administration.General
{
    public class Mitarbeiter
    {
        public int MitarbeiterNr { get; set; }
        public string Name { get; set; }
        public int Alter { get; set; }
        public int Gehalt { get; set; }
        public string JobBezeichnung { get; set; }
		public string Passwort { get; set; }

        public Mitarbeiter(int mitarbeiterNr, string name, int alter, int gehalt, string jobBezeichnung, string passwort)
        {
            MitarbeiterNr = mitarbeiterNr;
            Name = name;
            Alter = alter;
            Gehalt = gehalt;
            JobBezeichnung = jobBezeichnung;
			Passwort = passwort;
        }
		
		public int getMitarbeiterNr() {
        return MitarbeiterNr;
		}

		public void setMitarbeiterNr(int mitarbeiterNr) {
			this.MitarbeiterNr = mitarbeiterNr;
		}

		public String getName() {
			return Name;
		}

		public void setName(String name) {
			this.Name = name;
		}

		public int getAlter() {
			return Alter;
		}

		public void setAlter(int alter) {
			this.Alter = alter;
		}

		public int getGehalt() {
			return Gehalt;
		}

		public void setGehalt(int gehalt) {
			this.Gehalt = gehalt;
		}

		public String getJobBezeichnung() {
			return JobBezeichnung;
		}

		public void setJobBezeichnung(String jobBezeichnung) {
			this.JobBezeichnung = jobBezeichnung;
		}

        public String getPasswort()
        {
            return Passwort;
        }

        public void setPasswort(String passwort)
        {
            this.Passwort = passwort;
        }


        public override string ToString()
        {
            return $"Mitarbeiter{{MitarbeiterNr={MitarbeiterNr}, Name='{Name}', Alter={Alter}, Gehalt={Gehalt}, JobBezeichnung='{JobBezeichnung}'}}";
        }
    }
}

