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

    public async Task<PagedResponse<ResponseVeiculoShortJson>> Execute(int pageNumber, int pageSize)
    {
        var veiculos = await _veiculoRepository.GetAllAsync(pageNumber, pageSize);

        return new PagedResponse<ResponseVeiculoShortJson>(
            veiculos.Data.Select(veiculo => new ResponseVeiculoShortJson(
                veiculo.Id,
                veiculo.Placa,
                veiculo.Modelo,
                veiculo.Chassi
            )), veiculos.TotalCount, veiculos.PageNumber, veiculos.PageSize
        );
    }
}