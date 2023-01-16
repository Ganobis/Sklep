using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.ViewModel
{
    public class PrzedmiotViewModel
    {
        public System.Guid PrzedmiotID { get; set; }
        public int KategoriaID { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public HttpPostedFileBase Obrazek { get; set; }
        public decimal Cena { get; set; }
        public IEnumerable<SelectListItem> KategoriaSelectListItems { get; set; }
    }
}