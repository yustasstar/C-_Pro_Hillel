using System.Linq;
using System.Web.Mvc;
using AjaxMvcApplication.Models;

namespace AjaxMvcApplication.Controllers
{
    public class BookController : Controller
    {
        Database_BooksSQLEntities1 db = new Database_BooksSQLEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult JsonSearch(string name)
        {
            // {"Name":"SQL", "Author":"Гроф", "YearPress":"2010"}.
            var jsondata = db.books.Where(a => a.Author.Contains(name)).ToList();
            return Json(jsondata , JsonRequestBehavior.DenyGet);
        }

    }
}
