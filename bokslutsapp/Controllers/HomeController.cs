﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using SieParserLibrary;
using Bokslutsapp.Models;

namespace Bokslutsapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Kontologik()
        {
            var Bilagor = GetBilagor();
            return View(Bilagor);
        }
        
        public ActionResult Huvudbok(string konto, string ks,string pr,string beskrivning, string verifikation,string datum,string belopp)
        {
            var Bilagor = GetBilagor();
            if (!String.IsNullOrEmpty(konto)) { Bilagor = searchKonto(konto); } else if (!String.IsNullOrEmpty(ks)) { Bilagor = searchKS(ks); }
            else if (!String.IsNullOrEmpty(pr)) { Bilagor = searchPR(pr); } else if (!String.IsNullOrEmpty(beskrivning)) { Bilagor = searchBeskrivning(beskrivning); }
            else if (!String.IsNullOrEmpty(verifikation)) { Bilagor = searchVerfikation(verifikation); } else if (!String.IsNullOrEmpty(datum)) { Bilagor = searchDatum(datum); }
            else if (!String.IsNullOrEmpty(belopp)) { searchBelopp(belopp); }

            /*
            if (!String.IsNullOrEmpty(konto))
            {
                int nummer;
                DateTime tryTime;
                if(Int32.TryParse(konto, out nummer))
                {
                    Bilagor = Bilagor.Where(s => s.Konto == nummer);
                } else if(DateTime.TryParse(konto, out tryTime))
                {
                    Bilagor = Bilagor.Where(d => d.Datum.Equals(tryTime));
                }
                else
                {
                        Bilagor = Bilagor.Where(n => n.Beskrivning.ToLower().Contains(konto.ToLower()));
                }
                 
            }
            */
            if(Bilagor == null)
            {
               Bilagor = new List<_1930Bank>();
            }
            ViewBag.AccountList = Bilagor;

            return View(Bilagor);
        }

        private IEnumerable<_1930Bank> searchKonto(string kontoString)
        {
            int konto;
            var Bilagor = GetBilagor();
            if (Int32.TryParse(kontoString, out konto))
            {
                Bilagor = Bilagor.Where(s => s.Konto == konto);
            }

            return Bilagor;
        }

        private IEnumerable<_1930Bank> searchDatum(string dateString)
        {
            DateTime tryTime;
            var Bilagor = GetBilagor();
            if (DateTime.TryParse(dateString, out tryTime))
            {
                Bilagor = Bilagor.Where(d => d.Datum.Equals(tryTime));
            }

            return Bilagor;
        }

        private IEnumerable<_1930Bank> searchBeskrivning (string desc)
        {
            var Bilagor = GetBilagor();

            Bilagor = Bilagor.Where(n => n.Beskrivning.ToLower().Contains(desc.ToLower()));

            return Bilagor;
        }

        private IEnumerable<_1930Bank> searchKS(string ksString)
        {
            var Bilagor = GetBilagor();
            int ksNumber;
            if(Int32.TryParse(ksString, out ksNumber))
            {
                Bilagor = Bilagor.Where(k => k.Ks == ksNumber);
            }

            return Bilagor;
            
        }

        private IEnumerable<_1930Bank> searchPR(string prString)
        {
            var Bilagor = GetBilagor();
            int prNumber;
            if(Int32.TryParse(prString, out prNumber))
            {
                Bilagor = Bilagor.Where(p => p.Pr == prNumber);
            }

            return Bilagor;
        }

        private IEnumerable<_1930Bank> searchBelopp(string beloppString)
        {
            var Bilagor = GetBilagor();
            float belopp;
            if (float.TryParse(beloppString,NumberStyles.Number,CultureInfo.InvariantCulture, out belopp))
            {
                Bilagor = Bilagor.Where(b => Math.Abs(b.Belopp) == Math.Abs(belopp));
            }

            return Bilagor;
        }

        private IEnumerable<_1930Bank> searchVerfikation(string verifikation)
        {
            var Bilagor = GetBilagor();
            var parts = verifikation.ToCharArray();
            string serie = parts[0].ToString();
            int verNr;
            if(Int32.TryParse(parts[1].ToString(),out verNr))
            {
                Bilagor = Bilagor.Where(bank => bank.Serie.Equals(serie) && bank.VerifikationNr == verNr);
            }

            return Bilagor;
        }
        

        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            var Bilagor = GetBilagor();
            int nummer = Int32.Parse(Prefix);
            //var resultList = Bilagor.Where(s => s.Konto == nummer);            
            var resultList = (from N in Bilagor where N.Konto.ToString().StartsWith(Prefix) select new { N.Konto });

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetSearchRecord(string name)
        {
            var Bilagor = GetBilagor();
            if (!String.IsNullOrEmpty(name))
            {
                int nummer;
                DateTime tryTime;
                if (Int32.TryParse(name, out nummer))
                {
                    Bilagor = Bilagor.Where(s => s.Konto == nummer);
                }
                else if (DateTime.TryParse(name, out tryTime))
                {
                    Bilagor = Bilagor.Where(d => d.Datum.Equals(tryTime));
                }
                else
                {
                    Bilagor = Bilagor.Where(n => n.Beskrivning.ToLower().Contains(name.ToLower()));
                }

            }

            ViewBag.AccountList = Bilagor;

            return View(Bilagor);
        }

        /*
        public ActionResult Huvudbok()
        {

        }
        */

        private IEnumerable<_1930Bank> GetBilagor()
        {
            SieManager manager = new SieManager();
            var root = AppDomain.CurrentDomain.BaseDirectory;
            string path = root + "/Assets/test.se";
            List<Konto> kontoLista = manager.getKontoList(path);
            var verifikationer = manager.setupVerifications(path);
            var transaktioner = manager.getTransactions();
            

            int currId = 0;
            List<_1930Bank> bankLista = new List<_1930Bank>();
            foreach (Transaktion t in transaktioner)
            {
                if (t.AccountNr != 0)
                {
                    currId++;

                    _1930Bank newBank = new _1930Bank();
                    newBank.Konto = t.AccountNr;
                    if (t.verPost != null)
                    {
                        newBank.Beskrivning = t.getTransText();
                        newBank.VerifikationNr = t.verPost.VerNr;
                        newBank.Serie = t.verPost.Serie;
                        newBank.Datum = t.verPost.VerDatum;
                    }
                    else newBank.Beskrivning = "Beskrivning saknas";
                    newBank.Belopp = t.Belopp;
                    newBank.Id = currId;
                    //newBank.Pr = t.DimensionNr;
                    newBank.Ks = t.ObjektNr;
                    bankLista.Add(newBank);
                }
                //bankLista.Where(p => p.Beskrivning.Contains("Konto") && p.Belopp != 0); EXEMPEL PÅ LINQ sökning / filtrering
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
            
        }

        public string getKostnadStälle(int objektNr)
        {
            string returnValue = "";
            switch (objektNr)
            {
                case 1: returnValue = "Bolaget";
                    break;
                case 2: returnValue = "Affärsområde logistik";
                    break;
                case 3: returnValue = "Affärsområde farligt gods";
                    break;
                case 4: returnValue = "Redovisning";
                    break;
            }

            return returnValue;
        }
    }
}