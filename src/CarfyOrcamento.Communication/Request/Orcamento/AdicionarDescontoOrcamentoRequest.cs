namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarDescontoOrcamentoRequest(
    Guid Id,
    decimal ValorDesconto
    );