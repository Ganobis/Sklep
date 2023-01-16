using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sklep.ViewModel
{
    public class UzytkownikViewModel
    {
        public System.Guid UzytkownikID { get; set; }
        public string Mail { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public bool CzyKonto { get; set; }
        public bool CzyAdnim { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Haslo { get; set; }
        public string WiadomoscBledu { get; set; }
    }
}