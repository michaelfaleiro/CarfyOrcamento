namespace CarfyOrcamento.Communication.Request.Veiculo;

public record RegisterVeiculoRequest(
    Guid ClienteId,
    string Placa,
    string Chassi,
    string Marca,
    string Modelo,
    string Cor,
    int Ano,
    string Motor
    );