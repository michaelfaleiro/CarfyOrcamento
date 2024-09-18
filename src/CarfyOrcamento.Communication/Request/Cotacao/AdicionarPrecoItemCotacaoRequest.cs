namespace CarfyOrcamento.Communication.Request.Cotacao;
public record AdicionarPrecoItemCotacaoRequest(
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
