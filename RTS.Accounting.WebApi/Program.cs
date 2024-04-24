using RTS.Accounting.Infrastructure;
using RTS.Accounting.Application;
using RTS.Accounting.WebApi;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigurationManager configuration = builder.Configuration;

        builder.Services
            .AddInfrastructureServices(configuration)
            .AddApplicationServices()
            .AddWebApiServices();

        var app = builder.Build();

        ConfigureMiddlewares(app);

        app.Run();
    }

    // Configure the HTTP request pipeline.
    private static void ConfigureMiddlewares(WebApplication app)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.UseStaticFiles();

    }
}