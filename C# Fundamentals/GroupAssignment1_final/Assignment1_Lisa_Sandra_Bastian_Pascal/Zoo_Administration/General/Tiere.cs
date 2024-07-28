using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Administration.General
{
    public class Tier
    {
        public int TierNr { get; set; }
        public int Alter { get; set; }
        public int GehegeNr { get; set; }
        public string Name { get; set; }
        public string Art { get; set; }

        public Tier(int tierNr, int alter, int gehegeNr, string name, string art)
        {
            TierNr = tierNr;
            Alter = alter;
            GehegeNr = gehegeNr;
            Name = name;
            Art = art;
        }
		
		    public int getTierNr() {
			return TierNr;
		}

		public void setTierNr(int tierNr) {
			this.TierNr = tierNr;
		}

		public int getAlter() {
			return Alter;
		}

		public void setAlter(int alter) {
			this.Alter = alter;
		}

		public String getName() {
			return Name;
		}

		public void setName(String name) {
			this.Name = name;
		}

		public String getArt() {
			return Art;
		}

		public void setArt(String art) {
			this.Art = art;
		}

		public int getGehegeNr() {
			return GehegeNr;
		}

		public void setGehegeNr(int gehegeNr) {
			this.GehegeNr = gehegeNr;
		}



        public override string ToString()
        {
            return $"Tier{{TierNummer={TierNr}, Alter={Alter}, Name='{Name}', Bezeichnung='{Art}'}}";
        }
    }
}

