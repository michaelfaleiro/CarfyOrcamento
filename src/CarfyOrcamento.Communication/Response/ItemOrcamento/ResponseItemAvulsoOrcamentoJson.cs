namespace CarfyOrcamento.Communication.Response.ItemOrcamento;

public record ResponseItemAvulsoOrcamentoJson(
        Guid Id,
        Guid OrcamentoId,
        Guid FabricanteId,
        string Fabricante,
        string Sku,
        string Descricao,
        decimal ValorVenda,
        int Quantidade,
        DateTime CreatedAt, 
        DateTime? UpdatedAt
        );
