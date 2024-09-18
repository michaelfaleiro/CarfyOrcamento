using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.ItemOrcamento;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Orcamentos;

public record ResponseOrcamentoJson(
    Guid Id,
    ResponseClienteShortJson Cliente,
    ResponseVeiculoJson Veiculo,
    string Vendedor,
    IEnumerable<ResponseItemOrcamentoJson> Itens,
    IEnumerable<ResponseItemAvulsoOrcamentoJson> ItensAvulsos,
    EStatusOrcamento Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );