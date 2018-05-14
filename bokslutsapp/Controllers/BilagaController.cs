using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bokslutsapp.Models;
using SieParserLibrary;

namespace Bokslutsapp.Controllers
{
    public class BilagaController : Controller
    {
        // GET: Bilaga
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bank()
        {
            var Bilagor = GetBilagor();            
            return View(Bilagor);
        }

        private IEnumerable<_1930Bank> GetBilagor()
        {
            SieManager manager = new SieManager();
            var root = AppDomain.CurrentDomain.BaseDirectory;
            string path = root + "/Assets/test.se";            
            List<Konto> kontoLista = manager.getKontoList(path);
            int currId = 0;
            List<_1930Bank> bankLista = new List<_1930Bank>();
            
            foreach (Konto k in kontoLista)
            {
                currId++;
                _1930Bank newBank = new _1930Bank();
                newBank.Konto = k.Kontonummer;
                newBank.Beskrivning = k.Kontonamn;
                newBank.Belopp = 1237374.58f;
                newBank.Id = currId;
                newBank.Ks = 1;
                newBank.Pr = 1;
                bankLista.Add(newBank);
            }
            
            return bankLista;
            /*
            return new List<_1930Bank> {
            new _1930Bank { Id = 1, Beskrivning = "Affärskonto SHB-590123123", Konto = 1930, Ks = 1, Pr = 1, Belopp = 127374.58f },
            new _1930Bank { Id = 2, Beskrivning = "Sparkonto SHB-590456123", Konto = 1931, Ks = 1, Pr = 1, Belopp = 567374.20f },
            new _1930Bank { Id = 3, Beskrivning = "Sparkonto SHB-59789456", Konto = 1932, Ks = 1, Pr = 1, Belopp = 7374.78f },
            new _1930Bank { Id = 4, Beskrivning = "Placeringskonto Avanza", Konto = 1933, Ks = 1, Pr = 1, Belopp = 84380.23f }
            };
            */

            // comment
        }

        public ActionResult Skatt()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult Värdepapper()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult BilagaUtanMoms()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult Lager()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult Periodiseringar()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult EgetKapital()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult Kassa()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }

        public ActionResult UnderbilagaSkatt()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }
    }
}