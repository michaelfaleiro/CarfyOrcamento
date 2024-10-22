namespace CarfyOrcamento.Communication.Response.Veiculo;

public record ResponseVeiculoJson(
    Guid Id,
    Guid ClienteId,
    string Placa,
    string Chassi,
    string Marca,
    string Modelo,
    string Cor,
    int Ano,
    string Motor,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );