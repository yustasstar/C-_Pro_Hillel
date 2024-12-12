using System.Web.Routing;
using Students_MVC.Models;
using System.Data.Entity;

namespace Students_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new StudentDbInitializer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
