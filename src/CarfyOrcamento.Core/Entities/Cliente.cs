using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Core.Entities;

public class Cliente : Entity
{
    public Cliente()
    {
        Enderecos = [];
        Veiculos = [];
        Orcamentos = [];
    }

    public Cliente(string nomeRazaoSocial,
    string nomeFantasia,
    string cpfCnpj, string rgIe, string telefone,
    string email, ETipoPessoa tipoPessoa, string observacao)
    {
        NomeRazaoSocial = nomeRazaoSocial;
        NomeFantasia = nomeFantasia;
        CpfCnpj = cpfCnpj;
        RgIe = rgIe;
        Telefone = telefone;
        Email = email;
        TipoPessoa = tipoPessoa;
        Observacao = observacao;
        Enderecos = [];
        Orcamentos = [];
        Veiculos = [];
    }
    public string NomeRazaoSocial { get; set; } = null!;
    public string NomeFantasia { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string RgIe { get; set; } = string.Empty;
    public string Telefone { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
    public IList<Endereco> Enderecos { get; set; }
    public IList<Veiculo> Veiculos { get; set; }
    public IList<Orcamento> Orcamentos { get; set; }
    public ETipoPessoa TipoPessoa { get; set; }
    public string Observacao { get; set; } = string.Empty;

    public void AtualizarCliente(Cliente cliente)
    {
        NomeRazaoSocial = cliente.NomeRazaoSocial;
        NomeFantasia = cliente.NomeFantasia;
        CpfCnpj = cliente.CpfCnpj;
        RgIe = cliente.RgIe;
        Telefone = cliente.Telefone;
        Email = cliente.Email;
        TipoPessoa = cliente.TipoPessoa;
        Observacao = cliente.Observacao;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        Enderecos.Add(endereco);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoverEndereco(Endereco endereco)
    {
        Enderecos.Remove(endereco);
        UpdatedAt = DateTime.UtcNow;
    }

}
