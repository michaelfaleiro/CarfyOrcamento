using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.UpdateItem;

public class UpdateItemCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public UpdateItemCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(UpdateItemCotacaoRequest request)
    {
        Validate(request);

        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
                      ?? throw new NotFoundException("Cotação não encontrada");

        var itemCotacao = cotacao.Itens.FirstOrDefault(x => x.Id == request.Id)
                          ?? throw new NotFoundException("Item de cotação não encontrado");

        itemCotacao.AtualizarItemCotacao(request.Sku, request.Descricao, request.Quantidade, request.TipoProduto);

        await _cotacaoRepository.AtualizarItemCotacao(itemCotacao);
    }

    private void Validate(UpdateItemCotacaoRequest request)
    {
        var validator = new UpdateItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}