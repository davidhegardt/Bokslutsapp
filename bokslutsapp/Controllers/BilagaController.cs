using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bokslutsapp.Models;

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
            return new List<_1930Bank> {
            new _1930Bank { Id = 1, Beskrivning = "Affärskonto SHB-590123123", Konto = 1930, Ks = 1, Pr = 1, Belopp = 127374.58f },
            new _1930Bank { Id = 2, Beskrivning = "Sparkonto SHB-590456123", Konto = 1931, Ks = 1, Pr = 1, Belopp = 567374.20f },
            new _1930Bank { Id = 3, Beskrivning = "Sparkonto SHB-59789456", Konto = 1932, Ks = 1, Pr = 1, Belopp = 7374.78f },
            new _1930Bank { Id = 4, Beskrivning = "Placeringskonto Avanza", Konto = 1933, Ks = 1, Pr = 1, Belopp = 84380.23f }
            };
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
    }
}