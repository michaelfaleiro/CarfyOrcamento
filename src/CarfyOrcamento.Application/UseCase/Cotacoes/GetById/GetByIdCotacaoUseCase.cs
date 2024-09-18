﻿using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Cotacoes;
using CarfyOrcamento.Communication.Response.ItemCotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.GetById;
public class GetByIdCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public GetByIdCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task<ResponseJson<ResponseCotacaoJson>> ExecuteAsync(Guid id)
    {
        var cotacao = await _cotacaoRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Cotação não encontrada");


        return new ResponseJson<ResponseCotacaoJson>(
            new ResponseCotacaoJson(
                cotacao.Id,
                cotacao.OrcamentoId,
                cotacao.Status,
                cotacao.Itens.Select(item => new ResponseItemCotacaoJson(
                    item.Id,
                    item.Cotacao.Id,
                    item.Sku,
                    item.Descricao,
                    item.Quantidade,
                    item.TipoProduto,
                    item.PrecoItemFornecedor.Select(preco => new ResponsePrecoItemCotacaoJson(
                        preco.Id,
                        preco.ItemCotacao.Id,
                        preco.FornecedorId,
                        preco.NomeFantasia,
                        preco.FabricanteId,
                        preco.Fabricante,
                        preco.Sku,
                        preco.ValorCusto,
                        preco.ValorVenda,
                        preco.PrazoExpedicao,
                        preco.Observacao,
                        preco.CreatedAt,
                        preco.UpdatedAt
                    ))
                )),
                cotacao.CreatedAt,
                cotacao.UpdatedAt
            ));
    }
}