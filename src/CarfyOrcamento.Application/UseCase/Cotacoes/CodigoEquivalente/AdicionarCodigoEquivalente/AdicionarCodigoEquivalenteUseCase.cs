using CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.AdicionarCodigoEquivalente;

public class AdicionarCodigoEquivalenteUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;

    public AdicionarCodigoEquivalenteUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task ExecuteAsync(AdicionarCodigoEquivalenteRequest request)
    {
        Validate(request);

        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId)
                      ?? throw new NotFoundException("Cotação não encontrada");

        var item = cotacao.Itens.FirstOrDefault(i => i.Id == request.ItemId)
                          ?? throw new NotFoundException("Item não encontrado");

        var codigoEquivalente = new ItemCodigoEquivalente(
            item,
            request.Sku,
            Guid.Parse(request.FabricanteId),
            request.Fabricante,
            request.TipoProdutoEquivalente
        );

        await _cotacaoRepository.AdicionarCodigoEquivalente(codigoEquivalente);
    }

    private void Validate(AdicionarCodigoEquivalenteRequest request)
    {
        var validator = new AdicionarCodigoEquivalenteValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}