using System.Linq;
using System.Web.Mvc;
using AjaxMvcApplication.Models;

namespace AjaxMvcApplication.Controllers
{
    public class BookController : Controller
    {
        Database_BooksEntities db = new Database_BooksEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string name)
        {
            var allbooks = db.books.Where(a => a.Author.Contains(name)).ToList();
            return PartialView(allbooks);
        }

        public ActionResult OldBook()
        {
            book b = db.books.Where(a => a.YearPress < 2000).ToList().First();
            return PartialView(b);
        }

    }
}
