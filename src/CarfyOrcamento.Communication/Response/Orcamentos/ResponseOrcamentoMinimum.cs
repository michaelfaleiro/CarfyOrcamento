using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Orcamentos;

public record ResponseOrcamentoMinimum(
    Guid Id,
    EStatusOrcamento Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt);