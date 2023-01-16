using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.ViewModel
{
    public class ZamowienieViewModel
    {
        public string ZamowienieID { get; set; }
        public DateTime Data { get; set; }
        public Guid UzytkownikID { get; set; }
        public bool CzyZrealizowano { get; set; }
    }
}