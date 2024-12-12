using System.Collections.Generic;
using System.Web.Mvc;
using JQGridApp.Models;
using Newtonsoft.Json;

namespace JQGridApp.Controllers
{
    //http://www.trirand.com/blog/?page_id=6
    //http://www.trirand.com/jqgridwiki/doku.php?id=wiki:options
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
            clubs.Add(new Club { Id = 8, Name = "Карпаты", City = "Львов", Country = "Украина", FoundationYear = 1953 });
            clubs.Add(new Club { Id = 9, Name = "Сталь", City = "Каменское", Country = "Украина", FoundationYear = 1926 });
            clubs.Add(new Club { Id = 10, Name = "Волынь", City = "Луцк", Country = "Украина", FoundationYear = 1960 });
            clubs.Add(new Club { Id = 11, Name = "Ворскла", City = "Полтава", Country = "Украина", FoundationYear = 1955 });
            clubs.Add(new Club { Id = 12, Name = "Зирка", City = "Кропивницкий", Country = "Украина", FoundationYear = 1911 });
        }
        public ActionResult Index()
        {
            return View();
        }

        public string GetData()
        {
            return JsonConvert.SerializeObject(clubs);
        }
    }
}