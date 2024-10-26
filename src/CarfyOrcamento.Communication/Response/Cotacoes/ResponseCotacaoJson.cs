using CarfyOrcamento.Communication.Response.ItemCotacao;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Cotacoes;

public record ResponseCotacaoJson(
    Guid Id,
    Guid OrcamentoId,
    ResponseVeiculoJson Veiculo,
    EStatusCotacao Status,
    IEnumerable<ResponseItemCotacaoJson> Itens,
    DateTime CreatedAt,
    DateTime? UpdatedAt);