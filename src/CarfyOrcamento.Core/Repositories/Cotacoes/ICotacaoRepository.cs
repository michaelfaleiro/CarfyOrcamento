using CarfyOrcamento.Core.Entities;

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
}