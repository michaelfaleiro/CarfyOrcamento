namespace CarfyOrcamento.Core.Entities;

public class Veiculo : Entity
{
    public Veiculo()
    {
        ClienteVeiculos = [];
    }
    public Veiculo(string placa, string chassi, string marca, string modelo, string cor, int ano)
    {
        Placa = placa;
        Chassi = chassi;
        Marca = marca;
        Modelo = modelo;
        Cor = cor;
        Ano = ano;
        ClienteVeiculos = [];
    }

    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Cor { get; set; } = string.Empty;
    public int Ano { get; set; }
    public IList<ClienteVeiculos> ClienteVeiculos { get; set; }
    
    public void AtualizarVeiculo(Veiculo veiculo)
    {
        Placa = veiculo.Placa;
        Chassi = veiculo.Chassi;
        Marca = veiculo.Marca;
        Modelo = veiculo.Modelo;
        Cor = veiculo.Cor;
        Ano = veiculo.Ano;
        UpdatedAt = DateTime.UtcNow;
    }
}
