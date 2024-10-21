using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;

public class DescontoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public DescontoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(AdicionarDescontoOrcamentoRequest request)
    {
        ValidateRequest(request);
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        orcamento.Desconto(request.ValorDesconto);

        await _orcamentoRepository.UpdateAsync(orcamento);
    }
    
    private void ValidateRequest(AdicionarDescontoOrcamentoRequest request)
    {
        var validator = new DescontoOrcamentoValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid) return;
        
        var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
        
    }
}