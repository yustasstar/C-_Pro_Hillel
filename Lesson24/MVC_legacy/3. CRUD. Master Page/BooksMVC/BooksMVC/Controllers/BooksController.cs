using System.Data;
using System.Linq;
using System.Web.Mvc;
using BooksMVC.Models;

namespace BooksMVC.Controllers
{
    public class BooksController : Controller
    {
        private Database_BooksSQLEntities db = new Database_BooksSQLEntities();

        //
        // GET: /Books/

        public ActionResult Index()
        {
            return View(db.books.ToList());
        }

        //
        // GET: /Books/Details/5

        public ActionResult Details(int id = 0)
        {
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create

        [HttpPost]
        [ValidateAntiForgeryToken]// Этот атрибут помогает защититься от подделки межсайтовых запросов.
        public ActionResult Create(books books)
        {
            if (ModelState.IsValid)// Значение, указывающее наличие ошибок в объекте состояния модели
            {
                db.books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books);
        }

        //
        // GET: /Books/Edit/5

        public ActionResult Edit(int id = 0)
        {
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // POST: /Books/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]// Этот атрибут помогает защититься от подделки межсайтовых запросов.
        public ActionResult Edit(books books)
        {
            if (ModelState.IsValid)// Значение, указывающее наличие ошибок в объекте состояния модели
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        //
        // GET: /Books/Delete/5

        public ActionResult Delete(int id = 0)
        {
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // POST: /Books/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]// Этот атрибут помогает защититься от подделки межсайтовых запросов.
        public ActionResult DeleteConfirmed(int id)
        {
            books books = db.books.Find(id);
            db.books.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}