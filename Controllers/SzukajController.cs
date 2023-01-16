
using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class SzukajController : Controller
    {
        SklepDB_Entities koszykDBModel;
        public SzukajController()
        {
            koszykDBModel = new SklepDB_Entities();
        }
        // GET: Szukaj
        public ActionResult Index(string fraza)
        {
            return View(koszykDBModel.Przedmioty.Where(x => x.Nazwa.Contains(fraza) || fraza == null).ToList());
        }
    }
}