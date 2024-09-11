using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Core.Entities;

public class ItemOrcamento : Entity
{
    private ItemOrcamento()
    {
    }
    
    public ItemOrcamento(Guid produtoId, Guid fabricanteId, string fabricante, 
        string sku, string descricao,
        int quantidade, decimal valorVenda, Orcamento orcamento)
    {
        ItemExisteOrcamento(orcamento, produtoId.ToString());
        
        ProdutoId = produtoId;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        Orcamento = orcamento;
        Sku = sku;
        Descricao = descricao;
        Quantidade = quantidade;
        ValorVenda = valorVenda;
    }

    public Guid ProdutoId { get; set; }
    public Guid FabricanteId { get; set; }
    public Orcamento Orcamento { get; set; } = null!;
    public string Sku { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Fabricante { get; set; } = null!;
    public int Quantidade { get; set; }
    public decimal ValorVenda { get; set; }
    
    
    public void Atualizar(Guid produtoId, Guid fabricanteId, string fabricante, string sku, string descricao,
        int quantidade, decimal valorVenda)
    {
        ProdutoId = produtoId;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        Sku = sku;
        Descricao = descricao;
        Quantidade = quantidade;
        ValorVenda = valorVenda;
        UpdatedAt = DateTime.UtcNow;
    }
    
    private void ItemExisteOrcamento(Orcamento orcamento, string produtoId)
    {
        if (orcamento.Itens.Any(x => x.ProdutoId == Guid.Parse(produtoId)))
            throw new BusinessException("Item já adicionado ao orçamento");
    }
}