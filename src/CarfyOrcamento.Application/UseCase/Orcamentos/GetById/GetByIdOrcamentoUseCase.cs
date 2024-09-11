using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.ItemOrcamento;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.GetById;

public class GetByIdOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public GetByIdOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task<ResponseJson<ResponseOrcamentoJson>> ExecuteAsync(Guid id)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(id)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        return new ResponseJson<ResponseOrcamentoJson>(new ResponseOrcamentoJson(
            orcamento.Id,
            new ResponseClienteShortJson(
                orcamento.Cliente.Id,
                orcamento.Cliente.NomeRazaoSocial,
                orcamento.Cliente.Telefone,
                orcamento.Cliente.Email,
                orcamento.Cliente.TipoPessoa
            ),
            new ResponseVeiculoJson(
                orcamento.Veiculo.Id,
                orcamento.Veiculo.Placa,
                orcamento.Veiculo.Chassi,
                orcamento.Veiculo.Marca,
                orcamento.Veiculo.Modelo,
                orcamento.Veiculo.Cor,
                orcamento.Veiculo.Ano,
                orcamento.Veiculo.CreatedAt,
                orcamento.Veiculo.UpdatedAt
            ),
            orcamento.Vendedor,
            orcamento.Itens.Select(item => new ResponseItemOrcamentoJson(
                item.Id,
                item.ProdutoId,
                item.FabricanteId,
                item.Fabricante,
                item.Sku,
                item.Descricao,
                item.Quantidade,
                item.ValorVenda
            )).ToList(),
            orcamento.ItensAvulsos.Select(item => new ResponseItemAvulsoOrcamentoJson(
                item.Id,
                orcamento.Id,
                item.FabricanteId,
                item.Fabricante,
                item.Sku,
                item.Descricao,
                item.ValorVenda,
                item.Quantidade,
                item.CreatedAt,
                item.UpdatedAt
            )).ToList(),
            orcamento.Status,
            orcamento.CreatedAt,
            orcamento.UpdatedAt
        ));
    }
}