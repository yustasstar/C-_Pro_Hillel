using System.Web.Mvc;
using System.Web.Routing;

namespace AjaxMvcApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //url: "{controller}/{action}/{name}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "Book", action = "JsonSearch", name = "Архангельский" }
            );
        }
    }
}