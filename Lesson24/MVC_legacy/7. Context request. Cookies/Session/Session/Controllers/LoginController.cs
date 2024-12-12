using System;
using System.Web;
using System.Web.Mvc;
using Session.Models;
using System.Text;

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
                byte[] def = Encoding.Default.GetBytes(login.UserName);
                // Преобразуем массив 8-разрядных целых чисел без знака в эквивалентное строковое 
                // представление, состоящее из цифр в кодировке Base64.
                string str = Convert.ToBase64String(def);
                HttpCookie cookie = new HttpCookie("login", str); // создание куки
                cookie.Expires = DateTime.Now.AddDays(10); // срок хранения куки - 10 дней
                Response.Cookies.Add(cookie);
                //return Redirect("/Home/Index");
                return RedirectToAction("Index","Home");
            }
            return View(login);
        }
    }
}