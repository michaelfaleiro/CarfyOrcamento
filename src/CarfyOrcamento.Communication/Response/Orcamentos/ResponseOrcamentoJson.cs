using CarfyOrcamento.Communication.Response.ItemOrcamento;

namespace CarfyOrcamento.Communication.Response.Orcamentos;

public record ResponseOrcamentoJson(
    Guid Id,
    Guid ClienteId,
    Guid VeiculoId,
    Guid VendedorId,
    IEnumerable<ResponseItemOrcamentoJson> Itens,
    IEnumerable<ResponseItemAvulsoOrcamentoJson> ItensAvulsos,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );