using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using ASP_NET_Identity.Models;

namespace ASP_NET_Identity.Infrastructure
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            ApplicationUserManager mgr = HttpContext.Current
                .GetOwinContext().GetUserManager<ApplicationUserManager>();

            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}