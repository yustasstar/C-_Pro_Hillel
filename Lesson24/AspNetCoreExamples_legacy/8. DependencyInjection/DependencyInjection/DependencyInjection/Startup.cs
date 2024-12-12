using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Services;

namespace DependencyInjection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<IMessageSender, SmsMessageSender>();
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
