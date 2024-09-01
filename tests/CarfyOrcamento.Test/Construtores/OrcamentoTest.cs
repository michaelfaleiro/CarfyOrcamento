using CarfyOrcamento.Core.Entities;

namespace CarfyOrcamento.Test.Construtores;

public class OrcamentoTest
{
    [Fact]
    public void Deve_Criar_Um_Orcamento_Com_Sucesso()
    {
        // Arrange
        var clienteId = Guid.NewGuid();
        var veiculoId = Guid.NewGuid();
        var vendedorId = Guid.NewGuid();

        // Act
        var orcamento = new Orcamento(clienteId, veiculoId, vendedorId);

        // Assert
        Assert.NotNull(orcamento);
    }
    
}