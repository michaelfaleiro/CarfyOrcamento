using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Clientes;

public record class ResponseClienteJson(
    Guid Id,
    string NomeRazaoSocial,
    string NomeFantasia,
    string CpfCnpj,
    string RgIe,
    string Telefone,
    string Email,
    IEnumerable<ResponseOrcamentoMinimum> Orcamentos,
    IEnumerable<ResponseVeiculoJson> Veiculos,
    ETipoPessoa ETipoPessoa,
    string Observacao,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

