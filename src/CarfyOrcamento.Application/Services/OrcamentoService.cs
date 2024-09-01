using CarfyOrcamento.Application.UseCase.Orcamentos.AdicionarItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetAll;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetById;
using CarfyOrcamento.Application.UseCase.Orcamentos.Register;
using CarfyOrcamento.Application.UseCase.Orcamentos.RemoverItem;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Application.Services;

public static class OrcamentoService
{
    public static IServiceCollection OrcamentoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterOrcamentoUseCase>();
        services.AddScoped<GetAllOrcamentosUseCase>();
        services.AddScoped<GetByIdOrcamentoUseCase>();
        services.AddScoped<AdicionarItemOrcamentoUseCase>();
        services.AddScoped<RemoverItemOrcamentoUseCase>();
        
        
        return services;
    }
    
}