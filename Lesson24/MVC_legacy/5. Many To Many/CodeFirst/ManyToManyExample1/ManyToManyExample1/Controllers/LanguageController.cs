using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManyToManyExample1.Models;

namespace ManyToManyExample1.Controllers
{
    public class LanguageController : Controller
    {
        private LanguageContext db = new LanguageContext();

        //
        // GET: /Language/

        public ActionResult Index()
        {
            return View(db.Languages.ToList());
        }

        //
        // GET: /Language/Details/5

        public ActionResult Details(int id = 0)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        //
        // GET: /Language/Create

        public ActionResult Create()
        {
            ViewBag.Continents = db.Continents.ToList();
            return View();
        }

        //
        // POST: /Language/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Language language, string[] selectedContinents)
        {
            if (ModelState.IsValid)
            {
                // проверяем на наличие в массиве continents идентификаторов континентов
                if (selectedContinents != null)
                {
                    language.Continents = new List<Continent>();
                    foreach (var c in db.Continents)
                    {
                        if (selectedContinents.Contains(c.Id.ToString()))
                        {
                            language.Continents.Add(c);
                        }
                    }
                }
                db.Languages.Add(language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        //
        // GET: /Language/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            ViewBag.Continents = db.Continents.ToList();
            return View(language);
        }

        //
        // POST: /Language/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Language language, string[] selectedContinents)
        {
            if (ModelState.IsValid)
            {
                Language newLanguage = db.Languages.Find(language.Id);
                newLanguage.Name = language.Name;

                // проверяем на наличие в массиве continents идентификаторов континентов
                if (selectedContinents != null)
                {
                    var languagesContinents = new HashSet<int>(newLanguage.Continents.Select(c => c.Id));
                    foreach (var c in db.Continents)
                    {
                        if (selectedContinents.Contains(c.Id.ToString()))
                        {
                            if (!languagesContinents.Contains(c.Id))
                                newLanguage.Continents.Add(c);
                        }
                        else
                        {
                            if (languagesContinents.Contains(c.Id))
                                newLanguage.Continents.Remove(c);
                        }
                    }
                }
                else
                {
                    newLanguage.Continents.Clear();
                }

                db.Entry(newLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        //
        // GET: /Language/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        //
        // POST: /Language/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
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