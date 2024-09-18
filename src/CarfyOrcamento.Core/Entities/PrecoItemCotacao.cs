namespace CarfyOrcamento.Core.Entities;

public class PrecoItemCotacao : Entity
{
    private PrecoItemCotacao()
    {
    }

    public PrecoItemCotacao(Guid fornecedorId, string nomeFantasia, Guid fabricanteId, string fabricante, 
        string sku, string nome, decimal valorCusto, decimal valorVenda, int prazoExpedicao, ItemCotacao itemCotacao)
    {
        FornecedorId = fornecedorId;
        NomeFantasia = nomeFantasia;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        Sku = sku;
        Nome = nome;
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        PrazoExpedicao = prazoExpedicao;
        ItemCotacao = itemCotacao;
    }

    public Guid FornecedorId { get; set; }
    public string NomeFantasia { get; set; } = null!;
    public Guid FabricanteId { get; set; }
    public string Fabricante { get; set; } = null!;
    public string Sku { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public int PrazoExpedicao { get; set; }
    public ItemCotacao ItemCotacao { get; set; } = null!;
    public string? Observacao { get; set; }
    
    public void AtualizarPrecoItemCotacao(Guid fornecedorId, string nomeFantasia, Guid fabricanteId,
        string fabricante, string sku, string nome, decimal valorCusto, decimal valorVenda, int prazoExpedicao)
    {
        FornecedorId = fornecedorId;
        NomeFantasia = nomeFantasia;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        Sku = sku;
        Nome = nome;
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        PrazoExpedicao = prazoExpedicao;
        UpdatedAt = DateTime.UtcNow;
    }
}