using System.Web.Routing;
using System.Web.Mvc;

namespace StudentsMVC.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.Browser.Browser;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш браузер: " + ip + "</h2>");
        }
    }
}