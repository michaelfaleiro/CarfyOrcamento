using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.AdicionarItem;
public class AdicionarItemCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;


    public AdicionarItemCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(AdicionarItemCotacaoRequest request)
    {
        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
            ?? throw new NotFoundException("Cotação não encontrada");

        var itemCotacao = new ItemCotacao(cotacao, request.Sku, request.Descricao, request.Quantidade, request.TipoProduto);

        cotacao.Itens.Add(itemCotacao);

        await _cotacaoRepository.AdicionarItemCotacao(itemCotacao);

    }

    private void Validate(AdicionarItemCotacaoRequest request)
    {
        var validator = new AdicionarItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}
