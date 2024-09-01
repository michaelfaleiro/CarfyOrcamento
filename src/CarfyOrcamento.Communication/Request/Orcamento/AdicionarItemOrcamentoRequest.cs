namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarItemOrcamentoRequest(
    Guid OrcamentoId,
    Guid ProdutoId,
    string Sku,
    string Descricao,
    int Quantidade,
    decimal ValorVenda
);
