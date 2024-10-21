using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Cliente;

public record RegisterClienteRequest(
    string NomeRazaoSocial,
    string NomeFantasia,
    string CpfCnpj,
    string RgIe,
    string Telefone,
    string Email,
    ETipoPessoa ETipoPessoa,
    string Observacao);
