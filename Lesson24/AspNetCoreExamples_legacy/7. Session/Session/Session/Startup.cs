using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Session
{
    public class Startup
    {
        // Для работы с сессиями в проект ASP.NET через Nuget надо добавить два пакета: 
        // Microsoft.AspNetCore.Session и Microsoft.Extensions.Caching.Memory
        public void ConfigureServices(IServiceCollection services)
        {
            // Необходимо сконфигурировать параметры сессий в классе Startup. 
            // Все сессии работают поверх объекта IDistributedCache, и ASP.NET Core 
            // предоставляет встроенную реализацию IDistributedCache
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10); // Длительность сеанса (тайм-аут завершения сеанса)
                options.Cookie.Name = "Session";
                
            });
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Create}/{id?}");
            });
        }
    }
}
