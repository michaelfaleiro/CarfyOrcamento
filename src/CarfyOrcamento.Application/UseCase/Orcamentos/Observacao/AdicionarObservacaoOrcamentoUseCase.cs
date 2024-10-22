using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;

public class AdicionarObservacaoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public AdicionarObservacaoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(AdicionarObservacaoOrcamentoRequest request)
    {
        Validate(request);
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        orcamento.Observacao = request.Observacao;

        await _orcamentoRepository.UpdateAsync(orcamento);
    }

    private void Validate(AdicionarObservacaoOrcamentoRequest request)
    {
        var validator = new AdicionarObservacaoOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }

}