namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarFreteRequest(
    Guid Id,
    decimal ValorFrete
    );