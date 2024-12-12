using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MultilingualSite.Filters;
using MultilingualSite.Models;

namespace MultilingualSite.Controllers
{
     [Culture]
    public class ClubController : Controller
    {
        ClubContext cc = new ClubContext();

        public ActionResult Index()
        {
            return View(cc.Clubs);
        }

        [HttpGet]
        public ActionResult CreateClub()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClub(Club club)
        {
            if (ModelState.IsValid)
            {
                cc.Clubs.Add(club);
                cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en", "uk", "de" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

    }
}
