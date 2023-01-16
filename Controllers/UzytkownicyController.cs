using Sklep.Models;
using System.Linq;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class UzytkownicyController : Controller
    {
        SklepDB_Entities koszykDBModel;
        public UzytkownicyController()
        {
            koszykDBModel = new SklepDB_Entities();
        }
        // GET: Szukaj
        public ActionResult Index()
        {
            return View(koszykDBModel.Uzytkownicy.ToList());
        }
    }
}