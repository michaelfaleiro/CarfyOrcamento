using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Orcamento;

public record UpdateItemOrcamentoRequest(
    Guid Id,
    Guid OrcamentoId,
    Guid ProdutoId,
    Guid FabricanteId,
    string Fabricante,
    string Sku,
    string Descricao,
    int Quantidade,
    decimal ValorVenda);