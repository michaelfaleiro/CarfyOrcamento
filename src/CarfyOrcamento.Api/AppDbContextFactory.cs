using CarfyOrcamento.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarfyOrcamento.Api;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();


        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("CarfyOrcamento.Infrastructure"));
        
        return new AppDbContext(optionsBuilder.Options);
    }
    
}