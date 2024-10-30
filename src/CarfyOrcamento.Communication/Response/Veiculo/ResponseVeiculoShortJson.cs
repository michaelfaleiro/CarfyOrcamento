namespace CarfyOrcamento.Communication.Response.Veiculo;

public record ResponseVeiculoShortJson(
    Guid Id,
    string Placa,
    string Modelo,
    string Chassi,
    string Marca,
    int Ano
    );