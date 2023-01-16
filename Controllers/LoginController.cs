using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sklep.Models;
using Sklep.ViewModel;

namespace Sklep.Controllers
{
    public class LoginController : Controller
    {
        private SklepDB_Entities koszykDBModel;
        public LoginController()
        {
            koszykDBModel = new SklepDB_Entities();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autoryzuj(UzytkownikViewModel uzytkownikViewModel)
        {
            var daneUzytkownika = koszykDBModel.Uzytkownicy.Where(x => x.Mail == uzytkownikViewModel.Mail && x.Haslo == uzytkownikViewModel.Haslo).FirstOrDefault();
            if (daneUzytkownika == null)
            {
                uzytkownikViewModel.WiadomoscBledu = "Złe hasło lub login!";
                return View("Index", uzytkownikViewModel);
            }
            else
            {
                Session["UzytkownikID"] = daneUzytkownika.UzytkownikID;
                Session["UzytkownikMail"] = daneUzytkownika.Mail;
                if (daneUzytkownika.CzyAdmin == true)
                    Session["UzytkownikAdmin"] = true;
                else
                    Session["UzytkownikAdmin"] = null;
                Session["LicznikKoszya"] = null;
                Session["PrzedmiotKoszyka"] = null;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult LogOut()
        {
            Session["UzytkownikID"] = null;
            Session["UzytkownikMail"] = null;
            Session["UzytkownikAdmin"] = null;
            Session["LicznikKoszya"] = null;
            Session["PrzedmiotKoszyka"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult EdytujKonto()
        {
            return View();
        }
        [HttpPost]
        public JsonResult EdytujKonto(UzytkownikViewModel uzytkownikViewModel)
        {
            Uzytkownicy uzytkownik = new Uzytkownicy();
            uzytkownik.UzytkownikID = Guid.NewGuid();
            uzytkownik.Mail = uzytkownikViewModel.Mail;
            uzytkownik.Imie = uzytkownikViewModel.Imie;
            uzytkownik.Nazwisko = uzytkownikViewModel.Nazwisko;
            uzytkownik.Telefon = uzytkownikViewModel.Telefon;
            uzytkownik.Miasto = uzytkownikViewModel.Miasto;
            uzytkownik.Ulica = uzytkownikViewModel.Ulica;
            uzytkownik.CzyAdmin = false;
            uzytkownik.CzyKonto = true;
            uzytkownik.Haslo = uzytkownikViewModel.Haslo;

            koszykDBModel.Uzytkownicy.Add(uzytkownik);
            koszykDBModel.SaveChanges();

            return Json(new { Zakonczono = true, Wiadomosc = "Dodano konto" }, JsonRequestBehavior.AllowGet);
        }
    }
}