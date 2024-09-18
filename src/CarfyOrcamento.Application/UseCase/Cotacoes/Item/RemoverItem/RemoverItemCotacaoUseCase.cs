using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.RemoverItem;

public class RemoverItemCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public RemoverItemCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(RemoverItemCotacaoRequest request)
    {
        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
                      ?? throw new NotFoundException("Cotação não encontrada");

        var itemCotacao = cotacao.Itens.FirstOrDefault(x => x.Id == request.ItemId)
                          ?? throw new NotFoundException("Item de cotação não encontrado");

        await _cotacaoRepository.RemoverItemCotacao(itemCotacao);
    }

    private void Validate(RemoverItemCotacaoRequest request)
    {
        var validator = new RemoverItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}