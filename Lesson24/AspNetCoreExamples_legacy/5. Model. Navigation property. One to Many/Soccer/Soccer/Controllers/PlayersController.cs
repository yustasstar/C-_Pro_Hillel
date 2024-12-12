using System.Linq;
using Soccer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Soccer.Controllers
{
    public class PlayersController : Controller
    {
        SoccerContext db;

        public PlayersController(SoccerContext context)
        {
            db = context;
        }

        //
        // GET: /Players/

        public IActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        //
        // GET: /Players/Details/5

        public IActionResult Details(int id = 0)
        {
            var players = db.Players.Find(id);         
            if (players == null)
            {
                return NotFound();
            }
            ViewBag.TeamName = db.Teams.Find(players.TeamId).Name;
            return View(players);
        }

        //
        // GET: /Players/Create

        public IActionResult Create()
        {
            ViewBag.ListTeams = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        //
        // POST: /Players/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Players players)
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

        public IActionResult Edit(int id = 0)
        {
            Players players = db.Players.Find(id);
            if (players == null)
            {
                return NotFound();
            }
            ViewBag.ListTeams = new SelectList(db.Teams, "Id", "Name", players.TeamId);
            return View(players);
        }

        //
        // POST: /Players/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Players players)
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

        public IActionResult Delete(int id = 0)
        {
            Players players = db.Players.Find(id);
            if (players == null)
            {
                return NotFound();
            }
            return View(players);
        }

        //
        // POST: /Players/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Players players = db.Players.Find(id);
            db.Players.Remove(players);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}