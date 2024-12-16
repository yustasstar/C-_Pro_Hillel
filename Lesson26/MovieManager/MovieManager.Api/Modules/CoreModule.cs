﻿using Microsoft.EntityFrameworkCore;
using MovieManager.Data.Context;
using MovieManager.Service;

namespace MovieManager.Api.Modules
{
    public static class CoreModule
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
               .FromAssembliesOf(typeof(IRequestHandler<>))
               .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                   .AsImplementedInterfaces()
                   .WithTransientLifetime()
               .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)))
                   .AsImplementedInterfaces()
                   .WithTransientLifetime());

            services.AddDbContext<MovieManagerContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MovieManager"));
            });

            return services;
        }
    }
}
