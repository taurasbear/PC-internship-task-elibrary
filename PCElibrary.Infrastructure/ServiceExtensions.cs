using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PCElibrary.Application.Interfaces;
using PCElibrary.Infrastructure.Data.DbContext;
using PCElibrary.Infrastructure.Data.Repositories;
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
            services.AddScoped<IBookTypeRepository, BookTypeRepository>();
        }
    }
}
