using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Core.Response;

namespace CarfyOrcamento.Application.UseCase.Veiculos.GetAll;

public class GetAllVeiculosUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    
    public GetAllVeiculosUseCase(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }
    
    public async Task<PagedResponse<ResponseVeiculoJson>> Execute(int pageNumber, int pageSize)
    {
        var veiculos = await _veiculoRepository.GetAllAsync(pageNumber, pageSize);
        
        return new PagedResponse<ResponseVeiculoJson>(
            veiculos.Data.Select(veiculo => new ResponseVeiculoJson(
                veiculo.Id,
                veiculo.Placa,
                veiculo.Chassi,
                veiculo.Marca,
                veiculo.Modelo,
                veiculo.Cor,
                veiculo.Ano,
                veiculo.CreatedAt,
                veiculo.UpdatedAt
            )), veiculos.TotalCount, veiculos.PageNumber, veiculos.PageSize
        );
    }
}