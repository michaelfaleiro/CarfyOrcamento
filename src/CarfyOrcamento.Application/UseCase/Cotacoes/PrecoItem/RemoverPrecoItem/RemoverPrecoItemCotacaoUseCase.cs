using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.RemoverPrecoItem;

public class RemoverPrecoItemCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public RemoverPrecoItemCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(RemoverPrecoItemCotacaoRequest request)
    {
        Validate(request);

        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
                      ?? throw new NotFoundException("Cotação não encontrada");

        var item = cotacao.Itens.FirstOrDefault(x => x.Id == request.ItemId)
                   ?? throw new NotFoundException("Item de cotação não encontrado");

        var preco = item.PrecoItemFornecedor.FirstOrDefault(x => x.Id == request.Id)
                    ?? throw new NotFoundException("Preço de item de cotação não encontrado");

        await _cotacaoRepository.RemoverPrecoItemCotacao(preco);
    }

    private void Validate(RemoverPrecoItemCotacaoRequest request)
    {
        var validator = new RemoverPrecoItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}