namespace CarfyOrcamento.Core.Entities;

public class ItemOrcamento : Entity
{
    private ItemOrcamento()
    {
    }
    
    public ItemOrcamento(Guid produtoId, Orcamento orcamento,string sku, string descricao,
        int quantidade, decimal valorVenda)
    {
        ProdutoId = produtoId;
        Orcamento = orcamento;
        Sku = sku;
        Descricao = descricao;
        Quantidade = quantidade;
        ValorVenda = valorVenda;
    }

    public Guid ProdutoId { get; set; }
    public Orcamento Orcamento { get; set; } = null!;
    public string Sku { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int Quantidade { get; set; }
    public decimal ValorVenda { get; set; }
    
}