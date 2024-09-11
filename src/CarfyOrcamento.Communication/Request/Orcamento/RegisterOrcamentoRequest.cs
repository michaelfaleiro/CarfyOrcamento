
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Orcamento;

public record RegisterOrcamentoRequest(
    Guid ClienteId,
    Guid VeiculoId,
    string Vendedor,
    EStatusOrcamento Status
    );

