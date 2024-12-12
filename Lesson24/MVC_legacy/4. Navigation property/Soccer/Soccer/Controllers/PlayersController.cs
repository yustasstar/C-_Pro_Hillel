using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Soccer.Models;

namespace Soccer.Controllers
{
    public class PlayersController : Controller
    {
        private SoccerInfoEntities db = new SoccerInfoEntities();

        //
        // GET: /Players/

        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Teams);
            return View(players.ToList());
        }

        //
        // GET: /Players/Details/5

        public ActionResult Details(int id = 0)
        {
            Players players = db.Players.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            return View(players);
        }

        //
        // GET: /Players/Create

        public ActionResult Create()
        {
            ViewBag.ListTeams = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        //
        // POST: /Players/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Players players)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(players);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListTeams = new SelectList(db.Teams, "Id", "Name", players.TeamId);
            return View(players);
        }

        //
        // GET: /Players/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Players players = db.Players.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListTeams = new SelectList(db.Teams, "Id", "Name", players.TeamId);
            return View(players);
        }

        //
        // POST: /Players/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Players players)
        {
            if (ModelState.IsValid)
            {
                db.Entry(players).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListTeams = new SelectList(db.Teams, "Id", "Name", players.TeamId);
            return View(players);
        }

        //
        // GET: /Players/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Players players = db.Players.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            return View(players);
        }

        //
        // POST: /Players/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Players players = db.Players.Find(id);
            db.Players.Remove(players);
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