namespace CarfyOrcamento.Core.Entities;

public class PrecoItemCotacao : Entity
{
    private PrecoItemCotacao()
    {
    }

    public PrecoItemCotacao(Guid fornecedorId, string nomeFantasia, string sku, string nome,
        decimal valorCusto, decimal valorVenda, int prazoExpedicao, ItemCotacao itemCotacao)
    {
        FornecedorId = fornecedorId;
        NomeFantasia = nomeFantasia;
        Sku = sku;
        Nome = nome;
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        PrazoExpedicao = prazoExpedicao;
        ItemCotacao = itemCotacao;
    }

    public Guid FornecedorId { get; set; }
    public string NomeFantasia { get; set; } = null!;
    public string Sku { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public int PrazoExpedicao { get; set; }
    public ItemCotacao ItemCotacao { get; set; } = null!;
}