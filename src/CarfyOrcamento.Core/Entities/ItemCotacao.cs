namespace CarfyOrcamento.Core.Entities;

public class ItemCotacao : Entity
{
    private ItemCotacao()
    {
        CodigoEquivalentes = [];
    }
    
    public ItemCotacao(Cotacao cotacao, string? sku, string descricao, int quantidade)
    {
        Cotacao = cotacao;
        Sku = sku ?? string.Empty;
        Descricao = descricao;
        Quantidade = quantidade;
        CodigoEquivalentes = [];
    }
    
    public Cotacao Cotacao { get; set; } = null!;
    public string? Sku { get; set; }
    public string Descricao { get; set; } = null!;
    public int Quantidade { get; set; }
    public IList<ItemCodigoEquivalente> CodigoEquivalentes { get; set; }
}