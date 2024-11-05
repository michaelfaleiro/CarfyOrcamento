namespace CarfyOrcamento.Communication.Request.Catalogo;

public record UpdateCatalogoRequest(
    Guid Id,
    string Descricao,
    string Login,
    string Senha,
    string EnderecoSite,
    string Observacao
);