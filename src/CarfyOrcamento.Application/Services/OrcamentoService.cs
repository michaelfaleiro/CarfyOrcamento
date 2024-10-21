using CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;
using CarfyOrcamento.Application.UseCase.Orcamentos.Frete;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetAll;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetById;
using CarfyOrcamento.Application.UseCase.Orcamentos.Item.AdicionarItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.Item.RemoverItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.Item.UpdateItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.AdicionarItemAvulso;
using CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.RemoverItemAvulso;
using CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.UpdateItemAvulso;
using CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;
using CarfyOrcamento.Application.UseCase.Orcamentos.Register;
using CarfyOrcamento.Application.UseCase.Orcamentos.Status;
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
        services.AddScoped<UpdateItemOrcamentoUseCase>();
        services.AddScoped<RemoverItemOrcamentoUseCase>();
        services.AddScoped<AdicionarItemAvulsoOrcamentoUseCase>();
        services.AddScoped<UpdateItemAvulsoOrcamentoUseCase>();
        services.AddScoped<RemoverItemAvulsoOrcamentoUseCase>();
        services.AddScoped<AlterarStatusOrcamentoUseCase>();
        services.AddScoped<DescontoOrcamentoUseCase>();
        services.AddScoped<CupomDescontoUseCase>();
        services.AddScoped<FreteOrcamentoUseCase>();
        services.AddScoped<AdicionarObservacaoOrcamentoUseCase>();
        services.AddScoped<AdicionarObservacaoInternaOrcamentoUseCase>();

        return services;
    }
    
}