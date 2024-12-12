using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AppWithoutMVC
{
    // Класс Startup является входной точкой в приложение ASP.NET Core.
    // Этот класс производит конфигурацию приложения, настраивает сервисы, 
    // которые приложение будет использовать, устанавливает компоненты для обработки запроса или middleware.
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Необязательный метод ConfigureServices() регистрирует сервисы, которые используются приложением.
        }

        // Метод Configure выполняется один раз при создании объекта класса Startup, 
        // и компоненты middleware создаются один раз и живут в течение всего жизненного цикла приложения.
        public void Configure(IApplicationBuilder app)
        {
            // Компоненты, определенные через метод Run, не вызывают никакие другие компоненты 
            // и дальше обработку запроса не передают.
            app.Run(async (context) =>
            {
                var name = context.Request.Query["Name"];
                var surname = context.Request.Query["Surname"];
                string responseStr = "<html><head><meta charset='utf8'></head><body><h1>" + name + "  " + surname + "</h1>"
                    + "<a href='/?Name=Ivan&Surname=Ivanov'>User 1</a><br />"
                    + "<a href='/?Name=Petr&Surname=Petrov'>User 2</a><br />"
                    + "<a href='/?Name=Oleg&Surname=Semenov'>User 3</a><br />"
                    + "</body></html>";
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync(responseStr);
            });
        }
    }
}
