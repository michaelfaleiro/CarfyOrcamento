using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Veiculos.GetById;

public class GetByIdVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    
    public GetByIdVeiculoUseCase(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }
    
    public async Task<ResponseJson<ResponseVeiculoJson>> Execute(Guid id)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id) 
                      ?? throw new NotFoundException("Veículo não encontrado");
        
        
        return new ResponseJson<ResponseVeiculoJson>(
            new ResponseVeiculoJson(
                veiculo.Id,
                veiculo.Placa,
                veiculo.Chassi,
                veiculo.Marca,
                veiculo.Modelo,
                veiculo.Cor,
                veiculo.Ano,
                veiculo.CreatedAt,
                veiculo.UpdatedAt
            )
        );
    }
}