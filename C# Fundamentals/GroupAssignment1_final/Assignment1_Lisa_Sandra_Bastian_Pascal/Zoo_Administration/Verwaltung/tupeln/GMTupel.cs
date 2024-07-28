using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_Administration.General;

namespace Zoo_Administration.Verwaltung.tupeln
{
        /// <summary>
        /// Je zwei Mitarbeiter sind für ein Gehege zuständig
        /// </summary>
        public class GMTupel
        {
            public Gehege Gehege { get; set; }
            public Mitarbeiter Mitarbeiter1 { get; set; }
            public Mitarbeiter Mitarbeiter2 { get; set; }

            public GMTupel(Gehege gehege, Mitarbeiter mitarbeiter1, Mitarbeiter mitarbeiter2)
            {
                Gehege = gehege;
                Mitarbeiter1 = mitarbeiter1;
                Mitarbeiter2 = mitarbeiter2;
            }

            public GMTupel()
            {
            }

            public int GehegeNummer
            {
                get { return Gehege.GehegeNr; }
            }

            public int Mitarbeiter1Nummer
            {
                get { return Mitarbeiter1.MitarbeiterNr; }
            }

            public int Mitarbeiter2Nummer
            {
                get { return Mitarbeiter2.MitarbeiterNr; }
            }

            /// <summary>
            /// Vergleicht zwei GMTupeln miteinander
            /// </summary>
            /// <param name="vergleichswert">mit dieser GMTupel wird verglichen</param>
            /// <returns>true, wenn beide gleich sind; false, wenn nicht</returns>
            public bool IstGleich(GMTupel vergleichswert)
            {
                return (GehegeNummer == vergleichswert.GehegeNummer &&
                        Mitarbeiter1Nummer == vergleichswert.Mitarbeiter1Nummer &&
                        Mitarbeiter2Nummer == vergleichswert.Mitarbeiter2Nummer);
            }

            public override string ToString()
            {
                return $"GMTupel{{ Gehege={Gehege}, Mitarbeiter1={Mitarbeiter1}, Mitarbeiter2={Mitarbeiter2} }}";
            }
        }
    }



