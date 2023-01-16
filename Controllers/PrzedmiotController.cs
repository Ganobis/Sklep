using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sklep.Models;
using Sklep.ViewModel;

namespace Sklep.Controllers
{
    public class PrzedmiotController : Controller
    {
        private SklepDB_Entities koszykDBModel;
        public PrzedmiotController()
        {
            koszykDBModel = new SklepDB_Entities();
        }
        // GET: Przedmiot
        public ActionResult Index()
        {
            PrzedmiotViewModel przedmiotViewModel = new PrzedmiotViewModel();
            przedmiotViewModel.KategoriaSelectListItems = (from obj in koszykDBModel.Kategorie
                                                           select new SelectListItem()
                                                           {
                                                               Text = obj.KategoriaNazwa,
                                                               Value = obj.KategoriaID.ToString(),
                                                               Selected = true
                                                           });
            return View(przedmiotViewModel);
        }

        [HttpPost]
        public JsonResult Index(PrzedmiotViewModel przedmiotViewModel)
        {
            string NewImage = Guid.NewGuid() + Path.GetExtension(przedmiotViewModel.Obrazek.FileName);
            przedmiotViewModel.Obrazek.SaveAs(Server.MapPath("~/Images/" + NewImage));

            Przedmioty przedmiot = new Przedmioty();
            przedmiot.PrzedmiotID = Guid.NewGuid();
            przedmiot.KategoriaID = przedmiotViewModel.KategoriaID;
            przedmiot.Kod = przedmiotViewModel.Kod;
            przedmiot.Nazwa = przedmiotViewModel.Nazwa;
            przedmiot.Opis = przedmiotViewModel.Opis;
            przedmiot.Obrazek = "~/Images/" + NewImage ;
            przedmiot.Cena = przedmiotViewModel.Cena;

            koszykDBModel.Przedmioty.Add(przedmiot);
            koszykDBModel.SaveChanges();

            return Json(new { Zakonczono = true, Wiadomosc = "Dodano przedmiot"}, JsonRequestBehavior.AllowGet);
        }
    }
}