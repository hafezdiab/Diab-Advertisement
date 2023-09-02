using Diab_Advertisement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Diab_Advertisement.Api.Helpers;
using Diab_Advertisement.Api.Middleware;
using Diab_Advertisement.Api.Extensions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(MappingProfiles));
        builder.Services.AddControllers();
        builder.Services.AddDbContext<StoreContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddApplicationServices();
        builder.Services.AddSwaggerDocumentation();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMiddleware<ExceptionMiddleware> ();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            // Datenbank wird erstellt falls noch nicht existiert
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Anerror occured durring migration");
                }
            }
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.UseSwaggerDocumentation();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
        
        app.Run();
    }
}