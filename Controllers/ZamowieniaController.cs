using Sklep.Models;
using Sklep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class ZamowieniaController : Controller
    {
        SklepDB_Entities koszykDBModel;
        public ZamowieniaController()
        {
            koszykDBModel = new SklepDB_Entities();
        }
        public ActionResult Index()
        {
            return View(koszykDBModel.Zamowienia.ToList());
        }

        [HttpPost]
        public JsonResult Index(string zamowienieID)
        {
            Zamowienia zamowienie = koszykDBModel.Zamowienia.Find(zamowienieID);
            zamowienie.CzyZrealizowano = true;
            koszykDBModel.SaveChanges();

            return Json(new { Sukces = true }, JsonRequestBehavior.AllowGet);
        }
    }
}