namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AlterarStatusOrcamentoRequest(
    Guid Id,
    int Status);
