using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieParserLibrary
{
    public class SRU
    {
        private int SRUnumber;
        private int accountNumber;

        public int SRUNumber
        {
            get { return SRUnumber; }
            set
            {
                this.SRUnumber = value;
            }
        }

        public int AccountNr
        {
            get { return accountNumber; }
            set
            {
                this.accountNumber = value;
            }
        }

    }
}
