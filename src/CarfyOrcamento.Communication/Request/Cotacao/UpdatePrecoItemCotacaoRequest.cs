namespace CarfyOrcamento.Communication.Request.Cotacao;

public record UpdatePrecoItemCotacaoRequest(
    Guid Id,
    Guid CotacaoId,
    Guid ItemId,
    string FornecedorId,
    string Fornecedor,
    string FabricanteId,
    string Fabricante,
    int Quantidade,
    string Sku,
    string Descricao,
    decimal ValorCusto,
    decimal ValorVenda,
    int PrazoExpedicao,
    string Observacao);
