using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.ViewModel
{
    public class KoszykViewModel
    {
        public string PrzedmiotID { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }
        public decimal Calosc { get; set; }
        public string Obrazek { get; set; }
    }
}