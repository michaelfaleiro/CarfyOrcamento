namespace CarfyOrcamento.Communication.Request.Orcamento;

public record UpdateItemAvulsoOrcamentoRequest(
    Guid OrcamentoId,
    Guid ItemAvulsoId,
    Guid FabricanteId,
    string Sku,
    string Fabricante,
    int Quantidade,
    string Descricao,
    decimal ValorVenda
    );