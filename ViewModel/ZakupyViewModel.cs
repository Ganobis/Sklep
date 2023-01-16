using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.ViewModel
{
    public class ZakupyViewModel
    {
        public System.Guid PrzedmiotID { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public string Obrazek { get; set; }
        public string Opis { get; set; }
    }
}