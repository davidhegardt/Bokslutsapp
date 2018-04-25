using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieParserLibrary
{
    public class Skattepost
    {
        private int id;
        private DateTime datum;
        private String title;
        private int summa;

        public Skattepost(int id, DateTime datum, string title)
        {
            this.id = id;
            this.datum = datum;
            this.title = title;
        }

        public Skattepost(DateTime datum, string title, int summa)
        {
            this.datum = datum;
            this.title = title;
            this.summa = summa;
        }

        public Skattepost(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public Skattepost(int id, DateTime datum, string title, int summa) : this(id, datum, title)
        {
            this.summa = summa;
        }

        public int ID
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        public DateTime Datum
        {
            get { return this.datum; }
            set
            {
                this.datum = value;
            }
        }

        public String Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
            }
        }

        public int Summa
        {
            get { return this.summa; }
            set
            {
                this.summa = value;
            }
        }
    }
}
