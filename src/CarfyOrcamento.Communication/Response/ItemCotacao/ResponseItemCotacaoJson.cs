using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.ItemCotacao;
public record ResponseItemCotacaoJson(
    Guid Id,
    Guid CotacaoId,
    string? Sku,
    string Descricao,
    int Quantidade,
    ETipoProduto TipoProduto,
    IEnumerable<ResponsePrecoItemCotacaoJson> Precos
    );
