using System.Web.Mvc;
using Session.Models;

namespace Session.Controllers
{
    public class LoginController : Controller
    {
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid)
            {
                Session["login"] = login.UserName; // создание сессионной переменной
                Session.Timeout = 10; // Длительность сеанса (тайм-аут завершения сеанса)
                //return Redirect("/Home/Index");
                return RedirectToAction("Index","Home");
            }
            return View(login);
        }
    }
}