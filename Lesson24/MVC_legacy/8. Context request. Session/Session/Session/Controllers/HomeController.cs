using System.Web.Mvc;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Create", "Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon(); // завершается сессия
            // Session["login"] = null; // уничтожается только одна сессионная переменная
            return RedirectToAction("Create", "Login");
        }
    }
}