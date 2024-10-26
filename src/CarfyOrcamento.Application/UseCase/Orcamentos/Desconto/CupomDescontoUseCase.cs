using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;

public class CupomDescontoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public CupomDescontoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task ExecuteAsync(AdicionarCupomDescontoOrcamentoRequest request)
    {
        Validate(request);
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");
        
        orcamento.Cupom(request.CupomDesconto);
        
        await _orcamentoRepository.UpdateAsync(orcamento);
    }
    
    private void Validate(AdicionarCupomDescontoOrcamentoRequest request)
    {
        var validator = new CupomDescontoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;
        
        var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
        
    }
}