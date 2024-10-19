namespace PCElibrary.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PCElibrary.Application.Interfaces;
    using PCElibrary.Infrastructure.Data;
    using PCElibrary.Infrastructure.Data.DbContext;

    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDb"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
