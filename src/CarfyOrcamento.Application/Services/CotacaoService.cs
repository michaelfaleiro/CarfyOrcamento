using CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.AdicionarCodigoEquivalente;
using CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Delete;
using CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Update;
using CarfyOrcamento.Application.UseCase.Cotacoes.GetAll;
using CarfyOrcamento.Application.UseCase.Cotacoes.GetById;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.AdicionarItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.GetById;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.RemoverItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.UpdateItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.AdicionarPrecoItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.RemoverPrecoItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.UpdatePrecoItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.Register;
using CarfyOrcamento.Application.UseCase.Cotacoes.Status;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Application.Services;
public static class CotacaoService
{
    public static IServiceCollection CotacaoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterCotacaoUseCase>();
        services.AddScoped<GetByIdCotacaoUseCase>();
        services.AddScoped<GetAllCotacoesUseCase>();
        services.AddScoped<AlterarStatusCotacaoUseCase>();
        services.AddScoped<AdicionarItemCotacaoUseCase>();
        services.AddScoped<UpdateItemCotacaoUseCase>();
        services.AddScoped<RemoverItemCotacaoUseCase>();
        services.AddScoped<AdicionarPrecoItemCotacaoUseCase>();
        services.AddScoped<UpdatePrecoItemCotacaoUseCase>();
        services.AddScoped<RemoverPrecoItemCotacaoUseCase>();
        services.AddScoped<AdicionarCodigoEquivalenteUseCase>();
        services.AddScoped<RemoverCodigoEquivalenteUseCase>();
        services.AddScoped<UpdateCodigoEquivalenteUseCase>();
        services.AddScoped<GetItemCotacaoByIdUseCase>();

        return services;
    }
}
