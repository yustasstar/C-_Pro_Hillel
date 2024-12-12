using Microsoft.Owin;
using Owin;
using ASP_NET_Identity.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

// класс запуска приложения OWIN, в котором определяются компоненты конвейера приложения
[assembly: OwinStartup(typeof(ASP_NET_Identity.App_Start.Startup))]

namespace ASP_NET_Identity.App_Start
{
    public class Startup
    {
        // IAppBuilder интерфейс  является промежуточным слоем, который участвует в обработке запросов
        public void Configuration(IAppBuilder app)
        {
            // Метод CreatePerOwinContext создает новые экземпляры классов ApplicationUserManager и ApplicationContext для каждого запроса. 
            // Это гарантирует, что каждый запрос будет отдельно работать с данными ASP.NET Identity и что не придется беспокоиться о 
            // синхронизации или настройке кэширования данных
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Метод UseCookieAuthentication указывает платформе Identity о том, что нужно использовать куки для авторизации пользователей, 
            // а параметры передаются через объект CookieAuthenticationOptions
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                // тип аутентификации в приложении
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                // адрес URL, по которому будут перенаправляться неавторизованные пользователи
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}