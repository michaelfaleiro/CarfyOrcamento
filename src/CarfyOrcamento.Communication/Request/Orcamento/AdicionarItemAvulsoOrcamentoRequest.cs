namespace CarfyOrcamento.Communication.Request.Orcamento;

public record AdicionarItemAvulsoOrcamentoRequest(
    Guid OrcamentoId,
    Guid FabricanteId,
    string Sku,
    string Fabricante,
    int Quantidade,
    string Descricao,
    decimal ValorVenda
    );