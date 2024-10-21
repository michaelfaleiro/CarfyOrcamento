namespace CarfyOrcamento.Core.Entities;

public class Veiculo : Entity
{
    protected Veiculo()
    {
        
    }
    public Veiculo(Cliente cliente,string placa, string chassi, string marca, string modelo, string cor,  int ano, string motor)
    {
        Cliente = cliente;
        Placa = placa;
        Chassi = chassi;
        Marca = marca;
        Modelo = modelo;
        Cor = cor;
        Ano = ano;
        Motor = motor;
    }

    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Cor { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string Motor { get; set; } = string.Empty;
    public Cliente Cliente { get; set; } = null!;
    
    public void AtualizarVeiculo(Veiculo veiculo)
    {
        Placa = veiculo.Placa;
        Chassi = veiculo.Chassi;
        Marca = veiculo.Marca;
        Modelo = veiculo.Modelo;
        Cor = veiculo.Cor;
        Ano = veiculo.Ano;
        Motor = veiculo.Motor;
        UpdatedAt = DateTime.UtcNow;
    }
}
