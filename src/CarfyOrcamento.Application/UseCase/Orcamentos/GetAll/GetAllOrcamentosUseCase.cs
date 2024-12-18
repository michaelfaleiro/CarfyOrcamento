using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Repositories.Orcamentos;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.GetAll;

public class GetAllOrcamentosUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public GetAllOrcamentosUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task<PagedResponse<ResponseOrcamentoShortJson>> ExecuteAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate , DateTime? endDate, string? search, string? vendedor, string? sort)
    {
        var orcamentos = await _orcamentoRepository.GetAllAsync(
            pageNumber, pageSize, status, startDate, endDate, search, vendedor, sort);

        return new PagedResponse<ResponseOrcamentoShortJson>(orcamentos.Data.Select(orcamento => new ResponseOrcamentoShortJson(
            orcamento.Id,
            new ResponseClienteShortJson(
                orcamento.Cliente.Id,
                orcamento.Cliente.NomeRazaoSocial,
                orcamento.Cliente.Telefone,
                orcamento.Cliente.Email,
                orcamento.Cliente.TipoPessoa
            ),
            new ResponseVeiculoShortJson(
                orcamento.Veiculo.Id,
                orcamento.Veiculo.Placa,
                orcamento.Veiculo.Modelo,
                orcamento.Veiculo.Chassi,
                orcamento.Veiculo.Marca,
                orcamento.Veiculo.Ano
            ),
            orcamento.Vendedor,
            orcamento.Status,
            orcamento.CreatedAt,
            orcamento.UpdatedAt
        )).ToList(), orcamentos.TotalCount, pageNumber, pageSize);
    }
}