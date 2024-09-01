using CarfyOrcamento.Core.Entities;

namespace CarfyOrcamento.Communication.Response.Orcamentos;

public record ResponseOrcamentoShortJson(
    Guid Id,
    Guid ClienteId,
    Guid VeiculoId,
    Guid VendedorId,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);