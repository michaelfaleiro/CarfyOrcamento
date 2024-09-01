namespace CarfyOrcamento.Core.Entities;

public class Orcamento : Entity
{
    private Orcamento()
    {
        Itens = [];
        ItensAvulsos = [];
    }
        
    public Orcamento(Guid clienteId, Guid veiculoId, Guid vendedorId)
    {
        ClienteId = clienteId;
        VeiculoId = veiculoId;
        VendedorId = vendedorId;
        Itens = [];
        ItensAvulsos = [];
    }
    
    public Guid ClienteId { get; set; }
    public Guid VeiculoId { get; set; }
    public Guid VendedorId { get; set; }
    public IList<ItemOrcamento> Itens { get; set; } 
    public IList<ItemAvulsoOrcamento> ItensAvulsos { get; set; }
    public StatusOrcamento? Status { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal ValorDesconto { get; set; }
    
}