using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Core.Entities;

public class ItemCotacao : Entity
{
    private ItemCotacao()
    {
        CodigoEquivalentes = [];
        PrecoItemFornecedor = [];
    }

    public ItemCotacao(Cotacao cotacao, string? sku, string descricao, int quantidade, ETipoProduto tipoProduto)
    {
        Cotacao = cotacao;
        Sku = sku ?? string.Empty;
        Descricao = descricao;
        Quantidade = quantidade;
        CodigoEquivalentes = [];
        PrecoItemFornecedor = [];
        TipoProduto = tipoProduto;
    }

    public Cotacao Cotacao { get; set; } = null!;
    public string? Sku { get; set; }
    public string Descricao { get; set; } = null!;
    public int Quantidade { get; set; }
    public IList<ItemCodigoEquivalente> CodigoEquivalentes { get; set; }
    public IList<PrecoItemCotacao> PrecoItemFornecedor { get; set; }
    public ETipoProduto TipoProduto { get; set; }

    public void AtualizarItemCotacao(string? sku, string descricao, int quantidade, ETipoProduto tipoProduto)
    {
        Sku = sku ?? string.Empty;
        Descricao = descricao;
        Quantidade = quantidade;
        TipoProduto = tipoProduto;
        UpdatedAt = DateTime.UtcNow;
    }
}