using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.ItemCotacao;

public record ResponseCodigoEquivalenteCotacaoJson(
    Guid Id,
    string Sku,
    Guid FabricanteId,
    string Fabricante,
    ETipoProdutoEquivalente TipoProdutoEquivalente,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

