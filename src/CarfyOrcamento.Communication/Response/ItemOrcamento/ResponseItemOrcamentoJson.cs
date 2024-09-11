namespace CarfyOrcamento.Communication.Response.ItemOrcamento;

public record ResponseItemOrcamentoJson(
    Guid Id,
    Guid ProdutoId,
    Guid FabricanteId,
    string Fabricante,
    string Sku,
    string Descricao,
    int Quantidade,
    decimal ValorVenda
);
