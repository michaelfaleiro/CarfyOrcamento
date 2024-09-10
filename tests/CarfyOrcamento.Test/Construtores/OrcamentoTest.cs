using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Test.Construtores;

public class OrcamentoTest
{
    [Fact]
    public void Deve_Criar_Um_Orcamento_Com_Sucesso()
    {
        // Arrange
        var cliente = new Cliente("cliente", "", "12345678901",
            "", "48991834474", "email@email.com", ETipoPessoa.Fisica, "");
        
        var veiculo = new Veiculo("ABC1234","KNH12345678901234", "Fiat",
            "Uno", "BRANCO", 2010);
        
        var vendedor = "vendedor";
        var status = EStatusOrcamentoCotacao.Novo;
    
        // Act
        var orcamento = new Orcamento(cliente, veiculo, vendedor, status);
    
        // Assert
        Assert.NotNull(orcamento);
    }
    
}