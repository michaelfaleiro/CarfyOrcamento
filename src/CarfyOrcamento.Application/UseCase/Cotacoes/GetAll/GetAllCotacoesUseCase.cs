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

    public async Task<PagedResponse<ResponseCotacaoShortJson>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var cotacoes = await _cotacaoRepository.GetAllAsync(pageNumber, pageSize);

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
