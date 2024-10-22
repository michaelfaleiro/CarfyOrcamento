namespace CarfyOrcamento.Communication.Response.ItemCotacao;
public record ResponsePrecoItemCotacaoJson(
    Guid Id,
    Guid CotacaoId,
    Guid ItemId,
    Guid FornecedorId,
    string Fornecedor,
    Guid FabricanteId,
    string Fabricante,
    int Quantidade,
    string Sku,
    string Descricao,
    decimal ValorCusto,
    decimal ValorVenda,
    int PrazoExpedicao,
    string? Observacao,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
