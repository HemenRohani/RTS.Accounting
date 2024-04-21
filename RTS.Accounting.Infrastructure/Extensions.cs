using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTS.Accounting.Application;


namespace RTS.Accounting.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string appDataBaseConnectionString = configuration.GetConnectionString("AppDataBaseConnectionString");

            services.AddDbContext<AppDbContext>(ctx => ctx.UseSqlServer(appDataBaseConnectionString));

            return services;
        }
    }
}
