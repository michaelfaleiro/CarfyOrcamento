namespace CarfyOrcamento.Core.Entities;

public class Catalogo : Entity
{
    public Catalogo(string descricao, string login, string senha, string enderecoSite, string observacao)
    {
        Descricao = descricao;
        Login = login;
        Senha = senha;
        EnderecoSite = enderecoSite;
        Observacao = observacao;
    }

    public string Descricao { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string EnderecoSite { get; set; }
    public string Observacao { get; set; }

    public void Update(string descricao, string login, string senha, string enderecoSite, string observacao)
    {
        Descricao = descricao;
        Login = login;
        Senha = senha;
        EnderecoSite = enderecoSite;
        Observacao = observacao;
        UpdatedAt = DateTime.UtcNow;
    }

}