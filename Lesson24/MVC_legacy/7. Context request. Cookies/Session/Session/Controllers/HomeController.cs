using System;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.Cookies["login"] == null)
            {
                return RedirectToAction("Create", "Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["login"];
            cookie.Expires = DateTime.Now.AddDays(-1); // удаление куки
            Response.Cookies.Add(cookie);
            return RedirectToAction("Create", "Login");
        }
    }
}