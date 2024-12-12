using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Validations.Models;

namespace Validations
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new BookDbInitializer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}