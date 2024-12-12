using System.Web.Optimization;
using System.Web.Routing;
using CRUDDialogApp.Models;
using System.Data.Entity;

namespace CRUDDialogApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new StudentDbInitializer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
