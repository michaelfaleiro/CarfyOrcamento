namespace CarfyOrcamento.Core.Entities;

public class ItemAvulsoOrcamento : Entity
{
    private ItemAvulsoOrcamento()
    {
    }
    
    public ItemAvulsoOrcamento(string sku, int quantidade, string descricao, decimal valorVenda, Orcamento orcamento)
    {
        Sku = sku;
        Quantidade = quantidade;
        Descricao = descricao;
        ValorVenda = valorVenda;
        Orcamento = orcamento;
    }

    public string Sku { get; set; } = null!;
    public int Quantidade { get; set; }
    public string Descricao { get; set; } = null!;
    public decimal ValorVenda { get; set; }
    public Orcamento Orcamento { get; set; } = null!;
}