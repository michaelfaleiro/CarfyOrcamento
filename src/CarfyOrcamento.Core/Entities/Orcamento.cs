using CarfyOrcamento.Core.Enums;

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
    public decimal ValorDesconto { get; set; }
   
    public void AlterarStatus(EStatusOrcamento status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }

}