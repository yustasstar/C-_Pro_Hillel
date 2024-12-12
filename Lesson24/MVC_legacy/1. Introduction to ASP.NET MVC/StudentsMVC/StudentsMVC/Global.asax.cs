using System.Web.Routing;
using System.Data.Entity;
using StudentsMVC.Models;

namespace StudentsMVC
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
