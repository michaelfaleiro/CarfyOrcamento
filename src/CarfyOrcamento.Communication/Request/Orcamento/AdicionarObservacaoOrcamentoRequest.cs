namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarObservacaoOrcamentoRequest(
    Guid Id,
    string Observacao);