using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Core.Entities;

public class ItemAvulsoOrcamento : Entity
{
    private ItemAvulsoOrcamento()
    {
    }
    
    public ItemAvulsoOrcamento(Guid fabricanteId, string sku, string fabricante, int quantidade, string descricao, decimal valorVenda, Orcamento orcamento)
    {
        ItemExisteOrcamento(orcamento, sku);
        
        FabricanteId = fabricanteId;
        Sku = sku;
        Fabricante = fabricante;
        Quantidade = quantidade;
        Descricao = descricao;
        ValorVenda = valorVenda;
        Orcamento = orcamento;
    }

    public Guid FabricanteId { get; set; }
    public string Sku { get; set; } = null!;
    public string Fabricante { get; set; } = null!;
    public int Quantidade { get; set; }
    public string Descricao { get; set; } = null!;
    public decimal ValorVenda { get; set; }
    public Orcamento Orcamento { get; set; } = null!;
    
    public void Atualizar(Guid fabricanteId, string sku, string fabricante, int quantidade, string descricao, decimal valorVenda)
    {
        FabricanteId = fabricanteId;
        Sku = sku;
        Fabricante = fabricante;
        Quantidade = quantidade;
        Descricao = descricao;
        ValorVenda = valorVenda;
        UpdatedAt = DateTime.UtcNow;
    }

    private void ItemExisteOrcamento(Orcamento orcamento, string sku)
    {
        if (orcamento.ItensAvulsos.Any(x => 
                string.Equals(x.Sku, sku, StringComparison.CurrentCultureIgnoreCase)))
            throw new BusinessException("Item já adicionado ao orçamento");
    }
}