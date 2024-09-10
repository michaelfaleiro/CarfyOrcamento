using System;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Core.Entities;

public class Endereco : Entity
{

    public Endereco()
    {
    }
    public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string cep, ETipoEndereco tipoEndereco)
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
        TipoEndereco = tipoEndereco;
    }

    public string Logradouro { get; set; } = null!;
    public string Numero { get; set; } = null!;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public ETipoEndereco TipoEndereco { get; set; }
}
