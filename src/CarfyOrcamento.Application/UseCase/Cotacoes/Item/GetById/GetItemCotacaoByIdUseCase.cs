using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.ItemCotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.GetById;

public class GetItemCotacaoByIdUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public GetItemCotacaoByIdUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task<ResponseJson<ResponseItemCotacaoJson>> Execute(Guid id)
    {
        var item = await _cotacaoRepository.GetItemById(id)
            ?? throw new NotFoundException("Item não encontrado");

        return new ResponseJson<ResponseItemCotacaoJson>(
            new ResponseItemCotacaoJson(
                item.Id,
                item.Cotacao.Id,
                item.Sku,
                item.Descricao,
                item.Quantidade,
                item.TipoProduto,
                item.PrecoItemFornecedor.Select(preco => new ResponsePrecoItemCotacaoJson(
                    preco.Id,
                    item.Cotacao.Id,
                    preco.ItemCotacao.Id,
                    preco.FornecedorId,
                    preco.Fornecedor,
                    preco.FabricanteId,
                    preco.Fabricante,
                    preco.Sku,
                    preco.ValorCusto,
                    preco.ValorVenda,
                    preco.PrazoExpedicao,
                    preco.Observacao,
                    preco.CreatedAt,
                    preco.UpdatedAt
                )).ToList(),
                item.CodigoEquivalentes.Select(codigo => new ResponseCodigoEquivalenteCotacaoJson(
                    codigo.Id,
                    codigo.Sku,
                    codigo.FabricanteId,
                    codigo.Fabricante,
                    codigo.TipoProdutoEquivalente,
                    codigo.CreatedAt,
                    codigo.UpdatedAt
                )).ToList(),
                item.CreatedAt,
                item.UpdatedAt
            ));
    }
}