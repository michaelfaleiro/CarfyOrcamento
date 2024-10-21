using CarfyOrcamento.Communication.Request.Veiculo;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Clientes.Veiculos;

public class RemoverVeiculoClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;
    
    public RemoverVeiculoClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    public async Task RemoverVeiculoAsync(RemoverVeiculoRequest request)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId) 
                      ?? throw new NotFoundException("Cliente não encontrado");
        
        var clienteVeiculo = cliente.Veiculos.FirstOrDefault(x => x.Id == request.VeiculoId) 
                             ?? throw new NotFoundException("Veículo não encontrado");
        
        cliente.Veiculos.Remove(clienteVeiculo);
        
        await _clienteRepository.UpdateAsync(cliente);
    }
}