using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Veiculos.Delete;

public class DeleteVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    
    public DeleteVeiculoUseCase(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }
    
    public async Task Execute(Guid id)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id) 
                      ?? throw new NotFoundException("Veículo não encontrado");
        
        await _veiculoRepository.DeleteAsync(veiculo);
    }
}