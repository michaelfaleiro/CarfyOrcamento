namespace CarfyOrcamento.Communication.Response.Veiculo;

public record ResponseVeiculoJson(
    Guid Id,
    string Placa,
    string Chassi,
    string Marca,
    string Modelo,
    string Cor,
    int Ano,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );