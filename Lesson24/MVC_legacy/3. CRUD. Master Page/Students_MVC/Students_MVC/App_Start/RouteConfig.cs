using System.Web.Mvc;
using System.Web.Routing;

namespace Students_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default2",
               url: "Журнал/Создание-нового-студента",
               defaults: new { controller = "Students", action = "Create" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Students", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
