using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using WebAPISample.Models;

namespace WebAPISample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new StudentDbInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
