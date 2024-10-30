using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Response;

namespace CarfyOrcamento.Core.Repositories.Cotacoes;

public interface ICotacaoRepository : IRepository<Cotacao>
{
    Task AdicionarItemCotacao(ItemCotacao itemCotacao);
    Task AtualizarItemCotacao(ItemCotacao itemCotacao);
    Task RemoverItemCotacao(ItemCotacao itemCotacao);
    Task AdicionarPrecoItemCotacao(PrecoItemCotacao precoItemCotacao);
    Task AtualizarPrecoItemCotacao(PrecoItemCotacao precoItemCotacao);
    Task RemoverPrecoItemCotacao(PrecoItemCotacao precoItemCotacao);
    Task AdicionarCodigoEquivalente(ItemCodigoEquivalente itemCodigoEquivalente);
    Task AtualizarCodigoEquivalente(ItemCodigoEquivalente itemCodigoEquivalente);
    Task RemoverCodigoEquivalente(ItemCodigoEquivalente itemCodigoEquivalente);
    Task<ItemCotacao?> GetItemById(Guid itemId);
    Task<PagedResponse<Cotacao>> GetAllCotacoesAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate = null,
        DateTime? endDate = null, string? search = null, string? vendedor = null, string? orderBy = null);
}