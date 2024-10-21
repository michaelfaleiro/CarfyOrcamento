namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarCupomDescontoOrcamentoRequest(
    Guid Id,
    decimal CupomDesconto
    );