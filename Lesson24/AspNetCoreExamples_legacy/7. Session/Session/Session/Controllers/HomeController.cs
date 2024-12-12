using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Create", "Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear(); // очищается сессия
            return RedirectToAction("Create", "Login");
        }
    }
}
