using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Test.Construtores;
public class ClienteTest
{
    [Fact]
    public void Deve_Criar_Um_Cliente_Com_Sucesso()
    {
        // Arrange
        var nomeRazaoSocial = "cliente";
        var nomeFantasia = "";
        var cpfCnpj = "12345678901";
        var rgIe = "";
        var telefone = "48999999999";
        var email = "";
        var tipoPessoa = ETipoPessoa.Fisica;
        var observacao = "";

        // Act
        var cliente = new Cliente(nomeRazaoSocial, nomeFantasia, cpfCnpj, rgIe, telefone, email, tipoPessoa, observacao);

        // Assert
        Assert.NotNull(cliente);

    }

    [Fact]
    public void Deve_Atualizar_Um_Cliente_Com_Sucesso()
    {
        // Arrange
        var cliente = new Cliente("cliente", "", "12345678901",
            "", "48999999999", "", ETipoPessoa.Fisica, "");

        var clienteAtualizado = new Cliente("cliente atualizado", "", "12345678901",
            "", "48999999999", "", ETipoPessoa.Fisica, "");

        // Act
        cliente.AtualizarCliente(clienteAtualizado);

        // Assert
        Assert.Equal(cliente.NomeRazaoSocial, clienteAtualizado.NomeRazaoSocial);
    }
}
