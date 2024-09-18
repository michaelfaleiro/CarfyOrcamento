namespace CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;

public record RemoverCodigoEquivalenteRequest(
    Guid Id,
    Guid CotacaoId,
    Guid ItemId);