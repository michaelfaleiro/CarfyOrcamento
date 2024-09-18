namespace CarfyOrcamento.Communication.Request.Veiculo;

public record RegisterVeiculoRequest(
    string Placa,
    string Chassi,
    string Marca,
    string Modelo,
    string Cor,
    int Ano
    );