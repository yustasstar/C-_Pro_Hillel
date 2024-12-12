using System.Linq;
using Soccer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Soccer.Controllers
{
    public class TeamsController : Controller
    {
        SoccerContext db;

        public TeamsController(SoccerContext context)
        {
            db = context;
        }

        //
        // GET: /Teams/

        public IActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        //
        // GET: /Teams/Details/5

        public IActionResult Details(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams);
        }

        //
        // GET: /Teams/Create

        public IActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teams/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teams teams)
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

        public IActionResult Edit(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams);
        }

        //
        // POST: /Teams/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teams teams)
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

        public IActionResult Delete(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams);
        }

        //
        // POST: /Teams/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Teams teams = db.Teams.Find(id);
            db.Teams.Remove(teams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}