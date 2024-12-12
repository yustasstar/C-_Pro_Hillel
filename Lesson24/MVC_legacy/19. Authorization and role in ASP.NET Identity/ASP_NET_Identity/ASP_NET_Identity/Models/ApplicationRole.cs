using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP_NET_Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }
    }
}