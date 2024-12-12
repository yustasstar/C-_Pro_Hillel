﻿using Microsoft.AspNetCore.Mvc;

namespace Cookie.Controllers
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
            Response.Cookies.Delete("login"); // удаление куки
            return RedirectToAction("Create", "Login");
        }
    }
}
