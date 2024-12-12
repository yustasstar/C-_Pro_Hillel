using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AspNetCore.NewDb.Models;

namespace AspNetCore.NewDb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.StudentsDb;Trusted_Connection=True";
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app)
        {
            // Cоздается маршрут, который позволит сопоставлять запросы с контроллерами и их методами
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Students}/{action=Index}/{id?}");
            });
        }
    }
}
