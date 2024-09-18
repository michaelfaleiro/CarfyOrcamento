using CarfyOrcamento.Communication.Response.ItemCotacao;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Cotacoes;

public record ResponseCotacaoJson(
    Guid Id,
    Guid OrcamentoId,
    EStatusCotacao Status,
    IEnumerable<ResponseItemCotacaoJson> Itens,
    DateTime CreatedAt,
    DateTime? UpdatedAt);