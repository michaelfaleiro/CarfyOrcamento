namespace CarfyOrcamento.Communication.Request.Orcamento;

public record RemoverItemAvulsoOrcamentoRequest(
    Guid OrcamentoId,
    Guid ItemAvulsoId
    );