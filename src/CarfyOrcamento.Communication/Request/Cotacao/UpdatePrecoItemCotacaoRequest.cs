namespace CarfyOrcamento.Communication.Request.Cotacao;

public record UpdatePrecoItemCotacaoRequest(
    Guid Id,
    Guid CotacaoId,
    Guid ItemId,
    Guid FornecedorId,
    string NomeFantasia,
    Guid FabricanteId,
    string Fabricante,
    string Sku,
    string Nome,
    decimal ValorCusto,
    decimal ValorVenda,
    int PrazoExpedicao);
