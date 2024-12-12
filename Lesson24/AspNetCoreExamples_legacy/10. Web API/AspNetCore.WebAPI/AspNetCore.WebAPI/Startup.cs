using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.WebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=(localdb)\mssqllocaldb;Database=AspNetCore.WebAPI.StudentsDb;Trusted_Connection=True";
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(connection));
        }

        // Microsoft.AspNetCore.StaticFiles - пакет для работы со статическими файлами
        // Microsoft.EntityFrameworkCore.SqlServer, 
        // Microsoft.EntityFrameworkCore.Tools - пакеты для работы с EntityFrameworkCore
        public void Configure(IApplicationBuilder app)
        {
            // Для работы со статическими файлами
            // Благодаря этому мы сможем обратиться напрямую к веб-странице, например, по пути http://localhost:xxxx/index.html.
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
