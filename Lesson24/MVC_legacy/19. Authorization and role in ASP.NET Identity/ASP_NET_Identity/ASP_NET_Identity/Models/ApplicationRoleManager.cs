using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ASP_NET_Identity.Models
{
    class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
            : base(store)
        { }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            // Класс RoleStore<T> реализует интерфейс IRoleStore<T> из Entity Framework, 
            // который описывает CRUD-методы (create/read/update/delete) для работы с хранилищем данных
            ApplicationRoleManager manager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            return manager;
        }
    }
}