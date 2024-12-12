using System.Data;
using System.Linq;
using System.Web.Mvc;
using Soccer.Models;

namespace Soccer.Controllers
{
    public class TeamsController : Controller
    {
        private SoccerInfoEntities db = new SoccerInfoEntities();

        //
        // GET: /Teams/

        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        //
        // GET: /Teams/Details/5

        public ActionResult Details(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        //
        // GET: /Teams/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teams/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teams);
        }

        //
        // GET: /Teams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        //
        // POST: /Teams/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teams);
        }

        //
        // GET: /Teams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        //
        // POST: /Teams/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teams teams = db.Teams.Find(id);
            db.Teams.Remove(teams);
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