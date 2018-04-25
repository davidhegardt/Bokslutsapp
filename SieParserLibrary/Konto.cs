using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieParserLibrary
{
    public class Konto
    {
        private int kontoNummer;
        private string kontoNamn;
        private int SRUnummer;

        public int SRUnumber
        {
            get { return SRUnummer; }
            set
            {
                this.SRUnummer = value;
            }
        }

        /* Get och set-funktioner för variabler */
        public string Kontonamn
        {
            get { return kontoNamn; }
            set
            {
                this.kontoNamn = value;
            }
        }

        public int Kontonummer
        {
            get { return kontoNummer; }
            set
            {
                this.kontoNummer = value;
            }
        }
    }
}
