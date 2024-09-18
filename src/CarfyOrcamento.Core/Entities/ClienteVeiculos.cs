namespace CarfyOrcamento.Core.Entities;

public class ClienteVeiculos : Entity
{
    public ClienteVeiculos()
    {
    }
    public ClienteVeiculos(Cliente cliente, Veiculo veiculo)
    {
        Cliente = cliente;
        Veiculo = veiculo;
    }

    public Cliente Cliente { get; set; } = null!;
    public Veiculo Veiculo { get; set; } = null!;
    
}