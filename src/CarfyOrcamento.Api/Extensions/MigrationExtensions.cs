using CarfyOrcamento.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Api.Extensions;

public static class MigrationExtensions
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    
}