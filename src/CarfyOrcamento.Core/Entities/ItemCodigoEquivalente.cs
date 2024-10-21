using System.ComponentModel.DataAnnotations.Schema;
using CarfyOrcamento.Core.Enums;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Core.Entities;

public class ItemCodigoEquivalente : Entity
{
    private ItemCodigoEquivalente()
    {
    }

    public ItemCodigoEquivalente(ItemCotacao itemCotacao , string sku, Guid fabricanteId, string fabricante,
        ETipoProdutoEquivalente tipoProdutoEquivalente)
    {
        CodigoEquivalenteExiste(itemCotacao, sku);
        ItemCotacao = itemCotacao;
        Sku = sku;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        TipoProdutoEquivalente = tipoProdutoEquivalente;
    }

    public string Sku { get; set; } = null!;
    [Column(TypeName = "uuid")]
    public Guid FabricanteId { get; set; }
    public string Fabricante { get; set; } = null!;
    public ETipoProdutoEquivalente TipoProdutoEquivalente { get; set; }
    public ItemCotacao ItemCotacao { get; set; } = null!;
    public void AtualizarCodigoEquivalente(string sku, Guid fabricanteId, string fabricante,
        ETipoProdutoEquivalente tipoProdutoEquivalente)
    {
        Sku = sku;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        TipoProdutoEquivalente = tipoProdutoEquivalente;
        UpdatedAt = DateTime.UtcNow;
    }

    private void CodigoEquivalenteExiste(ItemCotacao itemCotacao, string sku)
    {
        if (itemCotacao.CodigoEquivalentes.Any(x => x.Sku == sku))
        {
            throw new BusinessException("Código equivalente já cadastrado");
        }
    }
    
}