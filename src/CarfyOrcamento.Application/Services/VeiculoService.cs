using CarfyOrcamento.Application.UseCase.Veiculos.Delete;
using CarfyOrcamento.Application.UseCase.Veiculos.GetAll;
using CarfyOrcamento.Application.UseCase.Veiculos.GetById;
using CarfyOrcamento.Application.UseCase.Veiculos.Register;
using CarfyOrcamento.Application.UseCase.Veiculos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Application.Services;

public static class VeiculoService
{
    public static IServiceCollection VeiculoUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterVeiculoUseCase>();
        services.AddScoped<GetAllVeiculosUseCase>();
        services.AddScoped<GetByIdVeiculoUseCase>();
        services.AddScoped<UpdateVeiculoUseCase>();
        services.AddScoped<DeleteVeiculoUseCase>();

        return services;
    }
    
}