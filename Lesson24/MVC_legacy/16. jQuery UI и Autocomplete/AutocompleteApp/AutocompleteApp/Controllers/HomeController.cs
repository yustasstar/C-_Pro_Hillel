using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutocompleteApp.Models;

namespace AutocompleteApp.Controllers
{
    public class HomeController : Controller
    {
        static List<Club> clubs = new List<Club>();

        static HomeController()
        {
            clubs.Add(new Club { Id = 1, Name = "Черноморец", City = "Одесса", Country = "Украина", FoundationYear = 1936 });
            clubs.Add(new Club { Id = 2, Name = "Динамо", City = "Киев", Country = "Украина", FoundationYear = 1927 });
            clubs.Add(new Club { Id = 3, Name = "Шахтер", City = "Донецк", Country = "Украина", FoundationYear = 1936 });
            clubs.Add(new Club { Id = 4, Name = "Заря", City = "Луганск", Country = "Украина", FoundationYear = 1923 });
            clubs.Add(new Club { Id = 5, Name = "Олимпик", City = "Донецк", Country = "Украина", FoundationYear = 2001 });
            clubs.Add(new Club { Id = 6, Name = "Александрия", City = "Александрия", Country = "Украина", FoundationYear = 1948 });
            clubs.Add(new Club { Id = 7, Name = "Днепр", City = "Днепр", Country = "Украина", FoundationYear = 1918 });
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var models = clubs.Where(a => a.Name.Contains(term))
                            .Select(a => new { value = a.Name })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}