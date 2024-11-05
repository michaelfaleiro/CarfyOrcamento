using CarfyOrcamento.Application.UseCase.Catalogos.Delete;
using CarfyOrcamento.Application.UseCase.Catalogos.GetAll;
using CarfyOrcamento.Application.UseCase.Catalogos.GetById;
using CarfyOrcamento.Application.UseCase.Catalogos.Register;
using CarfyOrcamento.Application.UseCase.Catalogos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Application.Services;

public static class CatalogoService
{
    public static IServiceCollection CatalogoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterCatalogoUseCase>();
        services.AddScoped<GetAllCatalogosUseCase>();
        services.AddScoped<GetByIdCatalogoUseCase>();
        services.AddScoped<UpdateCatalogoUseCase>();
        services.AddScoped<DeleteCatalogoUseCase>();

        return services;
    }
    
}