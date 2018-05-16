using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bokslutsapp;
using Bokslutsapp.Models;

namespace Bokslutsapp.Viewmodels
{
    public class BilagaBilagorViewModel
    {
        public _1930Bank SingleBank { get; set; }
        public IEnumerable<_1930Bank> AllBanks { get; set; }
    }
}