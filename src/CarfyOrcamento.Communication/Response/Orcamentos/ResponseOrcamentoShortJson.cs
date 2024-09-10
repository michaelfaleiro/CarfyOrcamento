using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Orcamentos;

public record ResponseOrcamentoShortJson(
    Guid Id,
    ResponseClienteShortJson Cliente,
    ResponseVeiculoJson Veiculo,
    string Vendedor,
    EStatusOrcamentoCotacao Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);