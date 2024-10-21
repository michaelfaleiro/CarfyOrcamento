using CarfyOrcamento.Core.Enums;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Core.Entities;

public class Orcamento : Entity
{
    private Orcamento()
    {
        Itens = [];
        ItensAvulsos = [];
        Cotacoes = [];
    }

    public Orcamento(Cliente cliente, Veiculo veiculo, string vendedor, EStatusOrcamento status) 
    {
        Cliente = cliente;
        Veiculo = veiculo;
        Vendedor = vendedor;
        Itens = [];
        ItensAvulsos = [];
        Cotacoes = [];
        Status = status;
    }

    public Cliente Cliente { get; set; } = null!;
    public Veiculo Veiculo { get; set; } = null!;
    public string Vendedor { get; set; } = null!;
    public IList<ItemOrcamento> Itens { get; set; }
    public IList<ItemAvulsoOrcamento> ItensAvulsos { get; set; }
    public IList<Cotacao> Cotacoes { get; set; } 
    public EStatusOrcamento Status { get; set; }
    public decimal CupomDesconto { get; set; }
    public decimal ValorDesconto { get; set; }
    public decimal ValorFrete { get; set; }
    public decimal TotalProdutos => Itens.Sum(i => i.ValorVenda * i.Quantidade)
                            + ItensAvulsos.Sum(i => i.ValorVenda * i.Quantidade);
    
    public string Observacao { get; set; } = string.Empty;
    public string ObservacaoInterna { get; set; } = string.Empty;
    
    
    public void AlterarStatus(EStatusOrcamento status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Desconto(decimal valor)
    {
        if (valor < 0)
            throw new BusinessException("O valor do desconto não pode ser negativo.");
        
        ValorDesconto = valor;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AdicionarFrete(decimal valor)
    {
        if (valor < 0)
            throw new BusinessException("O valor do frete não pode ser negativo.");
        
        ValorFrete = valor;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Cupom(decimal valor)
    {
        if (valor < 0)
            throw new BusinessException("O valor do cupom não pode ser negativo.");
        
        CupomDesconto = valor;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AdicionarObservacao(string observacao)
    {
        Observacao = observacao;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AdicionarObservacaoInterna(string observacao)
    {
        ObservacaoInterna = observacao;
        UpdatedAt = DateTime.UtcNow;
    }
}