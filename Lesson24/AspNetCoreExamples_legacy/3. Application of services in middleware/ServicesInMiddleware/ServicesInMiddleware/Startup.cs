using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServicesInMiddleware.Services;


namespace ServicesInMiddleware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Transient: объект сервиса создается каждый раз, когда требуется экземпляр класса сервиса. 
            // Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, которые не хранят данных о состоянии.
            services.AddCounterService();

            // Scoped: для каждого запроса создается один объект сервиса.
            //services.AddScoped<ICounter, RandomCounter>();
            //services.AddScoped<CounterService>();

            // Singleton: объект сервиса создается при первом обращении к нему, 
            // все последующие запросы используют один и тот же ранее созданный объект сервиса
            //services.AddSingleton<ICounter, RandomCounter>();
            //services.AddSingleton<CounterService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
