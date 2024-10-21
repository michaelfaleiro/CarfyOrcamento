namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarObservacaoInternaOrcamentoRequest(
    Guid Id,
    string ObservacaoInterna
    );