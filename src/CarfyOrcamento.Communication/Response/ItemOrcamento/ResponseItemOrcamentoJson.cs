namespace CarfyOrcamento.Communication.Response.ItemOrcamento;

public record ResponseItemOrcamentoJson(
    Guid Id,
    string Sku,
    string Descricao,
    int Quantidade,
    decimal ValorVenda
);
