using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // отключить обработку запросов для файлов с расширением *.axd (WebResource.axd)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Файлы .axd не существуют физически. ASP.NET использует URL-адреса 
            // с расширениями .axd(ScriptResource.axd и WebResource.axd) внутри, и они обрабатываются HttpHandler.

            routes.MapRoute(
                name: "Default", // имя маршрута
                url: "{controller}/{action}/{id}", // шаблон Url, с которым будет сопоставляться данный маршрут.
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}