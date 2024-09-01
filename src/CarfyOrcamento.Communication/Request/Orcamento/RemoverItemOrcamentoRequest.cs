namespace CarfyOrcamento.Communication.Request.Orcamento;

public record RemoverItemOrcamentoRequest(Guid OrcamentoId, Guid ItemOrcamentoId);