using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using ManyToManyExample1.Models;

namespace ManyToManyExample1.Controllers
{
    public class ContinentController : Controller
    {
        private LanguageContext db = new LanguageContext();

        //
        // GET: /Continent/

        public ActionResult Index()
        {
            return View(db.Continents.ToList());
        }

        //
        // GET: /Continent/Details/5

        public ActionResult Details(int id = 0)
        {
            Continent continent = db.Continents.Find(id);
            if (continent == null)
            {
                return HttpNotFound();
            }
            return View(continent);
        }

        //
        // GET: /Continent/Create

        public ActionResult Create()
        {
            ViewBag.Languages = db.Languages.ToList();
            return View();
        }

        //
        // POST: /Continent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Continent continent, string[] selectedLanguages)
        {
            if (ModelState.IsValid)
            {
                if (selectedLanguages != null)
                {
                    continent.Languages = new List<Language>();
                    foreach (var lang in db.Languages)
                    {
                        if (selectedLanguages.Contains(lang.Id.ToString()))
                        {
                            continent.Languages.Add(lang);
                        }
                    }
                }
                db.Continents.Add(continent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(continent);
        }

        //
        // GET: /Continent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Continent continent = db.Continents.Find(id);
            if (continent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Languages = db.Languages.ToList();
            return View(continent);
        }

        //
        // POST: /Continent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Continent continent, string[] selectedLanguages)
        {
            if (ModelState.IsValid)
            {
                Continent newContinent = db.Continents.Find(continent.Id);
                newContinent.Name = continent.Name;

                if (selectedLanguages != null)
                {
                    var languagesContinents = new HashSet<int>(newContinent.Languages.Select(lang => lang.Id));
                    foreach (var lang in db.Languages)
                    {
                        if (selectedLanguages.Contains(lang.Id.ToString()))
                        {
                            if (!languagesContinents.Contains(lang.Id))
                                newContinent.Languages.Add(lang);
                        }
                        else
                        {
                            if (languagesContinents.Contains(lang.Id))
                                newContinent.Languages.Remove(lang);
                        }
                    }
                }
                else
                {
                    newContinent.Languages.Clear();
                }

                db.Entry(newContinent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(continent);
        }

        //
        // GET: /Continent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Continent continent = db.Continents.Find(id);
            if (continent == null)
            {
                return HttpNotFound();
            }
            return View(continent);
        }

        //
        // POST: /Continent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Continent continent = db.Continents.Find(id);
            db.Continents.Remove(continent);
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