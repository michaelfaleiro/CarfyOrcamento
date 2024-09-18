using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Response.Clientes;

public record class ResponseClienteShortJson(
    Guid Id,
    string NomeRazaoSocial,
    string Telefone,
    string Email,
    ETipoPessoa ETipoPessoa
);
