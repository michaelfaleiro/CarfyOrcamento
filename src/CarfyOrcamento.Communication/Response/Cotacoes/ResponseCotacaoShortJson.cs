using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Cotacoes;
public record ResponseCotacaoShortJson(
    Guid Id,
    Guid OrcamentoId,
    EStatusCotacao Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );
