using CarfyOrcamento.Core.Repositories.Catalogos;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Infrastructure.Data.Repositories.Catalogos;
using CarfyOrcamento.Infrastructure.Data.Repositories.Clientes;
using CarfyOrcamento.Infrastructure.Data.Repositories.Cotacoes;
using CarfyOrcamento.Infrastructure.Data.Repositories.Orcamentos;
using CarfyOrcamento.Infrastructure.Data.Repositories.Veiculos;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Infrastructure;

public static class DependecyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {

        services.AddScoped<ICotacaoRepository, CotacaoRepository>();
        services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        services.AddScoped<ICatalogoRepository, CatalogoRepository>();
    }

}