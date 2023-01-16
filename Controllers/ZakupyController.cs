using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sklep.Models;
using Sklep.ViewModel;

namespace Sklep.Controllers
{
    public class ZakupyController : Controller
    {
        private SklepDB_Entities koszykDBModel;
        private List<KoszykViewModel> listaKoszykViewModel;
        public ZakupyController()
        {
            koszykDBModel = new SklepDB_Entities();
            listaKoszykViewModel = new List<KoszykViewModel>();
        }
        // GET: Koszyk
        public ActionResult Index()
        {
            IEnumerable<ZakupyViewModel> listakoszykViewModels = (from objItem in koszykDBModel.Przedmioty
                                                                  join
                                                                      objCate in koszykDBModel.Kategorie
                                                                      on objItem.KategoriaID equals objCate.KategoriaID
                                                                  select new ZakupyViewModel()
                                                                  {
                                                                      PrzedmiotID = objItem.PrzedmiotID,
                                                                      Nazwa = objItem.Nazwa,
                                                                      Cena = objItem.Cena,
                                                                      Obrazek = objItem.Obrazek,
                                                                      Opis = objItem.Opis
                                                                  }

                ).ToList();
            return View(listakoszykViewModels);
        }
        [HttpPost]
        public JsonResult Index(string przedmiotID)
        {
            KoszykViewModel koszykViewModel = new KoszykViewModel();
            Przedmioty przedmiot = koszykDBModel.Przedmioty.Single(model => model.PrzedmiotID.ToString() == przedmiotID);
            if (Session["LicznikKoszya"] != null)
            {
                listaKoszykViewModel = Session["PrzedmiotKoszyka"] as List<KoszykViewModel>;
            }
            if (listaKoszykViewModel.Any(model => model.PrzedmiotID == przedmiotID))
            {
                koszykViewModel = listaKoszykViewModel.Single(model => model.PrzedmiotID == przedmiotID);
                koszykViewModel.Ilosc = koszykViewModel.Ilosc + 1;
                koszykViewModel.Calosc = koszykViewModel.Cena * koszykViewModel.Ilosc;
            }
            else
            {
                koszykViewModel.PrzedmiotID = przedmiotID;
                koszykViewModel.Nazwa = przedmiot.Nazwa;
                koszykViewModel.Obrazek = przedmiot.Obrazek;
                koszykViewModel.Cena = przedmiot.Cena;
                koszykViewModel.Ilosc = 1;
                koszykViewModel.Calosc = przedmiot.Cena;
                listaKoszykViewModel.Add(koszykViewModel);
            }
            Session["LicznikKoszya"] = listaKoszykViewModel.Count;
            Session["PrzedmiotKoszyka"] = listaKoszykViewModel;
            return Json(new { Sukces = true, Licznik = listaKoszykViewModel.Count }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Koszyk()
        {
            listaKoszykViewModel = Session["PrzedmiotKoszyka"] as List<KoszykViewModel>;
            return View(listaKoszykViewModel);
        }
        [HttpPost]
        public ActionResult DodajZamowienieSesja()
        {
            string zamowienieID;
            listaKoszykViewModel = Session["PrzedmiotKoszyka"] as List<KoszykViewModel>;
            Zamowienia zamowienie = new Zamowienia()
            {
                Data = DateTime.Now,
                ZamowienieID = String.Format("{0:ddmmyyyyHHmmss}", DateTime.Now),
                UzytkownikID = Guid.Parse(Session["UzytkownikID"].ToString()),
                CzyZrealizowano = false
        };
            koszykDBModel.Zamowienia.Add(zamowienie);
            koszykDBModel.SaveChanges();
            zamowienieID = zamowienie.ZamowienieID;

            foreach (var przedmiot in listaKoszykViewModel)
            {
                SzczegolyZamownienia szczegolyZamowieniaViewModel = new SzczegolyZamownienia()
                {
                    ZamownienieID = zamowienieID,
                    PrzedmiotID = przedmiot.PrzedmiotID,
                    Ilosc = przedmiot.Ilosc,
                    Cena = przedmiot.Cena,
                    Calosc = przedmiot.Calosc
                };
                koszykDBModel.SzczegolyZamownienia.Add(szczegolyZamowieniaViewModel);
                koszykDBModel.SaveChanges();
            }
            Session["PrzedmiotKoszyka"] = null;
            Session["LicznikKoszya"] = null;
            return RedirectToAction("Index");
        }
    }
}