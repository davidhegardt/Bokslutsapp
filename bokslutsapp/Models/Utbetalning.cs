using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bokslutsapp.Models
{
    public class Utbetalning
    {
        public String datum { get; set; }
        public String referens { get; set; }
        public String titel { get; set; }
        public String konto { get; set; }
        public String belopp { get; set; }
    }
}