using CarfyOrcamento.Core.Entities;

namespace CarfyOrcamento.Communication.Request.Orcamento;

public record RegisterOrcamentoRequest(
    Guid ClienteId,
    Guid VeiculoId,
    Guid VendedorId);

