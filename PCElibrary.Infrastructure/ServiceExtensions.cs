﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PCElibrary.Infrastructure.DbContext;
using PCElibrary.Infrastructure.Repositories;
using PCElibrary.Server.Repositories.Interfaces;

namespace PCElibrary.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDb"));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
