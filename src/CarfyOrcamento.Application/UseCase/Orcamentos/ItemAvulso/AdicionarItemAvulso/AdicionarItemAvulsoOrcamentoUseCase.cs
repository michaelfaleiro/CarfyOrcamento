using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.AdicionarItemAvulso;

public class AdicionarItemAvulsoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public AdicionarItemAvulsoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(AdicionarItemAvulsoOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        orcamento.UpdatedAt = DateTime.UtcNow;

        var item = new ItemAvulsoOrcamento(
            request.FabricanteId,
            request.Sku,
            request.Fabricante,
            request.Quantidade,
            request.Descricao,
            request.ValorVenda,
            orcamento
        );

        await _orcamentoRepository.AdicionarItemAvulsoAsync(item);
    }

    private void Validate(AdicionarItemAvulsoOrcamentoRequest request)
    {
        var validator = new AdicionarItemAvulsoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}