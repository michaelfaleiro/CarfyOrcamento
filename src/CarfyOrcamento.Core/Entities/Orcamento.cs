using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Core.Entities;

public class Orcamento : Entity
{
    private Orcamento()
    {
        Itens = [];
        ItensAvulsos = [];
    }

    public Orcamento(Cliente cliente, Veiculo veiculo, string vendedor, EStatusOrcamentoCotacao status) 
    {
        Cliente = cliente;
        Veiculo = veiculo;
        Vendedor = vendedor;
        Itens = [];
        ItensAvulsos = [];
        Status = status;
    }

    public Cliente Cliente { get; set; } = null!;
    public Veiculo Veiculo { get; set; } = null!;
    public string Vendedor { get; set; } = null!;
    public IEnumerable<ItemOrcamento> Itens { get; set; }
    public IEnumerable<ItemAvulsoOrcamento> ItensAvulsos { get; set; }
    public EStatusOrcamentoCotacao Status { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal ValorDesconto { get; set; }
}