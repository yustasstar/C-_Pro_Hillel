using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PushNotifyApp.Models;
using System.Data.Entity;

namespace PushNotifyApp
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
