using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Core.Entities;

public class ItemCodigoEquivalente : Entity
{
    private ItemCodigoEquivalente()
    {
    }

    public ItemCodigoEquivalente(string sku, Guid fabricanteId, string fabricante,
        ETipoProdutoEquivalente tipoProdutoEquivalente)
    {
        Sku = sku;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        TipoProdutoEquivalente = tipoProdutoEquivalente;
    }

    public string Sku { get; set; } = null!;
    public Guid FabricanteId { get; set; }
    public string Fabricante { get; set; } = null!;
    public ETipoProdutoEquivalente TipoProdutoEquivalente { get; set; } 
}