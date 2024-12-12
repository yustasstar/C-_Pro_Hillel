using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore.Validation.StudentsDb.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Validation.StudentsDb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=AspNetCore.StudentsListDb;Trusted_Connection=True;";
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Students}/{action=Create}/{id?}");
            });
        }
    }
}
