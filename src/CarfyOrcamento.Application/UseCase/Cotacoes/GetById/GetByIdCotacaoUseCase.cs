﻿using System.Security.Cryptography.X509Certificates;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Cotacoes;
using CarfyOrcamento.Communication.Response.ItemCotacao;
using CarfyOrcamento.Communication.Response.Veiculo;
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
                new ResponseVeiculoJson(
                    cotacao.Orcamento.Veiculo.Id,
                    cotacao.Orcamento.Veiculo.Cliente.Id,
                    cotacao.Orcamento.Veiculo.Placa,
                    cotacao.Orcamento.Veiculo.Chassi,
                    cotacao.Orcamento.Veiculo.Marca,
                    cotacao.Orcamento.Veiculo.Modelo,
                    cotacao.Orcamento.Veiculo.Cor,
                    cotacao.Orcamento.Veiculo.Ano,
                    cotacao.Orcamento.Veiculo.Motor,
                    cotacao.Orcamento.Veiculo.CreatedAt,
                    cotacao.Orcamento.Veiculo.UpdatedAt
                ),
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
                        item.Cotacao.Id,
                        preco.ItemCotacao.Id,
                        preco.FornecedorId,
                        preco.Fornecedor,
                        preco.FabricanteId,
                        preco.Fabricante,
                        preco.Quantidade,
                        preco.Sku,
                        preco.Descricao,
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
                )),
                cotacao.CreatedAt,
                cotacao.UpdatedAt
            ));
    }
}
