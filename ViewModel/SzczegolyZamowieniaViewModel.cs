using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.ViewModel
{
    public class SzczegolyZamowieniaViewModel
    {
        public int SzczegolyZamownieniaID { get; set; }
        public string ZamownienieID { get; set; }
        public string PrzedmiotID { get; set; }
        public decimal Ilosc { get; set; }
        public decimal Cena { get; set; }
        public decimal Calosc { get; set; }
    }
}