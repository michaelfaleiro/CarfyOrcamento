using CarfyOrcamento.Application.UseCase.Clientes.Delete;
using CarfyOrcamento.Application.UseCase.Clientes.GetAll;
using CarfyOrcamento.Application.UseCase.Clientes.GetById;
using CarfyOrcamento.Application.UseCase.Clientes.Register;
using CarfyOrcamento.Application.UseCase.Clientes.Update;
using CarfyOrcamento.Application.UseCase.Clientes.Veiculos;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyOrcamento.Application.Services;

public static class ClienteService
{
    public static IServiceCollection ClienteUseCase(this IServiceCollection services)
    {
        services.AddScoped<RegisterClienteUseCase>();
        services.AddScoped<GetAllClientesUseCase>();
        services.AddScoped<GetByIdClienteUseCase>();
        services.AddScoped<UpdateClietnteUseCase>();
        services.AddScoped<DeleteClienteUseCase>();
        services.AddScoped<AdicionarVeiculoClienteUseCase>();
        services.AddScoped<RemoverVeiculoClienteUseCase>();

        return services;
    }

}
