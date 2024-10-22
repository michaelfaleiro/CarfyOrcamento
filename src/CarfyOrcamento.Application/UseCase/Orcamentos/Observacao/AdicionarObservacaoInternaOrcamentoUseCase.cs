using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;

public class AdicionarObservacaoInternaOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public AdicionarObservacaoInternaOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(AdicionarObservacaoInternaOrcamentoRequest request)
    {
        Validate(request);
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        orcamento.ObservacaoInterna = request.ObservacaoInterna;

        await _orcamentoRepository.UpdateAsync(orcamento);
    }

    private void Validate(AdicionarObservacaoInternaOrcamentoRequest request)
    {
        var validator = new AdicionarObservacaoInternaOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }

}