using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASP_NET_Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace ASP_NET_Identity.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                // GetOwinContext() возвращает объект контекста OWIN API (IOwinContext).
                // IOwinContext позволяет получить экземпляр класса UserManager, используемый для управления пользователями
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, 
                                                             Email = model.Email, 
                                                             BirthYear = model.BirthYear,
                                                             City = model.City,
                                                             Country = model.Country };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded) // Возвращает значение true, если операция прошла успешно.
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    // Возвращает список ошибок в виде строк, которые могли возникнуть при выполнении операции.
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        // IAuthenticationManager для управления входом на сайт
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
                else
                {
                    // Утверждения (claims) - это дополнительная информация о пользователях, на основе которой можно принимать решения по авторизации.
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(); // удаляет аутентификационные куки
                    // SignIn создает аутентификационные куки
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true // позволяет сохранять аутентификационные данные даже после закрытия пользователем браузера
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                EditModel model = new EditModel { BirthYear = user.BirthYear, City = user.City, Country = user.Country };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
                if (user != null)
                {
                    user.BirthYear = model.BirthYear;
                    user.City = model.City;
                    user.Country = model.Country;
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error when editing a profile");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User is not found");
                }
            }
            return View(model);
        }
    }
}