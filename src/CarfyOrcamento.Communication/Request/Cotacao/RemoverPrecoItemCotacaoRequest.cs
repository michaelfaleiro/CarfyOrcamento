namespace CarfyOrcamento.Communication.Request.Cotacao;

public record RemoverPrecoItemCotacaoRequest(
    Guid Id,
    Guid CotacaoId,
    Guid ItemId);