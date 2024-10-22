using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;

public record AdicionarCodigoEquivalenteRequest(
    Guid CotacaoId,
    Guid ItemId,
    string Sku,
    string FabricanteId,
    string Fabricante,
    ETipoProdutoEquivalente TipoProdutoEquivalente);