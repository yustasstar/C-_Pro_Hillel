using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Soccer.Models;
using Microsoft.EntityFrameworkCore;

namespace Soccer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Основная функциональность фреймворка сосредоточена в пакете Microsoft.AspNetCore.Mvc
            // MVC подключается в приложение в качестве сервиса
            services.AddMvc();

            // Контекст данных добавлен в качестве сервиса
            services.AddDbContext<SoccerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Teams}/{action=Index}/{id?}");
            });
        }
    }
}
