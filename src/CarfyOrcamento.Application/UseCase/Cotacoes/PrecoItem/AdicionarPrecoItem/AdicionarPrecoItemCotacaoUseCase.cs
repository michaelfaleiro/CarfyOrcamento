using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.AdicionarPrecoItem;

public class AdicionarPrecoItemCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public AdicionarPrecoItemCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(AdicionarPrecoItemCotacaoRequest request)
    {
        Validate(request);

        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
                      ?? throw new NotFoundException("Cotação não encontrada");


        var itemCotacao = cotacao.Itens.FirstOrDefault(x => x.Id == request.ItemId)
                          ?? throw new NotFoundException("Item de cotação não encontrado");

        cotacao.UpdatedAt = DateTime.UtcNow;

        var precoItemCotacao = new PrecoItemCotacao(
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
            request.Observacao,
            itemCotacao);

        await _cotacaoRepository.AdicionarPrecoItemCotacao(precoItemCotacao);
    }

    private void Validate(AdicionarPrecoItemCotacaoRequest request)
    {
        var validator = new AdicionarPrecoItemCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}