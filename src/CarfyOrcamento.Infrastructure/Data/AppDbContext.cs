using CarfyOrcamento.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Veiculo> Veiculos { get; set; } = null!;
    public DbSet<ClienteVeiculos> ClienteVeiculos { get; set; } = null!;
    public DbSet<Orcamento> Orcamentos { get; set; } = null!;
    public DbSet<ItemOrcamento> ItemOrcamentos { get; set; } = null!;
    public DbSet<ItemAvulsoOrcamento> ItemAvulsoOrcamentos { get; set; } = null!;
    public DbSet<Cotacao> Cotacoes { get; set; } = null!;
    public DbSet<ItemCotacao> ItemCotacoes { get; set; } = null!;
    public DbSet<ItemCodigoEquivalente> CodigoEquivalentes { get; set; } = null!;
    public DbSet<PrecoItemCotacao> PrecoItemCotacoes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<Orcamento>()
            .Property(o => o.ValorTotal)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ItemOrcamento>()
            .Property(i => i.ValorVenda)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ItemAvulsoOrcamento>()
            .Property(i => i.ValorVenda)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<PrecoItemCotacao>()
            .Property(p => p.ValorCusto)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<PrecoItemCotacao>()
            .Property(p => p.ValorVenda)
            .HasColumnType("decimal(18,2)");
    }
}