namespace CarfyOrcamento.Communication.Response.Catalogos;

public record ResponseCatalogoJson(
    Guid Id,
    string Descricao,
    string Login,
    string Senha,
    string EnderecoSite,
    string Observacao,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);