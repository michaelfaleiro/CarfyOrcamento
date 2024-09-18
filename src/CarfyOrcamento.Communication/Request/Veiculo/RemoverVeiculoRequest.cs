namespace CarfyOrcamento.Communication.Request.Veiculo;

public record RemoverVeiculoRequest(
    Guid ClienteId,
    Guid VeiculoId
    ); 