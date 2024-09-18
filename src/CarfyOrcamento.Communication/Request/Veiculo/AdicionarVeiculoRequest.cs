namespace CarfyOrcamento.Communication.Request.Veiculo;

public record AdicionarVeiculoRequest(
    Guid ClienteId,
    Guid VeiculoId
    );