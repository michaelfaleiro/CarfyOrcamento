using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.UpdatePrecoItem;

public class UpdatePrecoItemCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public UpdatePrecoItemCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(UpdatePrecoItemCotacaoRequest request)
    {
        Validate(request);

        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
                      ?? throw new NotFoundException("Cotação não encontrada");

        var item = cotacao.Itens.FirstOrDefault(x => x.Id == request.ItemId)
                   ?? throw new NotFoundException("Item de cotação não encontrado");

        var preco = item.PrecoItemFornecedor.FirstOrDefault(x => x.Id == request.Id)
                    ?? throw new NotFoundException("Preço de item de cotação não encontrado");

        cotacao.UpdatedAt = DateTime.UtcNow;

        preco.AtualizarPrecoItemCotacao(
            Guid.Parse(request.FornecedorId),
            request.Fornecedor,
            Guid.Parse(request.FabricanteId),
            request.Fabricante,
            request.Quantidade,
            request.Sku,
            request.Descricao,
            request.ValorCusto,
            request.ValorVenda,
            request.PrazoExpedicao,
            request.Observacao);

        await _cotacaoRepository.AtualizarPrecoItemCotacao(preco);
    }

    private void Validate(UpdatePrecoItemCotacaoRequest request)
    {
        var validator = new UpdatePrecoItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}