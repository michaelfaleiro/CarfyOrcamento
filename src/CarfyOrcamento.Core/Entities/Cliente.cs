using CarfyOrcamento.Core.Enums;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Core.Entities;

public class Cliente : Entity
{
    public Cliente()
    {
        Enderecos = [];
        Veiculos = [];
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
        Veiculos = [];
    }
    public string NomeRazaoSocial { get; set; } = null!;
    public string NomeFantasia { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string RgIe { get; set; } = string.Empty;
    public string Telefone { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
    public IList<Endereco> Enderecos { get; set; }
    public IList<ClienteVeiculos> Veiculos { get; set; }
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
    }
    
    public void AdicionarEndereco(Endereco endereco)
    {
        Enderecos.Add(endereco);
    }
    
    public void RemoverEndereco(Endereco endereco)
    {
        Enderecos.Remove(endereco);
    }
    
}
