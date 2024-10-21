using CarfyOrcamento.Communication.Request.Veiculo;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Clientes.Veiculos;

public class AdicionarVeiculoClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IVeiculoRepository _veiculoRepository;
    
    public AdicionarVeiculoClienteUseCase(IClienteRepository clienteRepository,
        IVeiculoRepository veiculoRepository)
    {
        _clienteRepository = clienteRepository;
        _veiculoRepository = veiculoRepository;
    }
    
    public async Task AdicionarVeiculoAsync(AdicionarVeiculoRequest request)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId) 
                      ?? throw new NotFoundException("Cliente não encontrado");
        
        
        var veiculo = await _veiculoRepository.GetByIdAsync(request.VeiculoId) 
                      ?? throw new NotFoundException("Veículo não encontrado");

        if (cliente.Veiculos.Any(x => x.Id == request.VeiculoId))
            throw new BusinessException("Veículo já cadastrado para o cliente");
        
        
        var clienteVeiculos = new ClienteVeiculos(cliente, veiculo);
       
        await _clienteRepository.AdicionarVeiculoAsync(veiculo);
        
    }
}