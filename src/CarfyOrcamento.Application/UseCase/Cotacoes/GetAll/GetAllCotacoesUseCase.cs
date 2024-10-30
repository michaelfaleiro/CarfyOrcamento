using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Cotacoes;
using CarfyOrcamento.Core.Repositories.Cotacoes;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.GetAll;
public class GetAllCotacoesUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public GetAllCotacoesUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task<PagedResponse<ResponseCotacaoShortJson>> ExecuteAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate , DateTime? endDate, string? search, string? vendedor, string? sort)
    {
        var cotacoes = await _cotacaoRepository.GetAllCotacoesAsync(
            pageNumber, pageSize, status, startDate, endDate, search, vendedor,sort);

        return new PagedResponse<ResponseCotacaoShortJson>(
            cotacoes.Data.Select(cotacao => new ResponseCotacaoShortJson(
                cotacao.Id,
                cotacao.OrcamentoId,
                cotacao.Status,
                cotacao.CreatedAt,
                cotacao.UpdatedAt
            )).ToList(),
            cotacoes.TotalCount,
            cotacoes.PageNumber,
            cotacoes.PageSize
        );
        
    }
}
