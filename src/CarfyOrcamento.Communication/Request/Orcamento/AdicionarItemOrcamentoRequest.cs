namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarItemOrcamentoRequest(
    Guid OrcamentoId,
    Guid ProdutoId,
    Guid FabricanteId,
    string Fabricante,
    string Sku,
    string Descricao,
    int Quantidade,
    decimal ValorVenda
);
