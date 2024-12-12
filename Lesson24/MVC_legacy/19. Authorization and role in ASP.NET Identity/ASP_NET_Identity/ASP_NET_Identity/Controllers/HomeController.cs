using System.Web;
using System.Web.Mvc;
using ASP_NET_Identity.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace ASP_NET_Identity.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
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

        public async Task<ActionResult> Index()
        {
            // Получим из БД пользователя, который прошел аутентификацию
            // Это возможно благодаря атрибуту  Authorize
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            return View(user);
        }
    }
}
