using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using ManyToManyExample1.Models;


namespace ManyToManyExample1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new ContinentDbInitializer());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}