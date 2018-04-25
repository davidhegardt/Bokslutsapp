using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bokslutsapp.Views.Register
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Anläggningsregister()
        {
            return View();
        }

        public ActionResult Värdepappersregister()
        {
            return View();
        }

        public ActionResult Periodiseringsregister()
        {
            return View();
        }
    }
}