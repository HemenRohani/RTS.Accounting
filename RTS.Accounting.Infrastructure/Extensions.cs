using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTS.Accounting.Domain.Interfaces;
using RTS.Accounting.Domain.Repositories;
using RTS.Accounting.Infrastructure.Repositories;


namespace RTS.Accounting.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("DatabaseConnectionString");

            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(dbConnectionString,
                 builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IInvoiceDocumentRepository, InvoiceDocumentRepository>();

            return services;
        }
    }
}
