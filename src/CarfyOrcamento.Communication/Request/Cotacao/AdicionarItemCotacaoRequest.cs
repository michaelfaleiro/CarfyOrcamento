using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Cotacao;
public record AdicionarItemCotacaoRequest(
    Guid CotacaoId,
    string? Sku,
    string Descricao,
    int Quantidade,
    ETipoProduto TipoProduto);
