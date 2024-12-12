using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RequestProcessingPipeline
{
    public class Startup
    {
        // Для работы с сессиями необходимо добавить два пакета: 
        // Microsoft.AspNetCore.Session и Microsoft.Extensions.Caching.Memory:
        public void ConfigureServices(IServiceCollection services)
        {
            // Все сессии работают поверх объекта IDistributedCache, и 
            // ASP.NET Core предоставляет встроенную реализацию IDistributedCache
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Встраивание сессий в конвейер обработки запроса
            app.UseSession();
            app.UseFromTwentyToHundred();
            app.UseFromElevenToNineteen();
            app.UseFromOneToTen();
        }
    }
}
