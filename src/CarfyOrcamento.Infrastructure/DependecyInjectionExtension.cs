using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Infrastructure.Data.Repositories.Cotacoes;
using CarfyOrcamento.Infrastructure.Data.Repositories.Orcamentos;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Infrastructure;

public static class DependecyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {

        services.AddScoped<ICotacaoRepository, CotacaoRepository>();
        services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();

    }
    
}