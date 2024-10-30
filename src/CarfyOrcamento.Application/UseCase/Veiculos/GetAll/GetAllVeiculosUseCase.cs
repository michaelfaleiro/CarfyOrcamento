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

    public async Task<PagedResponse<ResponseVeiculoShortJson>> ExecuteAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate , DateTime? endDate, string? search, string? sort)
    {
        var veiculos = await _veiculoRepository.GetAllVeiculosAsync(
            pageNumber, pageSize, status, startDate, endDate, search, sort);

        return new PagedResponse<ResponseVeiculoShortJson>(
            veiculos.Data.Select(veiculo => new ResponseVeiculoShortJson(
                veiculo.Id,
                veiculo.Placa,
                veiculo.Modelo,
                veiculo.Chassi,
                veiculo.Marca,
                veiculo.Ano
            )), veiculos.TotalCount, veiculos.PageNumber, veiculos.PageSize
        );
    }
}