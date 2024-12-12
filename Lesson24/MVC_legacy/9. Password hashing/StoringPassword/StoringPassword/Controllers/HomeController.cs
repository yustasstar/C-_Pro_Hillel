using System.Web.Mvc;

namespace StoringPassword.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LastName"] != null && Session["FirstName"] != null)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        public ActionResult Logout()
        {
            Session.Abandon(); // завершается сессия
            return RedirectToAction("Login", "Account");
        }
    }
}