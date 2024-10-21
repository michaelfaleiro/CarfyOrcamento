using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.ItemOrcamento;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Frete;

public class FreteOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public FreteOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task ExecuteAsync(AdicionarFreteRequest request)
    {
        ValidateRequest(request);
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");
        
        orcamento.AdicionarFrete(request.ValorFrete);
        
        await _orcamentoRepository.UpdateAsync(orcamento);
    }
    
    private void ValidateRequest(AdicionarFreteRequest request)
    {
        var validator = new FreteOrcamentoValidator();
        var validationResult = validator.Validate(request);
        
        if (!validationResult.IsValid) return;
        
        var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
        
    }
    
}