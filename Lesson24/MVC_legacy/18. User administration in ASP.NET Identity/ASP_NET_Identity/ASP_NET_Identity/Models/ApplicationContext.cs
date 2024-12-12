using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP_NET_Identity.Models
{
    // Класс контекста базы данных для Entity Framework, который будет работать с ApplicationUser.
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}