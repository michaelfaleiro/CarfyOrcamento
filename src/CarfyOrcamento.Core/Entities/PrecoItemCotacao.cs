using System.ComponentModel.DataAnnotations.Schema;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Core.Entities;

public class PrecoItemCotacao : Entity
{
    private PrecoItemCotacao()
    {
    }

    public PrecoItemCotacao(Guid fornecedorId, string fornecedor, Guid fabricanteId, string fabricante, int quantidade,
        string sku, string descricao, decimal valorCusto, decimal valorVenda, int prazoExpedicao, string observacao, ItemCotacao itemCotacao)
    {
        FornecedorId = fornecedorId;
        Fornecedor = fornecedor;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        Quantidade = quantidade;
        Sku = sku;
        Descricao = descricao;
        ValidarPrecoVenda(valorVenda);
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        PrazoExpedicao = prazoExpedicao;
        Observacao = observacao;
        ItemCotacao = itemCotacao;
    }
    [Column(TypeName = "uuid")]
    public Guid FornecedorId { get; set; }
    public string Fornecedor { get; set; } = null!;
    [Column(TypeName = "uuid")]
    public Guid FabricanteId { get; set; }
    public string Fabricante { get; set; } = null!;
    public int Quantidade { get; set; }
    public string Sku { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public int PrazoExpedicao { get; set; }
    public ItemCotacao ItemCotacao { get; set; } = null!;
    public string Observacao { get; set; } = string.Empty;

    public void AtualizarPrecoItemCotacao(Guid fornecedorId, string nomeFantasia, Guid fabricanteId,
        string fabricante, int quantidade, string sku, string descricao, decimal valorCusto, decimal valorVenda, int prazoExpedicao, string observacao)
    {
        FornecedorId = fornecedorId;
        Fornecedor = nomeFantasia;
        FabricanteId = fabricanteId;
        Fabricante = fabricante;
        Quantidade = quantidade;
        Sku = sku;
        Descricao = descricao;
        ValidarPrecoVenda(valorVenda);
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        PrazoExpedicao = prazoExpedicao;
        Observacao = observacao;
        UpdatedAt = DateTime.UtcNow;
    }

    private void ValidarPrecoVenda(decimal valorVenda)
    {
        if (valorVenda < ValorCusto)
            throw new BusinessException("Valor de venda não pode ser menor que o valor de custo");
    }

}