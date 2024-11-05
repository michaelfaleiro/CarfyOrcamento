namespace CarfyOrcamento.Communication.Request.Catalogo;

public record RegisterCatalogoRequest(
    string Descricao,
    string Login,
    string Senha,
    string EnderecoSite,
    string Observacao
);